using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class Path
    {
        public static string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\";
        public static string programx86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\";
        public static string publicDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\";
        public static string app = @"WVA Scan\WVA_Scan\Release\WVA_Scan_App.exe";
        public static string DirErrorLog = (publicDocs + @"\WVA_Scan\ErrorLog\");
        public static string tempDir = @"WVA_Scan\Temp\";
        public static string msiName = @"WVA_Scan_App.msi"; 
    }
}
