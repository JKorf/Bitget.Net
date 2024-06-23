using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketArgs
    {
        [JsonProperty("instType")]
        [JsonPropertyName("instType")]
        public string IntstrumentType { get; set; } = null!;
        [JsonProperty("channel")]
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = null!;
        [JsonProperty("instId")]
        [JsonPropertyName("instId")]
        public string InstrumentId { get; set; } = null!;
    }

    internal class BitgetSocketUpdate
    {
        [JsonProperty("action")]
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
        [JsonProperty("arg")]
        [JsonPropertyName("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
    }

    internal class BitgetSocketEvent
    {
        [JsonProperty("event")]
        [JsonPropertyName("event")]
        public string Event { get; set; } = null!;
        [JsonProperty("arg")]
        [JsonPropertyName("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
        [JsonProperty("op")]
        [JsonPropertyName("op")]
        public string Op { get; set; } = null!;
        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public int? Code { get; set; }
        [JsonProperty("msg")]
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
    }

    internal class BitgetSocketUpdate<T> : BitgetSocketUpdate
    {
        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;
    }
}
