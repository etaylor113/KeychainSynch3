using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Keychain_Synch
{
    public class Order
    {
        public string Time { get; set; }
        public string ActNumber { get; set; }
        public string DeviceID { get; set; }
        public string ConfigFile { get; set; }
        public string[] Barcodes { get; set; }
    }
}
