using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Objects.Socket
{
    public class BitgetSocketArgs
    {
        [JsonProperty("instType")]
        public string IntstrumentType { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("instId")]
        public string InstrumentId { get; set; }
    }

    public class BitgetSocketUpdate<T>
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("arg")]
        public BitgetSocketArgs Args { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
