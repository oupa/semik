/*
 Connection to FSUPICClient library, both read and write
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using SEMIK1.Forms;
using FSUIPC;

namespace SEMIK1
{
    class FSUIPCProvider
    {
        private static System.Windows.Forms.Timer TIMER = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer FLIGHTTIMER = new System.Windows.Forms.Timer();
        public static MainForm mainForm;
        private static readonly string AppTitle = "CSAV Semik";
        public static bool connected = false;

        // FSUIPC
        public static Offset<int> airspeed = new Offset<int>(0x02BC);
        public static Offset<int> groundspeed = new Offset<int>(0x02B4);
        public static Offset<string> message = new Offset<string>(0x3380, 128);
        public static Offset<int> messageControl = new Offset<int>(0x32FA);
        public static Offset<string> aircraft = new Offset<string>(0x3500, 24);
        public static Offset<int> vspeed = new Offset<int>(0x030C);
        public static Offset<byte> onground = new Offset<byte>(0x0366);
        public static Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        public static Offset<int> fsversion = new Offset<int>(0x3308);
        public static Offset<double> latitude = new Offset<double>(0x6010);
        public static Offset<double> longitude = new Offset<double>(0x6018);
        public static Offset<long> fslatitude = new Offset<long>(0x0560);
        public static Offset<long> fslongitude = new Offset<long>(0x0568);
        public static Offset<double> altitude = new Offset<double>(0x6020);
        public static Offset<int> heading = new Offset<int>(0x0580);
        public static Offset<int> pitch = new Offset<int>(0x0578);
        public static Offset<int> bank = new Offset<int>(0x057C);
        public static Offset<int> magVariation = new Offset<int>(0x02A0);
        public static Offset<int> groundAltitude = new Offset<int>(0x0B4C);
        public static Offset<int> engineType = new Offset<int>(0x0609);
        public static Offset<int> engineCount = new Offset<int>(0x0AEC);
        public static Offset<int> gearControl = new Offset<int>(0x0BE8);
        public static Offset<int> flapsPosition = new Offset<int>(0x0BDC);
        public static Offset<short> altimeterSetting = new Offset<short>(0x0330);
        public static Offset<int> altimeterReading = new Offset<int>(0x3324);
        public static Offset<BitArray> lights = new Offset<BitArray>(0x0D0C, 2);

        // FSUIPC WEIGHT
        public static Offset<int> fuelWeight = new Offset<int>(0x0AF4); // pounds per galon
        public static Offset<int> zeroFuelWeight = new Offset<int>(0x3BFC);
        public static Offset<double> loadedWeight = new Offset<double>(0x30C0);

        // FSUIPC fuel
        public static Offset<int> fuelCenterLevel = new Offset<int>(0x0B74); // percent % * 128 * 65536
        public static Offset<int> fuelCenterCap = new Offset<int>(0x0B78); // gallons
        public static Offset<int> fuelLeftMainLevel = new Offset<int>(0x0B7C);
        public static Offset<int> fuelLeftMainCap = new Offset<int>(0x0B80);
        public static Offset<int> fuelLeftAuxLevel = new Offset<int>(0x0B84);
        public static Offset<int> fuelLeftAuxCap = new Offset<int>(0x0B88);
        public static Offset<int> fuelLeftTipLevel = new Offset<int>(0x0B8C);
        public static Offset<int> fuelLeftTipCap = new Offset<int>(0x0B90);
        public static Offset<int> fuelRightMainLevel = new Offset<int>(0x0B94);
        public static Offset<int> fuelRightMainCap = new Offset<int>(0x0B98);
        public static Offset<int> fuelRightAuxLevel = new Offset<int>(0x0B9C);
        public static Offset<int> fuelRightAuxCap = new Offset<int>(0x0BA0);
        public static Offset<int> fuelRightTipLevel = new Offset<int>(0x0BA4);
        public static Offset<int> fuelRightTipCap = new Offset<int>(0x0BA8);

        // FSPUIPC radio
        public static Offset<short> com1 = new Offset<short>(0x034E);
        public static Offset<short> transponder = new Offset<short>(0x354);
        
        // FSUIPC sim
        public static Offset<short> paused = new Offset<short>(0x264);
        public static Offset<short> slew = new Offset<short>(0x05DC);
        public static Offset<short> rate = new Offset<short>(0x0C1A);

        // FSUPIC weather
        public static Offset<short> windSpeed = new Offset<short>(0x0E90);
        public static Offset<short> windDirection = new Offset<short>(0x0E92);
        public static Offset<short> pressure = new Offset<short>(0x0EC6);
        
        // FSUIPC surface
        public static Offset<byte> surface = new Offset<byte>(0x31E8);
        public static Offset<int> APMasterSwitch = new Offset<int>(0x07BC);
        
        // FSUIPC acceleration
        public static Offset<double> acceleration_x = new Offset<double>(0x3060);
        public static Offset<double> acceleration_y = new Offset<double>(0x3068);
        public static Offset<double> acceleration_z = new Offset<double>(0x3070);

        // FSUIPC keyboard
        public static Offset<int> keystroke = new Offset<int>(0x3200);
        public static Offset<int> keystroke_wParam = new Offset<int>(0x3204);
        public static Offset<int> keystroke_lParam = new Offset<int>(0x3208);

        // SQUAWKBOX
        // public static Offset<byte> squawkbox_running = new Offset<byte>(0x7B80);
        // public static Offset<byte> squawkbox_transponder_mode = new Offset<byte>(0x7B91);

        //public static Offset<byte> engineFail = new Offset<byte>(0x0B6B);

        public static void Connect() 
        {
            TIMER.Enabled = true;
            TIMER.Interval = 2000;
            TIMER.Tick += new EventHandler(CheckConnection);
            TIMER.Start();
            mainForm.setStatus("Waiting for connection to FS");
            mainForm.setProgress(true);
        }

        public static void Disconnect()
        {
            TIMER.Stop();
            FSUIPCConnection.Close();
            connected = false;
        }

        public static bool isConnected()
        {
            return connected;
        }

        /*public static void FailEngine(byte engine) {
            engineFail.Value = engine;
            try
            {
                FSUIPCConnection.Process();
            }
            catch (Exception)
            {
                
            }
        }*/

        public static void SetAPMasterSwitch(int ap) {
            APMasterSwitch.Value = ap;
            try
            {
                FSUIPCConnection.Process();
            }
            catch (Exception)
            {

            }
        }

        public static void sendMessage(string mes, int timeout)
        {
            message.Value = mes;
            messageControl.Value = timeout;
            try
            {
                FSUIPCConnection.Process();
            }
            catch (Exception) {
                //Logger.Log("Connection to FS was lost");
                FSUIPCConnection.Close();
                mainForm.setStatus("Connection lost");
            }
            
        }

        public static void CheckConnection(Object myObject = null, EventArgs myEventArgs = null)
        {
            mainForm.setProgress(true);
            try
            {
                FSUIPCConnection.Open();
                connected = true;
                Logger.Log("Connected to FS");
                Logger.Log("DLL version:" + FSUIPCConnection.DLLVersion.ToString());
                mainForm.setStatus("Connected to FS");
                mainForm.setProgress(false);
                TIMER.Enabled = false;
                TIMER.Tick += new EventHandler(CheckConnected);
                TIMER.Stop();

                sendMessage(AppTitle + " is now connected!", 10);
                FLIGHTTIMER.Enabled = true;
                FLIGHTTIMER.Interval = 1000;

                FLIGHTTIMER.Tick += new EventHandler(updateData);
                FLIGHTTIMER.Start();

                mainForm.fplForm.startInfoTimer();
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }

        public static void Reconnect()
        {
            try
            {
                FSUIPCConnection.Open();
                connected = true;
                Logger.Log("Connected to FS");
                Logger.Log("DLL version:" + FSUIPCConnection.DLLVersion.ToString());
                mainForm.setStatus("Connected to FS");
                mainForm.setProgress(false);
                sendMessage(AppTitle + " is now connected!", 10);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }

        private static void updateData(Object myObject, EventArgs myEventArgs)
        {
            mainForm.fsData.update();
            try
            {
                if (connected) // paranoia
                {
                    FSUIPCConnection.Process();
                }
            }
            catch (Exception)
            {
                //Logger.Log("Connection to FS was lost");
                FSUIPCConnection.Close();
                mainForm.setStatus("Connection lost");
                FLIGHTTIMER.Stop();
                TIMER.Stop();
                connected = false;
                Connect();
            }
        }

        private static void CheckConnected(Object myObject, EventArgs myEventArgs)
        {
            try
            {
                FSUIPCConnection.Process();
            }
            catch (Exception)
            {
                //Logger.Log("Connection to FS was lost");
                FSUIPCConnection.Close();
                mainForm.setStatus("Connection lost");
                FLIGHTTIMER.Stop();
                TIMER.Stop();
                connected = false;
                Connect();
            }
        }

        public static void sendKeyPress(int key)
        { 
            int wParam;
            switch (key) { 
                case 0:
                    wParam = 0x30;
                    break;
                case 1:
                    wParam = 0x31;
                    break;
                case 2:
                    wParam = 0x32;
                    break;
                case 3:
                    wParam = 0x33;
                    break;
                case 4:
                    wParam = 0x34;
                    break;
                case 5:
                    wParam = 0x35;
                    break;
                case 6:
                    wParam = 0x36;
                    break;
                case 7:
                    wParam = 0x37;
                    break;
                case 8:
                    wParam = 0x38;
                    break;
                case 9:
                    wParam = 0x39;
                    break;
                case 11:
                    wParam = 0x91; //ScrollLock
                    break;
                default:
                    wParam = 0x91;
                    break;
            }

            try
            {
                keystroke.Value = 0x0101;
                keystroke_wParam.Value = wParam;
                keystroke_lParam.Value = 1;
                FSUIPCConnection.Process();
                Logger.Log("KEY " + wParam.ToString() + " sent");
                keystroke.Value = 0x0100;
                keystroke_wParam.Value = wParam;
                keystroke_lParam.Value = 0;
                FSUIPCConnection.Process();
            }
            catch (Exception ex) {
                string e = ex.ToString();
            }
        }
    }
}
