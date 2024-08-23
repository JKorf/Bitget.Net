using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Position leverage info
    /// </summary>
    public record BitgetPositionLeverage
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Long position leverage
        /// </summary>
        [JsonPropertyName("longLeverage")]
        public decimal? LongLeverage { get; set; }
        /// <summary>
        /// Short position leverage
        /// </summary>
        [JsonPropertyName("shortLeverage")]
        public decimal? ShortLeverage { get; set; }
        /// <summary>
        /// Cross margin position leverage
        /// </summary>
        [JsonPropertyName("crossMarginLeverage")]
        public decimal? CrossMarginLeverage { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
    }
}
