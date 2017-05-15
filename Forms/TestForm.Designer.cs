namespace SEMIK1.Forms
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.labelConnection = new System.Windows.Forms.Label();
            this.finishedLabel = new System.Windows.Forms.Label();
            this.trackingLabel = new System.Windows.Forms.Label();
            this.parkingLabel = new System.Windows.Forms.Label();
            this.onGroundLabel = new System.Windows.Forms.Label();
            this.vspeedLabel = new System.Windows.Forms.Label();
            this.airspeedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Location = new System.Drawing.Point(12, 240);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(0, 13);
            this.labelConnection.TabIndex = 1;
            // 
            // finishedLabel
            // 
            this.finishedLabel.AutoSize = true;
            this.finishedLabel.Location = new System.Drawing.Point(19, 205);
            this.finishedLabel.Name = "finishedLabel";
            this.finishedLabel.Size = new System.Drawing.Size(0, 13);
            this.finishedLabel.TabIndex = 7;
            // 
            // trackingLabel
            // 
            this.trackingLabel.AutoSize = true;
            this.trackingLabel.Location = new System.Drawing.Point(19, 174);
            this.trackingLabel.Name = "trackingLabel";
            this.trackingLabel.Size = new System.Drawing.Size(69, 13);
            this.trackingLabel.TabIndex = 13;
            this.trackingLabel.Text = "finishedLabel";
            // 
            // parkingLabel
            // 
            this.parkingLabel.AutoSize = true;
            this.parkingLabel.Location = new System.Drawing.Point(19, 144);
            this.parkingLabel.Name = "parkingLabel";
            this.parkingLabel.Size = new System.Drawing.Size(35, 13);
            this.parkingLabel.TabIndex = 12;
            this.parkingLabel.Text = "label2";
            // 
            // onGroundLabel
            // 
            this.onGroundLabel.AutoSize = true;
            this.onGroundLabel.Location = new System.Drawing.Point(19, 117);
            this.onGroundLabel.Name = "onGroundLabel";
            this.onGroundLabel.Size = new System.Drawing.Size(35, 13);
            this.onGroundLabel.TabIndex = 11;
            this.onGroundLabel.Text = "label1";
            // 
            // vspeedLabel
            // 
            this.vspeedLabel.AutoSize = true;
            this.vspeedLabel.Location = new System.Drawing.Point(19, 90);
            this.vspeedLabel.Name = "vspeedLabel";
            this.vspeedLabel.Size = new System.Drawing.Size(35, 13);
            this.vspeedLabel.TabIndex = 10;
            this.vspeedLabel.Text = "label1";
            // 
            // airspeedLabel
            // 
            this.airspeedLabel.AutoSize = true;
            this.airspeedLabel.Location = new System.Drawing.Point(19, 63);
            this.airspeedLabel.Name = "airspeedLabel";
            this.airspeedLabel.Size = new System.Drawing.Size(35, 13);
            this.airspeedLabel.TabIndex = 9;
            this.airspeedLabel.Text = "label1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.trackingLabel);
            this.Controls.Add(this.parkingLabel);
            this.Controls.Add(this.onGroundLabel);
            this.Controls.Add(this.vspeedLabel);
            this.Controls.Add(this.airspeedLabel);
            this.Controls.Add(this.finishedLabel);
            this.Controls.Add(this.labelConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ČSAV Šemík";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label finishedLabel;
        private System.Windows.Forms.Label trackingLabel;
        private System.Windows.Forms.Label parkingLabel;
        private System.Windows.Forms.Label onGroundLabel;
        private System.Windows.Forms.Label vspeedLabel;
        private System.Windows.Forms.Label airspeedLabel;
    }
}

