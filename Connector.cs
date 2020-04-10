using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections;
using SEMIK1.Forms;

namespace SEMIK1
{
    public class Connector
    {
        public static MainForm mainForm;

        public static XmlNodeList GetNearestAirport(double latitude, double longitude)
        {
            string args = "lat=" + latitude;
            args += "&lon=" + longitude;
            string uri = Properties.Settings.Default.weburl + "/XML/GetNearestAirport.php";
            try
            {
                string response = SemikRequest(args, uri, "GetNearestAirport", true);
                return ParseNearestAirport(response);
            }
            catch (Exception e)
            {
                Logger.Log("GetAlternates: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlNodeList ParseNearestAirport(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Reading nearest airports");
                return (xml.GetElementsByTagName("airport"));
            }
            else
            {
                Logger.Log("Reading nearest failed - " + message);
                return null;
            }
        }

        public static XmlNodeList GetAlternates(string icao)
        {
            string args = "icao=" + icao;
            string uri = Properties.Settings.Default.weburl + "/XML/GetAlternates.php";
            try
            {
                string response = SemikRequest(args, uri, "GetAlternates", true);
                return ParseAlternates(response);
            }
            catch (Exception e)
            {
                Logger.Log("GetAlternates: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlNodeList ParseAlternates(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Reading alternates");
                return(xml.GetElementsByTagName("alternate"));
            }
            else
            {
                Logger.Log("Reading alternates failed - " + message);
                return null;
            }
        }

