using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Isolated tier configuration
    /// </summary>
    public record BitgetIsolatedTierConfig
    {
        /// <summary>
        /// Tier
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Base asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("baseMaxBorrowableAmount")]
        public decimal BaseMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// Quote asset max borrowable quantity
        /// </summary>
        [JsonPropertyName("quoteMaxBorrowableAmount")]
        public decimal QuoteMaxBorrowableQuantity { get; set; }
        /// <summary>
        /// Maintain margin rate
        /// </summary>
        [JsonPropertyName("maintainMarginRate")]
        public decimal MaintainMarginRate { get; set; }
        /// <summary>
        /// Initial margin rate
        /// </summary>
        [JsonPropertyName("initRate")]
        public decimal InitialMarginRate { get; set; }
    }


}
