using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Plan order update
    /// </summary>
    public class BitgetFuturesPlanOrderUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonProperty("id")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonProperty("cOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("tgtCcy")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("sz")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Actual price
        /// </summary>
        [JsonProperty("actualPx")]
        public decimal? ActualPrice { get; set; }
        /// <summary>
        /// Actual quantity
        /// </summary>
        [JsonProperty("actualSz")]
        public decimal ActualQuantity { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonProperty("triggerPx")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonProperty("ordPx")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("state")]
        public BitgetPlanOrderStatus Status { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("ordType")]
        public BitgetOrderType OrderType { get; set; }
        /// <summary>
        /// Plan type
        /// </summary>
        [JsonProperty("planType")]
        public BitgetPlanOrderEvent? PlanType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonProperty("side")]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonProperty("posSide")]
        public BitgetPositionSide PositionSide { get; set; }
        /// <summary>
        /// Order trigger type
        /// </summary>
        [JsonProperty("triggerPxType")]
        public BitgetTriggerType TriggerType { get; set; }
        /// <summary>
        /// Order trigger type
        /// </summary>
        [JsonProperty("eps")]
        public BitgetOrderPlacementSource Source { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonProperty("tS")]
        public string? TradeSide { get; set; }
        /// <summary>
        /// Hold mode
        /// </summary>
        [JsonProperty("hM")]
        public BitgetHoldMode HoldMode { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("uTime")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// Trigger time
        /// </summary>
        [JsonProperty("triggerTime")]
        public DateTime? TriggerTime { get; set; }
        /// <summary>
        /// Executed quantity
        /// </summary>
        [JsonProperty("executeSize")]
        public decimal? ExecutedQuantity { get; set; }
        /// <summary>
        /// Key id
        /// </summary>
        [JsonProperty("key")]
        public string? KeyId { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        [JsonProperty("version")]
        public string? Version { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty("userId")]
        public string? UserId { get; set; }
    }
}
