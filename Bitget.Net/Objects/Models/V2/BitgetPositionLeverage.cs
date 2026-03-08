using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position leverage info
    /// </summary>
    [SerializationModel]
    public record BitgetPositionLeverage
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>longLeverage</c>"] Long position leverage
        /// </summary>
        [JsonPropertyName("longLeverage")]
        public decimal? LongLeverage { get; set; }
        /// <summary>
        /// ["<c>shortLeverage</c>"] Short position leverage
        /// </summary>
        [JsonPropertyName("shortLeverage")]
        public decimal? ShortLeverage { get; set; }
        /// <summary>
        /// ["<c>crossMarginLeverage</c>"] Cross margin position leverage
        /// </summary>
        [JsonPropertyName("crossMarginLeverage")]
        public decimal? CrossMarginLeverage { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
    }
}
