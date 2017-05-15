/*
 This will create data submited by user when completing Flight plan form
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SEMIK1
{
    [Serializable()]
    public class FlightInit : ISerializable
    {
        public string departure;
        public string arrival;
        public string alternate;
        public int flight_level;
        public string callsign;
        public string route;
        public string aircraft;
        public string registration;
        public int pax;
        public string iata;
        public int build = VersionChecker.buildVersion;

        public FlightInit() { 
        }

        public FlightInit(SerializationInfo info, StreamingContext ctxt)
        {
            this.departure = (string)info.GetValue("departure", typeof(string));
            this.arrival = (string)info.GetValue("arrival", typeof(string));
            this.alternate = (string)info.GetValue("alternate", typeof(string));
            this.flight_level = (int)info.GetValue("flight_level", typeof(int));
            this.callsign = (string)info.GetValue("callsign", typeof(string));
            this.route = (string)info.GetValue("route", typeof(string));
            this.aircraft = (string)info.GetValue("aircraft", typeof(string));
            this.registration = (string)info.GetValue("registration", typeof(string));
            this.pax = (int)info.GetValue("pax", typeof(int));
            this.iata = (string)info.GetValue("iata", typeof(string));
            this.build = (int)info.GetValue("build", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("departure", this.departure);
            info.AddValue("arrival", this.arrival);
            info.AddValue("alternate", this.alternate);
            info.AddValue("flight_level", this.flight_level);
            info.AddValue("callsign", this.callsign);
            info.AddValue("route", this.route);
            info.AddValue("aircraft", this.aircraft);
            info.AddValue("registration", this.registration);
            info.AddValue("pax", this.pax);
            info.AddValue("iata", this.iata);
            info.AddValue("build", this.build);
        }
    }
}
