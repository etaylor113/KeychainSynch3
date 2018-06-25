using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WVA_Scan_Launcher
{
    class JSON_Payload
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