        public static XmlElement GetPax(string iata, int limit)
        {
            string args = "iata=" + iata;
            args += "&limit=" + limit;
            string uri = Properties.Settings.Default.weburl + "/XML/GetPax.php";
            try
            {
                string response = SemikRequest(args, uri, "GetPax", true);
                return ParsePax(response);
            }
            catch (Exception e)
            {
                Logger.Log("GetPax: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParsePax(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Reading pax");
                return node;
            }
            else
            {
                Logger.Log("Reading pax failed - " + message);
                mainForm.setProgress(false);
                MessageBox.Show(message, "Reading pax error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static XmlElement GetBriefing(string pid, string auth_code)
        {
            string args = "";
            args += "pid=" + pid;
            args += "&auth=" + auth_code;
            string uri = Properties.Settings.Default.weburl + "/XML/GetBriefing.php";
            try
            {
                string response = SemikRequest(args, uri, "GetBriefing", true);
                return ParseBriefing(response);
            }
            catch (Exception e)
            {
                Logger.Log("GetBriefing: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParseBriefing(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                return node;
            }
            else
            {
                Logger.Log("Briefing call failed");
                mainForm.setProgress(false);
                return null;
            }
        }

        public static XmlDocument GetLogin(string pid, string auth_code, string username, string password)
        {
            string args = "";
            if (pid.Length == 0 || auth_code.Length == 0)
            {
                args += "usr=" + encode_p(username);
                args += "&pwd=" + encode_p(password);
                //Logger.Log(args);
                args += "&auth_method=full_login";
            }
            else
            {
                args += "pid=" + pid;
                args += "&auth=" + auth_code;
                args += "&auth_method=pre_authentified";
            }
            string uri = Properties.Settings.Default.weburl + "/XML/SemikLogin.php";
            try
            {
                string response = SemikRequest(args, uri, "GetLogin", true);
                return ParseLogin(response);
            }
            catch (Exception e)
            {
                Logger.Log("GetLogin: Exception : " + e.ToString());
                return null;
            }
        }

        private static String encode_p(String p)
        {
            String encoded = p;
            try
            {
                encoded = System.Net.WebUtility.UrlEncode(p);
            }
            catch (Exception) {}
            return encoded;
        }

        public static XmlDocument ParseLogin(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                return xml;
            }
            else {
                Logger.Log("Login failed");
                mainForm.setProgress(false);
                Properties.Settings.Default.remember = false;
                MessageBox.Show(message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static XmlNodeList GetIata(string departure, string arrival)
        { 
            string args = "departure=" + departure + "&arrival=" + arrival + "&pid=" + mainForm.pilot.pid;
            string uri = Properties.Settings.Default.weburl + "/XML/GetIata.php";
            try
            {
                string response = SemikRequest(args, uri, "GetIata", true);
                return (parseIata(response));
            }
            catch (Exception e)
            {
                Logger.Log("GetIata: Exception : " + e.ToString());
                return null;
            }
            
        }

        public static XmlNodeList parseIata(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Reading iata");
                return (xml.GetElementsByTagName("flight"));
            }
            else
            {
                Logger.Log("Reading iata failed - " + message);
                mainForm.setProgress(false);
                return null;
            }
        }

        public static XmlElement CheckDepartureAirport(string icao, string lat, string lon, string alt)
        { 
            string args = "";
            args += "icao=" + icao;
            args += "&lat=" + lat;
            args += "&lon=" + lon;
            args += "&alt=" + alt;
            string uri = Properties.Settings.Default.weburl + "/XML/IsAtAirport.php";
            try
            {
                string response = SemikRequest(args, uri, "CheckDepartureAirport", true);
                return (ParseCheckDepartureAirport(response));
            }
            catch (Exception e)
            {
                Logger.Log("CheckDepartureAirport: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParseCheckDepartureAirport(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Is at airport checked OK");
                return node;
            }
            else
            {
                Logger.Log("Is at airport checked NOT OK : " + message);
                return null;
            }
        }

        public static XmlNodeList GetCompanyRoutes()
        {
            string args = "";
            string uri = Properties.Settings.Default.weburl + "/XML/GetCompanyRoutes.php";
            try
            {
                string response = SemikRequest(args, uri, "GetCompanyRoutes", true);
                return (ParseGetCompanyRoutes(response));
            }
            catch (Exception e)
            {
                Logger.Log("GetCompanyRoutes: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlNodeList ParseGetCompanyRoutes(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            XmlNodeList addonsList = (XmlNodeList)xml.GetElementsByTagName("addon");
            string message = node.GetAttribute("message");
            if (message == "OK" && addonsList != null)
            {
                Logger.Log("GetCompanyRoutes OK");
                return addonsList;
            }
            else
            {
                Logger.Log("GetCompanyRoutes NOT OK : " + message);
                return null;
            }
        }

        public static XmlElement GetAirport(string icao) {
            string args = "icao=" + icao;
            string uri = Properties.Settings.Default.weburl + "/XML/GetAirport.php";
            try
            {
                string response = SemikRequest(args, uri, "GetAirport", true);
                return (ParseGetAirport(response));
            }
            catch (Exception e)
            {
                Logger.Log("GetAirport: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParseGetAirport(string response) 
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            XmlElement airportNode = (XmlElement)xml.GetElementsByTagName("airport")[0];
            string message = node.GetAttribute("message");
            if (message == "OK" && airportNode != null)
            {
                Logger.Log("GetAirport OK");
                return airportNode;
            }
            else
            {
                Logger.Log("GetAirport NOT OK : " + message);
                return null;
            }
        }

        public static XmlDocument GetOnlinePilot(string network)
        {
            string args = "";
            if (network == "vatsim")
            {
                args += "vatsim_id=" + mainForm.pilot.vatsim_id;
            }
            else {
                args += "ivao_id=" + mainForm.pilot.ivao_id;
            }
            string uri = Properties.Settings.Default.weburl + "/XML/GetOnlinePilot.php";
            try
            {
                string response = SemikRequest(args, uri, "GetOnlinePilot", true);
                return (ParseGetOnlinePilot(response));
            }
            catch (Exception e)
            {
                Logger.Log("GetOnlinePilot: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlDocument ParseGetOnlinePilot(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Reading pilot (v:" + mainForm.pilot.vatsim_id + "/i:" + mainForm.pilot.ivao_id + ") from network " + message);
                return xml;
            }
            else
            {
                Logger.Log("Reading pilot (v:" + mainForm.pilot.vatsim_id + "/i:" + mainForm.pilot.ivao_id + ") from network failed - " + message);
                //enableForm();
                mainForm.setProgress(false);
                MessageBox.Show(message, "Pilot network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public static void SendPirepTemp(string args)
        {
            string uri = Properties.Settings.Default.weburl + "/XML/ReceivePirepTemp.php";
            try
            {
                string response = SemikRequest(args, uri, "SendPirepTemp", false);
                //return (ParseSendPirepTemp(response));
            }
            catch (Exception e)
            {
                Logger.Log("SendPirepTemp: Exception : " + e.ToString());
                //return null;
            }
        }

        public static void ParseSendPirepTemp(string response)
        {
           //Logger.Log("Temp pirep response:" + response);
        }

        public static XmlElement SendPirep(string args)
        {
            string uri = Properties.Settings.Default.weburl + "/XML/ReceivePirep.php";
            try
            {
                string response = SemikRequest(args, uri, "SendPirep", false);
                return (ParseSendPirep(response));
            }
            catch (Exception e)
            {
                Logger.Log("SendPirep: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParseSendPirep(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("SendPirep response - OK");
                return node;
            }
            else
            {
                MessageBox.Show(response, "SendPirep error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log("SendPirep response - Error");
                Logger.Log(response);
                mainForm.setProgress(false);
                return null;
            }
        }

        public static XmlElement PositionUpdate(double lat, double lon, double alt, double gs, double ias, double heading, string dep_icao, string arr_icao, string iata, string callsign, string route, string aircraft, int pax, int phase, double elevation, string tracking_id)
        {
            string args = "";
            args += "pid=" + mainForm.pilot.pid;
            args += "&auth=" + mainForm.pilot.auth_code;
            args += "&latitude=" + lat;
            args += "&longitude=" + lon;
            args += "&groundspeed=" + gs;
            args += "&airspeed=" + ias;
            args += "&altitude=" + alt;
            args += "&heading=" + heading;
            args += "&dep_icao=" + dep_icao;
            args += "&arr_icao=" + arr_icao;
            args += "&iata=" + iata;
            args += "&callsign=" + callsign;
            args += "&route=" + route;
            args += "&aircraft=" + aircraft;
            args += "&pax=" + pax;
            args += "&phase=" + phase;
            args += "&elevation=" + elevation;
            if (tracking_id != "")
            {
                args += "&tracking_id=" + tracking_id;
            }

            string uri = Properties.Settings.Default.weburl + "/XML/PositionUpdate.php";
            try
            {
                string response = SemikRequest(args, uri, "PositionUpdate", false);
                return (ParsePositionUpdate(response));
            }
            catch (Exception e)
            {
                Logger.Log("PositionUpdate: Exception : " + e.ToString());
                return null;
            }
        }

        public static XmlElement ParsePositionUpdate(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Position update response - OK");
                return node;
            }
            else
            {
                Logger.Log("Position update response - Error");
                Logger.Log(response);
                mainForm.setProgress(false);
                return null;
            }
        }

        public static string CheckVersion()
        {
            string args = "";
            string uri = Properties.Settings.Default.weburl + "/XML/CheckVersion.php";
            try
            {
                string response = SemikRequest(args, uri, "CheckVersion", true);
                return (ParseCheckVersion(response));
            }
            catch (Exception e)
            {
                Logger.Log("CheckVersion: Exception : " + e.ToString());
                return null;
            }
        }

        public static string ParseCheckVersion(string response)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("Check Version response - OK");
                return node.GetAttribute("version");
            }
            else
            {
                Logger.Log("Check Version response - Error");
                Logger.Log(response);
                mainForm.setProgress(false);
                return null;
            }    
        }

        public static bool SendDivertReport(string icao, string reason, string pirepId, double latitude, double longitude, string duration) {
            string args = "icao=" + icao;
            args += "&pirep_id=" + pirepId;
            args += "&reason=" + reason;
            args += "&pid=" + mainForm.pilot.pid;
            args += "&auth=" + mainForm.pilot.auth_code;
            args += "&lat=" + latitude.ToString();
            args += "&lon=" + longitude.ToString();
            args += "&duration=" + duration;

            string uri = Properties.Settings.Default.weburl + "/XML/ReportDivert.php";
            try
            {
                string response = SemikRequest(args, uri, "SendDivertReport", true);
                return (ParseSendDivertReport(response));
            }
            catch (Exception e)
            {
                Logger.Log("SendDivertReport: Exception : " + e.ToString());
                return false;
            }
        }

        public static bool ParseSendDivertReport(string response) {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string code = node.GetAttribute("code");
            if (code == "0")
            {
                Logger.Log("SendDiverReport response - OK");
                return true;
            }
            else
            {
                Logger.Log("SendDiverReport response - Error");
                Logger.Log(response);
                mainForm.setProgress(false);
                return false;
            }
        }

        public static bool UploadTV(string tracking_id, string filename, string csv) {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers.Add("Content-Type", "binary/octet-stream");
                string query = "?pid=" + mainForm.pilot.pid;
                query += "&auth=" + mainForm.pilot.auth_code;
                query += "&tracking_id=" + tracking_id;
                query += "&filename=" + filename;
                query += "&csv=" + csv;
                bool response = ParseUploadTV(client.UploadFile(Properties.Settings.Default.weburl + "/XML/UploadTV.php" + query, "POST", filename));
                return response;
            }
            catch (Exception e) {
                Logger.Log("UploadTV false " + e.ToString());
                return false;
            }
        }

        public static bool ParseUploadTV(byte[] response)
        {
            string s = System.Text.Encoding.UTF8.GetString(response, 0, response.Length);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(s);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                return true;
                
            }
            else
            {
                Logger.Log("UploadTV response - Error");
                Logger.Log(s);
                mainForm.setProgress(false);
                return false;
            }
        }

        public static bool UploadFDR(string pirep_id, string filename) {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers.Add("Content-Type", "binary/octet-stream");
                string query = "?pid=" + mainForm.pilot.pid;
                query += "&auth=" + mainForm.pilot.auth_code;
                query += "&pirep_id=" + pirep_id;
                query += "&filename=" + filename;
                bool response = ParseUploadFDR(client.UploadFile(Properties.Settings.Default.weburl + "/XML/UploadFDR.php" + query, "POST", filename));
                return response;
            }
            catch (Exception e) {
                Logger.Log("Upload FDR false " + e.ToString());
                return false;
            }
        }

        public static bool ParseUploadFDR(byte[] response) {
            string s = System.Text.Encoding.UTF8.GetString(response, 0, response.Length);
            Logger.Log("UploadResponse: " + s);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(s);
            XmlElement node = (XmlElement)xml.GetElementsByTagName("semik")[0];
            string message = node.GetAttribute("message");
            if (message == "OK")
            {
                Logger.Log("UploadFDR response - OK");
                return true;
            }
            else
            {
                Logger.Log("UploadFDR response - Error");
                Logger.Log(s);
                mainForm.setProgress(false);
                return false;
            } 
        }
             
        public static string SemikRequest(string post, string uri, string action, bool verbose)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                StreamReader reader;
                Stream dataStream;
                WebResponse response;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "CSAV/Semik";
                request.Method = "POST";
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = post;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                Logger.Log("SemikRequest : action : " + action);
                if (action != "GetLogin")
                {
                    Logger.Log("SemikRequest : postData : " + post);
                }
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                Cursor.Current = Cursors.WaitCursor;
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                string s = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return s;
            }
            catch (Exception ex)
            {
                if (verbose) {
                    MessageBox.Show(ex.ToString(), "Web request error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Logger.Log("SemikRequest: Exception : " + ex.ToString());
                return "";
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
