using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketRequest
    {
        [JsonProperty("op")]
        public string Op { get; set; }
        [JsonProperty("args")]
        public object[] Args { get; set; }
    }
}
