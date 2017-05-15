/*
 Holds available data about currently logged pilot
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SEMIK1
{
    [Serializable()]
    public class Pilot : ISerializable
    {
        public string callsign;
        public string name;
        public string rank;
        public int flights;
        public string hours;
        public decimal miles;
        public string vatsim_id;
        public string ivao_id;
        public string locationIcao;
        public string locationText;
        public string pid;
        public string auth_code;

        public Pilot()
        {
        }

        public Pilot(SerializationInfo info, StreamingContext ctxt)
        {
            this.callsign = (string)info.GetValue("callsign", typeof(string));
            this.name = (string)info.GetValue("name", typeof(string));
            this.rank = (string)info.GetValue("rank", typeof(string));
            this.flights = (int)info.GetValue("flights", typeof(int));
            this.hours = (string)info.GetValue("hours", typeof(string));
            this.vatsim_id = (string)info.GetValue("vatsim_id", typeof(string));
            this.ivao_id = (string)info.GetValue("ivao_id", typeof(string));
            this.locationIcao = (string)info.GetValue("locationIcao", typeof(string));
            this.locationText = (string)info.GetValue("locationText", typeof(string));
            this.pid = (string)info.GetValue("pid", typeof(string));
            this.auth_code = (string)info.GetValue("auth_code", typeof(string));
            this.miles = (decimal)info.GetValue("miles", typeof(decimal));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("callsign", this.callsign);
            info.AddValue("name", this.name);
            info.AddValue("rank", this.rank);
            info.AddValue("flights", this.flights);
            info.AddValue("hours", this.hours);
            info.AddValue("vatsim_id", this.vatsim_id);
            info.AddValue("ivao_id", this.ivao_id);
            info.AddValue("locationIcao", this.locationIcao);
            info.AddValue("locationText", this.locationText);
            info.AddValue("pid", this.pid);
            info.AddValue("auth_code", this.auth_code);
            info.AddValue("miles", this.miles);
        }
    }
}
