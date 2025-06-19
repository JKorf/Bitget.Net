using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Auto deleverage rank
    /// </summary>
    public record BitgetFuturesAdlRank
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Auto deleverage rank
        /// </summary>
        [JsonPropertyName("adlRank")]
        public decimal AdlRank { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide HoldSide { get; set; }
    }
}
