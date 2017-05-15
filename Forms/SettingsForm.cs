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
    public partial class SettingsForm : Form
    {
        MainForm mainForm;

        public SettingsForm(MainForm m)
        {
            InitializeComponent();
            mainForm = m;
            fill();
        }

        public void fill() 
        {
            this.useSoundCheckbox.Checked = Properties.Settings.Default.use_sound;
            this.volumeBar.Value = Convert.ToInt16(Properties.Settings.Default.sound_volume * 100);
            this.useTVCheckbox.Checked = Properties.Settings.Default.use_tv;
            this.refreshUpDown.Value = Properties.Settings.Default.tv_refresh;
            this.testerCheckbox.Checked = Properties.Settings.Default.offline;
            this.incrementCheckbox.Checked = Properties.Settings.Default.tv_increment;
            this.keywordTxt.Text = Properties.Settings.Default.tv_keyword;
            this.useKeywordCheckbox.Checked = Properties.Settings.Default.tv_use_keyword;
            this.fdrImagingCheckbox.Checked = Properties.Settings.Default.fdr_imaging;
            this.WarningsCheckbox.Checked = Properties.Settings.Default.display_warnings;
            this.AutoConnectCheckbox.Checked = Properties.Settings.Default.auto_connect;
            this.parkingBrakeTimeout.Value = Properties.Settings.Default.parking_brake_timeout;
        }

        private bool SaveSettings() {
            if (this.useKeywordCheckbox.Checked && this.keywordTxt.Text.Length == 0)
            {
                MessageBox.Show("Cannot use empty keyword to capture Flight Simulator window", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Properties.Settings.Default.use_sound = this.useSoundCheckbox.Checked;
            Properties.Settings.Default.sound_volume = (float)this.volumeBar.Value / 100;
            Properties.Settings.Default.use_tv = this.useTVCheckbox.Checked;
            Properties.Settings.Default.tv_refresh = (int)this.refreshUpDown.Value;
            Properties.Settings.Default.offline = this.testerCheckbox.Checked;
            Properties.Settings.Default.tv_increment = this.incrementCheckbox.Checked;
            Properties.Settings.Default.tv_keyword = this.keywordTxt.Text;
            Properties.Settings.Default.tv_use_keyword = this.useKeywordCheckbox.Checked;
            Properties.Settings.Default.fdr_imaging = this.fdrImagingCheckbox.Checked;
            Properties.Settings.Default.display_warnings = this.WarningsCheckbox.Checked;
            Properties.Settings.Default.auto_connect = this.AutoConnectCheckbox.Checked;
            Properties.Settings.Default.parking_brake_timeout = (int)this.parkingBrakeTimeout.Value;
            Properties.Settings.Default.Save();
            SoundFactory.SetVolume(this.volumeBar.Value);
            return true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSettings()) this.Hide();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SoundFactory.TestSound("Landing");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SoundFactory.TestSound("TaxiToGate");
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            SoundFactory.TestSound("Descent");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            SoundFactory.TestSound("TaxiFromGate");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SoundFactory.StopSound();
        }

        private void volumeBar_ValueChanged_1(object sender, EventArgs e)
        {
            SoundFactory.SetVolume(this.volumeBar.Value);
        }
    }
}
