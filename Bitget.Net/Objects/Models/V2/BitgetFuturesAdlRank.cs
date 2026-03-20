using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Auto deleverage rank
    /// </summary>
    public record BitgetFuturesAdlRank
    {
        /// <summary>
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>adlRank</c>"] Auto deleverage rank
        /// </summary>
        [JsonPropertyName("adlRank")]
        public decimal AdlRank { get; set; }
        /// <summary>
        /// ["<c>holdSide</c>"] Position side
        /// </summary>
        [JsonPropertyName("holdSide")]
        public PositionSide PositionSide { get; set; }
    }
}
