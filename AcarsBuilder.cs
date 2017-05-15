using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEMIK1;
using System.Globalization;

namespace SEMIK1
{
    public class AcarsBuilder
    {
        public static Pilot pilot;
        public static TimeSpan duration;

        public static string FSACARSCompatiblePirep(FlightInit fi, string lineBreak)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            List<string> lines = new List<string>();
            // UTC of flight init event
            FlightEvent initEvent = FlightTracking.GetFlightEvent("FlightInit");
            if (initEvent == null) return "Terminating - FlightInit event not found";
            DateTime initTime = initEvent.time;
            lines.Add("[" + initTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss") + "]");
            
            // flight info
            lines.Add("Flight IATA:" + fi.iata);
            lines.Add("Pilot Number:" + pilot.callsign.Substring(3));
            lines.Add("Company ICAO:" + pilot.callsign.Substring(0, 3));
            lines.Add("Aircraft Type: " + Fleet.getAircraftByIcao(fi.aircraft).code);
            lines.Add("Aircraft Registration:" + fi.registration);
            lines.Add("Departing Airport:" + fi.departure);
            lines.Add("Destination Airport:" + fi.arrival);
            lines.Add("Alternate Airport:" + fi.alternate);
            lines.Add("PAX:" + fi.pax);
            lines.Add("Online:"); // TODO
            lines.Add("Route:" + fi.route);
            lines.Add("Flight Level:FL" + (fi.flight_level / 100).ToString("000"));
            
            // slew and pause
            bool paused = (FlightTracking.GetFlightEvent("Paused") != null);
            bool slewed = (FlightTracking.GetFlightEvent("Slewed") != null);
            bool simrate = (FlightTracking.GetFlightEvent("SimRateChange") != null);

            if (!slewed && !simrate)
                lines.Add("No Slew and time accel");
            else if (slewed && !simrate)
                lines.Add("Slew detected, no time accel");
            else if (!slewed && simrate)
                lines.Add("Time accel detected, no slew");
            else
                lines.Add("Time accel AND slew detected");

            if (!paused)
                lines.Add("No Pause");
            else lines.Add("Pause detected");

