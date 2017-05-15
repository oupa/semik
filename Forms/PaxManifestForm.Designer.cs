namespace SEMIK1.Forms
{
    partial class PaxManifestForm
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
            this.manifestGrid = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.manifestGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // manifestGrid
            // 
            this.manifestGrid.AllowUserToAddRows = false;
            this.manifestGrid.AllowUserToDeleteRows = false;
            this.manifestGrid.AllowUserToResizeColumns = false;
            this.manifestGrid.AllowUserToResizeRows = false;
            this.manifestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.manifestGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.name});
            this.manifestGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manifestGrid.Location = new System.Drawing.Point(0, 0);
            this.manifestGrid.Name = "manifestGrid";
            this.manifestGrid.ReadOnly = true;
            this.manifestGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.manifestGrid.Size = new System.Drawing.Size(388, 268);
            this.manifestGrid.TabIndex = 0;
            // 
            // number
            // 
            this.number.Frozen = true;
            this.number.HeaderText = "No.";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 45;
            // 
            // name
            // 
            this.name.FillWeight = 300F;
            this.name.Frozen = true;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 300;
            // 
            // PaxManifestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 268);
            this.Controls.Add(this.manifestGrid);
            this.Name = "PaxManifestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Passenger Manifest";
            ((System.ComponentModel.ISupportInitialize)(this.manifestGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView manifestGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}