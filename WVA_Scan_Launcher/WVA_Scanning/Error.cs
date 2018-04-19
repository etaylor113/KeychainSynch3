using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class Error
    {
        public static void PrintError(string error)
        {
            try
            {
                if (!Directory.Exists(Path.DirErrorLog)) { }
                Directory.CreateDirectory(Path.DirErrorLog);

                if (!File.Exists(Path.DirErrorLog + @"\ErrorLog.txt"))
                {
                    var file = File.Create(Path.DirErrorLog + @"ErrorLog.txt");
                    file.Close();
                }

                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter((Path.DirErrorLog + @"ErrorLog.txt"), true))
                {
                    writer.WriteLine("");
                    writer.WriteLine("-----------------------------------------------------------------------------------");
                    writer.WriteLine("");
                    writer.WriteLine("(TIME: " + time + ")");
                    writer.WriteLine("(ERROR:" + error + ")");
                    writer.WriteLine("");
                    writer.WriteLine("-----------------------------------------------------------------------------------");
                    writer.WriteLine("");
                    writer.Close();
                }
            }
            catch { };
        }
    }
}
