using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Balance update
    /// </summary>
    [SerializationModel]
    public record BitgetBalanceUpdate
    {
        /// <summary>
        /// Asset name
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Available quantity
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Frozen quantity
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal? Frozen { get; set; }
        /// <summary>
        /// Frozen quantity
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// Limit available
        /// </summary>
        [JsonPropertyName("limitAvailable")]
        public decimal? LimitAvailable { get; set; }
        /// <summary>
        /// Usdt value
        /// </summary>
        [JsonPropertyName("usdtValue")]
        public decimal UsdtValue { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }
}
