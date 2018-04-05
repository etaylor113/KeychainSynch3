using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Errors
    {    
        public static void PrintToLog(string error)
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string DirErrorLog = (dirPublicDocs + @"\WVA_Scan\ErrorLog\");

                if (!Directory.Exists(DirErrorLog)) { }
                Directory.CreateDirectory(DirErrorLog);

                if (!File.Exists(DirErrorLog + @"\ErrorLog.txt"))
                {
                    var file = File.Create(DirErrorLog + @"ErrorLog.txt");
                    file.Close();
                }

                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter((DirErrorLog + @"\ErrorLog.txt"), true))
                {
                    writer.WriteLine("(TIME: " + time + ")");
                    writer.WriteLine("(ERROR:" + error + ")");
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            catch { };
        }
    }
}
