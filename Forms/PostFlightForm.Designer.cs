namespace SEMIK1.Forms
{
    partial class PostFlightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostFlightForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.resultMessagesGrid = new System.Windows.Forms.DataGridView();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeResult = new System.Windows.Forms.Button();
            this.tabDivert = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reasonTxt = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.airportLabel = new System.Windows.Forms.Label();
            this.divertAirportCombo = new System.Windows.Forms.ComboBox();
            this.sendDivertButton = new System.Windows.Forms.Button();
            this.divertMessageTxt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultMessagesGrid)).BeginInit();
            this.tabDivert.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabResult);
            this.tabControl.Controls.Add(this.tabDivert);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(430, 322);
            this.tabControl.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.button1);
            this.tabResult.Controls.Add(this.resultMessagesGrid);
            this.tabResult.Controls.Add(this.closeResult);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(422, 296);
            this.tabResult.TabIndex = 0;
            this.tabResult.Text = "Flight Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // resultMessagesGrid
            // 
            this.resultMessagesGrid.AllowUserToAddRows = false;
            this.resultMessagesGrid.AllowUserToDeleteRows = false;
            this.resultMessagesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultMessagesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.message});
            this.resultMessagesGrid.Location = new System.Drawing.Point(6, 6);
            this.resultMessagesGrid.Name = "resultMessagesGrid";
            this.resultMessagesGrid.ReadOnly = true;
            this.resultMessagesGrid.Size = new System.Drawing.Size(410, 255);
            this.resultMessagesGrid.TabIndex = 2;
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.FillWeight = 330F;
            this.message.HeaderText = "Messages";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // closeResult
            // 
            this.closeResult.Location = new System.Drawing.Point(341, 267);
            this.closeResult.Name = "closeResult";
            this.closeResult.Size = new System.Drawing.Size(75, 23);
            this.closeResult.TabIndex = 1;
            this.closeResult.Text = "Close";
            this.closeResult.UseVisualStyleBackColor = true;
            this.closeResult.Click += new System.EventHandler(this.closeResult_Click);
            // 
            // tabDivert
            // 
            this.tabDivert.Controls.Add(this.groupBox1);
            this.tabDivert.Controls.Add(this.sendDivertButton);
            this.tabDivert.Controls.Add(this.divertMessageTxt);
            this.tabDivert.Location = new System.Drawing.Point(4, 22);
            this.tabDivert.Name = "tabDivert";
            this.tabDivert.Padding = new System.Windows.Forms.Padding(3);
            this.tabDivert.Size = new System.Drawing.Size(422, 296);
            this.tabDivert.TabIndex = 1;
            this.tabDivert.Text = "Report Divert";
            this.tabDivert.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reasonTxt);
            this.groupBox1.Controls.Add(this.reasonLabel);
            this.groupBox1.Controls.Add(this.airportLabel);
            this.groupBox1.Controls.Add(this.divertAirportCombo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(6, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 176);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Form";
            // 
            // reasonTxt
            // 
            this.reasonTxt.Location = new System.Drawing.Point(13, 65);
            this.reasonTxt.Multiline = true;
            this.reasonTxt.Name = "reasonTxt";
            this.reasonTxt.Size = new System.Drawing.Size(389, 97);
            this.reasonTxt.TabIndex = 8;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reasonLabel.Location = new System.Drawing.Point(10, 47);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(88, 13);
            this.reasonLabel.TabIndex = 7;
            this.reasonLabel.Text = "Reason for divert";
            // 
            // airportLabel
            // 
            this.airportLabel.AutoSize = true;
            this.airportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.airportLabel.Location = new System.Drawing.Point(10, 22);
            this.airportLabel.Name = "airportLabel";
            this.airportLabel.Size = new System.Drawing.Size(91, 13);
            this.airportLabel.TabIndex = 6;
            this.airportLabel.Text = "Diverted to airport";
            // 
            // divertAirportCombo
            // 
            this.divertAirportCombo.FormattingEnabled = true;
            this.divertAirportCombo.Location = new System.Drawing.Point(107, 19);
            this.divertAirportCombo.Name = "divertAirportCombo";
            this.divertAirportCombo.Size = new System.Drawing.Size(144, 21);
            this.divertAirportCombo.TabIndex = 5;
            // 
            // sendDivertButton
            // 
            this.sendDivertButton.Location = new System.Drawing.Point(315, 267);
            this.sendDivertButton.Name = "sendDivertButton";
            this.sendDivertButton.Size = new System.Drawing.Size(101, 23);
            this.sendDivertButton.TabIndex = 5;
            this.sendDivertButton.Text = "Submit report";
            this.sendDivertButton.UseVisualStyleBackColor = true;
            this.sendDivertButton.Click += new System.EventHandler(this.sendDivertButton_Click);
            // 
            // divertMessageTxt
            // 
            this.divertMessageTxt.Location = new System.Drawing.Point(11, 12);
            this.divertMessageTxt.Name = "divertMessageTxt";
            this.divertMessageTxt.Size = new System.Drawing.Size(394, 59);
            this.divertMessageTxt.TabIndex = 1;
            this.divertMessageTxt.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close and quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PostFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 346);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostFlightForm";
            this.Text = "Flight Completed";
            this.tabControl.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultMessagesGrid)).EndInit();
            this.tabDivert.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TabPage tabDivert;
        private System.Windows.Forms.Button closeResult;
        private System.Windows.Forms.DataGridView resultMessagesGrid;
        private System.Windows.Forms.Label divertMessageTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox reasonTxt;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label airportLabel;
        private System.Windows.Forms.ComboBox divertAirportCombo;
        private System.Windows.Forms.Button sendDivertButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.Button button1;

    }
}