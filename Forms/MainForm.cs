/*
 MDI parent for all other forms of the application. Handles top menu, switching of content and information displayed in status bar.
 Also handles initial connection to FSUIPC.
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
using FSUIPC;

namespace SEMIK1.Forms
{
    public partial class MainForm : Form
    {
        public LoginForm loginForm;
        public TestForm testForm;
        public FPLForm fplForm;
        public AcarsForm acarsForm;
        public FDRForm fdrForm;
        public PilotForm pilotForm;
        public SettingsForm settingsForm;
        public ImageForm imageForm;
        public RoutesForm routesForm;
        Timer progressTimer = new Timer();
        public FSData fsData;
        public Pilot pilot;
        Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            FSUIPCProvider.mainForm = this;
            Connector.mainForm = this;
            fsData = new FSData();
            pilot = new Pilot();
            Snapshot.Init();
            SoundFactory.Init();
            Logger.pilot = AcarsBuilder.pilot = pilot;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Log("");
            Logger.Log("Application started - build " + VersionChecker.buildVersion);
            Logger.Log(System.Environment.OSVersion.VersionString);
            //Logger.Log(System.Environment.Version.ToString());

            this.pilotInfoToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Enabled = false;
            this.startNewACARSToolStripMenuItem.Enabled = false;
            this.socketCommToolStripMenuItem.Enabled = false;

            VersionChecker.CheckVersion();
            showLogin();
        }

        public void showLogin()
        {
            //if (activeForm == loginForm) return;
            if (activeForm != null) activeForm.Hide();
            if (loginForm == null)
            {
                loginForm = new LoginForm(this);
                loginForm.MdiParent = this;
                loginForm.Dock = DockStyle.Fill;
            }

            this.pilotInfoToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Enabled = false;
            this.startNewACARSToolStripMenuItem.Enabled = false;
            this.ACARSMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Enabled = true;
            this.companyRoutesToolStripMenuItem.Enabled = false;
            this.FDRMenuItem.Enabled = false;

            loginForm.Show();
            loginForm.enableForm();
            setProgress(false);
            setStatus("");
            setUser("User not logged in");
            activeForm = loginForm;
        }

        public void login()
        {
            loginForm.Hide();
            showTest();
        }

        public void postLogin()
        {
            showFPL();
            this.pilotInfoToolStripMenuItem.Enabled = true;
            this.helpToolStripMenuItem.Enabled = true;
            this.startNewACARSToolStripMenuItem.Enabled = true;
            this.ACARSMenuItem.Enabled = true;
            this.settingsToolStripMenuItem.Enabled = true;
            this.companyRoutesToolStripMenuItem.Enabled = true;
            this.FDRMenuItem.Enabled = true;
            if (pilot.rank == "INSTRUCTOR") {
                this.socketCommToolStripMenuItem.Enabled = true;    
            }
        }

        public void showFPL()
        {
            if (activeForm == fplForm) return;
            activeForm.Hide();
            if (fplForm == null)
            {
                fplForm = new FPLForm(this);
                fplForm.MdiParent = this;
                fplForm.Dock = DockStyle.Fill;
            }
            fplForm.Show();
            activeForm = fplForm;
            fplForm.Unlock();
            fplForm.startValidateTimer();
            fplForm.startInfoTimer();
        }

        public void showAcars()
        {
            fplForm.Lock();
            this.ACARSMenuItem.Enabled = false;
            this.FDRMenuItem.Enabled = false;
            this.startNewACARSToolStripMenuItem.Enabled = false;
            this.openFDRFileToolStripMenuItem.Enabled = false;

            activeForm.Hide();
            acarsForm = new AcarsForm(this);
            acarsForm.MdiParent = this;
            acarsForm.Dock = DockStyle.Fill;
            acarsForm.Show();
            acarsForm.CreateTracking();
            activeForm = acarsForm;
        }

        public void finishAcars()
        {
            this.ACARSMenuItem.Enabled = true;
            this.FDRMenuItem.Enabled = true;
            this.startNewACARSToolStripMenuItem.Enabled = true;
            this.openFDRFileToolStripMenuItem.Enabled = true;
        }

        public void showTest()
        {
            this.pilotInfoToolStripMenuItem.Enabled = true;
            testForm = new TestForm(this);
            testForm.MdiParent = this;
            testForm.Show();
        }

        public void setStatus(string message) 
        {
            this.flightConnectionLabel.Text = message;
        }

        public void setUser(string user)
        {
            this.loggedUserStatusLabel.Text = user;
        }

        public void setProgress(bool visible)
        {
            this.toolStripProgressBar.Visible = visible;
            if (visible && !progressTimer.Enabled) {
                progressTimer.Enabled = true;
                progressTimer.Start();
                progressTimer.Interval = 100;
                progressTimer.Tick += new EventHandler(progressBarTick);
            }
            else if (!visible) {
                progressTimer.Stop();
                progressTimer.Enabled = false;
            }
        }

        public void setFlightMode(string flightMode)
        { 
            this.flightModeStatusLabel.Text = "Flight mode: "+ flightMode;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void progressBarTick(object sender, EventArgs e) 
        {
            if (this.toolStripProgressBar.Maximum > this.toolStripProgressBar.Value)
            {
                this.toolStripProgressBar.PerformStep();
            }
            else {
                this.toolStripProgressBar.Value = this.toolStripProgressBar.Minimum;
            }
        }

        public void ShowImage(Image i, string caption) {
            if (imageForm == null) {
                imageForm = new ImageForm(this);
            }
            imageForm.Text = caption;
            imageForm.ShowImage(i);
        }

        private void pilotInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //activeForm.Hide();
            pilotForm = new PilotForm(this, activeForm != acarsForm);
            pilotForm.fill();
            pilotForm.MdiParent = this;
            pilotForm.Dock = DockStyle.Fill;
            pilotForm.Show();
            if (activeForm == settingsForm || activeForm == pilotForm || activeForm == routesForm || activeForm == settingsForm)
            {
                activeForm.Hide();
            }
            activeForm = pilotForm;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) {
                this.Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Closing Šemík",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            e.Cancel = result == DialogResult.Cancel;
        }

        private void openFDRFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Šemík FDR files (*.fdr)|*.fdr";
            ofd.Title = "Choose file";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Serializer ser = new Serializer();
                FDR fdr = ser.LoadFDR(ofd.FileName);
                fdrForm = new FDRForm(this);
                activeForm.Hide();
                fdrForm.MdiParent = this;
                fdrForm.Dock = DockStyle.Fill;
                fdrForm.Show();
                fdrForm.ShowFDR(fdr);
                activeForm = fdrForm;
             }
        }

        private void startNewACARSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFPL();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Log("Closing application");
            FSUIPCConnection.Close();
            SoundFactory.Dispose();
            notifyIcon.Dispose();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (activeForm == settingsForm) return;
           // activeForm.Hide();
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm(this);
                settingsForm.MdiParent = this;
                settingsForm.Dock = DockStyle.Fill;
            }
            if (activeForm == settingsForm || activeForm == pilotForm || activeForm == routesForm || activeForm == settingsForm)
            {
                activeForm.Hide();
            }
            settingsForm.Show();
            activeForm = settingsForm;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog(this);
        }

        private void closeFDRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdrForm != null) {
                fdrForm.Close();
            }
        }

        private void companyRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (routesForm == null)
            {
                routesForm = new RoutesForm(this);
                routesForm.MdiParent = this;
                routesForm.Dock = DockStyle.Fill;
            }
            if (activeForm == settingsForm || activeForm == pilotForm || activeForm == routesForm || activeForm == settingsForm)
            {
                activeForm.Hide();
            }
            routesForm.Show();
            activeForm = routesForm;
        }

        private void socketCommToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocketCommForm sconn = new SocketCommForm(this);
            sconn.Show();
        }

        private void connectToSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FSUIPCProvider.isConnected())
            {
                FSUIPCProvider.Connect();
            } else {
                FSUIPCProvider.Disconnect();
                FSUIPCProvider.Connect();
            }
        }
    }
}
