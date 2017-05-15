/*
 So far very basic form to display information about currently logged pilot.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEMIK1;

namespace SEMIK1.Forms
{
    public partial class PilotForm : Form
    {
        MainForm mainForm;
        bool logoutEnabled;

        public PilotForm(MainForm m, bool _logoutEnabled)
        {
            InitializeComponent();
            logoutEnabled = _logoutEnabled;
            mainForm = m;
        }

        private void PilotForm_Load(object sender, EventArgs e)
        {

        }

        public void fill() 
        {
            if (mainForm.pilot == null) {
                this.pilotDataTxt.Text = "";
                return;
            }
            string message = "callsign: " + mainForm.pilot.callsign;
            message += "\nname: " + mainForm.pilot.name;
            message += "\nrank: " + mainForm.pilot.rank;
            message += "\nflights: " + mainForm.pilot.flights;
            message += "\nhours: " + mainForm.pilot.hours;
            message += "\nmiles: " + mainForm.pilot.miles;
            message += "\nvatsim id: " + mainForm.pilot.vatsim_id;
            message += "\nivao_id: " + mainForm.pilot.ivao_id;
            message += "\nlocation: " + mainForm.pilot.locationIcao + " " + mainForm.pilot.locationText;
            
            this.pilotDataTxt.Text = message;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void disableLogout()
        {
            //this.logoutButton.Enabled = false;
        }

        public void enableLogout()
        {
            //this.logoutButton.Enabled = true;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (!logoutEnabled) return;

            Properties.Settings.Default.remember = false;
            Properties.Settings.Default.pid = "";
            Properties.Settings.Default.auth_code = "";
            Properties.Settings.Default.Save();

            mainForm.loginForm.clearForm();
            mainForm.pilot = null;
            mainForm.showLogin();
        }
    }
}
