using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    [SerializationModel]
    internal record BitgetServerTime
    {
        [JsonPropertyName("serverTime")]
        public DateTime ServerTime { get; set; }
    }
}
