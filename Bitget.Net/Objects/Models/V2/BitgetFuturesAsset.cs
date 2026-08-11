using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures Asset
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesAsset
    {
        /// <summary>
        /// Asset Name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Coin { get; set; }
        /// <summary>
        /// Available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}
