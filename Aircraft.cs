using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEMIK1
{
    class Aircraft
    {
        public string id;
        public string name;
        public string code;
        public string tas;
        public string icao;
        public List<string> regs;
        public List<string> flaps;
        public int mtow;
        public int mlw;
        public int max_pitch;
        public int min_pitch;
        public int max_pitch_takeoff;
        public int bank_limit;
        public int pax;
        
        public string getFlaps(int position){
            string r = "";
            if (position == 16383) {
                r = flaps[flaps.Count - 1];
            }
            else if (position == 0)
            {
                r = flaps[0];
            }
            else
            {
                int ratio = (int)(16383 / flaps.Count);
                int fsratio = position / ratio;
                if (fsratio > 0 && fsratio < (flaps.Count - 1))
                {
                    r = flaps[fsratio];
                }
                else {
                    r = "?";
                }
            }
            return r;
        }
    }
}
