namespace SEMIK1.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.loggedUserStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.flightConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.flightModeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ACARSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewACARSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FDRMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFDRFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyRoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.socketCommToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.connectToSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(574, 346);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggedUserStatusLabel,
            this.toolStripProgressBar,
            this.flightConnectionLabel,
            this.flightModeStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 426);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(630, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // loggedUserStatusLabel
            // 
            this.loggedUserStatusLabel.Name = "loggedUserStatusLabel";
            this.loggedUserStatusLabel.Size = new System.Drawing.Size(104, 17);
            this.loggedUserStatusLabel.Text = "User not logged in";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Step = 1;
            // 
            // flightConnectionLabel
            // 
            this.flightConnectionLabel.Name = "flightConnectionLabel";
            this.flightConnectionLabel.Size = new System.Drawing.Size(140, 17);
            this.flightConnectionLabel.Text = "Flight Sim not connected";
            // 
            // flightModeStatusLabel
            // 
            this.flightModeStatusLabel.Name = "flightModeStatusLabel";
            this.flightModeStatusLabel.Size = new System.Drawing.Size(147, 17);
            this.flightModeStatusLabel.Text = "Flight mode: Pre-boarding";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ACARSMenuItem,
            this.FDRMenuItem,
            this.pilotInfoToolStripMenuItem,
            this.companyRoutesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.socketCommToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(120, 6, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(630, 31);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ACARSMenuItem
            // 
            this.ACARSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewACARSToolStripMenuItem,
            this.connectToSimulatorToolStripMenuItem});
            this.ACARSMenuItem.Enabled = false;
            this.ACARSMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ACARSMenuItem.Name = "ACARSMenuItem";
            this.ACARSMenuItem.Size = new System.Drawing.Size(56, 19);
            this.ACARSMenuItem.Text = "ACARS";
            // 
            // startNewACARSToolStripMenuItem
            // 
            this.startNewACARSToolStripMenuItem.Name = "startNewACARSToolStripMenuItem";
            this.startNewACARSToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.startNewACARSToolStripMenuItem.Text = "Start new flight";
            this.startNewACARSToolStripMenuItem.Click += new System.EventHandler(this.startNewACARSToolStripMenuItem_Click);
            // 
            // FDRMenuItem
            // 
            this.FDRMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFDRFileToolStripMenuItem,
            this.closeFDRToolStripMenuItem});
            this.FDRMenuItem.Enabled = false;
            this.FDRMenuItem.Name = "FDRMenuItem";
            this.FDRMenuItem.Size = new System.Drawing.Size(40, 19);
            this.FDRMenuItem.Text = "FDR";
            // 
            // openFDRFileToolStripMenuItem
            // 
            this.openFDRFileToolStripMenuItem.Name = "openFDRFileToolStripMenuItem";
            this.openFDRFileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openFDRFileToolStripMenuItem.Text = "Open FDR file";
            this.openFDRFileToolStripMenuItem.Click += new System.EventHandler(this.openFDRFileToolStripMenuItem_Click);
            // 
            // closeFDRToolStripMenuItem
            // 
            this.closeFDRToolStripMenuItem.Name = "closeFDRToolStripMenuItem";
            this.closeFDRToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.closeFDRToolStripMenuItem.Text = "Close FDR";
            this.closeFDRToolStripMenuItem.Click += new System.EventHandler(this.closeFDRToolStripMenuItem_Click);
            // 
            // pilotInfoToolStripMenuItem
            // 
            this.pilotInfoToolStripMenuItem.Enabled = false;
            this.pilotInfoToolStripMenuItem.Name = "pilotInfoToolStripMenuItem";
            this.pilotInfoToolStripMenuItem.Size = new System.Drawing.Size(67, 19);
            this.pilotInfoToolStripMenuItem.Text = "Pilot Info";
            this.pilotInfoToolStripMenuItem.Click += new System.EventHandler(this.pilotInfoToolStripMenuItem_Click);
            // 
            // companyRoutesToolStripMenuItem
            // 
            this.companyRoutesToolStripMenuItem.Enabled = false;
            this.companyRoutesToolStripMenuItem.Name = "companyRoutesToolStripMenuItem";
            this.companyRoutesToolStripMenuItem.Size = new System.Drawing.Size(110, 19);
            this.companyRoutesToolStripMenuItem.Text = "Company Routes";
            this.companyRoutesToolStripMenuItem.Click += new System.EventHandler(this.companyRoutesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // socketCommToolStripMenuItem
            // 
            this.socketCommToolStripMenuItem.Name = "socketCommToolStripMenuItem";
            this.socketCommToolStripMenuItem.Size = new System.Drawing.Size(62, 19);
            this.socketCommToolStripMenuItem.Text = "SComm";
            this.socketCommToolStripMenuItem.Visible = false;
            this.socketCommToolStripMenuItem.Click += new System.EventHandler(this.socketCommToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "CSAV Semik";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEMIK1.Properties.Resources.stripIcon;
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // connectToSimulatorToolStripMenuItem
            // 
            this.connectToSimulatorToolStripMenuItem.Name = "connectToSimulatorToolStripMenuItem";
            this.connectToSimulatorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.connectToSimulatorToolStripMenuItem.Text = "Connect to simulator";
            this.connectToSimulatorToolStripMenuItem.Click += new System.EventHandler(this.connectToSimulatorToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(630, 448);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ČSAV Šemík Beta (Horymír Revenge)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel loggedUserStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel flightConnectionLabel;
        private System.Windows.Forms.ToolStripStatusLabel flightModeStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pilotInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem FDRMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFDRFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ACARSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewACARSToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeFDRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyRoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem socketCommToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToSimulatorToolStripMenuItem;

    }
}