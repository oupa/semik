using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSUIPC;

namespace SEMIK1.Forms
{
    public partial class TestForm : Form
    {
        private static MainForm mainForm;
        private static readonly string AppTitle = "CSAV Semik";
        private static System.Windows.Forms.Timer TIMER = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer RUNTIMER = new System.Windows.Forms.Timer();
        private static bool tracking = false;
        private static bool trackingAllowed = false;
        private static bool wasAirborne = false;
        private static bool trackingFinished = false;

        Offset<int> airspeed = new Offset<int>(0x02BC);
        Offset<int> groundspeed = new Offset<int>(0x02B4);
        Offset<string> message = new Offset<string>(0x3380, 128);
        Offset<int> messageControl = new Offset<int>(0x32FA);
        Offset<string> aircraft = new Offset<string>(0x3500, 24);
        Offset<int> vspeed = new Offset<int>(0x030C);
        Offset<byte> onground = new Offset<byte>(0x0366);
        Offset<short> parkingBrake = new Offset<short>(0x0BC8);
        Offset<int> fsversion = new Offset<int>(0x3308);

        // 32FA offset - message

        public TestForm(MainForm m)
        {
            mainForm = m;
            InitializeComponent();
            TIMER.Enabled = true;
            TIMER.Interval = 500;
            TIMER.Tick += new EventHandler(TIMERTick);
            TIMER.Start();
            mainForm.setStatus("Waiting for connection...");
            mainForm.setProgress(true);

            this.airspeedLabel.Text = "";
            this.vspeedLabel.Text = "";
            this.onGroundLabel.Text = "";
            this.parkingLabel.Text = "";
            this.trackingLabel.Text = "";
            this.finishedLabel.Text = "";

        }

        private void startRUNTIMER() 
        {
            RUNTIMER.Enabled = true;
            RUNTIMER.Interval = 10;
            RUNTIMER.Tick += new EventHandler(RUNTIMERTick);
            RUNTIMER.Start();
        }

        private void RUNTIMERTick(Object myObject, EventArgs myEventArgs)
        {
            try
            {
                FSUIPCConnection.Process();
                
                double airpeedKnots = (double)airspeed.Value / 128d;
                double groundspeedKnots = (double)groundspeed.Value / 128d;
                double vspeedFT = (double)vspeed.Value * 60 * 3.28084 / 256;
                this.airspeedLabel.Text = "airspeed: " + airpeedKnots.ToString("f1");
                this.vspeedLabel.Text = "vspeed: " + vspeedFT;
                this.onGroundLabel.Text = "onGround: " + ((onground.Value == 1) ? "YES" : "NO");
                this.parkingLabel.Text = "parkingBrake: " + ((parkingBrake.Value == 32767) ? "ON" : "OFF");

                if (!trackingFinished && !tracking && !trackingAllowed && parkingBrake.Value == 0) { 
                    sendMessage("Semik requires to apply parking brake before you start flight tracking.", 0);
                }
                if (!trackingFinished && !trackingAllowed && !tracking && parkingBrake.Value == 32767)
                {
                    if (onground.Value == 1)
                    {
                        trackingAllowed = true;
                        sendMessage("Semik is now connected and ready.", 10);
                    }
                    else 
                    {
                        sendMessage("Semik also wants you to start the flight on ground.", 10);
                    }
                }
                if (!trackingFinished && !tracking && trackingAllowed && parkingBrake.Value == 0 && Math.Abs(groundspeedKnots) < 4)
                {
                    sendMessage("Semik started the flight tracking...", 10);
                    mainForm.setStatus("Tracking in progress...");
                    tracking = true;
                }
                if (!trackingFinished && tracking && !wasAirborne && onground.Value == 0)
                {
                    wasAirborne = true;
                }
                if (!trackingFinished && tracking && wasAirborne && parkingBrake.Value == 32767 && onground.Value == 1 && Math.Abs(groundspeedKnots) < 4)
                {
                    tracking = false;
                    trackingFinished = true;
                    sendMessage("Semik finished tracking, thank you!", 5);
                    mainForm.setStatus("Tracking finished.");
                }

                this.trackingLabel.Text = "tracking : " + ((tracking) ? "ON" : "OFF");
                this.finishedLabel.Text = "tracking finished : "+ ((trackingFinished) ? "YES" : "NO");

            }
            catch (FSUIPCException ex)
            {
               Logger.Log("Connection to FS was lost - " + ex);
               FSUIPCConnection.Close();
               mainForm.setStatus("Connection lost");
               RUNTIMER.Stop();
            }
            
       }

        private void connect_Click(object sender, EventArgs e)
        {
            openFSUIPC();
        }

        private void TIMERTick(Object myObject, EventArgs myEventArgs)
        {
            openFSUIPC();
        }

        private void sendMessage(string mes, int timeout) {
            message.Value = mes;
            messageControl.Value = timeout;
            FSUIPCConnection.Process();
        }

        private void openFSUIPC()
        {
            try
            {
                FSUIPCConnection.Open();
                //this.connect.Enabled = false;

                Logger.Log("Connected to FS");
                mainForm.setStatus("Connected to FS");
                mainForm.setProgress(false);
                TIMER.Enabled = false;
                TIMER.Stop();
                sendMessage(AppTitle + " is now connected!", 10);
                startRUNTIMER();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
