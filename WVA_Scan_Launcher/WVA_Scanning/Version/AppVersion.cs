using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class AppVersion
    {
        public static string GetVersion(string path)
        {
            string version = AssemblyName.GetAssemblyName(path).Version.ToString();
            return version;
        }
    }
}
