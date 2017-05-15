using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using SEMIK1;

namespace SEMIK1.Forms
{
    public partial class FDRForm : Form
    {
        public MainForm mainForm;
        NumberFormatInfo nfi = new NumberFormatInfo();
        private FDR fdr;

        public FDRForm(MainForm m)
        {
            mainForm = m;
            nfi.NumberDecimalSeparator = ".";
            InitializeComponent();
            fdrTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(ftrTree_NodeDoubleClick);
        }

        private void ftrTree_NodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e) 
        {
            string name = "";
            name = e.Node.Name;
            if (name != "")
            {
                FlightEvent fe = GetFlightEvent(name);
                if (fe != null)
                {
                    string caption = fe.GetUTCTimeString() + " / " + fe.id;
                    mainForm.ShowImage(fe.image, caption);
                }
            }
        }

        public FlightEvent GetFlightEvent(string id)
        {

            for (int i = 0; i < fdr.FlightEvents.Count; i++)
            {
                if (id == fdr.FlightEvents[i].id)
                {
                    return fdr.FlightEvents[i];
                }
            }
            return null;
        }

        public void ShowFDR(FDR f) 
        {
            fdr = f;
            try
            {
                for (int i = 0; i < fdr.FlightEvents.Count; i++) {
                    addTreeItem(fdr.FlightEvents[i]);
                }

                addInitItem("Pilot name", fdr.Pilot.name);
                addInitItem("Pilot rank", fdr.Pilot.rank);
                addInitItem("CSAV ID/callsign", fdr.Pilot.pid + " / " + fdr.Pilot.callsign);
                addInitItem("VATSIM / IVAO", fdr.Pilot.vatsim_id + " / " + fdr.Pilot.ivao_id);
                addInitItem("", "");
                addInitItem("Flight IATA", fdr.FlightInit.iata);
                addInitItem("Departure", fdr.FlightInit.departure);
                addInitItem("Arrival", fdr.FlightInit.arrival);
                addInitItem("Alternate", fdr.FlightInit.alternate);
                addInitItem("Flight Level", fdr.FlightInit.flight_level.ToString());
                addInitItem("Callsign", fdr.FlightInit.callsign);
                addInitItem("Aircraft", fdr.FlightInit.aircraft);
                addInitItem("Registration", fdr.FlightInit.registration);
                addInitItem("Route", fdr.FlightInit.route);
                addInitItem("PAX", fdr.FlightInit.pax.ToString());
                addInitItem("Application Build", fdr.FlightInit.build.ToString());
            }
            catch (Exception e) {
                Logger.Log(e.ToString());
            }

            CreateProfile();
            CreateSpeeds();
        }

        public void CreateProfile() {
            profileChart.ChartAreas.Add("Default");
            profileChart.ChartAreas["Default"].Position.Auto = true;
            //profileChart.ChartAreas["Default"].Position.X = 10;
            //profileChart.ChartAreas["Default"].Position.Y = 10;
            //profileChart.ChartAreas["Default"].Position.Width = 100;
            //profileChart.ChartAreas["Default"].Position.Height = 70;

            profileChart.ChartAreas["Default"].InnerPlotPosition.Auto = true;
            //profileChart.ChartAreas["Default"].InnerPlotPosition.X = 10;
            //profileChart.ChartAreas["Default"].InnerPlotPosition.Y = 10;
            //profileChart.ChartAreas["Default"].InnerPlotPosition.Width = 100;
            //profileChart.ChartAreas["Default"].InnerPlotPosition.Height = 70;
            
            profileChart.Series.Add("Flight Profile");
            profileChart.Series[0].ChartArea = "Default"; 
            profileChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            profileChart.Series.Add("Terrain");
            profileChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            profileChart.Series[1].ChartArea = "Default";
            
            profileChart.Series.Add("VerticalSpeed");
            profileChart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            profileChart.Series[2].ChartArea = "Default";
            
            long t_start = fdr.FlightEvents[0].time.Ticks;

            for (int i = 0; i < fdr.FlightEvents.Count; i++) {
                long t = (fdr.FlightEvents[i].time.Ticks - t_start) / 10000000;
                profileChart.Series[0].Points.AddXY(t, fdr.FlightEvents[i].altitude);
                profileChart.Series[1].Points.AddXY(t, fdr.FlightEvents[i].altitude - fdr.FlightEvents[i].groundElevation);
                profileChart.Series[2].Points.AddXY(t, fdr.FlightEvents[i].verticalSpeed);
            }
            profileChart.ChartAreas["Default"].AxisX.ScaleView.Zoom(0, 1000);
            profileChart.ChartAreas["Default"].CursorX.IsUserEnabled = true;
            profileChart.ChartAreas["Default"].CursorX.IsUserSelectionEnabled = true;
            profileChart.ChartAreas["Default"].AxisX.ScaleView.Zoomable = true;
            profileChart.ChartAreas["Default"].AxisX.ScrollBar.IsPositionedInside = true;
        }

