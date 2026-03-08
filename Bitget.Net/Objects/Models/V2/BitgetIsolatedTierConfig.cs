using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Isolated tier configuration
    /// </summary>
    [SerializationModel]
    public record BitgetIsolatedTierConfig
    {
        /// <summary>
        /// ["<c>tier</c>"] Tier
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseMaxBorrowableAmount</c>"] Base asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("baseMaxBorrowableAmount")]
        public decimal BaseMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>quoteMaxBorrowableAmount</c>"] Quote asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("quoteMaxBorrowableAmount")]
        public decimal QuoteMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// ["<c>maintainMarginRate</c>"] Maintain margin rate
        /// </summary>
        [JsonPropertyName("maintainMarginRate")]
        public decimal MaintainMarginRate { get; set; }
        /// <summary>
        /// ["<c>initRate</c>"] Initial margin rate
        /// </summary>
        [JsonPropertyName("initRate")]
        public decimal InitialMarginRate { get; set; }
    }


}
