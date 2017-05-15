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
    public partial class ImageForm : Form
    {
        MainForm mainForm;

        public ImageForm(MainForm m)
        {
            InitializeComponent();
            mainForm = m;
        }

        public void ShowImage(Image i) 
        {
            this.pictureBox.Image = i;
            this.Show();
        }

        private void ImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.imageForm = null;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Right") {
                Point p = new Point();
                p.X = e.X + this.Location.X;
                p.Y = e.Y + this.Location.Y;
                //this.contextMenu.Show(p);
            }
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

    }
}
