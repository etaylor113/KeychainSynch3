using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Path
    {
        public static string DirPublicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        public static string DirProgram86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        public static string DirErrorLog = (DirPublicDocs + @"\WVA_Scan\ErrorLog\");
        public static string DirScannerData = (DirPublicDocs + @"\WVA_Scan\ScanData\");
        public static string tempDir = (DirPublicDocs + @"\WVA_Scan\Temp\");        
        public static string appMsiName = @"WVA_Scan_App.msi";
        public static string launchMsiName = @"WVA_Scan_Launcher.msi";
    }
}
