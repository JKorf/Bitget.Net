using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Bitget futures order
    /// </summary>
    public class BitgetFuturesOrder
    {
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order quantity (base asset when orderType=limit; quote asset when orderType=market)
        /// </summary>
        [JsonProperty("size")]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonProperty("filledQty")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Average price
        /// </summary>
        [JsonProperty("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        public BitgetFuturesOrderSide Side { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonProperty("timeInForce")]
        public BitgetTimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Total profits
        /// </summary>
        [JsonProperty("totalProfits")]
        public decimal TotalProfits { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonProperty("posSide")]
        public BitgetPositionSide PositionSide { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Filled value
        /// </summary>
        [JsonProperty("filledAmount")]
        public decimal FilledValue { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("marginMode")]
        public BitgetMarginMode MarginMode { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonProperty("reduceOnly")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("enterPointSource")]
        public BitgetOrderPlacementSource PlaceSource { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode")]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType")]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Order source
        /// </summary>
        [JsonProperty("orderSource")]
        public string OrderSource { get; set; } = string.Empty;
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tradeSide")]
        public string TradeSide { get; set; } = string.Empty;
        /// <summary>
        /// Creation time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("state")]
        public BitgetOrderStatus Status { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("presetStopLossPrice")]
        public decimal StopLossPrice { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("presetTakeProfitPrice")]
        public decimal TakeProfitPrice { get; set; }
    }
}
