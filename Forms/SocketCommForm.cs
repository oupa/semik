using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows.Forms;
using System.Threading;

namespace SEMIK1.Forms
{
    public partial class SocketCommForm : Form
    {
        MainForm mainForm;
        private string _szData;
        byte[] m_DataBuffer = new byte[1024];
        IAsyncResult m_asynResult;
        public AsyncCallback pfnCallBack;
        public Socket m_socClient;
        public delegate void DataReceived(string data);
        public event DataReceived ReceivedData;
        delegate void SetTextCallback(string text);
        public Boolean connecting;
        public Boolean disconnecting;
        public Boolean connected;
        public Boolean updating;
        private List<RemotePilot> pilots;

        public string szData
        {
            get { return _szData; }
            set
            {
                if (_szData != value)
                {
                    _szData = value;
                    OnData(_szData);
                }
            }
        }

        protected void OnData(string data)
        {
            if (ReceivedData != null)
            {
                ReceivedData(data);
            }
        }

        public void OnConnect(Boolean ins)
        {
            m_socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(ipText.Text);
            int iPortNo = System.Convert.ToInt32(portText.Text);
            IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);

            try
            {
                m_socClient.Connect(ipEnd);
                if (m_socClient.Connected)
                {
                    connecting = true;
                    WaitForData(true);
                    if (ins)
                    {
                        SendMessage("connectInstructor", "connectInstructor");
                    }
                    else
                    {
                        SendMessage("connectPilot", "connectPilot");
                    }
                }
            }
            catch (SocketException e) 
            {
                MessageBox.Show("Could not connect to the server.");
                Logger.Log(e.ToString());
            }
        }
        public void WaitForData(Boolean connecting)
        {
            if (pfnCallBack == null)
                pfnCallBack = new AsyncCallback(OnDataReceived);

            m_asynResult = m_socClient.BeginReceive(m_DataBuffer, 0, m_DataBuffer.Length, SocketFlags.None, pfnCallBack, null);
        }
        public void OnDataReceived(IAsyncResult asyn)
        {
            
            //end receive...
            try
            {
                int iRx = 0;
                iRx = m_socClient.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(m_DataBuffer, 0, iRx, chars, 0);
                szData = new System.String(chars);
                Logger.Log(szData);
                if (connecting)
                {
                    if (szData.Contains("ok"))
                    {
                        connecting = false;
                        connected = true;
                    }
                    else
                    {
                        Logger.Log(szData);
                        MessageBox.Show("Connection refused");
                        return;
                    }
                }
                if (updating) {
                    if (szData.Contains("pilot-list"))
                    {
                        updating = false;
                        updatePilotList(szData);
                    }
                }
                if (disconnecting)
                {
                    if (szData.Contains("ok"))
                    {
                        disconnecting = false;
                        connected = false;
                        Logger.Log("disconnecting...");
                        m_socClient.Close();
                    }
                }
                else {
                    WaitForData(false);
                }
                updateText();
            }
            catch (SocketException e) {
                MessageBox.Show("Connection to the server was lost.");
                Logger.Log(e.ToString());
                connected = false;
                connecting = false;
            }
        }

        public void updatePilotList(string result)
        {
            MessageBox.Show(result);
        }

        public void updateText() 
        {
            
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (this.outputText.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { szData });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                this.outputText.Text = szData;
            }
        }

        public void SetText(string msg) {
            this.outputText.Text = msg;
            if (connected)
            {
                ConnectedState();
            }
            else {
                DisconnectedState();
            }
        }

        public void ConnectedState() {
            connectInstructorButton.Enabled = false;
            connectPilotButton.Enabled = false;
            disconnectButton.Enabled = true;
            sendButton.Enabled = true;
        }

        public void DisconnectedState() {
            if (mainForm.pilot.rank == "INSTRUCTOR")
            {
                connectInstructorButton.Enabled = true;
            }
            else
            {
                connectInstructorButton.Enabled = false;
            }
            connectPilotButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
        }
        public SocketCommForm(MainForm main)
        {
            mainForm = main;
            InitializeComponent();
            if (mainForm.pilot.rank == "INSTRUCTOR")
            {
                connectInstructorButton.Enabled = true;
            }
            else {
                connectInstructorButton.Enabled = false;
            }
            sendButton.Enabled = false;
            disconnectButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputText.Text.Length == 0) return;
            SendMessage("chat",inputText.Text);
            inputText.Text = "";
        }

        private void SendMessage(string code, string msg)
        {
            byte[] outStream = message(code,msg);
            m_socClient.Send(outStream);
        }

        private byte[] message(string code, string msg) {
            //return System.Text.Encoding.ASCII.GetBytes(mainForm.pilot.pid + ";" + mainForm.pilot.auth_code + ";" + code + ";" + msg);
            return System.Text.Encoding.ASCII.GetBytes(msg);
        }

        private void msg() {
            outputText.Text += "\n" + szData;
        }

        private void pilotConnectButtonpilotConnectButton_Click(object sender, EventArgs e)
        {
            OnConnect(false);
        }

        private void connectInstructorButton_Click(object sender, EventArgs e)
        {
            OnConnect(true);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (mainForm.pilot.rank == "INSTRUCTOR")
            {
                connectInstructorButton.Enabled = true;
            }
            connectPilotButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
            disconnecting = true;
            SendMessage("disconnect", "");
            
            //m_socClient.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updating = true;
            SendMessage("getPilotList", "");
        }
    }
}
