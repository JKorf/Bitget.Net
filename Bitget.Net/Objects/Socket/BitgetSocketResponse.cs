using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketResponse
    {
        [JsonPropertyName("event")]
        public string Event { get; set; } = null!;
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
        [JsonPropertyName("topic")]
        public string Topic { get; set; } = null!;
        [JsonPropertyName("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
        [JsonPropertyName("code")]
        public int? Code { get; set; }
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
        [JsonPropertyName("ts")]
        public DateTime? Timestamp { get; set; }

    }

    internal class BitgetSocketResponse<T> : BitgetSocketResponse
    {
        [JsonPropertyName("args")]
        public T Data { get; set; } = default!;
    }
}
