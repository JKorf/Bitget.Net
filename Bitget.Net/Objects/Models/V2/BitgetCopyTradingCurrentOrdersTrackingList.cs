using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Current tracking order list item
    /// </summary>
    public record BitgetCopyTradingCurrentOrdersTrackingItem
    {
        /// <summary>
        /// ["<c>trackingNo</c>"] Track order number
        /// </summary>
        [JsonPropertyName("trackingNo")]
        public string TrackingNo { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>traderId</c>"] Trader user ID
        /// </summary>
        [JsonPropertyName("traderId")]
        public string TraderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>openOrderId</c>"] Opening order ID
        /// </summary>
        [JsonPropertyName("openOrderId")]
        public string OpenOrderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>closeOrderId</c>"] Closing order ID
        /// </summary>
        [JsonPropertyName("closeOrderId")]
        public string CloseOrderId { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>symbol</c>"] Trading pair
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// ["<c>posSide</c>"] Position direction
        /// </summary>
        [JsonPropertyName("posSide")]
        public PositionSide PositionSide { get; set; }

        /// <summary>
        /// ["<c>openLeverage</c>"] Leverage for opening position
        /// </summary>
        [JsonPropertyName("openLeverage")]
        public int OpenLeverage { get; set; }

        /// <summary>
        /// ["<c>openPriceAvg</c>"] Average entry price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal OpenAveragePrice { get; set; }

        /// <summary>
        /// ["<c>openTime</c>"] Position opening time (millisecond timestamp)
        /// </summary>
        [JsonPropertyName("openTime")]
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// ["<c>openSize</c>"] Opening volume
        /// </summary>
        [JsonPropertyName("openSize")]
        public decimal OpenSize { get; set; }

        /// <summary>
        /// ["<c>openFee</c>"] Opening fee (excluding discounts)
        /// </summary>
        [JsonPropertyName("openFee")]
        public decimal OpenFee { get; set; }

        /// <summary>
        /// ["<c>openMarginSz</c>"] Margin amount
        /// </summary>
        [JsonPropertyName("openMarginSz")]
        public decimal OpenMarginSize { get; set; }

        /// <summary>
        /// ["<c>closeAvgPrice</c>"] Margin amount
        /// </summary>
        [JsonPropertyName("closeAvgPrice")]
        public decimal? CloseAveragePrice { get; set; }

        /// <summary>
        /// ["<c>closeSize</c>"] Closing volume
        /// </summary>
        [JsonPropertyName("closeSize")]
        public decimal? CloseSize { get; set; }

        /// <summary>
        /// ["<c>closeTime</c>"] Position closing time (millisecond timestamp)
        /// </summary>
        [JsonPropertyName("closeTime")]
        public DateTime? CloseTime { get; set; }

        /// <summary>
        /// ["<c>traderName</c>"] Trader alias
        /// </summary>
        [JsonPropertyName("traderName")]
        public string TraderName { get; set; } = string.Empty;
    }
}
