using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            { 
                bool needsUpdate = false;

                Json_Response payload = new Json_Response();

                UpdateOutput updateOutput = new UpdateOutput();
            
                var json = JsonConvert.SerializeObject(updateOutput);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2.wisvis.com/aws/scanner/json_check_update.rb");
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(json);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                // Read response from api 
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var json_Message = reader.ReadToEnd();
                    var jsonResponse = JsonConvert.DeserializeObject<Json_Response>(json_Message);

                    if (jsonResponse.Message == "True")
                    {
                        needsUpdate = true;
                    }
                    else if (jsonResponse.Message == "False")
                    {
                        needsUpdate = false;
                    }
                    else
                    {
                        // If we got here, something went wrong with the api. 
                        throw new System.InvalidOperationException("API broke while attemping to fetch update.");
                    }
                    reader.Close();                        
                }
                response.Close();

                if ((((HttpWebResponse)response).StatusDescription) != "OK")
                {
                    throw new System.InvalidOperationException("Attempted to connect but connection could not be established.");
                }

                // Check update status after streams have been cleaned up.
                switch (needsUpdate)
                {
                    case true:
                        return true;
                    case false:
                        return false;
                    default:
                        return false;
                }
            }
            catch(Exception e)
            {               
                Errors.ReportError(e.ToString());
                return false;
            }
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
    