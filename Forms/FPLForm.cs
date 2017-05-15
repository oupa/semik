/*
 Form with information about the flight which is about to be tracked.
 User can fill data by himself or load data from network from server-side script.
 Additionaly more script will load flight iata code, passengers and check if pilot is at the airport filled in flight plan.
 This works only if connection to FS is established.
 Basic validation is checking the fields and enables or disables various features, maily the button to begin tracking.
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections;
using FSUIPC;

namespace SEMIK1.Forms
{
    public partial class FPLForm : Form
    {
        private static MainForm mainForm;
        Timer VALIDATETIMER;
        Timer INFOTIMER;
        string validatedAirport = "";
        PaxManifestForm paxManifestForm;
        List<string> paxList = new List<string>();
        Aircraft aircraft;
        Aircraft previousAircraft;
        List<Airport> alternates;

        public FPLForm(MainForm m)
        {
            mainForm = m;
            InitializeComponent();
        }

        private void FPLForm_Load(object sender, EventArgs e)
        {
            buttonIvao.Enabled = (mainForm.pilot.ivao_id.Length > 0);
            buttonVatsim.Enabled = (mainForm.pilot.vatsim_id.Length > 0);
            fillAircrafts();
            if (Properties.Settings.Default.auto_connect)
            {
                FSUIPCProvider.Connect();
            }
            this.boardingInfoTxt.Text = "";
            alternates = new List<Airport>();
            VerifyFDRImaging();
        }

        public void startValidateTimer() {
            VALIDATETIMER = new Timer();
            VALIDATETIMER.Tick += new EventHandler(VALIDATETIMER_Tick);
            VALIDATETIMER.Interval = 1000;
            VALIDATETIMER.Enabled = true;
            VALIDATETIMER.Start();
        }

        private void VerifyFDRImaging() {
            if (Properties.Settings.Default.fdr_imaging == false && Properties.Settings.Default.fdr_reminder == false) {
                DialogResult res = MessageBox.Show(
                    "FDR imaging is set to OFF. With FDR imaging, each incident is recorded with a screenshot. This offers a better option for training and allows to claim in case the event of an error with incident detection. Do you wish to turn FDR imaging on?", "FDR imaging is OFF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Properties.Settings.Default.fdr_imaging = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("FDR imaging is now ON. Recommend you also check the settings for CSAV TV to prevent unwanted screen capturing");
                }
                else { 
                    MessageBox.Show("If you wish to turn FDR imaging on in future, just go to Settings > Options");
                }
                Properties.Settings.Default.fdr_reminder = true;
                Properties.Settings.Default.Save();
            }
        }

        private void VALIDATETIMER_Tick(Object myObject, EventArgs myEventArgs)
        {
            this.buttonPax.Enabled = validatePaxButton();
            this.buttonManifest.Enabled = validateManifestButton();
            this.buttonManifest.Visible = validateManifestButton();
            this.buttonBoarding.Enabled = validateBoardingButton();
        }

        private void buttonVatsim_Click(object sender, EventArgs e)
        {
            loadData("vatsim");
        }

        private void buttonIvao_Click(object sender, EventArgs e)
        {
            loadData("ivao");
        }

        public void startInfoTimer() {
            INFOTIMER = new Timer();
            INFOTIMER.Tick += new EventHandler(INFOTIMER_Tick);
            INFOTIMER.Interval = 5000;
            INFOTIMER.Enabled = true;
            INFOTIMER.Start();
        }

        private void INFOTIMER_Tick(Object myObject, EventArgs myEventArgs)
        {
            FSData f = mainForm.fsData;
            fsInfoTxt.Text = "";        
            if (validatedAirport.Length > 0){
                fsInfoTxt.Text += "Airport OK:\n" + validatedAirport + "\n"; 
            }

            fsInfoTxt.Text += "\nAircaft:" + f.aircraftName;
            
            fsInfoTxt.Text += "\nGW: " + f.loadedWeight.ToString("N0") + " kg";
            if (aircraft != null && f.loadedWeight > aircraft.mtow)
                fsInfoTxt.Text += " (!)";

            fsInfoTxt.Text += "\nZFW: " + f.zeroFuelWeight.ToString("N0") + " kg";
            fsInfoTxt.Text += "\nFuel: " + f.fuelTotalWeight.ToString("N0") + " kg";
            
            fsInfoTxt.Text += "\nOn ground:" + ((f.onGround) ? "YES" : "NO");
            fsInfoTxt.Text += "\nParking brake:" + ((f.parkingBrake) ? "ON":"OFF");
            fsInfoTxt.Text += "\nGear: " + ((f.gear) ? "UP":"DOWN");
            
            if (previousAircraft == null) 
            {
                aircraft = Fleet.getAircraftByIcao(f.aircraftName);
                if (aircraft != null)
                {
                    this.aircraftCombo.Text = aircraft.icao;
                    previousAircraft = aircraft;
                }
            }

            if (aircraft != null) {
                if (aircraft.icao != previousAircraft.icao) {
                    aircraft = Fleet.getAircraftByIcao(f.aircraftName);
                    this.aircraftCombo.Text = aircraft.icao;
                    previousAircraft = aircraft;
                }

                fsInfoTxt.Text += "\nFlaps:" + aircraft.getFlaps(f.flapsPosition);
            }
            
            fsInfoTxt.Text += "\nHeading:" + f.heading.ToString("N0");
            fsInfoTxt.Text += "\nCom 1: " + f.com1;
            fsInfoTxt.Text += "\nTransponder: " + f.transponder;
            //fsInfoTxt.Text += "\nPaused: " + ((f.paused) ? "YES":"NO");
            //fsInfoTxt.Text += "\nSlew: " + ((f.slewMode) ? "YES" : "NO");
            //fsInfoTxt.Text += "\nRate: " + f.simRate + "x";
            fsInfoTxt.Text += "\nWind: " + f.windDirection.ToString("N0") + "° " + f.windSpeed + " knots";
            fsInfoTxt.Text += "\nPressure: " + f.pressure + "hPa";
            fsInfoTxt.Text += "\nAltimeter: " + f.altimeterSetting + "hPa";
            //fsInfoTxt.Text += "\nPitch: " + f.pitch.ToString("N0");
            //fsInfoTxt.Text += "\nBank: " + f.bank.ToString("N0");
            fsInfoTxt.Text += "\nSurface: " + f.surface + "\n" + f.GetSurfaceString();
            //fsInfoTxt.Text += "\nG: " + (1 + f.acceleration_y).ToString("N2");
        }

        private void ClearFields()
        {
            this.departureTxt.Text = "";
            this.arrivalTxt.Text = "";
            this.alternateCombo.Text = "";
            this.alternateCombo.Items.Clear();
            this.iataCombo.Text = "";
            this.iataCombo.Items.Clear();
            this.callsignTxt.Text = "";
            this.routeTxt.Text = "";
            this.aircraftCombo.Text = "";
            this.registrationCombo.Text = "";
            this.paxTxt.Text = "";
            this.boardingInfoTxt.Text = "";
            this.cargoTxt.Text = "";
        }

        private bool validatePaxButton() 
        {
             if (this.iataCombo.Text.Length > 3 && (this.paxTxt.Text.Length == 0 || this.paxTxt.Text == "0") && !this.chbTraining.Checked)
             {
                 return true;
             }
            return false;
        }

        private bool validateManifestButton()
        {
            if (!validatePaxButton() && this.paxTxt.Text.Length != 0 && this.paxTxt.Text != "0")
            {
                return true;
            }

            return false;
        }

        private bool validateBoardingButton()
        {
            this.boardingInfoTxt.Visible = false;
            if (this.departureTxt.Text.Length < 4) return false;
            if (this.arrivalTxt.Text.Length < 4) return false;
            if (this.alternateCombo.Text.Length < 4) return false;
            if (this.flightLevelUpDown.Text.Length < 3) return false;
            if (this.iataCombo.Text.Length < 4) return false;
            if (this.routeTxt.Text.Length == 0) return false;
            if (this.aircraftCombo.Text.Length < 3) return false;
            if (this.callsignTxt.Text.Length < 5) return false;
            //if (this.aircraftRegistrationTxt.Text.Length < 6) return false;
            if (this.paxTxt.Text.Length == 0 && !this.chbTraining.Checked) return false;
            if (!FSUIPCProvider.isConnected()) return false;
            this.boardingInfoTxt.Visible = true;
            if (!mainForm.fsData.onGround)
            {
                FSUIPCProvider.sendMessage("Please be on ground to enable boarding...", 1);
                this.boardingInfoTxt.Text = "Please be on ground to enable boarding...";
                return false;
            }
            else
            {
               if (!mainForm.fsData.parkingBrake)
               {
                   FSUIPCProvider.sendMessage("Please apply parking brake to enable boarding...", 1);
                   this.boardingInfoTxt.Text = "Please apply parking brake to enable boarding...";
                   return false;
               }
               else 
               {
                   FSUIPCProvider.sendMessage("", 1);
               }
            }
            this.boardingInfoTxt.Text = "Everything looks good, you may now begin your flight.";
            return true;
        }

        private void buttonBoarding_Click(object sender, EventArgs e)
        {
            if (validatedAirport == "") {
                DialogResult dlg2 = MessageBox.Show(
                     "It appears, that the airport your aircraft is at doesn`t match the departure airport of the flight specified in flight plan. Do you wish to continue anyway?",
                     "Departure airport missmatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg2 != DialogResult.Yes)
                {
                    return;
                } 
            }

            if (this.iataCombo.Text == "OK9999") {
                DialogResult dlg1 = MessageBox.Show(
                    "You have chosen to fly a training flight. If you had not obtained an instructor`s approval via CSAV OnDemand, this flight will be logged, but you will not gain any flight hours. Do you wish to start the flight now?",
                    "Training flight",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg1 != DialogResult.Yes) {
                    return;
                }
            }
            
            if (Fleet.isInFleet(aircraftCombo.Text)){
                mainForm.showAcars();
            } else {
                DialogResult dlg = MessageBox.Show(
                    "The aircraft specified (" + aircraftCombo.Text + ") is not in Šemík/ČSAV library of supported aircrafts."+
                    "All parameters will be taken from default aircraft (B737-500)." +
                    "Click OK to continue or Cancel to correct this.", "Unsupported aircraft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.OK)
                {
                    mainForm.showAcars();
                }
                else {
                    aircraftCombo.Text = "";
                }
            }
            
            
        }

        private void loadIata()
        {
            if (this.departureTxt.Text.Length != 4 || this.arrivalTxt.Text.Length != 4)
            {
                return;
            }

            XmlNodeList iatas = Connector.GetIata(departureTxt.Text, arrivalTxt.Text);
            iataSuccess(iatas);
        }

        private void iataSuccess(XmlNodeList iataXml)
        {
            if (iataXml == null) {
                this.iataCombo.Items.Clear();
                this.iataCombo.Text = "";
                return;
            };
            this.iataCombo.Items.Clear();
            for (int i = 0; i < iataXml.Count; i++ )
            {
                XmlElement iata = (XmlElement)iataXml[i];
                string a = iata.GetAttribute("iata");
                this.iataCombo.Items.Add(a);
            }
            this.iataCombo.SelectedIndex = 0;
        }

        private void loadPax()
        {
            Aircraft a = Fleet.getAircraftByIcao(this.aircraftCombo.Text);
            if (a != null)
            {
                XmlElement xml = Connector.GetPax(this.iataCombo.Text, a.pax);
                paxSuccess(xml);
            }
            else { 
                MessageBox.Show(
                    "Cannot find selected aircraft icao (" + this.aircraftCombo.Text + ") in ČSAV fleet configuration. If you think this error, please contact administrator.",
                    "Cannot recognize aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
            }
            
        }

        private void paxSuccess(XmlElement paxNode)
        {
            if (paxNode == null) return;
            paxTxt.Text = paxNode.GetAttribute("pax");
            weightTxt.Text = paxNode.GetAttribute("weight");
            cargoTxt.Text = paxNode.GetAttribute("cargo");

            paxList.Clear();
            XmlNodeList paxNodes = paxNode.GetElementsByTagName("pax");
            for (int i = 0; i < paxNodes.Count; i++) 
            {
                XmlElement pax = (XmlElement)paxNodes[i];
                string name = pax.GetAttribute("name");
                paxList.Add(name);
            }
        }

        private void loadData(string network) 
        {
            XmlDocument xml = Connector.GetOnlinePilot(network);
            pilotNetworkSuccess(xml);
        }

        private void pilotNetworkSuccess(XmlDocument pilotXml) 
        {
            if (pilotXml == null) return;
            departureTxt.Text = pilotXml.SelectSingleNode("/semik/planned_depairport").InnerText;
            arrivalTxt.Text = pilotXml.SelectSingleNode("/semik/planned_destairport").InnerText;
            alternateCombo.Text = pilotXml.SelectSingleNode("/semik/planned_altairport").InnerText;
            flightLevelUpDown.Text = pilotXml.SelectSingleNode("/semik/planned_altitude").InnerText;
            callsignTxt.Text = pilotXml.SelectSingleNode("/semik/callsign").InnerText;
            routeTxt.Text = pilotXml.SelectSingleNode("/semik/planned_route").InnerText;
            aircraftCombo.Text = convertAircraft(pilotXml.SelectSingleNode("/semik/planned_aircraft").InnerText);
            loadIata();
        }

        private void loadAlternates()
        {
            if (this.arrivalTxt.Text.Length != 4)
            {
                return;
            }

            XmlNodeList xml = Connector.GetAlternates(this.arrivalTxt.Text);
            alternatesSuccess(xml);
        }

        private void alternatesSuccess(XmlNodeList alternatesXml)
        {
            if (alternatesXml == null) return;
            alternates = new List<Airport>();
            alternateCombo.Items.Clear();
            for (int i = 0; i < alternatesXml.Count; i++)
            {
                XmlElement alternate = (XmlElement)alternatesXml[i];
                string a = alternate.GetAttribute("icao");
                alternateCombo.Items.Add(a);
                Logger.Log(a);
                Airport aa = new Airport();
                aa.icao = alternate.GetAttribute("icao");
                aa.name = alternate.GetAttribute("name");
                aa.rwy = alternate.GetAttribute("rwy");
                aa.ils = (alternate.GetAttribute("ils") == "1");
                aa.distance = alternate.GetAttribute("distance");
                aa.iata = alternate.GetAttribute("iata");
                alternates.Add(aa);
            }
            alternateCombo.SelectedIndex = 0;
        }

        private void fillAircrafts()
        {
            this.aircraftCombo.Items.Clear();
            foreach (Aircraft a in Fleet.aircrafts) {
                this.aircraftCombo.Items.Add(a.icao);
            }
        }

        private string convertAircraft(string orig)
        {
            if (orig.IndexOf('/') >= 0) {
                String[] spl = orig.Split('/');
                for (int i = 0; i < spl.Length; i++)
                {
                    String s = spl[i];
                    if (s.Length == 4)
                    {
                        return s;
                    }
                }
            }
            return orig;
        }

        private void buttonPax_Click(object sender, EventArgs e)
        {
            loadPax();
        }

        private void aircraftCombo_TextChanged(object sender, EventArgs e)
        {
            if (Fleet.isInFleet(this.aircraftCombo.Text))
            {
                updateRegistrationCombo();
            }
            else {
                registrationCombo.Items.Clear();
                registrationCombo.Text = "";
            }
            this.paxTxt.Text = "";
            this.weightTxt.Text = "";
            this.cargoTxt.Text = "";
            this.buttonManifest.Visible = false;
            this.buttonPax.Visible = true;
        }

        private void updateRegistrationCombo() {
            Aircraft a = Fleet.getAircraftByIcao(this.aircraftCombo.Text);
            registrationCombo.Items.Clear();
            foreach(string r in a.regs){
                registrationCombo.Items.Add(r);
            }
            registrationCombo.SelectedIndex = 0;
        }

        private void departureTxt_TextChanged(object sender, EventArgs e)
        {
            departureTxt.Text = departureTxt.Text.ToUpper();
            departureTxt.SelectionStart = departureTxt.Text.Length;
            if (departureTxt.Text.Length == 4)
            {
                loadIata();
                if (FSUIPCProvider.connected) checkDepartureAirport();
            }
        }

        private void arrivalTxt_TextChanged(object sender, EventArgs e)
        {
            arrivalTxt.Text = arrivalTxt.Text.ToUpper();
            arrivalTxt.SelectionStart = arrivalTxt.Text.Length;
            loadIata();
            loadAlternates();
            clearPax();
        }

        private void clearPax()
        {
            paxList.Clear();
            paxTxt.Text = "";
            weightTxt.Text = "";
            cargoTxt.Text = "";
        }

        private void checkDepartureAirport()
        {
            XmlElement xml = Connector.CheckDepartureAirport(
                this.departureTxt.Text,
                mainForm.fsData.latitude.ToString(),
                mainForm.fsData.longitude.ToString(),
                mainForm.fsData.altitude.ToString());

            CheckDepartureAirportSuccess(xml);
        }

        private void CheckDepartureAirportSuccess(XmlElement node)
        {
            if (node == null)
            {
                this.departureTxt.ForeColor = System.Drawing.Color.Red;
                validatedAirport = "";
            }
            else 
            {
                Logger.Log("Is at airport checked OK : " + this.departureTxt.Text);
                this.departureTxt.ForeColor = System.Drawing.Color.Black;
                validatedAirport = node.GetAttribute("city") + " " + node.GetAttribute("airport");
            }
        }

        public void Lock() 
        {
            this.departureTxt.Enabled = false;
            this.arrivalTxt.Enabled = false;
            this.alternateCombo.Enabled = false;
            this.flightLevelUpDown.Enabled = false;
            this.callsignTxt.Enabled = false;
            this.routeTxt.Enabled = false;
            this.aircraftCombo.Enabled = false;
            this.registrationCombo.Enabled = false;
            INFOTIMER.Stop();
            VALIDATETIMER.Stop();
        }

        public void Unlock()
        {
            ClearFields();
            this.departureTxt.Enabled = true;
            this.arrivalTxt.Enabled = true;
            this.alternateCombo.Enabled = true;
            this.flightLevelUpDown.Enabled = true;
            this.callsignTxt.Enabled = true;
            this.routeTxt.Enabled = true;
            this.aircraftCombo.Enabled = true;
            this.registrationCombo.Enabled = true;
        }

        public FlightInit InitFlight()
        {
            try
            {
                FlightInit fi = new FlightInit();
                fi.departure = this.departureTxt.Text;
                fi.arrival = this.arrivalTxt.Text;
                fi.alternate = this.alternateCombo.Text;
                fi.flight_level = Convert.ToInt32(this.flightLevelUpDown.Text);
                fi.callsign = this.callsignTxt.Text;
                fi.route = this.routeTxt.Text;
                fi.aircraft = this.aircraftCombo.Text;
                fi.registration = this.registrationCombo.Text;
                fi.iata = this.iataCombo.Text;
                if (this.paxTxt.Text.Length == 0)
                {
                    fi.pax = 0;
                }
                else
                {
                    fi.pax = Convert.ToInt32(this.paxTxt.Text);
                }
                return fi;
            }
            catch (Exception e) {
                Logger.Log("Failed to init flight from FPL : " + e.ToString());
                MessageBox.Show(e.ToString(), "Init flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
           }
        }

        private void buttonManifest_Click(object sender, EventArgs e)
        {
            paxManifestForm = new PaxManifestForm(paxList);
            paxManifestForm.ShowDialog();
        }

        private void chbTraining_CheckedChanged(object sender, EventArgs e)
        {
            this.paxTxt.Text = "0";
            this.weightTxt.Text = "0";
            this.cargoTxt.Text = "0";
            if (chbTraining.Checked)
            {
                this.buttonPax.Enabled = false;
                this.buttonManifest.Enabled = false;
                this.iataCombo.Enabled = false;
                this.iataCombo.Text = "OK9999";
            }
            else 
            {
                this.buttonPax.Enabled = true;
                this.iataCombo.Enabled = true;
                this.iataCombo.Text = "";
                loadIata();
            }
        }

        private void FPLForm_Shown(object sender, EventArgs e)
        {
            Unlock();
        }

        private void alternateCombo_TextChanged(object sender, EventArgs e)
        {
            alternateCombo.Text = alternateCombo.Text.ToUpper();
            alternateCombo.SelectionStart = alternateCombo.Text.Length;
        }

        private void routeTxt_TextChanged(object sender, EventArgs e)
        {
            routeTxt.Text = routeTxt.Text.ToUpper();
            routeTxt.SelectionStart = routeTxt.Text.Length;
        }

        private void callsignTxt_TextChanged(object sender, EventArgs e)
        {
            callsignTxt.Text = callsignTxt.Text.ToUpper();
            callsignTxt.SelectionStart = callsignTxt.Text.Length;
        }

        private Airport getAlternate(string icao)
        {
            for (int i = 0; i < alternates.Count; i++) {
                if (icao == alternates[i].icao) {
                    return alternates[i];
                }
            }
            return null;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            Airport a = getAlternate(alternateCombo.Text);
            string message = "";
            if (a != null)
            {
                message = a.icao + " " + a.name + "\n";
                message += "dist: " + a.distance + " nm\n";
                message += "ils: " + ((a.ils) ? "Yes" : "No") + "\n";
                message += "rwy: " + a.rwy + " ft";
            }
            toolTip.Show(message, alternateCombo);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(alternateCombo);
        }

        private void buttonBriefing_Click(object sender, EventArgs e)
        {
            loadBriefing();
        }

        private void loadBriefing()
        {
            XmlElement briefing = Connector.GetBriefing(mainForm.pilot.pid, mainForm.pilot.auth_code);
            if (briefing == null) {
                return;
            }

            departureTxt.Text = briefing.GetAttribute("dep_icao").ToUpper();
            arrivalTxt.Text = briefing.GetAttribute("arr_icao").ToUpper();
            routeTxt.Text = briefing.GetAttribute("route").ToUpper();
            aircraftCombo.Text = briefing.GetAttribute("aircraft").ToUpper();
            registrationCombo.Text = briefing.GetAttribute("registration").ToUpper();
            paxTxt.Text = briefing.GetAttribute("pax").ToString();
            weightTxt.Text = briefing.GetAttribute("weight").ToString();
            cargoTxt.Text = briefing.GetAttribute("cargo").ToString();
            iataCombo.Text = briefing.GetAttribute("iata").ToUpper().Replace("-","");

            if (mainForm.fsData.aircraftName != "" && mainForm.fsData.aircraftName != briefing.GetAttribute("aircraft"))
            {
                MessageBox.Show("Aircraft in simulator does not match the aircraft from briefing.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
