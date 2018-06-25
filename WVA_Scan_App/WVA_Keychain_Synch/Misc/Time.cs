using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Time
    {
        public string GetTime()
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                return time.ToString();
            }
            catch (Exception error)
            {
                Error err = new Error();
                err.ReportError(error.ToString());
                return "TIME ERROR!";
            }
        }

    }
}
