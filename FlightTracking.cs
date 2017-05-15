/*
 This class should handle all the logic associated with Flight Tracking
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEMIK1;
using SEMIK1.Forms;
using System.Drawing;
using System.Xml;
using System.Globalization;
using System.Runtime.Serialization;

namespace SEMIK1
{
    public class FlightTracking
    {
        public static FlightInit flightInit; // data submited by user from FlightPlanForm
        public static Timer FMODETIMER; // this timer will check current conditions and switch the flight mode accordingly
        public static Timer POSITIONTIMER; // this timer will report aircraft position
        public static Timer EVENTSTIMER; // this timer will watch status of the aircraft and report various events
        public static Timer TVTIMER; // timer will take snapshots at given time period
        public static FSData fsData; // reference to data from FS
        private static int flightMode; // numeric representation of flight mode
        private static List<string> flightModes = new List<string>(); // text representation of flight mode
        public static AcarsForm acarsForm;
        public static string tracking_id;
        private static Aircraft aircraft;
        public static double distance;
        private static Pilot pilot;

        private static bool lastOnGround;
        private static bool lastGearPosition;
        private static double lastVerticalSpeed;
        private static int lastFlapsPosition;
        private static string lastCom1 = "";
        private static string lastTransponder = "";
        private static double lastLatitude;
        private static double lastLongitude;

        private static bool wasPaused;
        private static bool wasSlew;
        private static bool wasSimRate;
        private static double wasLimitBank;
        private static double wasLimitPositivePitch;
        private static double wasLimitNegativePitch;
        private static bool wasAltimeterUnset;
        private static bool wasParkingBrakeMoving;
        private static bool wasUnsafeSurface;
        private static bool wasRefuel;
        private static double initialPitch;
        private static NumberFormatInfo nfi;
        private static List<FlightEvent> flightEvents;
        private static double lastFuel;
        private static bool playedBeforeTakeoff;

        private static int timeout = 0;
        private static bool timeoutRunning = false;

        private static double lastPositionDistance = 0.0;
        private static DateTime lastPositionTime;
                      
        public static void Create(FlightInit fi, FSData fsd, AcarsForm acf, Pilot pi)
        {
            Logger.Init();
            pilot = pi;
            
            flightModes.Clear();
            flightModes.Add("Boarding");
            flightModes.Add("Taxi from gate");
            flightModes.Add("Departure");
            flightModes.Add("Climb");
            flightModes.Add("Cruise");
            flightModes.Add("Descent");
            flightModes.Add("Approach");
            flightModes.Add("Landing");
            flightModes.Add("Taxi to gate");
            flightModes.Add("Arrived at gate");
                        
            flightInit = fi;
            fsData = fsd;
            acarsForm = acf;
            Logger.Log("Flight tracking inited : " + flightInit.departure + " > " + flightInit.arrival);
           
            nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            lastGearPosition = fsData.gear;
            playedBeforeTakeoff = false;
            timeout = 0;
        }

        public static void Start()
        {
            flightEvents = new List<FlightEvent>();
            tracking_id = "";
            aircraft = Fleet.getAircraftByIcao(flightInit.aircraft);
            wasPaused = wasSimRate = wasSlew = wasUnsafeSurface = false;
            lastLatitude = fsData.latitude;
            lastLongitude = fsData.longitude;
            lastFuel = fsData.fuelTotalWeight;
            distance = 0.0;
            timeout = 0;
            timeoutRunning = false;

            FMODETIMER = new Timer();
            FMODETIMER.Tick += new EventHandler(FMODETIMER_Tick);
            FMODETIMER.Interval = 1000;
            FMODETIMER.Enabled = true;
            FMODETIMER.Start();
            
            EVENTSTIMER = new Timer();
            EVENTSTIMER.Tick += new EventHandler(EVENTSTIMER_Tick);
            EVENTSTIMER.Interval = 5000;
            EVENTSTIMER.Enabled = true;
            EVENTSTIMER.Start();

            TVTIMER = new Timer();
            TVTIMER.Tick += new EventHandler(TVTIMER_Tick);
            TVTIMER.Interval = Properties.Settings.Default.tv_refresh * 1000;
            TVTIMER.Enabled = true;
            TVTIMER.Start();

            LogStartVars();
            startPositionTimer();
            changeFlightMode(0, true);
            Logger.Log("Flight tracking started");
        }

        private static void LogStartVars()
        {
            Logger.LogEvent("FLIGHT INIT", "");
            LogPosition();
            LogWeights();
            Logger.LogEvent("FS Aircraft", fsData.aircraftName);
            LogFlightEvent("FlightInit","",1);
        }

        private static void TVTIMER_Tick(Object myObject, EventArgs myEventArgs) 
        {
            if (!Properties.Settings.Default.use_tv) return;

            TVTIMER.Interval = Properties.Settings.Default.tv_refresh * 1000;
            
            string file = Snapshot.TakeSnapshot();
            if (file.Length > 0 && tracking_id.Length > 0 && !Properties.Settings.Default.offline) {
                FlightEvent fe = LogFlightEvent("TV", "tv snapshot", 3);
                bool result = Connector.UploadTV(tracking_id, file, fe.GetCSV(";"));
            }
        }

        private static void UploadTempPirep()
        {
            string args = "";
            args += "pid=" + pilot.pid;
            args += "&auth=" + pilot.auth_code;
            args += "&tracking_id=" + tracking_id;
            args += "&fsapirep=" + AcarsBuilder.FSACARSCompatiblePirep(flightInit, "*");
            Connector.SendPirepTemp(args);
        }

        private static void EVENTSTIMER_Tick(Object myObject, EventArgs myEventArgs)
        {
            // FLIGHT CONTROLS EVENTS (based on flight mode)
            if (fsData.gear != lastGearPosition) {
                lastGearPosition = fsData.gear;
                Logger.LogEvent("GEAR", ((fsData.gear) ? "Gear up" : "Gear down") + " - " + Math.Round(fsData.airSpeed) + " knots");
                if (fsData.gear)
                    LogFlightEvent("Gear","Gear Up:" + Math.Round(fsData.airSpeed) + " knots",1);
                else
                    LogFlightEvent("Gear", "Gear Down:" + Math.Round(fsData.airSpeed) + " knots",1);
            }

            if (fsData.flapsPosition > lastFlapsPosition) {
                Logger.LogEvent("FLAPS", "Flaps move up" + " - Pos : " + aircraft.getFlaps(fsData.flapsPosition) + " - " + Math.Round(fsData.airSpeed) + " knots");
                LogFlightEvent("Flaps","Flaps " + aircraft.getFlaps(fsData.flapsPosition) + " at " + Math.Round(fsData.airSpeed) + " knots",1);
            }

            if (fsData.flapsPosition < lastFlapsPosition)
            {
                Logger.LogEvent("FLAPS", "Flaps move down" + " - Pos : " + aircraft.getFlaps(fsData.flapsPosition) + " - " + Math.Round(fsData.airSpeed) + " knots");
                LogFlightEvent("Flaps","Flaps " + aircraft.getFlaps(fsData.flapsPosition) + " at " + Math.Round(fsData.airSpeed) + " knots",1);
            }

            if (flightMode == 2) {
                if (fsData.pitch > (initialPitch + 2) && GetFlightEvent("Rotate") == null) { 
                    Logger.LogEvent("VR", Math.Round(fsData.airSpeed) + " knots");
                    LogFlightEvent("Rotate", "", 1);
                }

                if (lastOnGround != fsData.onGround) { 
                    Logger.LogEvent("V2", Math.Round(fsData.airSpeed) + " knots");
                    LogFlightEvent("Takeoff","",1);

                    if (fsData.loadedWeight > aircraft.mtow) {
                        Logger.LogEvent("TakeoffOverweight", "Exceeded MTOW by " + Math.Round(fsData.loadedWeight - aircraft.mtow) + " kg");
                        LogFlightEvent("TakeoffOverweight", "Exceeded MTOW by " + Math.Round(fsData.loadedWeight - aircraft.mtow) + " kg", 4);
                    }

                    if (fsData.pitch > aircraft.max_pitch_takeoff) {
                        Logger.LogEvent("TakeoffOverRotate", "Pitch was " + Math.Round(fsData.pitch) + " / MaxPitch allowed: " + aircraft.max_pitch_takeoff.ToString());
                        LogFlightEvent("TakeoffOverRotate", "Pitch was " + Math.Round(fsData.pitch) + " / MaxPitch allowed: " + aircraft.max_pitch_takeoff.ToString(), 2);
                    }
                }
            }

            /*if (fsData.onGround && !fsData.IsSafeSurface() && !wasUnsafeSurface) {
                Logger.LogEvent("UNSAFE SURFACE", fsData.GetSurfaceString());
                wasUnsafeSurface = true;
                LogFlightEvent("UnsafeSurface", fsData.GetSurfaceString(), 2);
            }*/

            if (flightMode == 7){
                lastVerticalSpeed = fsData.verticalSpeed;
                if (lastOnGround != fsData.onGround)
                {
                    Logger.LogEvent("TOUCHDOWN", "td rate : " + Math.Round(lastVerticalSpeed) + " ft/min" + " airspeed " + Math.Round(fsData.airSpeed) + " knots");
                    LogWeights();
                    LogPosition();
                    FlightEvent ev = GetFlightEvent("Touchdown");
                    if (ev != null){
                        flightEvents.Remove(ev);
                    }

                    LogFlightEvent("Touchdown","",1);

                    // correct vertical speed of currently logged touchdown event
                    FlightEvent td = GetFlightEvent("Touchdown");
                    td.verticalSpeed = Math.Round(lastVerticalSpeed);

                    // do the same in case of abnormal landing incl. correction
                    if (td.verticalSpeed < -1000) {
                        LogFlightEvent("AbnormalLanding","",2);
                        FlightEvent al = GetFlightEvent("AbnormalLanding");
                        al.verticalSpeed = td.verticalSpeed;
                    }

                    if (fsData.loadedWeight > aircraft.mlw)
                    {
                        Logger.LogEvent("LandingOverweight", "Exceeded MLW by " + Math.Round(fsData.loadedWeight - aircraft.mlw) + " kg");
                        LogFlightEvent("LandingOverweight", "Exceeded MLW by " + Math.Round(fsData.loadedWeight - aircraft.mlw) + " kg", 4);
                    }

                    // surface
                    if (!fsData.IsSafeSurface()) {
                        LogFlightEvent("LandingOffRunway", fsData.GetSurfaceString(), 2);
                    }
                }
                lastOnGround = fsData.onGround;
            }

            // RADIOS
            if (fsData.com1 != lastCom1) {
                Logger.LogEvent("COM1", fsData.com1);
                lastCom1 = fsData.com1;
                LogFlightEvent("ComChange","Com1 Freq=" + fsData.com1,1);
            }
            if (fsData.transponder != lastTransponder)
            {
                Logger.LogEvent("TRANSPONDER", fsData.transponder);
                lastTransponder = fsData.transponder;
                LogFlightEvent("Transponder", "Squawk " + fsData.transponder,1);
            }

            // LIMIT EVENTS
            if (wasLimitBank < Math.Abs(fsData.bank) && Math.Abs(fsData.bank) > aircraft.bank_limit) {
                double exceed = Math.Abs(fsData.bank) - aircraft.bank_limit;
                if (exceed > 3){
                    Logger.LogEvent("BANK LIMIT", "Bank limit exceeded by " + Math.Round(exceed) + " deg");
                    wasLimitBank = Math.Abs(fsData.bank);
                    LogFlightEvent("BankLimit","",2);
                }
            }

            if (wasLimitNegativePitch > fsData.pitch && fsData.pitch < -1 * aircraft.min_pitch) {
                double exceed = fsData.pitch - aircraft.min_pitch;
                if (Math.Abs(exceed) > 3) {
                    Logger.LogEvent("NEG PITCH LIMIT", "Negative pitch limit exceeded by " + Math.Abs(Math.Round(exceed)) + " deg");
                    wasLimitNegativePitch = -1 * fsData.pitch;
                    LogFlightEvent("NegativePitch", "Limit negative pitch (down) " + aircraft.min_pitch + " deg was exceeded by" + Math.Abs(Math.Round(exceed)) + " deg",2);
                }
            }

            if (wasLimitPositivePitch < fsData.pitch && fsData.pitch > aircraft.max_pitch)
            {
                double exceed = fsData.pitch - aircraft.max_pitch;
                if (exceed > 3)
                {
                    Logger.LogEvent("POS PITCH LIMIT", "Positive pitch limit exceeded by " + Math.Round(exceed) + " deg");
                    wasLimitPositivePitch = fsData.pitch;
                    LogFlightEvent("PositivePitch", "Limit positive pitch (down) " + aircraft.max_pitch + " deg was exceeded by" + Math.Abs(Math.Round(exceed)) + " deg",2);
                }
            }

            if (flightMode == 7 && GetFlightEvent("SinkRate") == null && ((fsData.altitude - fsData.groundAltitude) < 1000 && fsData.groundAltitude < fsData.altitude) && fsData.verticalSpeed < -1500){
                LogFlightEvent("SinkRate","",2);
            }

            // SIM EVENTS
            if (!wasPaused && fsData.paused && !fsData.onGround) {
                Logger.LogEvent("PAUSED SIMULATION","Don't do that!");
                LogFlightEvent("Paused","",2);
                wasPaused = true;
            }

            if (!wasSlew && fsData.slewMode)
            {
                Logger.LogEvent("SLEW MODE DETECTED", "Don't do that!");
                LogFlightEvent("Slewed","",2);
                wasSlew = true;
            }

            if (!wasSimRate && fsData.simRate != 1)
            {
                Logger.LogEvent("DIFFERENT SIM RATE DETECTED", fsData.simRate.ToString() + "x");
                LogFlightEvent("SimRateChange", fsData.simRate.ToString() + "x",2);
                wasSimRate = true;
            }

            if (!wasRefuel && !fsData.onGround && (lastFuel + 5) < fsData.fuelTotalWeight) {
                Logger.LogEvent("REFUEL DETECTED", "Fuel: " + Math.Round(fsData.fuelTotalWeight) + " / Previous: " + Math.Round(lastFuel));
                LogFlightEvent("Refueling", "Fuel: " + Math.Round(fsData.fuelTotalWeight) + " / Previous: " + Math.Round(lastFuel), 2);
                wasRefuel = true;
            }

            if (!wasAltimeterUnset && !fsData.onGround && fsData.altitude > 18500 && Math.Abs(fsData.altimeterSetting - 1013) > 1)
            {
                LogFlightEvent("AltimeterNotStd", "", 2);
                wasAltimeterUnset = true;
            }

            if (!wasParkingBrakeMoving && fsData.onGround && fsData.groundSpeed > 2 && fsData.parkingBrake) {
                LogFlightEvent("ParkingBrakeWhileMoving", "", 2);
                wasParkingBrakeMoving = true;
            }

            lastFuel = fsData.fuelTotalWeight;
            lastOnGround = fsData.onGround;
            lastFlapsPosition = fsData.flapsPosition;
        }

        private static void startPositionTimer() 
        {
            POSITIONTIMER = new Timer();
            POSITIONTIMER.Tick += new EventHandler(POSITIONTIMER_Tick);
            POSITIONTIMER.Interval = 120000;
            POSITIONTIMER.Enabled = true;
            POSITIONTIMER.Start();
        }

        private static void POSITIONTIMER_Tick(Object myObject, EventArgs myEventArgs)
        {
            double dist = AddDistance();
            ReportPosition();
            string pirep = AcarsBuilder.FSACARSCompatiblePirep(flightInit,"\n");
            Logger.LogAcars(pirep);

            DateTime t = DateTime.Now;

            if (flightMode > 2 && flightMode < 8) {
                if (lastPositionTime != null)
                {
                    TimeSpan span = t.Subtract(lastPositionTime);
                    if (dist == 0) {  // nezmenila se pozice
                        if (span.TotalSeconds >= 120.0) { 
                            Logger.Log("Position unchanged during flight - time span in seconds: " + span.TotalSeconds);    
                            LogFlightEvent("CriticalPause", "Time span " + span.TotalSeconds.ToString() + " seconds", 2);
                            lastPositionTime = t; // vynulujeme a budeme incident posilat kazdych 150 sekund
                        }
                    }
                }
 
                if (dist > 0.001) // zmenila se pozice -> zapisu cas zmeny
                {
                    lastPositionDistance = distance;
                    lastPositionTime = t;
                }
            }

            UploadTempPirep();
        }

        private static void FMODETIMER_Tick(Object myObject, EventArgs myEventArgs)
        {
            if (!FSUIPCProvider.isConnected())
            {
                FSUIPCProvider.CheckConnection();
                return;
            }
            else {
                acarsForm.mainForm.setStatus("Connected to FS");
                acarsForm.mainForm.setProgress(false);
            }
            // tracking logic
            switch (flightMode) { 
                // boarding
                case 0:
                    if (!fsData.parkingBrake) 
                    {
                        POSITIONTIMER.Interval = 15000;
                        changeFlightMode(1, true);
                        LogFlightEvent("BlockOff","",1);
                        initialPitch = fsData.pitch;
                        SoundFactory.PlaySound("TaxiFromGate");
                        acarsForm.enableButtons();
                    }
                break;
                // taxi from gate
                case 1:
                    if (fsData.lightsLanding && !playedBeforeTakeoff) 
                    {
                        SoundFactory.PlaySound("BeforeTakeoff");
                        playedBeforeTakeoff = true;
                    }
                    if (fsData.airSpeed > 50)  
                    {
                        SoundFactory.StopSound();
                        changeFlightMode(2, true);
                        EVENTSTIMER.Interval = 100;
                        POSITIONTIMER.Interval = 10000;
                    }
                break;
                // departure
                case 2:
                    CheckClimb();
                break;
                // climb
                case 3:
                    if (fsData.altitude >= (flightInit.flight_level - 500))
                    {
                        Logger.LogEvent("TOC", "Top of climb");
                        LogFlightEvent("TOC","",1);
                        LogPosition();
                        changeFlightMode(4, true);
                        POSITIONTIMER.Interval = 30000;
                    }
                    CheckLanding();
                break;
                // cruise
                case 4:
                    if (fsData.altitude < (flightInit.flight_level - 1500))
                    {
                        changeFlightMode(5, true);
                        Logger.LogEvent("TOD", "Top of descent");
                        LogFlightEvent("TOD","",1);
                        LogWeights();
                        LogPosition();
                        SoundFactory.PlaySound("Descent");
                        POSITIONTIMER.Interval = 30000;
                    }
                    CheckLanding();
                break;
                // descend
                case 5:
                    if (fsData.altitude >= (flightInit.flight_level - 500))
                    {
                        POSITIONTIMER.Interval = 30000;
                        changeFlightMode(4, true);
                    }
                    if (((fsData.altitude - fsData.groundAltitude) < 10000))
                    {
                        POSITIONTIMER.Interval = 20000;
                        changeFlightMode(6, true);
                    }
                    CheckLanding();
                break;
                // approach
                case 6:
                    CheckLanding();
                break;
                // landing
                case 7:
                    if (fsData.onGround && fsData.groundSpeed <= 25) {
                        changeFlightMode(8, true);
                        EVENTSTIMER.Interval = 5000;
                        POSITIONTIMER.Interval = 30000;
                        SoundFactory.PlaySound("TaxiToGate");
                    }
                    CheckClimb();
                break;
                // taxi to gate
                case 8:
                    if (fsData.groundSpeed < 2 && fsData.parkingBrake) 
                    {
                        if (timeout < Properties.Settings.Default.parking_brake_timeout)
                        {
                            timeoutRunning = true;
                            timeout++;
                            FSUIPCProvider.sendMessage("Flight will be finished in " + (Properties.Settings.Default.parking_brake_timeout - timeout).ToString() + " seconds", 1);
                        }
                        else {
                            changeFlightMode(9, true);
                            Logger.LogEvent("GATE", "Arrived at gate");
                            LogFlightEvent("BlockOn", "", 1);
                            LogPosition();
                            LogWeights();
                            StopTimers();
                            CheckFuelCalculations();
                            acarsForm.disableButtons();
                        }
                    }
                    else if (timeoutRunning && !fsData.parkingBrake) {
                        timeout = 0;
                        FSUIPCProvider.sendMessage("Parking brake timeout reset", 2);
                    }
                break;
            }
        }
        
        private static double AddDistance()
        {
            // nastavi globalni soucet na = distance a vrati inkrement

            double dist = DistLatLong(lastLatitude, lastLongitude, fsData.latitude, fsData.longitude, "nm");

            Logger.Log("Adding distance : " + distance + " + " + dist);
            distance += dist;
            lastLatitude = fsData.latitude;
            lastLongitude = fsData.longitude;

            return dist;
        }

        public static void StopTimers()
        {
            TVTIMER.Stop();
            POSITIONTIMER.Stop();
            EVENTSTIMER.Stop();
            FMODETIMER.Stop();
        }

        public static void FinishTracking(bool cancel)
        {
            if (!cancel)
            {
                Logger.LogAcars(AcarsBuilder.FSACARSCompatiblePirep(flightInit, "\n"));
            }
            else {
                StopTimers();
                acarsForm.disableButtons();
            }
            FSUIPCProvider.Disconnect();
            SendPirep(cancel);
        }

        private static void SendPirep(bool cancel)
        {
            string args = "";
            if (cancel)
            {
                args += "pid=" + pilot.pid;
                args += "&auth=" + pilot.auth_code;
                args += "&tracking_id=" + FlightTracking.tracking_id;
                args += "&terminate=terminate";
            } else {
                args += AcarsBuilder.SemikUploadString(flightInit);
            }
            
            
            XmlElement xml = Connector.SendPirep(args);
            SendPirepSuccess(xml, cancel);
        }


        private static void SendPirepSuccess(XmlElement xml, bool cancel)
        {
            string utcTime = DateTime.Now.ToUniversalTime().Hour.ToString("00") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("00");
            if (xml == null)
            {
                Logger.Log("SendPirep returned null");
                acarsForm.addMessage(utcTime, "SendPirep returned null");

                DialogResult result = MessageBox.Show("There was problem with sending pirep. You can try again.","Send pirep error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                if (result == DialogResult.Retry) {
                    SendPirep(cancel);
                }

                return;
            }

            if (cancel)
            {
                acarsForm.mainForm.finishAcars();
                acarsForm.Close();
                MessageBox.Show("Flight tracking has been cancelled");
                return;
            }

            try
            {
                acarsForm.addMessage(utcTime, "SendPirep results");
                XmlNodeList messages = xml.GetElementsByTagName("message");
                for (int i = 0; i < messages.Count; i++)
                {
                    XmlElement message = (XmlElement)messages[i];
                    acarsForm.addMessage(utcTime, "Message: " + message.GetAttribute("text"));
                }
                XmlNode pirep = xml.GetElementsByTagName("pirep_id")[0];
                string id = "";
                if (pirep != null)
                {
                    id = pirep.InnerText;
                    if (id.Length > 0)
                    {

                        string fdr = SaveFDR();
                        if (fdr.Length > 0)
                        {
                            UploadFDR(id, fdr);
                        }
                    }
                }
                acarsForm.finishTracking(messages, id);
            }
            catch (Exception e)
            {
                Logger.Log("SendPirep exception");
                Logger.Log(e.ToString());
                acarsForm.addMessage(utcTime, "SendPirep exception");
                acarsForm.addMessage(utcTime, e.ToString());
            }
        }

        public static string CheckFuelCalculations() 
        {
            string outString = "";
            FlightEvent blockoff = GetFlightEvent("BlockOff");
            FlightEvent blockon = GetFlightEvent("BlockOn");
            if (blockoff == null) {
                outString += "Unable to calculate fuel, BlockOff Event missing";
                FinishTracking(false);
                return outString;
            }
            double fuelSpent = blockoff.fuel - blockon.fuel;
            TimeSpan duration = blockon.time.Subtract(blockoff.time);
            double minutes = duration.TotalMinutes;
            double averageConsumption = fuelSpent / minutes;
            outString += "calculated average comsumption : " + Math.Round(averageConsumption * 60) + " kg/h\n";
            double minutesRemaining = blockon.fuel / averageConsumption;
            outString += " > minutes remaining : " + Math.Round(minutesRemaining) + " min\n";

            XmlElement alternate = Connector.GetAirport(flightInit.alternate);
            
            double minutesToAlternate = 60; // in case the alternate airport icao is not found 
            if (alternate != null){
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                double altLatitude = Convert.ToDouble(alternate.GetAttribute("latitude"),provider);
                double altLongitude = Convert.ToDouble(alternate.GetAttribute("longitude"),provider);
                double distanceToAlternate = DistLatLong(blockon.latitude, blockon.longitude, altLatitude, altLongitude, "nm");
                double tas = Convert.ToDouble(aircraft.tas) * .6; // 
                minutesToAlternate = 60 * distanceToAlternate / tas;
                minutesToAlternate = Math.Max(minutesToAlternate, 15);
            }
            outString += " > minutes to alternate airport : " + Math.Round(minutesToAlternate) + " min\n";
            double requiredReserve = minutesToAlternate + 30;
            outString += " > calculated required reserve : " + Math.Round(requiredReserve) + " min\n";
            double maxReserve = Math.Round(requiredReserve * 3 + minutes / 6);

            if (minutesRemaining < requiredReserve) {
                outString += " >> ReserveFuelLow";
                LogFlightEvent("ReserveFuelLow",outString, 4);
            }
            else if (minutesRemaining > maxReserve)
            {
                outString += " >> ReserveFuelHigh (comparing to " + maxReserve + " min)";
                LogFlightEvent("ReserveFuelHigh", outString, 4);
            }
            else {
                outString += " >> Within tolerance";
            }
            FinishTracking(false);
            return outString;
        }

        public static void UploadFDR(string pirep_id, string filename)
        {
            bool uploadSuccess = Connector.UploadFDR(pirep_id, filename);
            string utcTime = DateTime.Now.ToUniversalTime().Hour.ToString("00") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("00");
            if (uploadSuccess)
            {
                acarsForm.addMessage(utcTime, "FDR Uploaded");
            }
            else {
                acarsForm.addMessage(utcTime, "FDR Upload Error - See log for details");
            }
        }

        public static string SaveFDR()
        {
            FDR fdr = new FDR();
            fdr.FlightEvents = flightEvents;
            fdr.FlightInit = flightInit;
            fdr.Pilot = pilot;

            Serializer serializer = new Serializer();
            string filename = "fdr/fdr_" + Logger.timeBase + ".fdr";
            bool result = serializer.SaveFDR(filename, fdr);
            if (result)
            {
                return filename;
            }
            else {
                return "";
            }
        }

        private static void CheckClimb() {
            if (fsData.verticalSpeed > 0 && ((fsData.altitude - fsData.groundAltitude) > 2500))
            {
                EVENTSTIMER.Interval = 5000;
                POSITIONTIMER.Interval = 30000;
                changeFlightMode(3, true);
            }
        }

        private static void CheckLanding() {
            if ((fsData.altitude - fsData.groundAltitude) < 1500 && (fsData.altitude - fsData.groundAltitude) > 0 && fsData.verticalSpeed < -400 && fsData.altitude > 0)
            {
                changeFlightMode(7, true);
                EVENTSTIMER.Interval = 100;
                POSITIONTIMER.Interval = 10000;
                SoundFactory.PlaySound("Landing");
            }
        }

        private static void LogPosition()
        {
            Logger.LogEvent("Position", "lat:" + fsData.latitude.ToString("####.#######", nfi) + ";lon:" + fsData.longitude.ToString("####.########", nfi) + ";alt:" + Math.Round(fsData.altitude) + ";hdg:" + fsData.heading.ToString("000"));
        }

        private static void LogWeights()
        {
            Logger.LogEvent("Gross weight", Math.Round(fsData.loadedWeight) + " kg");
            Logger.LogEvent("Zero fuel weight", Math.Round(fsData.zeroFuelWeight) + " kg");
            Logger.LogEvent("Fuel weight", Math.Round(fsData.fuelTotalWeight) + " kg");
        }

        public static void changeFlightMode(int mode, bool showInFs)
        {
            flightMode = mode;
            acarsForm.updateStatus(flightModes[flightMode]);
            Logger.Log("Flight mode changed to : " + flightModes[flightMode]);
            if (showInFs)
            {
                sendMessage("Flight mode changed to : " + flightModes[flightMode], 5);
            }
            ReportPosition();
            acarsForm.mainForm.setFlightMode(flightModes[flightMode]);
        }

        public static void ReportPosition() 
        {
            //if (!Properties.Settings.Default.offline)
           // {
                XmlElement xml = Connector.PositionUpdate(
                    fsData.latitude,
                    fsData.longitude,
                    fsData.altitude,
                    fsData.groundSpeed,
                    fsData.airSpeed,
                    fsData.heading,
                    flightInit.departure,
                    flightInit.arrival,
                    flightInit.iata,
                    flightInit.callsign,
                    flightInit.route,
                    flightInit.aircraft,
                    flightInit.pax,
                    flightMode,
                    fsData.altitude - fsData.groundAltitude,
                    tracking_id
                   );
                ReportPositionSuccess(xml);
           // }
            LogFlightEvent("AutoPos", "", 0);
        }

        private static void ReportPositionSuccess(XmlElement xml)
        {
            string utcTime = DateTime.Now.ToUniversalTime().Hour.ToString("00") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("00");
            if (xml == null)
            {
                Logger.Log("PositionUpdate returned null");

                acarsForm.addMessage(utcTime, "No response from server");
                return;
            }
            try
            {
                tracking_id = xml.GetAttribute("tracking_id");
                acarsForm.addMessage(utcTime, "Report position ok");
                XmlNodeList warnings = xml.GetElementsByTagName("warning");
                for (int i = 0; i < warnings.Count; i++) 
                {
                    XmlElement warning = (XmlElement)warnings[i];
                    acarsForm.addMessage(utcTime, "Warning: " + warning.GetAttribute("message"));
                    if (Properties.Settings.Default.display_warnings) {
                        sendMessage("Warning: " + warning.GetAttribute("message"), 7);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log("Report position exception");
                Logger.Log(e.ToString());
                acarsForm.addMessage(utcTime, "Report position exception");
                acarsForm.addMessage(utcTime, e.ToString());
            }
        }

        public static FlightEvent LogFlightEvent(string id, string remarks, int type) 
        {
            FlightEvent eev = GetFlightEvent(id);
            if (eev != null){
                if (eev.type == 2)
                    return null;
                else if (eev.id == "Touchdown")
                    flightEvents.Remove(eev);
            }
            
            FlightEvent fe = new FlightEvent();
            fe.id = id;
            fe.type = type;
            fe.time = DateTime.Now;
            fe.latitude = fsData.latitude;
            fe.longitude = fsData.longitude;
            fe.altitude = fsData.altitude;
            fe.heading = fsData.heading;
            fe.groundSpeed = fsData.groundSpeed;
            fe.airSpeed = fsData.airSpeed;
            fe.aircraft = fsData.aircraftName;
            fe.fuel = fsData.fuelTotalWeight;
            fe.grossWeight = fsData.loadedWeight;
            fe.windDirection = fsData.windDirection;
            fe.windSpeed = fsData.windSpeed;
            fe.pressure = fsData.pressure;
            fe.altimeterSetting = fsData.altimeterSetting;
            fe.transponder = fsData.transponder;
            fe.com1 = fsData.com1;
            fe.pitch = fsData.pitch;
            fe.verticalSpeed = fsData.onGround ? 0 : fsData.verticalSpeed;
            fe.remarks = remarks;
            fe.distance = distance;
            fe.bank = fsData.bank;
            fe.groundElevation = fsData.altitude - fsData.groundAltitude;
            fe.flaps = aircraft.getFlaps(fsData.flapsPosition);
            fe.gear = (fsData.gear ? "Up" : "Down");

            if (type == 2 && Properties.Settings.Default.fdr_imaging == true) 
            {
                Logger.Log("Incident detected, imaging is on - taking screenshot...");
                Image i = Snapshot.TakeImage(fe.id);
                if (i != null) {
                    Logger.Log("Screenshot taken");
                    fe.image = i;
                }
            }

            if (type != 3) // not logging tv events
            {
                flightEvents.Add(fe);
                acarsForm.addEvent(fe);
            }
            return fe;
        }

        public static FlightEvent GetFlightEvent(string id)
        {
            
            for (int i = 0; i < flightEvents.Count; i++) {
                if (id == flightEvents[i].id) {
                    return flightEvents[i];
                }
            }
            return null;
        }

        public static List<FlightEvent> GetFlightEvents() 
        {
            return flightEvents;
        }

        public static void SetFlightEvents(List<FlightEvent> value) 
        {
            flightEvents = value;
        }

        public static void SetAircraft(string icao)
        {
            aircraft = Fleet.getAircraftByIcao(icao);
        }

        public static void SetFlightInit(FlightInit init)
        {
            flightInit = init;
        }

        public static string getFlightMode() 
        {
            return flightModes[flightMode];
        }
        
        private static void sendMessage(string message, int timeout)
        {
            FSUIPCProvider.sendMessage(message, timeout);
        }

        public static double DistLatLong(double lat1, double lon1, double lat2, double lon2, string units)
        {
            //Credits to 'The Math Forum' for the formula
            //http://mathforum.org/library/drmath/view/51879.html 

            double degrad = Math.PI / 180;
            double a, c, R;
            R = 0;
            double dlon, dlat;

            //convert the degree values to radians before calculation
            lat1 = lat1 * degrad;
            lon1 = lon1 * degrad;
            lat2 = lat2 * degrad;
            lon2 = lon2 * degrad;

            dlon = lon2 - lon1;
            dlat = lat2 - lat1;

            a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
            c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // R (Earth Radius) = 3956.0 mi = 3437.7 nm = 6367.0 km
            switch (units)
            {
                case "sm":
                    R = 3956.0;
                    break;
                case "nm":
                    R = 3437.7;
                    break;
                case "km": 
                    R = 6367.0;
                    break;
            }

            return (R * c);
        }
    }
}