        public void CreateSpeeds()
        {
            speedChart.ChartAreas.Add("Default");
            speedChart.ChartAreas["Default"].Position.Auto = true;

            speedChart.ChartAreas["Default"].InnerPlotPosition.Auto = true;

            speedChart.Series.Add("Ground Speed");
            speedChart.Series[0].ChartArea = "Default";
            speedChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            speedChart.Series.Add("Air Speed");
            speedChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            speedChart.Series[1].ChartArea = "Default";

            speedChart.Series.Add("Vertical Speed / 100");
            speedChart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            speedChart.Series[2].ChartArea = "Default";

            speedChart.Series.Add("Pitch x 10");
            speedChart.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            speedChart.Series[3].ChartArea = "Default";

            speedChart.Series.Add("Bank x 10");
            speedChart.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            speedChart.Series[4].ChartArea = "Default";

            long t_start = fdr.FlightEvents[0].time.Ticks;

            for (int i = 0; i < fdr.FlightEvents.Count; i++)
            {
                long t = (fdr.FlightEvents[i].time.Ticks - t_start) / 10000000;
                speedChart.Series[0].Points.AddXY(t, fdr.FlightEvents[i].groundSpeed);
                speedChart.Series[1].Points.AddXY(t, fdr.FlightEvents[i].airSpeed);
                speedChart.Series[2].Points.AddXY(t, fdr.FlightEvents[i].verticalSpeed / 100);
                speedChart.Series[3].Points.AddXY(t, fdr.FlightEvents[i].pitch * 10);
                speedChart.Series[4].Points.AddXY(t, fdr.FlightEvents[i].bank * 10);
            }
            speedChart.ChartAreas["Default"].AxisX.ScaleView.Zoom(0, 1000);
            speedChart.ChartAreas["Default"].CursorX.IsUserEnabled = true;
            speedChart.ChartAreas["Default"].CursorX.IsUserSelectionEnabled = true;
            speedChart.ChartAreas["Default"].AxisX.ScaleView.Zoomable = true;
            speedChart.ChartAreas["Default"].AxisX.ScrollBar.IsPositionedInside = true;
        }


        public void addInitItem(string variable, string value)
        {
            int n = fdrInitGrid.Rows.Add();
            this.fdrInitGrid.Rows[n].Cells[0].Value = variable;
            this.fdrInitGrid.Rows[n].Cells[1].Value = value;
        
        }

        public void addTreeItem(FlightEvent ev) 
        {

            TreeNode mainNode = fdrTree.Nodes.Add(ev.GetUTCTimeString() + " | " + ev.id);
            if (ev.type == 2)
            {
                mainNode.ForeColor = Color.OrangeRed;
            }
            else if (ev.type == 0){
                mainNode.ForeColor = Color.Gray;
            }
            mainNode.Nodes.Add("Position: " + ev.latitude.ToString() + " / " + ev.longitude.ToString());
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
            mainNode.Nodes.Add("Remarks " + ev.remarks);
            mainNode.Nodes.Add("Elevation: " + ev.groundElevation);
            if (ev.image != null) {
                TreeNode imageNode = mainNode.Nodes.Add("Image");
                imageNode.Name = ev.id;
                
            }
        }

    }
}