            //
            lines.Add("Detect pilot in Cockpit between each  1 and 5 minutes (Not implemented)");
            // TODO - vatsim / ivao metar
            List<FlightEvent> events = FlightTracking.GetFlightEvents();
            for (int i = 0; i < events.Count; i++){
                FlightEvent ev = events[i];
                if (ev.remarks.Length > 0){
                    lines.Add(ev.GetUTCTimeString() + "  " + ev.remarks);
                }
                if (ev.id == "FlightInit") {
                    lines.Add(ev.GetUTCTimeString() + "  Zero fuel Weight: " + Math.Round(ev.grossWeight - ev.fuel).ToString() + " kg, Fuel Weight: " + Math.Round(ev.fuel).ToString() + " kg");
                }
                if (ev.id == "BlockOff") {
                    lines.Add(ev.GetUTCTimeString() + "  Parking Brakes off");
                }
                if (ev.id == "Rotate") {
                    lines.Add(ev.GetUTCTimeString() + "  VR= " + Math.Round(ev.airSpeed) + " knots");
                }
                if (ev.id == "Takeoff") {
                    lines.Add(ev.GetUTCTimeString() + "  V2= " + Math.Round(ev.airSpeed) + " knots");
                    lines.Add(ev.GetUTCTimeString() + "  Take-off");
                    lines.Add(ev.GetUTCTimeString() + "  Take off Weight: " + Math.Round(ev.grossWeight) + " kg");
                    lines.Add(ev.GetUTCTimeString() + "  Wind:" + Math.Round(ev.windDirection).ToString("000") + "° @ " + Math.Round(ev.windSpeed).ToString("000") + " knots Heading: " + Math.Round(ev.heading).ToString("000") + "°");
                    lines.Add(ev.GetUTCTimeString() + "  Position: " + "lat:" + ev.latitude.ToString("####.#######", nfi) + ";lon:" + ev.longitude.ToString("####.########", nfi) + ";alt:" + Math.Round(ev.altitude) + ";hdg:" + ev.heading.ToString("000"));
                }
                if (ev.id == "TOC") {
                    lines.Add(ev.GetUTCTimeString() + "  TOC");
                    lines.Add(ev.GetUTCTimeString() + "  Fuel Weight: " + Math.Round(ev.fuel) + " kg");
                    lines.Add(ev.GetUTCTimeString() + "  Wind:" + Math.Round(ev.windDirection).ToString("000") + "° @ " + Math.Round(ev.windSpeed).ToString("000") + " knots Heading: " + Math.Round(ev.heading).ToString("000") + "°");
                    lines.Add(ev.GetUTCTimeString() + "  Position: " + "lat:" + ev.latitude.ToString("####.#######", nfi) + ";lon:" + ev.longitude.ToString("####.########", nfi) + ";alt:" + Math.Round(ev.altitude) + ";hdg:" + ev.heading.ToString("000"));
                }
                if (ev.id == "TOD") {
                    lines.Add(ev.GetUTCTimeString() + "  TOD");
                    lines.Add(ev.GetUTCTimeString() + "  Fuel Weight: " + Math.Round(ev.fuel) + " kg");
                    lines.Add(ev.GetUTCTimeString() + "  Wind:" + Math.Round(ev.windDirection).ToString("000") + "° @ " + Math.Round(ev.windSpeed).ToString("000") + " knots Heading: " + Math.Round(ev.heading).ToString("000") + "°");
                    lines.Add(ev.GetUTCTimeString() + "  Position: " + "lat:" + ev.latitude.ToString("####.#######", nfi) + ";lon:" + ev.longitude.ToString("####.########", nfi) + ";alt:" + Math.Round(ev.altitude) + ";hdg:" + ev.heading.ToString("000"));
                }
                if (ev.id == "Touchdown") { 
                    lines.Add(ev.GetUTCTimeString() + "  TouchDown:Rate " + Math.Round(ev.verticalSpeed) + " ft/min Speed: " + Math.Round(ev.airSpeed) + " knots");
                    // todo landing METAR
                    lines.Add(ev.GetUTCTimeString() + "  Land");
                    lines.Add(ev.GetUTCTimeString() + "  Wind:" + Math.Round(ev.windDirection).ToString("000") + "° @ " + Math.Round(ev.windSpeed).ToString("000") + " knots");
                    lines.Add(ev.GetUTCTimeString() + "  Heading: " + Math.Round(ev.heading).ToString("000") + "°");

                    DateTime timeTakeoff = FlightTracking.GetFlightEvent("Takeoff").time;
                    DateTime timeTouchdown = ev.time;
                    TimeSpan duration = timeTouchdown.Subtract(timeTakeoff);

                    lines.Add(ev.GetUTCTimeString() + "  Flight Duration: " + duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00"));
                    lines.Add(ev.GetUTCTimeString() + "  Landing Weight:" + Math.Round(ev.grossWeight));
                    lines.Add(ev.GetUTCTimeString() + "  Position: " + "lat:" + ev.latitude.ToString("####.#######", nfi) + ";lon:" + ev.longitude.ToString("####.########", nfi) + ";alt:" + Math.Round(ev.altitude) + ";hdg:" + ev.heading.ToString("000"));
                }
                if (ev.id == "BlockOn") { 
                    lines.Add(ev.GetUTCTimeString() + "  Parking brakes on");
                    DateTime timeBlockoff = FlightTracking.GetFlightEvent("BlockOff").time;
                    DateTime timeBlockon = ev.time;
                    TimeSpan duration = timeBlockon.Subtract(timeBlockoff);

                    lines.Add(ev.GetUTCTimeString() + "  Block to Block Duration:" + duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00"));
                    lines.Add(ev.GetUTCTimeString() + "  Final Fuel: " + Math.Round(ev.fuel) + " kg");
                    double spentFuel = FlightTracking.GetFlightEvent("FlightInit").fuel - ev.fuel;
                    lines.Add(ev.GetUTCTimeString() + "  Spent Fuel: " + Math.Round(spentFuel) + " kg");
                    lines.Add(ev.GetUTCTimeString() + "  Flight Length: " + Math.Round(FlightTracking.distance) + " NM");
                    FlightEvent tod = FlightTracking.GetFlightEvent("TOD");
                    if (tod != null)
                    {
                        double todLength = FlightTracking.DistLatLong(tod.latitude, tod.longitude, ev.latitude, ev.longitude, "nm");
                        lines.Add(ev.GetUTCTimeString() + "  TOD Land Length: " + Math.Round(todLength) + " NM");
                    }
                }
            }

            return string.Join(lineBreak, lines.ToArray());
        }

        public static string SemikUploadString(FlightInit fi) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            FlightEvent block_off = FlightTracking.GetFlightEvent("BlockOff");
            FlightEvent block_on = FlightTracking.GetFlightEvent("BlockOn");
            FlightEvent to = FlightTracking.GetFlightEvent("Takeoff");
            FlightEvent td = FlightTracking.GetFlightEvent("Touchdown");

            

            string args = "";
            args += "pid=" + pilot.pid;
            args += "&auth=" + pilot.auth_code;
            args += "&tracking_id=" + FlightTracking.tracking_id;
            args += "&blockoff_coords=" + block_off.latitude.ToString("####.#######", nfi) + ";" + block_off.longitude.ToString("####.#######", nfi);
            args += "&blockon_coords=" + block_on.latitude.ToString("####.#######", nfi) + ";" + block_on.longitude.ToString("####.#######", nfi);
            args += "&blockoff_time=" + block_on.GetUTCTimeString();

            args += "&td_rate=" + Math.Round(td.verticalSpeed);
            args += "&td_speed=" + Math.Round(td.airSpeed);
            args += "&td_coords=" + td.latitude.ToString("####.#######", nfi) + ";" + td.longitude.ToString("####.#######", nfi) + ";" + Math.Round(td.heading).ToString();
            args += "&fuel_spent=" + Math.Round(block_off.fuel - block_on.fuel);
            args += "&final_fuel=" + Math.Round(block_on.fuel);

            DateTime timeTakeoff = to.time;
            DateTime timeTouchdown = td.time;
            duration = timeTouchdown.Subtract(timeTakeoff);

            args += "&duration=" + duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00") + ":" + duration.Seconds.ToString("00");
            args += "&distance=" + Math.Round(FlightTracking.distance);
            args += "&equipment=" + fi.aircraft;
            args += "&registration=" + fi.registration;
            args += "&pax=" + fi.pax;
            
            List<FlightEvent> events = FlightTracking.GetFlightEvents();
            for (int i = 0; i < events.Count; i++) {
                FlightEvent ev = events[i];
                if (ev.type > 1) {
                    args += "&incidents[]=" + ev.GetCSV(";");
                }
            }

            args += "&fsapirep=" + FSACARSCompatiblePirep(fi, "*");

            return args;
        }

    }
}
