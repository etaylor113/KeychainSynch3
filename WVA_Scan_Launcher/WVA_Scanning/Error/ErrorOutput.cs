using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class ErrorOutput
    {
        public string ActNum;
        public string Error;

        public ErrorOutput(string _ActNum, string _Error)
        {
            ActNum = _ActNum;
            Error = _Error;
        }
    }
}
