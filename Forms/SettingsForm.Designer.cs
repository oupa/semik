namespace SEMIK1.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.closeBtn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.useSoundCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.incrementCheckbox = new System.Windows.Forms.CheckBox();
            this.useKeywordCheckbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshUpDown = new System.Windows.Forms.NumericUpDown();
            this.useTVCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.parkingBrakeTimeout = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.AutoConnectCheckbox = new System.Windows.Forms.CheckBox();
            this.WarningsCheckbox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fdrImagingCheckbox = new System.Windows.Forms.CheckBox();
            this.testerCheckbox = new System.Windows.Forms.CheckBox();
            this.API = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.webroot = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingBrakeTimeout)).BeginInit();
            this.API.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            resources.ApplyResources(this.closeBtn, "closeBtn");
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.API);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.volumeBar);
            this.tabPage1.Controls.Add(this.useSoundCheckbox);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button10
            // 
            resources.ApplyResources(this.button10, "button10");
            this.button10.Name = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // button9
            // 
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // volumeBar
            // 
            this.volumeBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.volumeBar, "volumeBar");
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Tag = "";
            this.volumeBar.TickFrequency = 10;
            this.volumeBar.ValueChanged += new System.EventHandler(this.volumeBar_ValueChanged_1);
            // 
            // useSoundCheckbox
            // 
            resources.ApplyResources(this.useSoundCheckbox, "useSoundCheckbox");
            this.useSoundCheckbox.Name = "useSoundCheckbox";
            this.useSoundCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.incrementCheckbox);
            this.tabPage2.Controls.Add(this.useKeywordCheckbox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.keywordTxt);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.refreshUpDown);
            this.tabPage2.Controls.Add(this.useTVCheckbox);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // incrementCheckbox
            // 
            resources.ApplyResources(this.incrementCheckbox, "incrementCheckbox");
            this.incrementCheckbox.Name = "incrementCheckbox";
            this.incrementCheckbox.UseVisualStyleBackColor = true;
            // 
            // useKeywordCheckbox
            // 
            resources.ApplyResources(this.useKeywordCheckbox, "useKeywordCheckbox");
            this.useKeywordCheckbox.Name = "useKeywordCheckbox";
            this.useKeywordCheckbox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // keywordTxt
            // 
            resources.ApplyResources(this.keywordTxt, "keywordTxt");
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.TextChanged += new System.EventHandler(this.keywordTxt_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // refreshUpDown
            // 
            this.refreshUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.refreshUpDown, "refreshUpDown");
            this.refreshUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.refreshUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.refreshUpDown.Name = "refreshUpDown";
            this.refreshUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // useTVCheckbox
            // 
            resources.ApplyResources(this.useTVCheckbox, "useTVCheckbox");
            this.useTVCheckbox.Name = "useTVCheckbox";
            this.useTVCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.parkingBrakeTimeout);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.AutoConnectCheckbox);
            this.tabPage3.Controls.Add(this.WarningsCheckbox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.fdrImagingCheckbox);
            this.tabPage3.Controls.Add(this.testerCheckbox);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // parkingBrakeTimeout
            // 
            this.parkingBrakeTimeout.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.parkingBrakeTimeout, "parkingBrakeTimeout");
            this.parkingBrakeTimeout.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.parkingBrakeTimeout.Name = "parkingBrakeTimeout";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // AutoConnectCheckbox
            // 
            resources.ApplyResources(this.AutoConnectCheckbox, "AutoConnectCheckbox");
            this.AutoConnectCheckbox.Name = "AutoConnectCheckbox";
            this.AutoConnectCheckbox.UseVisualStyleBackColor = true;
            // 
            // WarningsCheckbox
            // 
            resources.ApplyResources(this.WarningsCheckbox, "WarningsCheckbox");
            this.WarningsCheckbox.Name = "WarningsCheckbox";
            this.WarningsCheckbox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // fdrImagingCheckbox
            // 
            resources.ApplyResources(this.fdrImagingCheckbox, "fdrImagingCheckbox");
            this.fdrImagingCheckbox.Name = "fdrImagingCheckbox";
            this.fdrImagingCheckbox.UseVisualStyleBackColor = true;
            // 
            // testerCheckbox
            // 
            resources.ApplyResources(this.testerCheckbox, "testerCheckbox");
            this.testerCheckbox.Name = "testerCheckbox";
            this.testerCheckbox.UseVisualStyleBackColor = true;
            // 
            // API
            // 
            this.API.Controls.Add(this.webroot);
            this.API.Controls.Add(this.label11);
            resources.ApplyResources(this.API, "API");
            this.API.Name = "API";
            this.API.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // webroot
            // 
            resources.ApplyResources(this.webroot, "webroot");
            this.webroot.Name = "webroot";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingBrakeTimeout)).EndInit();
            this.API.ResumeLayout(false);
            this.API.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.CheckBox useSoundCheckbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox incrementCheckbox;
        private System.Windows.Forms.CheckBox useKeywordCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown refreshUpDown;
        private System.Windows.Forms.CheckBox useTVCheckbox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox fdrImagingCheckbox;
        private System.Windows.Forms.CheckBox testerCheckbox;
        private System.Windows.Forms.CheckBox WarningsCheckbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox AutoConnectCheckbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown parkingBrakeTimeout;
        private System.Windows.Forms.TabPage API;
        private System.Windows.Forms.TextBox webroot;
        private System.Windows.Forms.Label label11;
    }
}