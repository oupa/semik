using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace SEMIK1.Forms
{
    public partial class PostFlightForm : Form
    {
        private XmlNodeList messages;
        private string pirepId;
        private MainForm mainForm;

        public PostFlightForm(XmlNodeList _messages, string _pirepId, MainForm _main)
        {
            InitializeComponent();
            messages = _messages;
            pirepId = _pirepId;
            mainForm = _main;
            this.tabControl.TabPages.Remove(this.tabDivert);
            ShowResult();
        }

        private void ShowResult()
        {
            for (int i = 0; i < messages.Count; i++) {
                XmlElement message = (XmlElement)messages[i];
                if (message.GetAttribute("code") == "101"){
                    ShowDivert();
                } else {
                    AddResultMessage(message.GetAttribute("text"));
                }
            }
        }

        private void ShowDivert()
        {
            this.tabControl.TabPages.Add(this.tabDivert);
            this.tabControl.SelectedTab = this.tabDivert;
            string message = "It appears you have not landed on destination airport " + FlightTracking.flightInit.arrival + ".\n";
            message += "You can create a divert report here to complete the divert. The report will be sent to the airline staff to approve. Once approved, the flight be logged as diverted, allowing you to continue from the airport, to which you have diverted.";
            this.divertMessageTxt.Text = message;
            FlightEvent blockOn = FlightTracking.GetFlightEvent("BlockOn");
            XmlNodeList airports = Connector.GetNearestAirport(blockOn.latitude, blockOn.longitude);
            string errorMessage = "It appears you didn`t land on an airport at all. You can still submit a report, but in the text be more specific about what had happened during your flight.";
            if (airports == null){
                MessageBox.Show(errorMessage);
            } else {
                if (airports.Count > 0)
                {
                    this.divertAirportCombo.Items.Clear();
                    for (int i = 0; i < airports.Count; i++)
                    {
                        XmlElement airport = (XmlElement)airports[i];
                        this.divertAirportCombo.Items.Add(airport.GetAttribute("icao"));
                    }
                    this.divertAirportCombo.SelectedItem = this.divertAirportCombo.Items[0];
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void SendDivertReport() {
            string icao = divertAirportCombo.Text;
            if (icao == "") {
                MessageBox.Show("You must enter ICAO of the airport you diverted to");
                return;
            }
            string comment = this.reasonTxt.Text;
            if (comment == "") {
                MessageBox.Show("You must enter the reason for divert");
                return;
            }

            FlightEvent blockOn = FlightTracking.GetFlightEvent("BlockOn");
            TimeSpan duration = AcarsBuilder.duration;
            string durationString = duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00") + ":" + duration.Seconds.ToString("00");
            bool sendDivertResult = Connector.SendDivertReport(icao, comment, pirepId, blockOn.latitude, blockOn.longitude, durationString);
            if (sendDivertResult)
            {
                MessageBox.Show("Divert report has been sent. It is safe to close Šemík now.");
                this.Close();
            }
            else {
                MessageBox.Show("Divert report has not been sent. You can try again or see log for details of the error. Contact support if the problem continues.");
            }
        }

        private void AddResultMessage(string text)
        {
            int n = this.resultMessagesGrid.Rows.Add();
            this.resultMessagesGrid.Rows[n].Cells[0].Value = text;
        }

        private void closeResult_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendDivertButton_Click(object sender, EventArgs e)
        {
            SendDivertReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);
        }
    }
}
