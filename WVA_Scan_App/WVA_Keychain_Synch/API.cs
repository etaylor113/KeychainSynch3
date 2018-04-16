using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class API
    {
        public static string apiMessage { get; set; }

        public static void RunApi()
        {
            try {

                // Create new order from order class
                Order order = new Order()
                {
                    Time = MainForm.GetTime(),
                    ActNumber = MainForm.AccountNumber,
                    DeviceID = MainForm.DeviceID,
                    Barcodes = MainForm.Barcodes.ToArray()
                };

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

                // Clear Json_Response variables
                Json_Response.Status = "";
                Json_Response.Message = "";

                // Read response from api 
                WebResponse response = request.GetResponse();           
                using (Stream responseStream = response.GetResponseStream())
                {                 
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var json_Message = reader.ReadToEnd();
                    var jsonResponse = JsonConvert.DeserializeObject<Json_Response>(json_Message);

                    apiMessage = Json_Response.Message;

                    if (Json_Response.Status == "FAIL")
                    {
                        ShowMessage("There was an error creating your order. Please try again. If the error persists, contact WVA Scanner Support.");     // There was a problem creating the order
                    }
                    else if (Json_Response.Status == "SUCCESS")
                    {
                        MainForm.ClearData = true; // Tell polling thread in MainForm.cs it's okay to delete scanner data
                        ShowMessage("Your order was successfully created.");
                    }                   
                    else
                        ShowMessage("There was an error creating your order. Please try again. If the error persists, contact WVA Scanner Support.");   // If we got here, something was wrong with the payload
                    
                    reader.Close();
                }
                response.Close();
                
                if ((((HttpWebResponse)response).StatusDescription) == "OK")
                {
                    ShowMessage(apiMessage); // App made its way to the api successfully  
                }
                else
                {
                    ShowMessage("There was an error downloading scanner. Be sure you are connected to the internet and your scanner is plugged in. If the problem persists, contact WVA Scanner Support. ");  // Something went wrong when trying to connect to api
                }
            }
            catch (Exception e)
            {
                Errors.PrintToLog(e.ToString());
                ShowMessage("There was an error downloading scanner. Be sure you are connected to the internet and your scanner is plugged in. If the problem persists, contact WVA Scanner Support. ");  // Inform user something went wrong
            }
        }    

        private static void ShowMessage(string message)
        {       
            MessageForm.Response = message;
            MessageForm mf = new MessageForm();
            mf.ShowDialog();
        }
    }
}
