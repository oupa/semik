using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
using System.Drawing;

namespace SEMIK1
{
    [Serializable()]
    public class FlightEvent : ISerializable
    {
        public string id;
        public int type = 1;
        public DateTime time;
        public double latitude;
        public double longitude;
        public double altitude;
        public double verticalSpeed;
        public double groundSpeed;
        public double airSpeed;
        public double heading;
        public string aircraft;
        public double fuel;
        public double windSpeed;
        public double windDirection;
        public string remarks;
        public double grossWeight;
        public double pressure;
        public double altimeterSetting;
        public string transponder;
        public string com1;
        public double pitch;
        public double distance;
        public double bank;
        public double groundElevation;
        public string flaps;
        public string gear;
        public Image image;

        public FlightEvent()
        {
        }

        public FlightEvent(SerializationInfo info, StreamingContext ctxt)
        {
          this.id = (string)info.GetValue("id", typeof(string));
          this.type = (int)info.GetValue("type", typeof(int));
          this.time = (DateTime)info.GetValue("time", typeof(DateTime));
          this.latitude = (double)info.GetValue("latitude", typeof(double));
          this.longitude = (double)info.GetValue("longitude", typeof(double));
          this.altitude = (int)info.GetValue("altitude", typeof(int));
          this.verticalSpeed = (int)info.GetValue("verticalSpeed", typeof(int));
          this.groundSpeed = (int)info.GetValue("groundSpeed", typeof(int));
          this.airSpeed = (int)info.GetValue("airSpeed", typeof(int));
          this.heading = (int)info.GetValue("heading", typeof(int));
          this.aircraft = (string)info.GetValue("aircraft", typeof(string));
          this.fuel = (int)info.GetValue("fuel", typeof(int));
          this.windSpeed = (int)info.GetValue("windSpeed", typeof(int));
          this.windDirection = (int)info.GetValue("windDirection", typeof(int));
          this.remarks = (string)info.GetValue("remarks", typeof(string));
          this.grossWeight = (int)info.GetValue("grossWeight", typeof(int));
          this.pressure = (int)info.GetValue("pressure", typeof(int));
          this.altimeterSetting = (int)info.GetValue("altimeterSetting", typeof(int));
          this.transponder = (string)info.GetValue("transponder", typeof(string));
          this.com1 = (string)info.GetValue("com1", typeof(string));
          this.pitch = (int)info.GetValue("pitch", typeof(int));
          this.distance = (int)info.GetValue("distance", typeof(int));
          this.bank = (int)info.GetValue("bank", typeof(int));
          this.groundElevation = (int)info.GetValue("groundElevation", typeof(int));
          this.flaps = (string)info.GetValue("flaps", typeof(string));
          this.gear = (string)info.GetValue("gear", typeof(string));
          try
          {
              this.image = (Image)info.GetValue("image", typeof(Image));
          }
          catch (Exception) { }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.id);
            info.AddValue("type", this.type);
            info.AddValue("time", this.time);
            info.AddValue("latitude", this.latitude);
            info.AddValue("longitude", this.longitude);
            info.AddValue("altitude", this.altitude);
            info.AddValue("verticalSpeed", this.verticalSpeed);
            info.AddValue("groundSpeed", this.groundSpeed);
            info.AddValue("airSpeed", this.airSpeed);
            info.AddValue("heading", this.heading);
            info.AddValue("aircraft", this.aircraft);
            info.AddValue("fuel", this.fuel);
            info.AddValue("windSpeed", this.windSpeed);
            info.AddValue("windDirection", this.windDirection);
            info.AddValue("remarks", this.remarks);
            info.AddValue("grossWeight", this.grossWeight);
            info.AddValue("pressure", this.pressure);
            info.AddValue("altimeterSetting", this.altimeterSetting);
            info.AddValue("transponder", this.transponder);
            info.AddValue("com1", this.com1);
            info.AddValue("pitch", this.pitch);
            info.AddValue("distance", this.distance);
            info.AddValue("bank", this.bank);
            info.AddValue("groundElevation", this.groundElevation);
            info.AddValue("flaps", this.flaps);
            info.AddValue("gear", this.gear);
            try
            {
                info.AddValue("image", this.image);
            }
            catch (Exception) { }
        }

        public string GetUTCTimeString()
        {
            return (GetUTCTime().Hour.ToString("00") + ":" + GetUTCTime().Minute.ToString("00"));
        }

        public string GetUTCDateString()
        {
            DateTime t = GetUTCTime();
            return (t.Year.ToString("0000") + "-" + t.Month.ToString("00") + "-" + t.Day.ToString("00") + " " + t.Hour.ToString("00") + ":" + t.Minute.ToString("00") + ":" + t.Second.ToString("00"));
        }

        public DateTime GetUTCTime() {
            return time.ToUniversalTime();
        }

        public string GetCSV(string d) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            
            string csv = 
                id + d +
                GetUTCDateString() + d +
                latitude.ToString("####.#######", nfi) + d +
                longitude.ToString("####.#######", nfi) + d +
                Math.Round(altitude) + d +
                Math.Round(verticalSpeed) + d +
                Math.Round(groundSpeed) + d +
                Math.Round(airSpeed) + d +
                Math.Round(heading).ToString("000") + d +
                Math.Round(fuel) + d +
                Math.Round(windSpeed) + d +
                Math.Round(windDirection).ToString("000") + d +
                Math.Round(grossWeight) + d +
                pressure + d +
                altimeterSetting + d +
                transponder + d +
                com1 + d +
                Math.Round(pitch) + d +
                Math.Round(distance) + d +
                Math.Round(bank) + d +
                Math.Round(groundElevation) + d +
                flaps + d +
                gear + d + remarks;

            return csv;
        }
    }
}
