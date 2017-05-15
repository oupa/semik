/*
 Handles all necessary variables from FSUIPC in nice and readable format
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSUIPC;

namespace SEMIK1
{
    public class FSData
    {
        // time
        public DateTime updated; // timestamp of update

        // speeds
        public double airSpeed = 0.0; // knots
        public double groundSpeed = 0.0; // knots
        public double verticalSpeed = 0.0; // feet per minute
        
        // weight and fuel
        public double zeroFuelWeight = 0; // kg
        public double loadedWeight = 0; // kg
        public double fuelWeight = 0; // kg per gallon !!!

        public double fuelCenterLevel = 0.0; // percent % * 128 * 65536
        public double fuelCenterCap = 0.0; // gallons
        public double fuelLeftMainLevel = 0.0;
        public double fuelLeftMainCap = 0.0;
        public double fuelLeftAuxLevel = 0.0;
        public double fuelLeftAuxCap = 0.0;
        public double fuelLeftTipLevel = 0.0;
        public double fuelLeftTipCap = 0.0;
        public double fuelRightMainLevel = 0.0;
        public double fuelRightMainCap = 0.0;
        public double fuelRightAuxLevel = 0.0;
        public double fuelRightAuxCap = 0.0;
        public double fuelRightTipLevel = 0.0;
        public double fuelRightTipCap = 0.0;
        public double fuelTotalCap = 0.0;
        public double fuelTotalWeight = 0.0;
        public double altimeterSetting = 0.0;
        public double altimeterReading = 0.0;
        
        // position
        public double latitude = 0.0;
        public double longitude = 0.0;
        public double fslatitude = 0.0;
        public double fslongitude = 0.0;
        public double altitude = 0.0;
        public double heading = 0.0;
        public double pitch = 0.0;
        public double bank = 0.0;

        public double groundAltitude = 0.0;

        // text
        public string aircraftName = ""; // name of aircraft
        public int engineType = 0; // engine type

        // flight status
        public bool onGround = false; // is aircraft on ground
        
        // controls
        public bool parkingBrake = false; // parking brake
        public bool gear = true;
        public int flapsPosition = 0;

        // radios
        public string com1 = "";
        public string transponder = "";

        // sim
        public bool paused = false;
        public bool slewMode = false;
        public int simRate = 1;

        // weather
        public double windSpeed = 0.0;
        public double windDirection = 0.0;
        public double pressure = 0.0;
        public int surface;
        public double acceleration_x = 0.0;
        public double acceleration_y = 0.0;
        public double acceleration_z = 0.0;
        
        public bool lightsLanding = false;

        private double lastLatitude = 0.0;
        private double lastLongitude = 0.0;

        //public bool APMasterSwitch;

        public void update() 
        {
            updated = DateTime.Now;

            airSpeed = (double)FSUIPCProvider.airspeed.Value / 128d;
            groundSpeed = (double)FSUIPCProvider.groundspeed.Value / (65536 / 1.94384449); // 65536 * metres per second to knots
            verticalSpeed = (double)FSUIPCProvider.vspeed.Value * 0.768946875;

            latitude = (double)FSUIPCProvider.latitude.Value;
            longitude = (double)FSUIPCProvider.longitude.Value;
            altitude = (double)FSUIPCProvider.altitude.Value * 3.2808399;

            if (latitude == 0 && longitude == 0)
            {
                latitude = (double)FSUIPCProvider.fslatitude.Value * 90.0 / (10001750.0 * 65536.0 * 65536.0);
                longitude = (double)FSUIPCProvider.fslongitude.Value * 360.0 / (65536.0 * 65536.0 * 65536.0 * 65536.0);
            }
            

            if (altitude < 0.0) { altitude = 0.0; }
            altimeterReading = (double)FSUIPCProvider.altimeterReading.Value;

            if (altitude == 0 && altimeterReading > 100)
            {
                altitude = altimeterReading;
            }

            groundAltitude = (double)FSUIPCProvider.groundAltitude.Value * 3.2808399;
            if (groundAltitude < 0.0) { groundAltitude = 0.0; }

            // strange exception workaround that happens for unknown reason on some cases
            if (Math.Round(latitude) == 0 && Math.Round(longitude) == 0){
                latitude = lastLatitude;
                longitude = lastLongitude;
            }
            else {
                lastLatitude = latitude;
                lastLongitude = longitude;
            }
         

            heading = (double)FSUIPCProvider.heading.Value * 360 / 65536 / 65536 - (double)FSUIPCProvider.magVariation.Value * 360 / 65536;
            while (heading < 0) heading += 360;
            pitch = -1 * (double)FSUIPCProvider.pitch.Value * 360 / 65536 / 65536;
            bank = (double)FSUIPCProvider.bank.Value * 360 / 65536 / 65536;


            zeroFuelWeight = (double)FSUIPCProvider.zeroFuelWeight.Value * 0.45359237 / 256;
            loadedWeight = (double)FSUIPCProvider.loadedWeight.Value * 0.45359237;
            fuelWeight = (double)FSUIPCProvider.fuelWeight.Value * 0.45359237 / 256;

            fuelCenterLevel = (double)FSUIPCProvider.fuelCenterLevel.Value / 8388608;
            fuelCenterCap = (double)FSUIPCProvider.fuelCenterCap.Value;
            fuelLeftMainLevel = (double)FSUIPCProvider.fuelLeftMainLevel.Value / 8388608;
            fuelLeftMainCap = (double)FSUIPCProvider.fuelLeftMainCap.Value;
            fuelLeftAuxLevel = (double)FSUIPCProvider.fuelLeftAuxLevel.Value / 8388608;
            fuelLeftAuxCap = (double)FSUIPCProvider.fuelLeftAuxCap.Value;
            fuelLeftTipLevel = (double)FSUIPCProvider.fuelLeftTipLevel.Value / 8388608;
            fuelLeftTipCap = (double)FSUIPCProvider.fuelLeftTipCap.Value;
            fuelRightMainLevel = (double)FSUIPCProvider.fuelRightMainLevel.Value / 8388608;
            fuelRightMainCap = (double)FSUIPCProvider.fuelRightMainCap.Value;
            fuelRightAuxLevel = (double)FSUIPCProvider.fuelRightAuxLevel.Value / 8388608;
            fuelRightAuxCap = (double)FSUIPCProvider.fuelRightAuxCap.Value;
            fuelRightTipLevel = (double)FSUIPCProvider.fuelRightTipLevel.Value / 8388608;
            fuelRightTipCap = (double)FSUIPCProvider.fuelRightTipCap.Value;

            fuelTotalCap = fuelWeight * (fuelCenterCap + fuelLeftMainCap + fuelLeftAuxCap + fuelLeftTipCap + fuelRightMainCap + fuelRightAuxCap + fuelRightTipCap);
            
            fuelTotalWeight = 0;
            fuelTotalWeight += fuelCenterLevel * fuelCenterCap;
            fuelTotalWeight += fuelLeftMainLevel * fuelLeftMainCap;
            fuelTotalWeight += fuelLeftAuxLevel * fuelLeftAuxCap;
            fuelTotalWeight += fuelLeftTipLevel * fuelLeftTipCap;
            fuelTotalWeight += fuelRightMainLevel * fuelRightMainCap;
            fuelTotalWeight += fuelRightAuxLevel * fuelRightAuxCap;
            fuelTotalWeight += fuelRightTipLevel * fuelRightTipCap;

            fuelTotalWeight *= fuelWeight;

            aircraftName = FSUIPCProvider.aircraft.Value;
            engineType = FSUIPCProvider.engineType.Value;

            onGround = (FSUIPCProvider.onground.Value == 1);
            parkingBrake = (FSUIPCProvider.parkingBrake.Value != 0);
            gear = (FSUIPCProvider.gearControl.Value == 0);
            flapsPosition = FSUIPCProvider.flapsPosition.Value;

            com1 = ("1" + FSUIPCProvider.com1.Value.ToString("X"));
            if (com1.Length > 3){
                com1 = com1.Insert(3,".");
            }
            transponder = FSUIPCProvider.transponder.Value.ToString("X");
            while (transponder.Length < 4) {
                transponder = "0" + transponder;
            }
            altimeterSetting = (double)FSUIPCProvider.altimeterSetting.Value / 16;

            paused = (FSUIPCProvider.paused.Value == 1);
            slewMode = (FSUIPCProvider.slew.Value == 1);
            simRate = FSUIPCProvider.rate.Value / 256;

            windSpeed = (double)FSUIPCProvider.windSpeed.Value;
            windDirection = (double)FSUIPCProvider.windDirection.Value * 360 / 65536 - (double)FSUIPCProvider.magVariation.Value * 360 / 65536;
            if (windDirection < 0) windDirection += 360;
            pressure = (double)FSUIPCProvider.pressure.Value / 16;

            surface = (int)FSUIPCProvider.surface.Value;
            //APMasterSwitch = ((int)FSUIPCProvider.APMasterSwitch.Value == 1) ? true : false;

            acceleration_x = (double)FSUIPCProvider.acceleration_x.Value * 0.3048;
            acceleration_y = (double)FSUIPCProvider.acceleration_y.Value * 0.3048;
            acceleration_z = (double)FSUIPCProvider.acceleration_z.Value * 0.3048;

            lightsLanding = FSUIPCProvider.lights.Value[(int)LightType.Landing];
        }

        public string GetSurfaceString() { 
            string stype = "unknown";
            switch (surface)
            {
                case 0: stype = "CONCRETE"; break;
                case 1: stype = "GRASS"; break;
                case 2: stype = "WATER"; break;
                case 3: stype = "GRASS BUMPY"; break;
                case 4: stype = "ASPHALT"; break;
                case 5: stype = "SHORT GRASS"; break;
                case 6: stype = "LONG GRASS"; break;
                case 7: stype = "HARD TURF"; break;
                case 8: stype = "SNOW"; break;
                case 9: stype = "ICE"; break;
                case 10: stype = "URBAN"; break;
                case 11: stype = "FOREST"; break;
                case 12: stype = "DIRT"; break;
                case 13: stype = "CORAL"; break;
                case 14: stype = "GRAVEL"; break;
                case 15: stype = "OIL TREATED"; break;
                case 16: stype = "STEEL MATS"; break;
                case 17: stype = "BITUMINUS"; break;
                case 18: stype = "BRICK"; break;
                case 19: stype = "MACADAM"; break;
                case 20: stype = "PLANKS"; break;
                case 21: stype = "SAND"; break;
                case 22: stype = "SHALE"; break;
                case 23: stype = "TARMAC"; break;
                case 254: stype = "UNKNOWN"; break;
            }
            return stype;
        }

        public bool IsSafeSurface() 
        {
            if (surface == 0 || surface == 4 || surface == 16 || surface == 17 || surface == 23 || surface == 19) {
                return true;
            }
            return false;
        }

        private enum LightType
        {
            Navigation,
            Beacon,
            Landing,
            Taxi,
            Strobes,
            Instruments,
            Recognition,
            Wing,
            Logo,
            Cabin
        }
    }
}
