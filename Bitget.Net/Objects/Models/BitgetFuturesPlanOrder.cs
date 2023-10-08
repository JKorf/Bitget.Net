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
        [JsonProperty("status"), JsonConverter(typeof(EnumConverter))]
        public BitgetPlanOrderStatus Status { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("orderType"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Plan type
        /// </summary>
        [JsonProperty("planType"), JsonConverter(typeof(EnumConverter))]
        public BitgetFuturesPlanType PlanType { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(EnumConverter))]
        public BitgetTradeSide Side { get; set; }
        /// <summary>
        /// Order trigger type
        /// </summary>
        [JsonProperty("triggerType"), JsonConverter(typeof(EnumConverter))]
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
        [JsonProperty("enterPointSource"), JsonConverter(typeof(EnumConverter))]
        public BitgetOrderPlacementSource Source { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tradeSide")]
        public string? TradeSide { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("holdMode"), JsonConverter(typeof(EnumConverter))]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonProperty("reduceOnly")]
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Execute time
        /// </summary>
        [JsonProperty("executeTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ExecuteTime { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("executeSize")]
        public decimal? ExecutedQuantity { get; set; }
    }
}
