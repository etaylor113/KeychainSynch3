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
    class UpdateConfig
    {

        public static string UpdateString { get; set; }

        public static void RunUpdate()
        {
            GetUpdate();
            GetUpdateData();
            AssignVariables();
        }

        private static void GetUpdate()
        {
            try
            {

                Config config = new Config()
                {
                    Update = Variables.ConfigFile
                };

                var json = JsonConvert.SerializeObject(config);            

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ws2.wisvis.com/aws/scanner/final.rb");
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
                    UpdateString = reader.ReadToEnd();

                    reader.Close();
                }
                response.Close();
            }
            catch (Exception e)
            {
                Errors.Error = e.ToString();
                Errors.Error += "(Location: GetUpdate())";
                Errors.PrintToErrorLog();
            }
        }

        private static void GetUpdateData()
        {
            try
            {
                string[] stringArray;

                stringArray = UpdateString.Split(',');

                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string updateConfig = @"/WVA Scan/Config/Config.txt";
                var publicFile = File.Create(dirPublicDocs + updateConfig);
                publicFile.Close();

                StreamWriter wr = new StreamWriter(dirPublicDocs + updateConfig);
                {
                    foreach (string word in stringArray)
                    {
                        word.Trim();
                        wr.WriteLine(word);
                    }
                    wr.Close();
                }
            }
            catch { }
        }

        public static void AssignVariables()
        {
            string line;
            string selectedDir = "";

            if (DoesUpdateFileExist() == true)
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string updateConfig = @"/WVA Scan/Config/Config.txt";
                selectedDir = dirPublicDocs + updateConfig;
            }
            else
            {
                string dirProgram86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                string defaultConfig = @"/WVA Scan/Config/Config.txt";
                selectedDir = dirProgram86 + defaultConfig;
            }   
      
            StreamReader file = new StreamReader(selectedDir);
            {
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        int stringLength = 0;
                        string guid = "";
                        string temp = "";
                        string variable = "";

                        stringLength = line.Length;
                        guid = line.Remove(36, stringLength - 36);
                        temp = line.Replace(guid, "");
                        temp = temp.Trim();
                        variable = DecryptData(temp);

                        switch (guid)
                        {
                            case "760c9199-afc1-4e54-bab6-90f6ca9a3a07":
                                Variables.ConfigFile = variable;
                                break;
                            case "2cc9cc9a-befa-4314-89dc-88b6d66b6d96":
                                Variables.ANEF_Text = variable;
                                break;
                            case "4db6f1a5-f7ad-437a-b177-5245f3292b7d":
                                Variables.ErrorMessage_Text = variable;
                                break;
                            case "896ca679-b3f9-41e2-a083-6ead83a4c690":
                                Variables.NoScanned_Text = variable;
                                break;
                            case "043e6f2d-c226-4bb0-8707-9acd829e191c":
                                Variables.labelContactNum_Text = variable;
                                break;
                            case "76f63ec0-51cb-4f27-acd3-4b525c40b7e4":
                                Variables.ViewCart_Link = variable;
                                break;
                            case "9afe17ff-3885-41c4-9518-9869319b1c0b":
                                //Var_7 = variable;
                                break;
                            case "bb3516b6-9ff3-4912-9e27-266d3eb28fe5":
                                //Var_8 = variable;
                                break;
                            case "0cfcbed8-518f-414b-87fc-6baf5d23d321":
                                //Var_9 = variable;
                                break;
                            case "1202f8ba-a03d-4736-994a-ecf9031dfda6":
                                //Var_10 = variable;
                                break;
                        }
                    }
                    file.Close();
                }
                catch { file.Close(); }
            }
        }

        public static bool DoesUpdateFileExist()
        {
            string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            string updateConfig = @"/WVA Scan/Config/";
            
            if (File.Exists(dirPublicDocs + updateConfig))
                return true;
            else
                return false;
        }

        private static string DecryptData(string str)
        {
            List<string> tempList = new List<string>();
            List<string> decryptedString = new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "a","P3A" },
                { "b","3BN" },
                { "c","Jh&" },
                { "d","EL-" },
                { "e","l6z" },
                { "f","ZZ0" },
                { "g","mI-" },
                { "h","91Q" },
                { "i","c^O" },
                { "j","6s^" },
                { "k","6pw" },
                { "l","9~m" },
                { "m","s24" },
                { "n","EXi" },
                { "o","cj4" },
                { "p","PI<" },
                { "q","<xO" },
                { "r","ujp" },
                { "s","%4d" },
                { "t","K1k" },
                { "u","Y1O" },
                { "v","cx<" },
                { "w","xBW" },
                { "x","nI<" },
                { "y","V8L" },
                { "z","!8t" },
                { "0","!mJ" },
                { "1","sKV" },
                { "2","Dmg" },
                { "3","iUh" },
                { "4","k8b" },
                { "5","vF+" },
                { "6","tbM" },
                { "7","I^i" },
                { "8","A9%" },
                { "9","syB" },
                { "/","3eV" },
                { ".","Jxp" },
                { "=","0H&" },
                { "-","Tyl" },
                { "'","0z4" },
                { "?","%pG" },
                { ":","Qez" },
                { " ","+BE" },
                { "!","qs8" },
                { ",","6E+" },
                { ")","C&0" },
                { "(","5~O" },
                { "_","4ER" },
                { "\\","l0l" },
                { "@","LVY" },
                { "#","d0C" },
                { "%","Cs2" },
                { "[","1K5" },
                { "]","r>?" },
                { "|","WoL" },
                { "&","@2-" },
                { "A","-Ao" },
                { "B","s#O" },
                { "C","xl~" },
                { "D","PFE" },
                { "E","oKF" },
                { "F","GoS" },
                { "G","HG!" },
                { "H","tzJ" },
                { "I","VoO" },
                { "J","p8%" },
                { "K","g?X" },
                { "L","%rv" },
                { "M","KLN" },
                { "N","N4h" },
                { "O","R@f" },
                { "P","CdN" },
                { "Q","TqZ" },
                { "R","TG>" },
                { "S","j10" },
                { "T","5xz" },
                { "U","biD" },
                { "V","UKh" },
                { "W","G?*" },
                { "X","9W2" },
                { "Y","fU0" },
                { "Z","51M" }
            };

            int counter = 0;
            string temp = "";
            string unencrypted = "";

            foreach (char item in str)
            {
                temp += item.ToString();
                counter++;
                if (counter == 3)
                {
                    tempList.Add(temp);
                    counter = 0;
                    temp = "";
                }
            }

            foreach (var codedLetter in tempList)
            {
                foreach (var pair in dict)
                {
                    if (codedLetter == pair.Value)
                        decryptedString.Add(pair.Key);
                }
            }

            foreach (var letter in decryptedString)
            {
                unencrypted += letter;
            }

            tempList.Clear();
            decryptedString.Clear();

            return unencrypted;
        }


    }
}
