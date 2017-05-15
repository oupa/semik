using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace SEMIK1.Forms
{
    public partial class RoutesForm : Form
    {
        private MainForm mainForm;
        private WebClient downloadClient;
        private XmlNodeList loadedRoutes;
        private string[] pmdgRoutes;
        private string[] wilcoRoutes;
        private string[] atrRoutes;
        private string[] leveldRoutes;
        private string[] fsRoutes;
        XmlElement pmdg_node;
        XmlElement wilco_node;
        XmlElement atr_node;
        XmlElement leveld_node;
        XmlElement fs_node;
        ProgressForm progressForm;
        BackgroundWorker worker;
        int totalCount;
        int downloadedCount;
        string currentDownload;
        double pmdgLocalUpdate;
        double wilcoLocalUpdate;
        double atrLocalUpdate;
        double leveldLocalUpdate;
        double fsLocalUpdate;
        double pmdgRemoteUpdate;
        double wilcoRemoteUpdate;
        double atrRemoteUpdate;
        double leveldRemoteUpdate;
        double fsRemoteUpdate;
               
        public RoutesForm(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            downloadClient = new WebClient();
        }

        private void RoutesForm_Load(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            label2.Width = 400;
            label2.Text = "Here you can set up an automatic downloads and updates of Czech Airlines Virtual company routes.";

            pathPMDG.Text = (Properties.Settings.Default.path_pmdg == "") ? "Path is not set" : Properties.Settings.Default.path_pmdg;
            pathWilco.Text = (Properties.Settings.Default.path_wilco == "") ? "Path is not set" : Properties.Settings.Default.path_wilco;
            pathAtr.Text = (Properties.Settings.Default.path_atr == "") ? "Path is not set" : Properties.Settings.Default.path_atr;
            pathLeveld.Text = (Properties.Settings.Default.path_leveld == "") ? "Path is not set" : Properties.Settings.Default.path_leveld;
            pathFS.Text = (Properties.Settings.Default.path_fsplan == "") ? "Path is not set" : Properties.Settings.Default.path_fsplan;

            
            updateCheckboxes();
            LoadRouteList();
            ReadUpdateLogs();
            
        }

        private void Advise() {
            Color upToDate = System.Drawing.Color.LightGreen;
            Color outOfDate = System.Drawing.Color.LightSalmon;

            if (Properties.Settings.Default.path_pmdg != "") {
                panel1.BackColor = (pmdgRemoteUpdate > pmdgLocalUpdate) ? outOfDate : upToDate;
            }
            if (Properties.Settings.Default.path_wilco != "")
            {
                panel2.BackColor = (wilcoRemoteUpdate > wilcoLocalUpdate) ? outOfDate : upToDate;
            }
            if (Properties.Settings.Default.path_atr != "")
            {
                panel3.BackColor = (atrRemoteUpdate > atrLocalUpdate) ? outOfDate : upToDate;
            }
            if (Properties.Settings.Default.path_leveld != "")
            {
                panel4.BackColor = (leveldRemoteUpdate > leveldLocalUpdate) ? outOfDate : upToDate;
            }
            if (Properties.Settings.Default.path_fsplan != "")
            {
                panel5.BackColor = (fsRemoteUpdate > fsLocalUpdate) ? outOfDate : upToDate;
            }
        }

        private void ReadUpdateLogs() {
            if (Properties.Settings.Default.path_pmdg != "" )
            {
                string path = Properties.Settings.Default.path_pmdg + "/updatelog.txt";
                if (File.Exists(path))
                {
                    StreamReader a = new StreamReader(path);
                    string u = a.ReadLine();
                    a.Dispose();
                    pmdgLocalUpdate = System.Convert.ToDouble(u);
                }
                else {
                    pmdgLocalUpdate = 0;
                }
            }
            

            if (Properties.Settings.Default.path_wilco != "")
            {
                string path = Properties.Settings.Default.path_wilco + "/updatelog.txt";
                if (File.Exists(path))
                {
                    StreamReader a = new StreamReader(path);
                    string u = a.ReadToEnd();
                    a.Dispose();
                    wilcoLocalUpdate = System.Convert.ToDouble(u);
                }
                else
                {
                    wilcoLocalUpdate = 0;
                }
            }
            if (Properties.Settings.Default.path_atr != "")
            {
                string path = Properties.Settings.Default.path_atr + "/updatelog.txt";
                if (File.Exists(path))
                {
                    StreamReader a = new StreamReader(path);
                    string u = a.ReadToEnd();
                    a.Dispose();
                    atrLocalUpdate = System.Convert.ToDouble(u);
                }
                else
                {
                    atrLocalUpdate = 0;
                }
            }
            if (Properties.Settings.Default.path_leveld != "")
            {
                string path = Properties.Settings.Default.path_leveld + "/updatelog.txt";
                if (File.Exists(path))
                {
                    StreamReader a = new StreamReader(path);
                    string u = a.ReadToEnd();
                    a.Dispose();
                    leveldLocalUpdate = System.Convert.ToDouble(u);
                }
                else
                {
                    leveldLocalUpdate = 0;
                }
            }
            if (Properties.Settings.Default.path_fsplan != "")
            {
                string path = Properties.Settings.Default.path_fsplan + "/updatelog.txt";
                if (File.Exists(path))
                {
                    StreamReader a = new StreamReader(path);
                    string u = a.ReadToEnd();
                    a.Dispose();
                    fsLocalUpdate = System.Convert.ToDouble(u);
                }
                else
                {
                    fsLocalUpdate = 0;
                }
            }
            Advise();
        }

        private void updateCheckboxes() {
            updateAtrCheckbox.Enabled = (Properties.Settings.Default.path_atr != "");
            updatePMDGCheckbox.Enabled = (Properties.Settings.Default.path_pmdg != "");
            updateWilcoCheckbox.Enabled = (Properties.Settings.Default.path_wilco != "");
            updateLeveldCheckbox.Enabled = (Properties.Settings.Default.path_leveld != "");
            updateFSCheckbox.Enabled = (Properties.Settings.Default.path_fsplan != "");
        }

        private void LoadRouteList() {
            
            loadedRoutes = Connector.GetCompanyRoutes();
            if (loadedRoutes != null)
            {
                pmdg_node = GetRouteListById("pmdg");
                if (pmdg_node != null) {
                    pmdgRoutes = pmdg_node.InnerText.Split(',');
                    pmdgCountTxt.Text = pmdgRoutes.Count().ToString() + " routes on server";
                    pmdgRemoteUpdate = System.Convert.ToDouble(pmdg_node.GetAttribute("updated"));
                }
                wilco_node = GetRouteListById("wilco");
                if (wilco_node != null)
                {
                    wilcoRoutes = wilco_node.InnerText.Split(',');
                    label4.Text = wilcoRoutes.Count().ToString() + " routes on server";
                    wilcoRemoteUpdate = System.Convert.ToDouble(wilco_node.GetAttribute("updated"));
                }
                atr_node = GetRouteListById("atr");
                if (atr_node != null)
                {
                    atrRoutes = atr_node.InnerText.Split(',');
                    label6.Text = atrRoutes.Count().ToString() + " routes on server";
                    atrRemoteUpdate = System.Convert.ToDouble(atr_node.GetAttribute("updated"));
                }
                leveld_node = GetRouteListById("leveld");
                if (leveld_node != null)
                {
                    leveldRoutes = leveld_node.InnerText.Split(',');
                    label8.Text = leveldRoutes.Count().ToString() + " routes on server";
                    leveldRemoteUpdate = System.Convert.ToDouble(leveld_node.GetAttribute("updated"));
                }
                fs_node = GetRouteListById("fsplan");
                if (fs_node != null)
                {
                    fsRoutes = fs_node.InnerText.Split(',');
                    label8.Text = fsRoutes.Count().ToString() + " routes on server";
                    fsRemoteUpdate = System.Convert.ToDouble(fs_node.GetAttribute("updated"));
                }

                downloadButton.Enabled = true;
            }
            else {
                MessageBox.Show("Unable to load company routes, or no company routes are available.", "Ooops!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private XmlElement GetRouteListById(string id) {
            

            for (int i = 0; i < loadedRoutes.Count; i++) {
                XmlElement n = (XmlElement)loadedRoutes[i];
                if (n.GetAttribute("id") == id) {
                    return n;
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void browsePMDGButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK) {
                Properties.Settings.Default.path_pmdg = fbd.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                pathPMDG.Text = fbd.SelectedPath;
                ReadUpdateLogs();
            }
            fbd.Dispose();
            updateCheckboxes();
        }


        private void browseWilcoButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path_wilco = fbd.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                pathWilco.Text = fbd.SelectedPath;
                ReadUpdateLogs();
            }
            fbd.Dispose();
            updateCheckboxes();
        }

        private void browseAtrButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path_atr = fbd.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                pathAtr.Text = fbd.SelectedPath;
                ReadUpdateLogs();
            }
            fbd.Dispose();
            updateCheckboxes();
        }

        private void browseLeveldButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path_leveld = fbd.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                pathLeveld.Text = fbd.SelectedPath;
                ReadUpdateLogs();
            }
            fbd.Dispose();
            updateCheckboxes();
        }

        private void buildQueue() { 
        
        
        }

        private Boolean DownloadAndSaveFile(string url, string filename, string path) {
            try {
                downloadClient.DownloadFile(url + "/" + filename, path + "/" + filename);
                return true;
            } catch (WebException e){
                MessageBox.Show("Error downloading file " + filename + "(to path " + path + ")");
                Logger.Log(e.ToString());
                return false;
            }   
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            totalCount = 0;
            if (updatePMDGCheckbox.Enabled && updatePMDGCheckbox.Checked) totalCount += pmdgRoutes.Length;
            if (updateWilcoCheckbox.Enabled && updateWilcoCheckbox.Checked) totalCount += wilcoRoutes.Length;
            if (updateAtrCheckbox.Enabled && updateAtrCheckbox.Checked) totalCount += atrRoutes.Length;
            if (updateLeveldCheckbox.Enabled && updateLeveldCheckbox.Checked) totalCount += leveldRoutes.Length;
            if (updateFSCheckbox.Enabled && updateFSCheckbox.Checked) totalCount += fsRoutes.Length;

            if (totalCount > 0){
                progressForm = new ProgressForm();
                progressForm.Name = "Downloading routes...";
                progressForm.PresetProgress(totalCount);
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerAsync();
                progressForm.ShowDialog();
            } else {
                return;
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressForm.SetLabel(currentDownload);
            progressForm.ProgressStep();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressForm.Close();
            progressForm.Close();
            progressForm.Dispose();
            ReadUpdateLogs();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadedCount = 0;
            if (updatePMDGCheckbox.Enabled && updatePMDGCheckbox.Checked)
            {
                foreach (string filename in pmdgRoutes)
                {
                    currentDownload = "PMDG > " + filename;
                    if (DownloadAndSaveFile(pmdg_node.GetAttribute("dir"), filename, Properties.Settings.Default.path_pmdg))
                    {
                        downloadedCount++;
                        decimal p = 100 * downloadedCount / totalCount;
                        worker.ReportProgress((int)Math.Round(p));
                    }
                }
                Logger.LogUpdate("pmdg");
            }

            if (updateWilcoCheckbox.Enabled && updateWilcoCheckbox.Checked)
            {
                foreach (string filename in wilcoRoutes)
                {
                    currentDownload = "Wilco > " + filename;
                    if (DownloadAndSaveFile(wilco_node.GetAttribute("dir"), filename, Properties.Settings.Default.path_wilco))
                    {
                        downloadedCount++;
                        decimal p = 100 * downloadedCount / totalCount;
                        worker.ReportProgress((int)Math.Round(p));
                    }
                }
                Logger.LogUpdate("wilco");
            }

            if (updateAtrCheckbox.Enabled && updateAtrCheckbox.Checked)
            {
                foreach (string filename in atrRoutes)
                {
                    currentDownload = "ATR > " + filename;
                    if (DownloadAndSaveFile(atr_node.GetAttribute("dir"), filename, Properties.Settings.Default.path_atr))
                    {
                        downloadedCount++;
                        decimal p = 100 * downloadedCount / totalCount;
                        worker.ReportProgress((int)Math.Round(p));
                    }
                }
                Logger.LogUpdate("atr");
            }

            if (updateLeveldCheckbox.Enabled && updateLeveldCheckbox.Checked)
            {
                foreach (string filename in leveldRoutes)
                {
                    currentDownload = "LevelD > " + filename;
                    if (DownloadAndSaveFile(leveld_node.GetAttribute("dir"), filename, Properties.Settings.Default.path_leveld))
                    {
                        downloadedCount++;
                        decimal p = 100 * downloadedCount / totalCount;
                        worker.ReportProgress((int)Math.Round(p));
                    }
                }
                Logger.LogUpdate("leveld");
            }
            if (updateFSCheckbox.Enabled && updateFSCheckbox.Checked)
            {
                foreach (string filename in fsRoutes)
                {
                    currentDownload = "FS > " + filename;
                    if (DownloadAndSaveFile(fs_node.GetAttribute("dir"), filename, Properties.Settings.Default.path_fsplan))
                    {
                        downloadedCount++;
                        decimal p = 100 * downloadedCount / totalCount;
                        worker.ReportProgress((int)Math.Round(p));
                    }
                }
                Logger.LogUpdate("fsplan");
            } 
        }

        private void browseFSButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.path_fsplan = fbd.SelectedPath.ToString();
                Properties.Settings.Default.Save();
                pathFS.Text = fbd.SelectedPath;
                ReadUpdateLogs();
            }
            fbd.Dispose();
            updateCheckboxes();
        }

    }
}
