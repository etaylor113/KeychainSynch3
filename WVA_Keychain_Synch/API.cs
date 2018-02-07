using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Keychain_Synch
{
    class API
    {
        public static void RunApi()
        {
            try {

                // Create new order from order class
                Order order = new Order()
                {
                    Time = MainForm.GetTime(),
                    ActNumber = MainForm.AccountNumber,
                    DeviceID = MainForm.DeviceID,
                    ConfigFile = Variables.ConfigFile,
                    Barcodes = MainForm.Barcodes.ToArray()
                };

                // Write response to api
                var json = JsonConvert.SerializeObject(order);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2-qa.wisvis.com/aws/scanner/final.rb");
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

                  
                    if (Json_Response.Message == "Able to connect to remote server but File Send was not successful\nNo Response")
                    {
                        MessageForm.Response = "There was an error creating your order. Please try again. If the error persists, please contact WVA Scanner Support.";
                        MessageForm message = new MessageForm();
                        message.ShowDialog();
                        return;
                    }                
                    if (Json_Response.Status == "FAIL")
                    {
                        SpawnErrorPage();
                    }
                    if (Json_Response.Status == "SUCCESS")
                    {
                        MainForm.ClearData = true;    
                    }
                    if (Json_Response.Status == "UPDATE")
                    {
                        Variables.ConfigFile = Json_Response.Message;
                        UpdateConfig.RunUpdate();    
                    }      
                    reader.Close();
                }

                response.Close();          

                if ((((HttpWebResponse)response).StatusDescription) == "OK")
                {
                    MessageForm.Response = Json_Response.Message;
                    MessageForm message = new MessageForm();
                    message.ShowDialog();
                }
                else
                {
                    SpawnErrorPage();
                }
            }
            catch (Exception e)
            {
                SpawnErrorPage();

                Errors.Error = e.ToString();
                Errors.Error += "(Location: RunApi())";
                Errors.PrintToErrorLog();
            }
        }

        private static void SpawnErrorPage()
        {
            MessageForm.Response = "There was an error downloading scanner. Be sure you are connected to the internet. If the problem persists, please call WVA Scanner Support. ";
            MessageForm message = new MessageForm();
            message.ShowDialog();
        }
    }
}
