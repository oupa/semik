using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEMIK1
{
    public class VersionChecker
    {
        public static int buildVersion = 49;
        public static string status;

        public static void CheckVersion() {
            int remoteVersion = System.Convert.ToInt16(Connector.CheckVersion());
            if (remoteVersion > buildVersion)
            {
                status = "New version of Šemík (version " + remoteVersion.ToString() + ") is available to download.\n";
                status += "Upgrade is highly recommended.\n\n";
                status += "Open download page now?";
                DialogResult result = MessageBox.Show(status, "Version Checker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes) {
                    System.Diagnostics.Process.Start("http://www.csavirtual.cz/upload/semik/aktualni/semik.zip");
                }
            }
        }
    }
}
