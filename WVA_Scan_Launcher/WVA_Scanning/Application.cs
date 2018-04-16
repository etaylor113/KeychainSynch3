using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Main
{
    class App
    {
        public static void Install()
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/i \"C:\\Users\\Public\\Documents\\WVA_Scan\\Temp\\WVA_Scan_App.msi\"/passive";
            p.Start();
            p.WaitForExit();
        }

        public static void Uninstall()
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec.exe";
            p.StartInfo.Arguments = "/x \"C:\\Users\\Public\\Documents\\WVA_Scan\\Temp\\WVA_Scan_App.msi\"/passive";
            p.Start();
            p.WaitForExit();
        }

        public static bool DoesExist()
        {
            if (File.Exists(Path.programx86 + Path.app))
                return true;
            else
                return false;
        }

        public static void CreateDirs()
        {
            Directory.CreateDirectory(Path.publicDocs + Path.tempDir);
        }

        public static void LaunchWVA_Scan()
        {
            Process.Start(Path.programx86 + Path.app);
        }

        public static void Close()
        {
            Environment.Exit(0);
        }
    }
}
