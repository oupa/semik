/*
 Simple logger
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SEMIK1
{
  public class Logger {
    public static Pilot pilot;
    private static string flightLog = "";
    private static string acarsLog = "";
    public static string timeBase = "";

    public static void Log(string msg)
    {
        StreamWriter log;

        if (!File.Exists("semik.log"))
        {
            log = new StreamWriter("semik.log");
        }
        else
        {
            log = File.AppendText("semik.log");
        }

        if (msg == "")
        {
            log.WriteLine("---------------------------------------------");
        }
        else
        {
            log.WriteLine("[" + DateTime.Now + "] " + msg);
        }
        
        log.Close();
    }

    public static void Init() {
        System.IO.Directory.CreateDirectory("logs");
        System.IO.Directory.CreateDirectory("fdr");
        DateTime n = DateTime.Now;
        string d = n.Year.ToString("0000") + "-" + n.Month.ToString("00") + "-" + n.Day.ToString("00") + "-" + n.Hour.ToString("00") + n.Minute.ToString("00") + n.Second.ToString("00");
        timeBase = pilot.callsign + "_" + d;
    }

    public static void CreateFlightLog()
    {
        flightLog = "logs/semik_" + timeBase + ".txt";
    }

    public static void CreateAcarsLog()
    {
        acarsLog = "logs/acars_" + timeBase + ".txt";
    }

    public static void LogEvent(string msgType, string msg)
    {
        if (flightLog == "") { CreateFlightLog(); }
        StreamWriter log;
        if (!File.Exists(flightLog)){
            log = new StreamWriter(flightLog);
        } else {
            log = File.AppendText(flightLog);
        }
        log.WriteLine("["+ DateTime.Now + "] " + msgType + " | " + msg);
        log.Close();
    }

    public static void LogAcars(string acars)
    {
        if (acarsLog == "") { CreateAcarsLog(); }
        StreamWriter alog;
        alog = new StreamWriter(acarsLog);
        alog.WriteLine(acars);
        alog.Close();
    }

    public static void LogUpdate(string id)
    {
        DateTime n = DateTime.Now;
        string updated = n.Year.ToString("0000") + "" + n.Month.ToString("00") + "" + n.Day.ToString("00") + "" + n.Hour.ToString("00") + n.Minute.ToString("00") + n.Second.ToString("00");
        string path = Properties.Settings.Default["path_" + id] + "/updatelog.txt";
        StreamWriter ulog;
        ulog = new StreamWriter(path);
        ulog.WriteLine(updated);
        ulog.Dispose();
    }
  }
}
