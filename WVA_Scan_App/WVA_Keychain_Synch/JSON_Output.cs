﻿using System;
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
            Program = "WVA_Scan_App";
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
