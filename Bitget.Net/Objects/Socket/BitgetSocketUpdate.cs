using Newtonsoft.Json;

namespace Bitget.Net.Objects.Socket
{
    internal class BitgetSocketArgs
    {
        [JsonProperty("instType")]
        public string IntstrumentType { get; set; } = null!;
        [JsonProperty("channel")]
        public string Channel { get; set; } = null!;
        [JsonProperty("instId")]
        public string InstrumentId { get; set; } = null!;
    }

    internal class BitgetSocketUpdate
    {
        [JsonProperty("action")]
        public string Action { get; set; } = null!;
        [JsonProperty("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
    }

    internal class BitgetSocketEvent
    {
        [JsonProperty("event")]
        public string Event { get; set; } = null!;
        [JsonProperty("arg")]
        public BitgetSocketArgs Args { get; set; } = null!;
        [JsonProperty("op")]
        public string Op { get; set; } = null!;
        [JsonProperty("code")]
        public int? Code { get; set; }
        [JsonProperty("msg")]
        public string? Message { get; set; }
    }

    internal class BitgetSocketUpdate<T> : BitgetSocketUpdate
    {
        [JsonProperty("data")]
        public T Data { get; set; } = default!;
    }
}
