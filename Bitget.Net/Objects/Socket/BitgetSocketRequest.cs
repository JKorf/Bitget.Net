using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketRequest
    {
        [JsonProperty("op")]
        public string Op { get; set; } = string.Empty;
        [JsonProperty("args")]
        public Dictionary<string, string>[] Args { get; set; } = Array.Empty<Dictionary<string, string>>();
    }
}
