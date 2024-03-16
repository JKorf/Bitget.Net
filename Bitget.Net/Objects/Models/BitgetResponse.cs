using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    internal class BitgetResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string? Message { get; set; }
        public DateTime RequestTime { get; set; }
    }

    internal class BitgetResponse<T> : BitgetResponse
    {
        public T? Data { get; set; }
    }
}
