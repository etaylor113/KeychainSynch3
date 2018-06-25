using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WVA_Scan
{
    class API
    {
        [DllImport("Opticon.csp2.net")]
        static extern void RunApi([In, MarshalAs(UnmanagedType.SysInt)] int ReadBarcodes);

        public static string RunApi(Order order)
        {
            try
            {
                string returnMessage = "";

                // Write response to api
                var json = JsonConvert.SerializeObject(order);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2.wisvis.com/aws/scanner/json_final.rb");
                request.Method = "POST";
                request.Timeout = 10000;

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
                    string status = jsonResponse.Status;
                    string message = jsonResponse.Message;

                    if (status.Contains("FAIL"))
                    {
                        return message;     // There was a problem creating the order
                    }
                    else if (status.Contains("SUCCESS"))
                    {
                        if (Opticon.csp2.ClearData(MainForm.Comport) != 0)
                        {
                            string error = "Erasing scanner data failed!";
                            Error err = new Error();
                            err.ReportError(error.ToString());
                        }

                        returnMessage = message;
                    }
                    else
                    {
                        returnMessage = "There was an error creating your order.If the problem persists, please contact WVA Scanner Support. ";   // If we got here, something was wrong with the payload
                    }

                    reader.Close();
                }
                response.Close();

                if ((((HttpWebResponse)response).StatusDescription) != "OK")
                {
                    returnMessage = "There was an error creating your order.If the problem persists, please contact WVA Scanner Support. ";
                }

                return returnMessage;
            }
            catch (Exception e)
            {
                Error err = new Error();
                err.ReportError(e.ToString());

                if (e.Message == "The operation has timed out")
                {
                    return "Request timed out. We may be experiencing technical difficulties. If the problem percists please contact WVA Scanner Support.";
                }
                else
                {
                    return "There was an error creating your order. If the problem persists, please contact WVA Scanner Support. ";
                }           
            }
        }     
    }
}
