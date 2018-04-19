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
            Program = "WVA_Scan_Launcher";
            Version = GetVersion(); 
        }

        public string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            return version;
        }
    }
}
