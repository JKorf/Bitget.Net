using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Current tracking order list item
    /// </summary>
    public class BitgetCopyTradingCurrentOrdersTrackingItem
    {
        /// <summary>
        /// Track order number
        /// </summary>
        [JsonPropertyName("trackingNo")]
        public string TrackingNo { get; set; } = string.Empty;

        /// <summary>
        /// Trader user ID
        /// </summary>
        [JsonPropertyName("traderId")]
        public string TraderId { get; set; } = string.Empty;

        /// <summary>
        /// Opening order ID
        /// </summary>
        [JsonPropertyName("openOrderId")]
        public string OpenOrderId { get; set; } = string.Empty;

        /// <summary>
        /// Closing order ID
        /// </summary>
        [JsonPropertyName("closeOrderId")]
        public string CloseOrderId { get; set; } = string.Empty;

        /// <summary>
        /// Trading pair
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Position direction
        /// </summary>
        [JsonPropertyName("posSide")]
        public PositionSide PositionSide { get; set; }

        /// <summary>
        /// Leverage for opening position
        /// </summary>
        [JsonPropertyName("openLeverage")]
        public int OpenLeverage { get; set; }

        /// <summary>
        /// Average entry price
        /// </summary>
        [JsonPropertyName("openPriceAvg")]
        public decimal OpenAveragePrice { get; set; }

        /// <summary>
        /// Position opening time (millisecond timestamp)
        /// </summary>
        [JsonPropertyName("openTime")]
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Opening volume
        /// </summary>
        [JsonPropertyName("openSize")]
        public decimal OpenSize { get; set; }

        /// <summary>
        /// Opening fee (excluding discounts)
        /// </summary>
        [JsonPropertyName("openFee")]
        public decimal OpenFee { get; set; }

        /// <summary>
        /// Margin amount
        /// </summary>
        [JsonPropertyName("openMarginSz")]
        public decimal OpenMarginSize { get; set; }

        /// <summary>
        /// Margin amount
        /// </summary>
        [JsonPropertyName("closeAvgPrice")]
        public decimal? CloseAveragePrice { get; set; }

        /// <summary>
        /// Closing volume
        /// </summary>
        [JsonPropertyName("closeSize")]
        public decimal? CloseSize { get; set; }

        /// <summary>
        /// Position closing time (millisecond timestamp)
        /// </summary>
        [JsonPropertyName("closeTime")]
        public DateTime? CloseTime { get; set; }

        /// <summary>
        /// Trader alias
        /// </summary>
        [JsonPropertyName("traderName")]
        public string TraderName { get; set; } = string.Empty;
    }
}
