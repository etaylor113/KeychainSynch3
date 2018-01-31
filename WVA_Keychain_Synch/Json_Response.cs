using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Keychain_Synch
{
    class Json_Response
    {
        [JsonProperty("Status")]
        public static string Status { get; set; }

        [JsonProperty("Message")]
        public static string Message { get; set; }
    }
}
