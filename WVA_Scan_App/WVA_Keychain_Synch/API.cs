using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class API
    {
        [DllImport("Opticon.csp2.net")]
        static extern void RunApi([In, MarshalAs(UnmanagedType.SysInt)] int ReadBarcodes);

        public static void RunApi(Order order)
        {
            try
            {        
                // Write response to api
                var json = JsonConvert.SerializeObject(order);

                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2.wisvis.com/aws/scanner/json_final.rb");
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(json);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";

                using (Stream dataStream = request.GetRequestStream()  )
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
                        ShowMessage(message);     // There was a problem creating the order
                    }
                    else if (status.Contains("SUCCESS"))
                    {
                        if (Opticon.csp2.ClearData(MainForm.ComCheck) != 0)
                        {
                            string error = "Erasing scanner data failed!";
                            Errors.ReportError(error);
                        }             
          
                        ShowMessage(message);
                    }
                    else
                    {
                        ShowMessage("There was an error creating your order. Please try again. If the error persists, contact WVA Scanner Support.");   // If we got here, something was wrong with the payload
                    }                     
                    
                    reader.Close();
                }
                response.Close();
                
                if ((((HttpWebResponse)response).StatusDescription) != "OK")
                {
                    PrintGeneralError();
                }
            }
            catch (Exception e)
            {
                Errors.ReportError(e.ToString());
                PrintGeneralError();
            }
        }    

        private static void PrintGeneralError()
        {
            ShowMessage("There was an error downloading scanner. Be sure you are connected to the internet and your scanner is plugged in. If the problem persists, contact WVA Scanner Support. ");  
        }

        private static void ShowMessage(string message)
        {       
            MessageForm.Response = message;
            MessageForm mf = new MessageForm();
            mf.ShowDialog();
        }
    }
}
