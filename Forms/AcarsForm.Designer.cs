namespace SEMIK1.Forms
{
    partial class AcarsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcarsForm));
            this.messagesPage = new System.Windows.Forms.TabPage();
            this.messagesGrid = new System.Windows.Forms.DataGridView();
            this.message_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventsPage = new System.Windows.Forms.TabPage();
            this.eventsGrid = new System.Windows.Forms.DataGridView();
            this.event_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.acarsTreePage = new System.Windows.Forms.TabPage();
            this.acarsTTree = new System.Windows.Forms.TreeView();
            this.controlsPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnModeDeparture = new System.Windows.Forms.Button();
            this.btnModeLanding = new System.Windows.Forms.Button();
            this.btnModeApproach = new System.Windows.Forms.Button();
            this.btnModeDescent = new System.Windows.Forms.Button();
            this.btnModeCruise = new System.Windows.Forms.Button();
            this.btnModeClimb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.acarsTree = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.messagesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messagesGrid)).BeginInit();
            this.eventsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.acarsTreePage.SuspendLayout();
            this.controlsPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // messagesPage
            // 
            this.messagesPage.Controls.Add(this.messagesGrid);
            this.messagesPage.Location = new System.Drawing.Point(4, 22);
            this.messagesPage.Name = "messagesPage";
            this.messagesPage.Padding = new System.Windows.Forms.Padding(3);
            this.messagesPage.Size = new System.Drawing.Size(589, 400);
            this.messagesPage.TabIndex = 1;
            this.messagesPage.Text = "Server Messages";
            this.messagesPage.UseVisualStyleBackColor = true;
            // 
            // messagesGrid
            // 
            this.messagesGrid.AllowUserToAddRows = false;
            this.messagesGrid.AllowUserToDeleteRows = false;
            this.messagesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messagesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.message_time,
            this.message_text});
            this.messagesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagesGrid.Location = new System.Drawing.Point(3, 3);
            this.messagesGrid.Name = "messagesGrid";
            this.messagesGrid.ReadOnly = true;
            this.messagesGrid.Size = new System.Drawing.Size(583, 394);
            this.messagesGrid.TabIndex = 0;
            // 
            // message_time
            // 
            this.message_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.message_time.HeaderText = "Time";
            this.message_time.Name = "message_time";
            this.message_time.ReadOnly = true;
            this.message_time.Width = 55;
            // 
            // message_text
            // 
            this.message_text.FillWeight = 300F;
            this.message_text.HeaderText = "Text";
            this.message_text.Name = "message_text";
            this.message_text.ReadOnly = true;
            this.message_text.Width = 300;
            // 
            // eventsPage
            // 
            this.eventsPage.Controls.Add(this.eventsGrid);
            this.eventsPage.Location = new System.Drawing.Point(4, 22);
            this.eventsPage.Name = "eventsPage";
            this.eventsPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsPage.Size = new System.Drawing.Size(589, 400);
            this.eventsPage.TabIndex = 0;
            this.eventsPage.Text = "Acars Events";
            this.eventsPage.UseVisualStyleBackColor = true;
            // 
            // eventsGrid
            // 
            this.eventsGrid.AllowUserToAddRows = false;
            this.eventsGrid.AllowUserToDeleteRows = false;
            this.eventsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.event_time,
            this.event_id,
            this.altitude,
            this.gs,
            this.fuel,
            this.distance,
            this.event_remarks});
            this.eventsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsGrid.Location = new System.Drawing.Point(3, 3);
            this.eventsGrid.Name = "eventsGrid";
            this.eventsGrid.ReadOnly = true;
            this.eventsGrid.Size = new System.Drawing.Size(583, 394);
            this.eventsGrid.TabIndex = 0;
            // 
            // event_time
            // 
            this.event_time.FillWeight = 40F;
            this.event_time.HeaderText = "Time";
            this.event_time.Name = "event_time";
            this.event_time.ReadOnly = true;
            this.event_time.Width = 40;
            // 
            // event_id
            // 
            this.event_id.FillWeight = 70F;
            this.event_id.HeaderText = "ID";
            this.event_id.Name = "event_id";
            this.event_id.ReadOnly = true;
            this.event_id.Width = 70;
            // 
            // altitude
            // 
            this.altitude.FillWeight = 50F;
            this.altitude.HeaderText = "Alt";
            this.altitude.Name = "altitude";
            this.altitude.ReadOnly = true;
            this.altitude.Width = 50;
            // 
            // gs
            // 
            this.gs.FillWeight = 50F;
            this.gs.HeaderText = "GS";
            this.gs.Name = "gs";
            this.gs.ReadOnly = true;
            this.gs.Width = 50;
            // 
            // fuel
            // 
            this.fuel.FillWeight = 40F;
            this.fuel.HeaderText = "Fuel";
            this.fuel.Name = "fuel";
            this.fuel.ReadOnly = true;
            this.fuel.Width = 40;
            // 
            // distance
            // 
            this.distance.FillWeight = 70F;
            this.distance.HeaderText = "Distance";
            this.distance.Name = "distance";
            this.distance.ReadOnly = true;
            this.distance.Width = 70;
            // 
            // event_remarks
            // 
            this.event_remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.event_remarks.HeaderText = "Remarks";
            this.event_remarks.Name = "event_remarks";
            this.event_remarks.ReadOnly = true;
            this.event_remarks.Width = 74;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.eventsPage);
            this.tabControl.Controls.Add(this.acarsTreePage);
            this.tabControl.Controls.Add(this.messagesPage);
            this.tabControl.Controls.Add(this.controlsPage);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(597, 426);
            this.tabControl.TabIndex = 1;
            // 
            // acarsTreePage
            // 
            this.acarsTreePage.Controls.Add(this.acarsTTree);
            this.acarsTreePage.Location = new System.Drawing.Point(4, 22);
            this.acarsTreePage.Name = "acarsTreePage";
            this.acarsTreePage.Padding = new System.Windows.Forms.Padding(3);
            this.acarsTreePage.Size = new System.Drawing.Size(589, 400);
            this.acarsTreePage.TabIndex = 2;
            this.acarsTreePage.Text = "Acars Event Tree";
            this.acarsTreePage.UseVisualStyleBackColor = true;
            // 
            // acarsTTree
            // 
            this.acarsTTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acarsTTree.Location = new System.Drawing.Point(3, 3);
            this.acarsTTree.Name = "acarsTTree";
            this.acarsTTree.Size = new System.Drawing.Size(583, 394);
            this.acarsTTree.TabIndex = 0;
            // 
            // controlsPage
            // 
            this.controlsPage.Controls.Add(this.groupBox3);
            this.controlsPage.Controls.Add(this.groupBox2);
            this.controlsPage.Controls.Add(this.groupBox1);
            this.controlsPage.Location = new System.Drawing.Point(4, 22);
            this.controlsPage.Name = "controlsPage";
            this.controlsPage.Padding = new System.Windows.Forms.Padding(3);
            this.controlsPage.Size = new System.Drawing.Size(589, 400);
            this.controlsPage.TabIndex = 3;
            this.controlsPage.Text = "Controls";
            this.controlsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(8, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancel flight tracking";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(13, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel flight tracking";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(505, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Warning, by clicking Cancel flight, you will lose all progress of your flight and" +
                " the tracking will be finished.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModeDeparture);
            this.groupBox1.Controls.Add(this.btnModeLanding);
            this.groupBox1.Controls.Add(this.btnModeApproach);
            this.groupBox1.Controls.Add(this.btnModeDescent);
            this.groupBox1.Controls.Add(this.btnModeCruise);
            this.groupBox1.Controls.Add(this.btnModeClimb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change flight mode";
            // 
            // btnModeDeparture
            // 
            this.btnModeDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeDeparture.Location = new System.Drawing.Point(20, 94);
            this.btnModeDeparture.Name = "btnModeDeparture";
            this.btnModeDeparture.Size = new System.Drawing.Size(75, 23);
            this.btnModeDeparture.TabIndex = 8;
            this.btnModeDeparture.Text = "Departure";
            this.btnModeDeparture.UseVisualStyleBackColor = true;
            this.btnModeDeparture.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnModeLanding
            // 
            this.btnModeLanding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeLanding.Location = new System.Drawing.Point(401, 94);
            this.btnModeLanding.Name = "btnModeLanding";
            this.btnModeLanding.Size = new System.Drawing.Size(75, 23);
            this.btnModeLanding.TabIndex = 6;
            this.btnModeLanding.Text = "Landing";
            this.btnModeLanding.UseVisualStyleBackColor = true;
            this.btnModeLanding.Click += new System.EventHandler(this.btnModeLanding_Click);
            // 
            // btnModeApproach
            // 
            this.btnModeApproach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeApproach.Location = new System.Drawing.Point(325, 94);
            this.btnModeApproach.Name = "btnModeApproach";
            this.btnModeApproach.Size = new System.Drawing.Size(75, 23);
            this.btnModeApproach.TabIndex = 5;
            this.btnModeApproach.Text = "Approach";
            this.btnModeApproach.UseVisualStyleBackColor = true;
            this.btnModeApproach.Click += new System.EventHandler(this.btnModeApproach_Click);
            // 
            // btnModeDescent
            // 
            this.btnModeDescent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeDescent.Location = new System.Drawing.Point(248, 94);
            this.btnModeDescent.Name = "btnModeDescent";
            this.btnModeDescent.Size = new System.Drawing.Size(75, 23);
            this.btnModeDescent.TabIndex = 4;
            this.btnModeDescent.Text = "Descent";
            this.btnModeDescent.UseVisualStyleBackColor = true;
            this.btnModeDescent.Click += new System.EventHandler(this.btnModeDescent_Click);
            // 
            // btnModeCruise
            // 
            this.btnModeCruise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeCruise.Location = new System.Drawing.Point(172, 94);
            this.btnModeCruise.Name = "btnModeCruise";
            this.btnModeCruise.Size = new System.Drawing.Size(75, 23);
            this.btnModeCruise.TabIndex = 3;
            this.btnModeCruise.Text = "Cruise";
            this.btnModeCruise.UseVisualStyleBackColor = true;
            this.btnModeCruise.Click += new System.EventHandler(this.btnModeCruise_Click);
            // 
            // btnModeClimb
            // 
            this.btnModeClimb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnModeClimb.Location = new System.Drawing.Point(96, 94);
            this.btnModeClimb.Name = "btnModeClimb";
            this.btnModeClimb.Size = new System.Drawing.Size(75, 23);
            this.btnModeClimb.TabIndex = 2;
            this.btnModeClimb.Text = "Climb";
            this.btnModeClimb.UseVisualStyleBackColor = true;
            this.btnModeClimb.Click += new System.EventHandler(this.btnModeClimb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Change mode to:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // acarsTree
            // 
            this.acarsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acarsTree.LineColor = System.Drawing.Color.Empty;
            this.acarsTree.Location = new System.Drawing.Point(3, 3);
            this.acarsTree.Name = "acarsTree";
            this.acarsTree.Size = new System.Drawing.Size(583, 394);
            this.acarsTree.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(8, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 84);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection Service";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(13, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Try reconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(505, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "In case Šemík lost connection to FS, you might try to restore it here.";
            // 
            // AcarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 426);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcarsForm";
            this.Text = "AcarsForm";
            this.messagesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messagesGrid)).EndInit();
            this.eventsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.acarsTreePage.ResumeLayout(false);
            this.controlsPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage messagesPage;
        private System.Windows.Forms.DataGridView messagesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn message_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn message_text;
        private System.Windows.Forms.TabPage eventsPage;
        private System.Windows.Forms.DataGridView eventsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn altitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn gs;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_remarks;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TreeView acarsTree;
        private System.Windows.Forms.TabPage acarsTreePage;
        private System.Windows.Forms.TreeView acarsTTree;
        private System.Windows.Forms.TabPage controlsPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModeDeparture;
        private System.Windows.Forms.Button btnModeLanding;
        private System.Windows.Forms.Button btnModeApproach;
        private System.Windows.Forms.Button btnModeDescent;
        private System.Windows.Forms.Button btnModeCruise;
        private System.Windows.Forms.Button btnModeClimb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;

    }
}