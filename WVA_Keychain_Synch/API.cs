﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            try
            {
                string MessageFromApi = "";
                var json = JsonConvert.SerializeObject(MainForm.data);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2-qa.wisvis.com/aws/scanner/final.rb");
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(json);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    MessageFromApi = reader.ReadToEnd();
                    if (MessageFromApi == "Able to connect to remote server but File Send was not successful\nNo Response")
                    {
                        MessageForm.Response = "There was an error downloading scanner. Be sure you are connected to the internet and your scanner is plugged in. If the problem persists, please call WVA Scanner Support. ";
                        MessageForm message = new MessageForm();
                        message.ShowDialog();
                        return;
                    }

                    if (MessageFromApi.Contains("FAIL:"))
                    {
                        MessageFromApi = MessageFromApi.Replace("FAIL:", "");
                    }
                    if (MessageFromApi.Contains("SUCCESS:"))
                    {
                        MainForm.ClearData = true;
                        MessageFromApi = MessageFromApi.Replace("SUCCESS:", "");
                    }
                    switch (MessageFromApi)
                    {
                        case "UPDATE":
                            // Run method to update config file
                            break;
                    }

                    reader.Close();
                }

                response.Close();

                if ((((HttpWebResponse)response).StatusDescription) == "OK")
                {
                    MessageForm.Response = MessageFromApi;
                    MessageForm message = new MessageForm();
                    message.ShowDialog();
                }
                else
                {
                    MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                    MessageForm message = new MessageForm();
                    message.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageForm.Response = "There was an error downloading \nscanner. Be sure you are connected \nto the internet. If the problem persists, \nplease call WVA Scanner Support. ";
                MessageForm message = new MessageForm();
                message.ShowDialog();

                Errors.Error = e.ToString();
                Errors.Error += "(Location: RunApi())";
                Errors.PrintToErrorLog();
            }
        }
    }
}
