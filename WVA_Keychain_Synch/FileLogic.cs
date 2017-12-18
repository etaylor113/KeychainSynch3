using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Keychain_Synch
{
    class FileLogic
    {
        public static void CreateDirs()
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string DirErrorLog = (dirPublicDocs + @"\WVA_Keychain_Synch\ErrorLog\");
                string DirScannerData = (dirPublicDocs + @"\WVA_Keychain_Synch\ScannerData\");
                var DirAccountNumber = (dirPublicDocs + @"\WVA_Keychain_Synch\AccountNumber\");

                try
                {
                    if (Directory.Exists(DirErrorLog) == false)
                        Directory.CreateDirectory(DirErrorLog);
                }
                catch (Exception e1)
                {
                    Errors.Error = e1.ToString();
                    Errors.Error += "(Location: CreateDirs() :e1)";
                    Errors.PrintToErrorLog();
                }

                try
                {
                    if (Directory.Exists(DirScannerData) == false)
                        Directory.CreateDirectory(DirScannerData);
                }
                catch (Exception e2)
                {
                    Errors.Error = e2.ToString();
                    Errors.Error += "(Location: CreateDirs() :e2)";
                    Errors.PrintToErrorLog();
                }

                try
                {
                    if (Directory.Exists(DirAccountNumber) == false)
                    {
                        Directory.CreateDirectory(DirAccountNumber);
                        if (Directory.Exists(DirAccountNumber))
                        {
                            var file = File.Create(dirPublicDocs + @"\WVA_Keychain_Synch\AccountNumber\AccountNumber.txt");
                            file.Close();
                        }
                    }
                }
                catch (Exception e3)
                {
                    Errors.Error = e3.ToString();
                    Errors.Error += "(Location: CreateDirs() :e3)";
                    Errors.PrintToErrorLog();
                }
            }
            catch (Exception e4)
            {
                Errors.Error = e4.ToString();
                Errors.Error += "(Location: CreateDirs() :e4)";
                Errors.PrintToErrorLog();
            }
        }

        public static void CleanDirectory()
        {
            try
            {
                string dirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string[] files = Directory.GetFiles(dirPublicDocs + @"\WVA_Keychain_Synch\ScannerData\");

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    if (fi.CreationTime < DateTime.Now.AddDays(-30))
                    {
                        fi.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Errors.Error = e.ToString();
                Errors.Error += "(Location: CleanDirectory())";
                Errors.PrintToErrorLog();
            }
        }     

    }
}
