namespace SEMIK1.Forms
{
    partial class SocketCommForm
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
            this.inputText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.connectPilotButton = new System.Windows.Forms.Button();
            this.connectInstructorButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.portText = new System.Windows.Forms.TextBox();
            this.ipText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(13, 138);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(343, 76);
            this.inputText.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(281, 220);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(13, 249);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(343, 214);
            this.outputText.TabIndex = 2;
            // 
            // connectPilotButton
            // 
            this.connectPilotButton.Location = new System.Drawing.Point(13, 13);
            this.connectPilotButton.Name = "connectPilotButton";
            this.connectPilotButton.Size = new System.Drawing.Size(113, 23);
            this.connectPilotButton.TabIndex = 3;
            this.connectPilotButton.Text = "Connect as Pilot";
            this.connectPilotButton.UseVisualStyleBackColor = true;
            this.connectPilotButton.Click += new System.EventHandler(this.pilotConnectButtonpilotConnectButton_Click);
            // 
            // connectInstructorButton
            // 
            this.connectInstructorButton.Location = new System.Drawing.Point(132, 13);
            this.connectInstructorButton.Name = "connectInstructorButton";
            this.connectInstructorButton.Size = new System.Drawing.Size(126, 23);
            this.connectInstructorButton.TabIndex = 4;
            this.connectInstructorButton.Text = "Connect as Instructor";
            this.connectInstructorButton.UseVisualStyleBackColor = true;
            this.connectInstructorButton.Click += new System.EventHandler(this.connectInstructorButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(264, 13);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(243, 42);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(96, 23);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update pilot list";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(181, 81);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(60, 20);
            this.portText.TabIndex = 7;
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(35, 81);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(91, 20);
            this.ipText.TabIndex = 8;
            this.ipText.Text = "192.168.2.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // SocketCommForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 475);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectInstructorButton);
            this.Controls.Add(this.connectPilotButton);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputText);
            this.Name = "SocketCommForm";
            this.Text = "SocketCommForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button connectPilotButton;
        private System.Windows.Forms.Button connectInstructorButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}