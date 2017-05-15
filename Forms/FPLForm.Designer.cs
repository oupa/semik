namespace SEMIK1.Forms
{
    partial class FPLForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flightLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.alternateCombo = new System.Windows.Forms.ComboBox();
            this.iataCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.callsignTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.routeTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.arrivalTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.departureTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.aircraftCombo = new System.Windows.Forms.ComboBox();
            this.registrationCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonIvao = new System.Windows.Forms.Button();
            this.buttonVatsim = new System.Windows.Forms.Button();
            this.buttonBoarding = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cargoTxt = new System.Windows.Forms.TextBox();
            this.chbTraining = new System.Windows.Forms.CheckBox();
            this.buttonManifest = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.buttonPax = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.paxTxt = new System.Windows.Forms.TextBox();
            this.flightsimBox = new System.Windows.Forms.GroupBox();
            this.fsInfoTxt = new System.Windows.Forms.Label();
            this.boardingInfoTxt = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBriefing = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightLevelUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flightsimBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flightLevelUpDown);
            this.groupBox1.Controls.Add(this.alternateCombo);
            this.groupBox1.Controls.Add(this.iataCombo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.callsignTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.routeTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.arrivalTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.departureTxt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight Details";
            // 
            // flightLevelUpDown
            // 
            this.flightLevelUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.flightLevelUpDown.Location = new System.Drawing.Point(218, 39);
            this.flightLevelUpDown.Maximum = new decimal(new int[] {
            45000,
            0,
            0,
            0});
            this.flightLevelUpDown.Name = "flightLevelUpDown";
            this.flightLevelUpDown.Size = new System.Drawing.Size(69, 20);
            this.flightLevelUpDown.TabIndex = 16;
            // 
            // alternateCombo
            // 
            this.alternateCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.alternateCombo.FormattingEnabled = true;
            this.alternateCombo.Location = new System.Drawing.Point(136, 39);
            this.alternateCombo.Name = "alternateCombo";
            this.alternateCombo.Size = new System.Drawing.Size(76, 21);
            this.alternateCombo.TabIndex = 15;
            this.alternateCombo.TextChanged += new System.EventHandler(this.alternateCombo_TextChanged);
            // 
            // iataCombo
            // 
            this.iataCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iataCombo.FormattingEnabled = true;
            this.iataCombo.Location = new System.Drawing.Point(293, 39);
            this.iataCombo.Name = "iataCombo";
            this.iataCombo.Size = new System.Drawing.Size(76, 21);
            this.iataCombo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(377, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Callsign";
            // 
            // callsignTxt
            // 
            this.callsignTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.callsignTxt.Location = new System.Drawing.Point(376, 39);
            this.callsignTxt.Name = "callsignTxt";
            this.callsignTxt.Size = new System.Drawing.Size(67, 20);
            this.callsignTxt.TabIndex = 5;
            this.callsignTxt.TextChanged += new System.EventHandler(this.callsignTxt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(293, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Flight IATA";
            // 
            // routeTxt
            // 
            this.routeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routeTxt.Location = new System.Drawing.Point(10, 87);
            this.routeTxt.Multiline = true;
            this.routeTxt.Name = "routeTxt";
            this.routeTxt.Size = new System.Drawing.Size(433, 46);
            this.routeTxt.TabIndex = 6;
            this.routeTxt.TextChanged += new System.EventHandler(this.routeTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(7, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Route";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(216, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cruise Altitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(137, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alternate";
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(71, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arrival";
            // 
            // arrivalTxt
            // 
            this.arrivalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.arrivalTxt.Location = new System.Drawing.Point(73, 39);
            this.arrivalTxt.Name = "arrivalTxt";
            this.arrivalTxt.Size = new System.Drawing.Size(58, 20);
            this.arrivalTxt.TabIndex = 1;
            this.arrivalTxt.TextChanged += new System.EventHandler(this.arrivalTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departure";
            // 
            // departureTxt
            // 
            this.departureTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.departureTxt.Location = new System.Drawing.Point(9, 39);
            this.departureTxt.Name = "departureTxt";
            this.departureTxt.Size = new System.Drawing.Size(58, 20);
            this.departureTxt.TabIndex = 0;
            this.departureTxt.TextChanged += new System.EventHandler(this.departureTxt_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aircraftCombo);
            this.groupBox2.Controls.Add(this.registrationCombo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 113);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aircraft data";
            // 
            // aircraftCombo
            // 
            this.aircraftCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aircraftCombo.FormattingEnabled = true;
            this.aircraftCombo.Location = new System.Drawing.Point(13, 46);
            this.aircraftCombo.Name = "aircraftCombo";
            this.aircraftCombo.Size = new System.Drawing.Size(68, 21);
            this.aircraftCombo.TabIndex = 18;
            this.aircraftCombo.TextChanged += new System.EventHandler(this.aircraftCombo_TextChanged);
            // 
            // registrationCombo
            // 
            this.registrationCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.registrationCombo.FormattingEnabled = true;
            this.registrationCombo.Location = new System.Drawing.Point(90, 46);
            this.registrationCombo.Name = "registrationCombo";
            this.registrationCombo.Size = new System.Drawing.Size(80, 21);
            this.registrationCombo.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(88, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Registration";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(10, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Aircraft type";
            // 
            // buttonIvao
            // 
            this.buttonIvao.Location = new System.Drawing.Point(391, 15);
            this.buttonIvao.Name = "buttonIvao";
            this.buttonIvao.Size = new System.Drawing.Size(74, 23);
            this.buttonIvao.TabIndex = 3;
            this.buttonIvao.Text = "Load IVAO";
            this.buttonIvao.UseVisualStyleBackColor = true;
            this.buttonIvao.Click += new System.EventHandler(this.buttonIvao_Click);
            // 
            // buttonVatsim
            // 
            this.buttonVatsim.Location = new System.Drawing.Point(286, 15);
            this.buttonVatsim.Name = "buttonVatsim";
            this.buttonVatsim.Size = new System.Drawing.Size(99, 23);
            this.buttonVatsim.TabIndex = 4;
            this.buttonVatsim.Text = "Load VATSIM";
            this.buttonVatsim.UseVisualStyleBackColor = true;
            this.buttonVatsim.Click += new System.EventHandler(this.buttonVatsim_Click);
            // 
            // buttonBoarding
            // 
            this.buttonBoarding.Location = new System.Drawing.Point(21, 328);
            this.buttonBoarding.Name = "buttonBoarding";
            this.buttonBoarding.Size = new System.Drawing.Size(98, 23);
            this.buttonBoarding.TabIndex = 10;
            this.buttonBoarding.Text = "Begin boarding";
            this.buttonBoarding.UseVisualStyleBackColor = true;
            this.buttonBoarding.Click += new System.EventHandler(this.buttonBoarding_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cargoTxt);
            this.groupBox3.Controls.Add(this.chbTraining);
            this.groupBox3.Controls.Add(this.buttonManifest);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.weightTxt);
            this.groupBox3.Controls.Add(this.buttonPax);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.paxTxt);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(206, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 113);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Passengers";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(149, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Cargo";
            // 
            // cargoTxt
            // 
            this.cargoTxt.Enabled = false;
            this.cargoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cargoTxt.Location = new System.Drawing.Point(150, 45);
            this.cargoTxt.Name = "cargoTxt";
            this.cargoTxt.Size = new System.Drawing.Size(63, 20);
            this.cargoTxt.TabIndex = 26;
            // 
            // chbTraining
            // 
            this.chbTraining.AutoSize = true;
            this.chbTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbTraining.Location = new System.Drawing.Point(17, 78);
            this.chbTraining.Name = "chbTraining";
            this.chbTraining.Size = new System.Drawing.Size(136, 17);
            this.chbTraining.TabIndex = 25;
            this.chbTraining.Text = "Training / Service flight";
            this.toolTip.SetToolTip(this.chbTraining, "Use this if you are making a training flight or a flight out of the flight table." +
                    "");
            this.chbTraining.UseVisualStyleBackColor = true;
            this.chbTraining.CheckedChanged += new System.EventHandler(this.chbTraining_CheckedChanged);
            // 
            // buttonManifest
            // 
            this.buttonManifest.Enabled = false;
            this.buttonManifest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonManifest.Location = new System.Drawing.Point(153, 74);
            this.buttonManifest.Name = "buttonManifest";
            this.buttonManifest.Size = new System.Drawing.Size(90, 23);
            this.buttonManifest.TabIndex = 24;
            this.buttonManifest.Text = "Show manifest";
            this.buttonManifest.UseVisualStyleBackColor = true;
            this.buttonManifest.Visible = false;
            this.buttonManifest.Click += new System.EventHandler(this.buttonManifest_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(77, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Pax weight";
            // 
            // weightTxt
            // 
            this.weightTxt.Enabled = false;
            this.weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weightTxt.Location = new System.Drawing.Point(77, 45);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(63, 20);
            this.weightTxt.TabIndex = 22;
            // 
            // buttonPax
            // 
            this.buttonPax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPax.Location = new System.Drawing.Point(154, 73);
            this.buttonPax.Name = "buttonPax";
            this.buttonPax.Size = new System.Drawing.Size(82, 23);
            this.buttonPax.TabIndex = 9;
            this.buttonPax.Text = "Load PAX";
            this.buttonPax.UseVisualStyleBackColor = true;
            this.buttonPax.Click += new System.EventHandler(this.buttonPax_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(16, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Pax";
            // 
            // paxTxt
            // 
            this.paxTxt.Enabled = false;
            this.paxTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.paxTxt.Location = new System.Drawing.Point(16, 45);
            this.paxTxt.Name = "paxTxt";
            this.paxTxt.Size = new System.Drawing.Size(51, 20);
            this.paxTxt.TabIndex = 20;
            // 
            // flightsimBox
            // 
            this.flightsimBox.Controls.Add(this.fsInfoTxt);
            this.flightsimBox.Location = new System.Drawing.Point(470, 44);
            this.flightsimBox.Name = "flightsimBox";
            this.flightsimBox.Size = new System.Drawing.Size(136, 331);
            this.flightsimBox.TabIndex = 12;
            this.flightsimBox.TabStop = false;
            this.flightsimBox.Text = "Flightsim check";
            // 
            // fsInfoTxt
            // 
            this.fsInfoTxt.AutoSize = true;
            this.fsInfoTxt.Location = new System.Drawing.Point(10, 23);
            this.fsInfoTxt.MaximumSize = new System.Drawing.Size(150, 0);
            this.fsInfoTxt.Name = "fsInfoTxt";
            this.fsInfoTxt.Size = new System.Drawing.Size(10, 13);
            this.fsInfoTxt.TabIndex = 0;
            this.fsInfoTxt.Text = "-";
            // 
            // boardingInfoTxt
            // 
            this.boardingInfoTxt.AutoSize = true;
            this.boardingInfoTxt.Location = new System.Drawing.Point(134, 333);
            this.boardingInfoTxt.Name = "boardingInfoTxt";
            this.boardingInfoTxt.Size = new System.Drawing.Size(66, 13);
            this.boardingInfoTxt.TabIndex = 13;
            this.boardingInfoTxt.Text = "boardingInfo";
            // 
            // buttonBriefing
            // 
            this.buttonBriefing.Location = new System.Drawing.Point(166, 15);
            this.buttonBriefing.Name = "buttonBriefing";
            this.buttonBriefing.Size = new System.Drawing.Size(115, 23);
            this.buttonBriefing.TabIndex = 14;
            this.buttonBriefing.Text = "Load Briefing data";
            this.buttonBriefing.UseVisualStyleBackColor = true;
            this.buttonBriefing.Click += new System.EventHandler(this.buttonBriefing_Click);
            // 
            // FPLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBriefing);
            this.Controls.Add(this.boardingInfoTxt);
            this.Controls.Add(this.flightsimBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonBoarding);
            this.Controls.Add(this.buttonVatsim);
            this.Controls.Add(this.buttonIvao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPLForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FPLForm";
            this.Load += new System.EventHandler(this.FPLForm_Load);
            this.Shown += new System.EventHandler(this.FPLForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightLevelUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flightsimBox.ResumeLayout(false);
            this.flightsimBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox arrivalTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox departureTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox routeTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox callsignTxt;
        private System.Windows.Forms.Button buttonIvao;
        private System.Windows.Forms.Button buttonVatsim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBoarding;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox weightTxt;
        private System.Windows.Forms.Button buttonPax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox paxTxt;
        private System.Windows.Forms.ComboBox iataCombo;
        private System.Windows.Forms.ComboBox registrationCombo;
        private System.Windows.Forms.ComboBox aircraftCombo;
        private System.Windows.Forms.GroupBox flightsimBox;
        private System.Windows.Forms.Label fsInfoTxt;
        private System.Windows.Forms.Label boardingInfoTxt;
        private System.Windows.Forms.ComboBox alternateCombo;
        private System.Windows.Forms.NumericUpDown flightLevelUpDown;
        private System.Windows.Forms.Button buttonManifest;
        private System.Windows.Forms.CheckBox chbTraining;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cargoTxt;
        private System.Windows.Forms.Button buttonBriefing;
    }
}