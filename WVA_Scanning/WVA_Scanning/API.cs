using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Main
{
    class API
    {
        public static bool NeedsUpdate()
        {
            // https://www.wisvis.com/Scanner\GetUpdate.rb
            return true;
        }
        
        public static void GetUpdate()
        {
            App.CreateDirs();
            using (var client = new WebClient())
            {
                client.DownloadFile("https://ws2.wisvis.com/aws/scanner/CurrentMSI/WVA_Scan_App.msi", (Path.publicDocs + Path.tempDir + Path.msiName));
            }
        }
    }
}
