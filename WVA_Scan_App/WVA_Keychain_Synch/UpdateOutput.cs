using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class UpdateOutput
    {
        public string Version;
        public string Program;

        public UpdateOutput()
        {
            Program = "WVA_Scan_Launcher";
            Version = GetVersion();
        }

        public string GetVersion()
        {
            string path = Path.DirProgram86 + @"\WVA Scan\Launcher\WVA_Scan_Launcher.exe";
            string version = AssemblyName.GetAssemblyName(path).Version.ToString();
            return version;
        }
    }
}
