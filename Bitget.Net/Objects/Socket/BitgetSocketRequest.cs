using Newtonsoft.Json;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketRequest
    {
        [JsonProperty("op")]
        public string Op { get; set; } = string.Empty;
        [JsonProperty("args")]
        public object[] Args { get; set; } = Array.Empty<object>();
    }
}
