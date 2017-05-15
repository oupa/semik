using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SEMIK1;

namespace SEMIK1
{
    [Serializable()]
    public class FDR : ISerializable
    {
        private FlightInit flightInit;
        private List<FlightEvent> flightEvents;
        private Pilot pilot;

        public FlightInit FlightInit { 
            get { return this.flightInit; }
            set { this.flightInit = value; }
        }

        public List<FlightEvent> FlightEvents {
            get { return this.flightEvents; }
            set { this.flightEvents = value; }
        }

        public Pilot Pilot {
            get { return this.pilot; }
            set { this.pilot = value; }
        }

        public FDR () 
        { }

        public FDR(SerializationInfo info, StreamingContext ctxt) 
        {
            this.flightInit = (FlightInit)info.GetValue("FlightInit", typeof(FlightInit));
            this.flightEvents = (List<FlightEvent>)info.GetValue("FlightEvents", typeof(List<FlightEvent>));
            this.pilot = (Pilot)info.GetValue("Pilot", typeof(Pilot));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("FlightInit", this.flightInit);
            info.AddValue("FlightEvents", this.flightEvents);
            info.AddValue("Pilot", this.pilot);
        }
    }
}