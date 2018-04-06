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
                var DirAccountNumber = (Path.DirPublicDocs + @"\WVA_Scan\ActNum\");     

                if (Directory.Exists(Path.DirErrorLog) == false)
                    Directory.CreateDirectory(Path.DirErrorLog);

                if (Directory.Exists(Path.DirScannerData) == false)
                    Directory.CreateDirectory(Path.DirScannerData);

                if (Directory.Exists(DirAccountNumber) == false)
                {
                    Directory.CreateDirectory(DirAccountNumber);
                    if (Directory.Exists(DirAccountNumber))
                    {
                        var file = File.Create(Path.DirPublicDocs + DirAccountNumber + "ActNum.txt");
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
                string[] files = Directory.GetFiles(Path.DirPublicDocs + @"\WVA_Scan\ScanData\");
             
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
