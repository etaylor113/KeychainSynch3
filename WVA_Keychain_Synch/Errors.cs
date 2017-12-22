﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Keychain_Synch
{
    class Errors
    {
        public static string Error { get; set; }

        public static void PrintToErrorLog()
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string DirErrorLog = (dirPublicDocs + @"\WVA_Keychain_Synch\ErrorLog\");

                if (!Directory.Exists(DirErrorLog)) { }
                Directory.CreateDirectory(DirErrorLog);

                if (!File.Exists(DirErrorLog + @"\ErrorLog.txt"))
                {
                    var file = File.Create(DirErrorLog + @"\ErrorLog.txt");
                    file.Close();
                }

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter((DirErrorLog + @"\ErrorLog.txt"), true))
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    writer.Write("(TIME: " + time +"\n" + Error);
                    writer.Close();
                }

                Error = "";
            }
            catch { };
        }

    }
}
