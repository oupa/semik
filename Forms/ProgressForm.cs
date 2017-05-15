using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEMIK1.Forms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {

        }

        public void SetLabel(string text)
        {
            label.Text = text;
        }

        public void PresetProgress(int max)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = max;
            progressBar.Step = 1;
        }

        public void SetProgressPercent(int percent)
        {
            progressBar.Value = percent;
        }

        public void ProgressStep() {
            progressBar.PerformStep();
        }
    }
}
