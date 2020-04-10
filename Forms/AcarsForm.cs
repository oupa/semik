using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using SEMIK1;

namespace SEMIK1.Forms
{
    public partial class AcarsForm : Form
    {
        public MainForm mainForm;
        NumberFormatInfo nfi = new NumberFormatInfo();
       
        public AcarsForm(MainForm m)
        {
            mainForm = m;
            nfi.NumberDecimalSeparator = ".";
            InitializeComponent();
            
        }

        public void CreateTracking() 
        {
            this.eventsGrid.Rows.Clear();
            this.messagesGrid.Rows.Clear();
            this.acarsTree.Nodes.Clear();
            FlightInit fi = mainForm.fplForm.InitFlight();
            FlightTracking.Create(fi, mainForm.fsData, this, mainForm.pilot);
            FlightTracking.Start();
            disableButtons();
        }

        public void updateStatus(string message)
        {
            //statusTxt.Text = "Current flight mode: " + message;
        }

        public void addEvent(FlightEvent ev)
        {
            int n = eventsGrid.Rows.Add();
            this.eventsGrid.Rows[n].Cells[0].Value = ev.GetUTCTimeString();
            this.eventsGrid.Rows[n].Cells[1].Value = ev.id;
            this.eventsGrid.Rows[n].Cells[2].Value = Math.Round(ev.altitude);
            this.eventsGrid.Rows[n].Cells[3].Value = Math.Round(ev.groundSpeed);
            this.eventsGrid.Rows[n].Cells[4].Value = Math.Round(ev.fuel);
            this.eventsGrid.Rows[n].Cells[5].Value = Math.Round(ev.distance);
            this.eventsGrid.Rows[n].Cells[6].Value = ev.remarks;

            addTreeItem(ev);
        }

        public void addTreeItem(FlightEvent ev) 
        {

            TreeNode mainNode = acarsTTree.Nodes.Add(ev.GetUTCTimeString() + " | " + ev.id);
            if (ev.type == 2)
            {
                mainNode.ForeColor = Color.OrangeRed;
            }
            else if (ev.type == 0)
            {
                mainNode.ForeColor = Color.Gray;
            }
            mainNode.Nodes.Add("Position: " + ev.latitude.ToString("####.#####", nfi) + " / " + ev.longitude.ToString("####.#####",nfi));
            mainNode.Nodes.Add("Altitude: " + Math.Round(ev.altitude));
            mainNode.Nodes.Add("Airpeed: " + Math.Round(ev.airSpeed) + " / GS: " + Math.Round(ev.groundSpeed));
            mainNode.Nodes.Add("VS: " + Math.Round(ev.verticalSpeed));
            mainNode.Nodes.Add("Heading: " + Math.Round(ev.heading));
            mainNode.Nodes.Add("Com1: " + ev.com1 + " / Transponder: " + ev.transponder);
            mainNode.Nodes.Add("Wind: " + Math.Round(ev.windDirection) + "° at " + Math.Round(ev.windSpeed) + " kt");
            mainNode.Nodes.Add("Pressure: " + Math.Round(ev.pressure) + " / altimeter set:  " + ev.altimeterSetting);
            mainNode.Nodes.Add("Fuel: " + Math.Round(ev.fuel) + " / Gross weight: " + Math.Round(ev.grossWeight));
            mainNode.Nodes.Add("Pitch: " + Math.Round(ev.pitch) + " / Bank: " + Math.Round(ev.bank));
            mainNode.Nodes.Add("Distance flown: " + Math.Round(ev.distance));
            mainNode.Nodes.Add("Flaps " + ev.flaps);
            mainNode.Nodes.Add("Gear " + ev.gear);
        }

        public void addMessage(string time, string text)
        {
            int n = messagesGrid.Rows.Add();
            this.messagesGrid.Rows[n].Cells[0].Value = time;
            this.messagesGrid.Rows[n].Cells[1].Value = text;
        }

        public void finishTracking(XmlNodeList messages, string pirepId)
        {
            mainForm.finishAcars();
            PostFlightForm pff = new PostFlightForm(messages, pirepId, mainForm);
            pff.ShowDialog();
        }

        public void enableButtons() {
            btnModeDeparture.Enabled = true;
            btnModeClimb.Enabled = true;
            btnModeCruise.Enabled = true;
            btnModeDescent.Enabled = true;
            btnModeApproach.Enabled = true;
            btnModeLanding.Enabled = true;
            btnCancel.Enabled = true;
        }

        public void disableButtons()
        {
            btnModeDeparture.Enabled = false;
            btnModeClimb.Enabled = false;
            btnModeCruise.Enabled = false;
            btnModeDescent.Enabled = false;
            btnModeApproach.Enabled = false;
            btnModeLanding.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // departure
            Logger.Log("Manual mode change - Departure");
            FlightTracking.changeFlightMode(2, true);
        }

        private void btnModeClimb_Click(object sender, EventArgs e)
        {
            if (FlightTracking.fsData.onGround) return;
            Logger.Log("Manual mode change - Climb");
            FlightTracking.changeFlightMode(3, true);
        }

        private void btnModeCruise_Click(object sender, EventArgs e)
        {
            if (FlightTracking.fsData.onGround) return;
            Logger.Log("Manual mode change - Cruise");
            FlightTracking.changeFlightMode(4, true);
        }

        private void btnModeApproach_Click(object sender, EventArgs e)
        {
            if (FlightTracking.fsData.onGround) return;
            Logger.Log("Manual mode change - Approach");
            FlightTracking.changeFlightMode(6, true);
        }

        private void btnModeDescent_Click(object sender, EventArgs e)
        {
            if (FlightTracking.fsData.onGround) return;
            Logger.Log("Manual mode change - Descent");
            FlightTracking.changeFlightMode(5, true);
        }

        private void btnModeLanding_Click(object sender, EventArgs e)
        {
            if (FlightTracking.fsData.onGround) return;
            Logger.Log("Manual mode change - Landing");
            FlightTracking.changeFlightMode(7, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // cancel
            Logger.Log("Manual tracking cancelation");
            DialogResult res = MessageBox.Show("Do you really wish to cancel current flight?", "Really cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {
                FlightTracking.FinishTracking(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FSUIPCProvider.Reconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlightTracking.endFlight();
        }
    }
}
