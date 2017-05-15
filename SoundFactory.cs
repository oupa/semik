using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
//using IrrKlang;
//using FMODNet;

namespace SEMIK1
{
    public class SoundFactory
    {
        //private static ISoundEngine player;
        public static string file;
        private static float volume = -1;
        private static FMOD.System system = null;
        private static FMOD.Sound sound = null;
        private static FMOD.Channel channel = null; 
        private static bool inited = false;

        public static void Init()
        {
            try
            {
                //device = new SoundDevice();
                //device.Initialize(new SoundDeviceConfiguration
                //    {
                //        DebugMode = false,
                //        MaximumAllowedSounds = 4
                //    });
                inited = true;
            }
            catch (Exception e) {
                Logger.Log("SoundFactory exception");
                Logger.Log(e.ToString());
            }
        }
        public static void StopSound()
        {
            if (!inited) return;
            // if (player == null) return;
           //  player.StopAllSounds();
            //if (sound == null) return;
            if (channel == null) return;
            channel.stop();
        }

        public static void SetVolume(int vol)
        {
            if (!inited) return;
            volume = (float)vol / 100;
            if (channel != null)
            {
                channel.setVolume(volume);  
            }
        }

        public static void TestSound(string id) {
            if (!inited) return;
            MessageBox.Show("Now testing sound \"" + id + "\" with volume " + volume.ToString());
            PlaySound(id);
        }

        public static void PlaySound(string id){
            if (!inited) return;
            if (!Properties.Settings.Default.use_sound) return;
            //if (player != null) player.StopAllSounds();
            //if (player == null) player = new ISoundEngine();
            if (sound != null) StopSound();
            if (volume == -1) volume = Properties.Settings.Default.sound_volume;
            switch (id) 
            { 
                case "TaxiFromGate":
                    file = Application.StartupPath + "/sfx/crew2_safetyaboard.mp3";
                break;
                case "BeforeTakeoff":
                    file = Application.StartupPath + "/sfx/crew_preparetakeoff.mp3";
                break;
                case "Descent":
                    file = Application.StartupPath + "/sfx/crew6_descent.mp3";
                break;
                case "Landing":
                    file = Application.StartupPath + "/sfx/crew7_beforelandnight.mp3";
                break;
                case "TaxiToGate":
                    file = Application.StartupPath + "/sfx/crew8_aftland.mp3";
                break;
            }

            try
            {
                FMOD.RESULT result;
                uint version = 0;

                result = FMOD.Factory.System_Create(ref system);
                ERRCHECK(result);

                result = system.getVersion(ref version);
                ERRCHECK(result);
                if (version < FMOD.VERSION.number)
                {
                    MessageBox.Show("Error!  You are using an old version of FMOD " + version.ToString("X") + ".  This program requires " + FMOD.VERSION.number.ToString("X") + ".");
                }

                result = system.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
                ERRCHECK(result);
           
                result = system.createSound(file, FMOD.MODE.HARDWARE, ref sound);
                ERRCHECK(result);

                result = system.playSound(FMOD.CHANNELINDEX.FREE, sound, false, ref channel);
                ERRCHECK(result);
                channel.setVolume(volume);
            }
            catch (Exception e) {
                Logger.Log("SoundFactory Error: " + e.ToString());
            }
            
            //player.SoundVolume = volume;
           // player.Play2D(file);
        }

        private static void ERRCHECK(FMOD.RESULT result)
        {
            if (result != FMOD.RESULT.OK)
            {
                //MessageBox.Show("FMOD error! " + result + " - " + FMOD.Error.String(result));
                //Environment.Exit(-1);
                Logger.Log("FMOD error! " + result + " - " + FMOD.Error.String(result));
            }
        }


        public static void Dispose()
        {
            FMOD.RESULT result;

            /*
                Shut down
            */
            if (sound != null)
            {
                result = sound.release();
                ERRCHECK(result);
            }

            if (system != null)
            {
                result = system.close();
                ERRCHECK(result);
                result = system.release();
                ERRCHECK(result);
            }
        }
    }
}
