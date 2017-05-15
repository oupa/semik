using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace SEMIK1
{
    class Fleet
    {
        public static Aircraft[] aircrafts;

        public static void create(XmlNodeList fleetXml)
        {
            aircrafts = new Aircraft[fleetXml.Count];

            for (int i = 0; i < fleetXml.Count; i++)
            {
                try
                {
                    XmlElement ac = (XmlElement)fleetXml[i];
                    Aircraft a = new Aircraft();

                    a.id = ac.GetElementsByTagName("id")[0].InnerText;
                    a.code = ac.GetElementsByTagName("code")[0].InnerText;
                    a.name = ac.GetElementsByTagName("name")[0].InnerText;
                    a.icao = ac.GetElementsByTagName("icao")[0].InnerText;
                    a.tas = ac.GetElementsByTagName("TAS")[0].InnerText;
                    string[] regs = ac.GetElementsByTagName("regs")[0].InnerText.Split(',');
                    a.regs = new List<string>(regs);
                    string[] flaps = ac.GetElementsByTagName("flaps")[0].InnerText.Split(',');
                    a.flaps = new List<string>(flaps);
                    a.mtow = Convert.ToInt32(ac.GetElementsByTagName("mtow")[0].InnerText);
                    a.mlw = Convert.ToInt32(ac.GetElementsByTagName("mlw")[0].InnerText);
                    a.max_pitch = Convert.ToInt32(ac.GetElementsByTagName("pitch_max")[0].InnerText);
                    a.min_pitch = Convert.ToInt32(ac.GetElementsByTagName("pitch_min")[0].InnerText);
                    a.bank_limit = Convert.ToInt32(ac.GetElementsByTagName("bank_limit")[0].InnerText);
                    a.max_pitch_takeoff = Convert.ToInt32(ac.GetElementsByTagName("pitch_takeoff")[0].InnerText);
                    a.pax = Convert.ToInt32(ac.GetElementsByTagName("pax")[0].InnerText);
                    aircrafts[i] = a;
                }
                catch (Exception e) {
                    Logger.Log("Error parsing fleet " + e);
                }
             }

            Logger.Log("Fleet created : " + aircrafts.Length + " aircrafts");
        }

        public static bool isInFleet(string icao)
        {
            foreach (Aircraft a in aircrafts) {
                if (icao == a.icao)
                    return true;
            }
            return false;
        }

        public static Aircraft getAircraftByIcao(string icao)
        {
            foreach (Aircraft a in aircrafts) {
                if (icao == a.icao)
                    return a;
            }

            return null;
        }
    }
}
