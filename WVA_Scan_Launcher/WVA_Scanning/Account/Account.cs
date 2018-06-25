using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan_Launcher
{
    class Account
    {
        public static string GetAccountNumber()
        {
            try
            {
                string accountNumber = File.ReadLines(Path.publicDocs + @"\WVA_Scan\ActNum\ActNum.txt").Skip(0).Take(1).First();

                return accountNumber;
            }
            catch
            {
                return "";
            }
        }
    }
}
