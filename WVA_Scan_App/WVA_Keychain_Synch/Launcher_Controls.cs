using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Launcher_Controls
    {
        public static void Install()
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/i \"C:\\Users\\Public\\Documents\\WVA_Scan\\Temp\\WVA_Scan_Launcher.msi\"/passive";
            p.Start();
            p.WaitForExit();
        }

        public static void Uninstall()
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/x \"C:\\Users\\Public\\Documents\\WVA_Scan\\Temp\\WVA_Scan_Launcher.msi\"/passive";
            p.Start();
            p.WaitForExit();
        }     

        public static void CreateDirs()
        {
            Directory.CreateDirectory(Path.DirPublicDocs + Path.tempDir);
        }

        public static string GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        public static string GetActNum()
        {
            string ActNum = "";

            return ActNum;
        }

        public static void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
