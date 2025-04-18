using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketRequest
    {
        [JsonPropertyName("op")]
        public string Op { get; set; } = string.Empty;
        [JsonPropertyName("args")]
        public Dictionary<string, string>[] Args { get; set; } = Array.Empty<Dictionary<string, string>>();
    }
}
