using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class FileAction
    {
        public static void CreateDirs()
        {
            try
            {
                CreateScanDataDir();
                CreateActNumFiles();
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }

        public static void CreateScanDataDir()
        {
            // Create ScanData Dir
            if (!Directory.Exists(Paths.DirScannerData))
                Directory.CreateDirectory(Paths.DirScannerData);
        }

        public static void CreateActNumFiles()
        {
            string DirActnum = (Paths.DirPublicDocs + @"\WVA_Scan\ActNum\");
            string ActNumTXT = DirActnum + "ActNum.txt";

            // Create ActNum Dir
            if (!Directory.Exists(DirActnum))
                Directory.CreateDirectory(DirActnum);

            // Create ActNum.txt file            
            if (!File.Exists(ActNumTXT))
            {
                var file = File.Create(ActNumTXT);
                file.Close();
            }
        }

        public static void CleanDirectory()
        {
            try
            {
                string[] files = Directory.GetFiles(Paths.DirPublicDocs + @"\WVA_Scan\ScanData\");

                foreach (string file in files)
                {
                    FileInfo f = new FileInfo(file);

                    if (f.CreationTime < DateTime.Now.AddDays(-30))
                    {
                        f.Delete();
                    }
                }
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
            }
        }
    }
}
