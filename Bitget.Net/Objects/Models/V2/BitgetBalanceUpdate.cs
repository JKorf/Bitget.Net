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
        /// ["<c>locked</c>"] Frozen quantity
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal? Locked { get; set; }
        /// <summary>
        /// ["<c>limitAvailable</c>"] Limit available
        /// </summary>
        [JsonPropertyName("limitAvailable")]
        public decimal? LimitAvailable { get; set; }
        /// <summary>
        /// ["<c>usdtValue</c>"] Usdt value
        /// </summary>
        [JsonPropertyName("usdtValue")]
        public decimal UsdtValue { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime UpdateTime { get; set; }
    }
}
