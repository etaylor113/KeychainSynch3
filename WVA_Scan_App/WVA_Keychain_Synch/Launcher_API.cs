using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Launcher_API
    {
        public static bool NeedsUpdate()
        {
            // https://www.wisvis.com/WVA_Scan_Launcher.msi
            return true;
        }

        public static void GetUpdate()
        {
            using (var client = new WebClient())
            {
                string path = (Path.tempDir + Path.launchMsiName);
                client.DownloadFile("https://ws2.wisvis.com/aws/scanner/CurrentMSI/WVA_Scan_Launcher.msi", path);
            }
        }
    }
}
    