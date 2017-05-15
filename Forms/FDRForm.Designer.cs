namespace SEMIK1.Forms
{
    partial class FDRForm
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.fdrInitTab = new System.Windows.Forms.TabPage();
            this.fdrInitGrid = new System.Windows.Forms.DataGridView();
            this.variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdrEventsTab = new System.Windows.Forms.TabPage();
            this.fdrTree = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.profileChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl.SuspendLayout();
            this.fdrInitTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fdrInitGrid)).BeginInit();
            this.fdrEventsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.fdrInitTab);
            this.tabControl.Controls.Add(this.fdrEventsTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(597, 426);
            this.tabControl.TabIndex = 1;
            // 
            // fdrInitTab
            // 
            this.fdrInitTab.Controls.Add(this.fdrInitGrid);
            this.fdrInitTab.Location = new System.Drawing.Point(4, 22);
            this.fdrInitTab.Name = "fdrInitTab";
            this.fdrInitTab.Size = new System.Drawing.Size(589, 400);
            this.fdrInitTab.TabIndex = 3;
            this.fdrInitTab.Text = "FDR Init";
            this.fdrInitTab.UseVisualStyleBackColor = true;
            // 
            // fdrInitGrid
            // 
            this.fdrInitGrid.AllowUserToAddRows = false;
            this.fdrInitGrid.AllowUserToDeleteRows = false;
            this.fdrInitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fdrInitGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variable,
            this.val});
            this.fdrInitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdrInitGrid.Location = new System.Drawing.Point(0, 0);
            this.fdrInitGrid.Name = "fdrInitGrid";
            this.fdrInitGrid.ReadOnly = true;
            this.fdrInitGrid.Size = new System.Drawing.Size(589, 400);
            this.fdrInitGrid.TabIndex = 0;
            // 
            // variable
            // 
            this.variable.FillWeight = 200F;
            this.variable.HeaderText = "Variable";
            this.variable.Name = "variable";
            this.variable.ReadOnly = true;
            this.variable.Width = 200;
            // 
            // val
            // 
            this.val.FillWeight = 320F;
            this.val.HeaderText = "Value";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            this.val.Width = 320;
            // 
            // fdrEventsTab
            // 
            this.fdrEventsTab.Controls.Add(this.fdrTree);
            this.fdrEventsTab.Location = new System.Drawing.Point(4, 22);
            this.fdrEventsTab.Name = "fdrEventsTab";
            this.fdrEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.fdrEventsTab.Size = new System.Drawing.Size(589, 400);
            this.fdrEventsTab.TabIndex = 2;
            this.fdrEventsTab.Text = "FDR Events";
            this.fdrEventsTab.UseVisualStyleBackColor = true;
            // 
            // fdrTree
            // 
            this.fdrTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdrTree.Location = new System.Drawing.Point(3, 3);
            this.fdrTree.Name = "fdrTree";
            this.fdrTree.Size = new System.Drawing.Size(583, 394);
            this.fdrTree.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.profileChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 400);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Profile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // profileChart
            // 
            this.profileChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.profileChart.Legends.Add(legend1);
            this.profileChart.Location = new System.Drawing.Point(3, 3);
            this.profileChart.Name = "profileChart";
            this.profileChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.profileChart.Size = new System.Drawing.Size(583, 394);
            this.profileChart.TabIndex = 0;
            this.profileChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.speedChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 400);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "Speeds";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // speedChart
            // 
            this.speedChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.speedChart.Legends.Add(legend2);
            this.speedChart.Location = new System.Drawing.Point(3, 3);
            this.speedChart.Name = "speedChart";
            this.speedChart.Size = new System.Drawing.Size(583, 394);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "chart1";
            // 
            // FDRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 426);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FDRForm";
            this.Text = "AcarsForm";
            this.tabControl.ResumeLayout(false);
            this.fdrInitTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fdrInitGrid)).EndInit();
            this.fdrEventsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profileChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage fdrEventsTab;
        private System.Windows.Forms.TreeView fdrTree;
        private System.Windows.Forms.TabPage fdrInitTab;
        private System.Windows.Forms.DataGridView fdrInitGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn val;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart profileChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;

    }
}