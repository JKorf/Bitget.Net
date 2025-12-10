using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models
{
    internal record BitgetResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
        [JsonPropertyName("requestTime")]
        public DateTime RequestTime { get; set; }
    }

    internal record BitgetResponse<T> : BitgetResponse
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}