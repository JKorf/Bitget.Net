using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    internal class BitgetResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
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