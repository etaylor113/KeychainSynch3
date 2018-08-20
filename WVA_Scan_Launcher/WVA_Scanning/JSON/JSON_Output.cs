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
        public string ActNum;

        public JSON_Output()
        {
            Program = "WVA_Scan_App";
            ActNum = Account.GetAccountNumber();
            Version = AppVersion.GetVersion(Path.programx86 + @"\WVA Scan\WVA_Scan\Release\WVA_Scan_App.exe");
        }   
    }
}
