using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Balance info
    /// </summary>
    [SerializationModel]
    public record BitgetBalance
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>available</c>"] Available quantity
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>frozen</c>"] Frozen quantity
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal? Frozen { get; set; }
        /// <summary>
        /// ["<c>usdtValue</c>"] Usdt value
        /// </summary>
        [JsonPropertyName("usdtValue")]
        public decimal UsdtValue { get; set; }
    }
}
