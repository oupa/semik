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
    public partial class PaxManifestForm : Form
    {
        List<string> pax;

        public PaxManifestForm(List<string> paxList)
        {
            InitializeComponent();
            pax = paxList;
            fillPax();
        }

        private void fillPax()
        { 
            int count = 1;
            for(int i=0; i < pax.Count; i++)
            {
                int n = manifestGrid.Rows.Add();
                this.manifestGrid.Rows[n].Cells[0].Value = count;
                this.manifestGrid.Rows[n].Cells[1].Value = pax[i];
                count++;
            }
        }
    }
}
