using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class FileLogic
    {
        public static void CreateDirs()
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string DirErrorLog = (dirPublicDocs + @"\WVA_Scan\ErrorLog\");
                string DirScannerData = (dirPublicDocs + @"\WVA_Scan\ScanData\");
                var DirAccountNumber = (dirPublicDocs + @"\WVA_Scan\ActNum\");     

                if (Directory.Exists(DirErrorLog) == false)
                    Directory.CreateDirectory(DirErrorLog);

                if (Directory.Exists(DirScannerData) == false)
                    Directory.CreateDirectory(DirScannerData);

                if (Directory.Exists(DirAccountNumber) == false)
                {
                    Directory.CreateDirectory(DirAccountNumber);
                    if (Directory.Exists(DirAccountNumber))
                    {
                        var file = File.Create(dirPublicDocs + DirAccountNumber + "ActNum.txt");
                        file.Close();
                    }
                }
            }     
            catch (Exception e)
            {
                Errors.PrintToLog(e.ToString());
            }
        }

        public static void CleanDirectory()
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string[] files = Directory.GetFiles(dirPublicDocs + @"\WVA_Scan\ScanData\");
             
                foreach (string file in files)
                {
                    FileInfo f = new FileInfo(file);

                    if (f.CreationTime < DateTime.Now.AddDays(-30))
                    {
                        f.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Errors.PrintToLog(e.ToString());
            }
        }  
              

    }
}
