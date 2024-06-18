using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    internal class BitgetResponse
    {
        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
        [JsonPropertyName("requestTime")]
        public DateTime RequestTime { get; set; }
    }

    internal class BitgetResponse<T> : BitgetResponse
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
