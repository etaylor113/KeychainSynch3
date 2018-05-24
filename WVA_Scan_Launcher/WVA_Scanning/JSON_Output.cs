using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class JSON_Output
    {
        public string Version;
        public string Program;

        public JSON_Output()
        {
            Program = "WVA_Scan_App";
            Version = GetVersion(); 
        }

        public string GetVersion()
        {
            string path = Path.programx86 + @"\WVA Scan\WVA_Scan\Release\WVA_Scan_App.exe";
            string version = AssemblyName.GetAssemblyName(path).Version.ToString();
            return version;
        }
    }
}
