using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace SEMIK1
{
    public class Snapshot
    {
        public static Bitmap bmpScreenshot;
        public static Graphics gfxScreenshot;
        private static int count;
        private static int fdrcount;
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static ImageCodecInfo jpgEncoder;
        private static System.Drawing.Imaging.Encoder myEncoder;
        private static EncoderParameters myEncoderParameters;
        private static EncoderParameter myEncoderParameter;

        public static void Init(){
            count = fdrcount = 0;
            System.IO.Directory.CreateDirectory("tv");
            jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private static Bitmap ResizeBitmap(Bitmap b, Size size)
        {
            Bitmap result = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, size.Width, size.Height);
            return result;
        }

        private static bool WindowCheck() 
        {
            int chars = 256;
            StringBuilder buff = new StringBuilder(chars);

            // Obtain the handle of the active window.
            IntPtr handle = GetForegroundWindow();

            // Update the controls.
            if (GetWindowText(handle, buff, chars) > 0)
            {
                string windowName = buff.ToString();
                int nameActive = windowName.IndexOf(Properties.Settings.Default.tv_keyword);
                if (nameActive >= 0 && Properties.Settings.Default.tv_keyword.Length > 0)
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static Bitmap Shot(int width) {
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            double ratio = (double)Screen.PrimaryScreen.WorkingArea.Height / (double)Screen.PrimaryScreen.WorkingArea.Width;
            Size size = new Size();
            size.Width = width;
            size.Height = Convert.ToInt32(size.Width * ratio);
            Bitmap resized = ResizeBitmap(bmpScreenshot, size);
            bmpScreenshot.Dispose();
            gfxScreenshot.Dispose();
            return resized;
        }

        public static Image TakeImage(string remark) {
            try
            {
                if (!WindowCheck())
                    return null;

                fdrcount++;
                string utcTime = DateTime.Now.ToUniversalTime().Hour.ToString("00") + DateTime.Now.ToUniversalTime().Minute.ToString("00") + DateTime.Now.ToUniversalTime().Second.ToString("00") + fdrcount;
                Bitmap snapshot = Shot(1024);
                string file = Application.StartupPath + "/tv/fdr_inc_" + remark + "_" + utcTime + ".jpg";
                myEncoderParameter = new EncoderParameter(myEncoder,69L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                snapshot.Save(file, jpgEncoder, myEncoderParameters);
                snapshot.Dispose();

                Image image = Image.FromFile(file);
                return image;
            }
            catch (Exception) {
                return null;
            }
        }

        public static string TakeSnapshot() {
            try
            {
                bool useIncrement = Properties.Settings.Default.tv_increment;
                
                if (!Properties.Settings.Default.tv_use_keyword)
                    return "";

                if (!WindowCheck())
                    return "";

                Bitmap resized = Shot(970);
                string file = Application.StartupPath + "/tv/tv_" + Logger.timeBase + ((useIncrement) ? ("_" + count) : "") + ".jpg";
                myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                resized.Save(file, jpgEncoder, myEncoderParameters);

                
                resized.Dispose();
                count++;
                return file;
            }
            catch (Exception) {
                return "";
            }
        }

    }
}
