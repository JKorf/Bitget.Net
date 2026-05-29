using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketArgs
    {
        [JsonPropertyName("instType")]
        public string IntstrumentType { get; set; } = null!;
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = null!;
        [JsonPropertyName("topic")]
        public string Topic
        {
            get => Channel;
            set => Channel = value;
        }
        [JsonPropertyName("instId")]
        public string InstrumentId { get; set; } = null!;
        [JsonPropertyName("symbol")]
        public string Symbol
        {
            get => InstrumentId;
            set => InstrumentId = value;
        }
    }

    internal class BitgetSocketUpdate
    {
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
        [JsonPropertyName("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
    }

    internal class BitgetSocketEvent
    {
        [JsonPropertyName("event")]
        public string Event { get; set; } = null!;
        [JsonPropertyName("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
        [JsonPropertyName("op")]
        public string Op { get; set; } = null!;
        [JsonPropertyName("code")]
        public int? Code { get; set; }
        [JsonPropertyName("msg")]
        public string? Message { get; set; }
    }

    internal class BitgetSocketUpdate<T> : BitgetSocketUpdate
    {
        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }
}
