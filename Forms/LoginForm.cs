/*
 Form for loggin in the user. 
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
using System.IO;
using System.Xml;
using SEMIK1;

namespace SEMIK1.Forms
{
    public partial class LoginForm : Form
    {
        MainForm main;

        public LoginForm(MainForm m)
        {
            main = m;
            InitializeComponent();
        }

        private void fillText()
        {
            welcomeText.Text = "Welcome to Šemík. Please login using your pilot credentials that you use at CSAV website.";
            labelUserName.Text = "Username";
            labelPassword.Text = "Password";
            this.rememberCheckBox.Checked = Properties.Settings.Default.remember;
            if (Properties.Settings.Default.remember) {
                Logger.Log("Using saved authentication " + Properties.Settings.Default.auth_code);
                getLogin(Properties.Settings.Default.pid, Properties.Settings.Default.auth_code);
            }
        }

        private void disableForm()
        {
            this.usernameTxt.Enabled = false;
            this.passwordTxt.Enabled = false;
            this.buttonLogin.Enabled = false;
        }

        public void clearForm()
        {
            this.usernameTxt.Text = "";
            this.passwordTxt.Text = "";
            this.rememberCheckBox.Checked = false;
        }

        public void enableForm()
        {
            this.usernameTxt.Enabled = true;
            this.passwordTxt.Enabled = true;
            this.buttonLogin.Enabled = true;
        }

        private void getLogin(string pid, string auth_code) {
            disableForm();
            main.setStatus("Authenticating user...");
            main.setProgress(true);
            XmlDocument xml = Connector.GetLogin(pid, auth_code,usernameTxt.Text,passwordTxt.Text);
            loginSuccess(xml);
        }

        private void loginSuccess(XmlDocument loginXml) 
        {
            if (loginXml == null)
            {
                enableForm();
                main.setProgress(false);
                main.setStatus("");
                return;
            }
            try
            {
                main.pilot.callsign = loginXml.SelectSingleNode("/semik/callsign").InnerText;
                main.pilot.name = loginXml.SelectSingleNode("/semik/name").InnerText + " " + loginXml.SelectSingleNode("/semik/surname").InnerText;
                main.pilot.rank = loginXml.SelectSingleNode("/semik/rank").InnerText;
                main.pilot.hours = loginXml.SelectSingleNode("/semik/hours").InnerText;
                main.pilot.flights = Convert.ToInt32(loginXml.SelectSingleNode("/semik/flights").InnerText);
                main.pilot.miles = Convert.ToInt32(loginXml.SelectSingleNode("/semik/miles").InnerText);
                main.pilot.vatsim_id = loginXml.SelectSingleNode("/semik/vatsim_id").InnerText;
                main.pilot.ivao_id = loginXml.SelectSingleNode("/semik/ivao_id").InnerText;
                main.pilot.locationIcao = loginXml.SelectSingleNode("/semik/location").InnerText;
                main.pilot.locationText = loginXml.SelectSingleNode("/semik/location_text").InnerText;
                main.pilot.auth_code = loginXml.SelectSingleNode("/semik/auth_code").InnerText;
                main.pilot.pid = loginXml.SelectSingleNode("/semik/pilot_id").InnerText;

                XmlNodeList fleetXml = loginXml.GetElementsByTagName("aircraft");
                Fleet.create(fleetXml);
            
                if (this.rememberCheckBox.Checked)
                {
                    XmlNode auth_node = loginXml.SelectSingleNode("/semik/auth_code");
                    if (auth_node != null)
                    {
                        string auth_code = loginXml.SelectSingleNode("/semik/auth_code").InnerText;

                        if (this.rememberCheckBox.Checked && auth_code.Length > 0)
                        {
                            Logger.Log("Saving authentication " + auth_code);
                            Properties.Settings.Default.remember = true;
                            Properties.Settings.Default.pid = loginXml.SelectSingleNode("/semik/pilot_id").InnerText;
                            Properties.Settings.Default.auth_code = auth_code;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
                else
                {
                    Properties.Settings.Default.remember = false;
                    Properties.Settings.Default.pid = "";
                    Properties.Settings.Default.auth_code = "";
                    Properties.Settings.Default.Save();
                }

                Logger.Log("Login success");
                Logger.Log("Pilot object created : " + main.pilot.name);
                main.setUser(main.pilot.callsign + " : " + main.pilot.name);
                this.Hide();
                main.setProgress(false);
                main.postLogin();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            getLogin("","");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            main.setStatus("Welcome...");
            main.setProgress(false);
            fillText();
        }
    }
}
