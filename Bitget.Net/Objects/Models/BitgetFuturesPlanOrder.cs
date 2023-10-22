using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Plan order
    /// </summary>
    public class BitgetFuturesPlanOrder
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
        /// Execute order id
        /// </summary>
        [JsonProperty("executeOrderId")]
        public string? ExecuteOrderId { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Execution price
        /// </summary>
        [JsonProperty("executePrice")]
        public decimal? ExecutePrice { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPrice")]
        public decimal TriggerPrice { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        public BitgetPlanOrderStatus Status { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType")]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Plan type
        /// </summary>
        [JsonProperty("planType")]
        public BitgetFuturesPlanType PlanType { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("side")]
        public BitgetTradeSide Side { get; set; }
        /// <summary>
        /// Order trigger type
        /// </summary>
        [JsonProperty("triggerType")]
        public BitgetTriggerType TriggerType { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonProperty("presetTakeProfitPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonProperty("presetTakeLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// PlanType is "MovingPlan", "1" means 1.0% price correction, two decimal places
        /// </summary>
        [JsonProperty("rangeRate")]
        public decimal? RangeRate { get; set; }
        /// <summary>
        /// Order trigger type
        /// </summary>
        [JsonProperty("enterPointSource")]
        public BitgetOrderPlacementSource Source { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tradeSide")]
        public string? TradeSide { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode")]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonProperty("reduceOnly")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Execute time
        /// </summary>
        [JsonProperty("executeTime")]
        public DateTime? ExecuteTime { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("executeSize")]
        public decimal? ExecutedQuantity { get; set; }
    }
}
