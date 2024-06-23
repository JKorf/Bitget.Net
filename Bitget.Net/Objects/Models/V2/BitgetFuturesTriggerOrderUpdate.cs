using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Future trigger order update
    /// </summary>
    public record BitgetFuturesTriggerOrderUpdate
    {
        /// <summary>
        /// Plan type
        /// </summary>
        [JsonPropertyName("planType")]
        public PlanType PlanType { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("actualSize")]
        public decimal ActualQuantity { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// Trigger type
        /// </summary>
        [JsonPropertyName("triggerType")]
        public TriggerPriceType? TriggerType { get; set; }
        /// <summary>
        /// Trigger time
        /// </summary>
        [JsonPropertyName("triggerTime")]
        public DateTime? TriggerTime { get; set; }
        /// <summary>
        /// Trigger order status
        /// </summary>
        [JsonPropertyName("status")]
        public TriggerOrderStatus? Status { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Position side
        /// </summary>
        [JsonPropertyName("posSide")]
        public PositionSide PositionSide { get; set; }
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;        
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide? TradeSide { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode? PositionMode { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// Take profit trigger price
        /// </summary>
        [JsonPropertyName("stopSurplusTriggerPrice")]
        public decimal? TakeProfitTriggerPrice { get; set; }
        /// <summary>
        /// Take profit trigger type
        /// </summary>
        [JsonPropertyName("stopSurplusTriggerType")]
        public TriggerPriceType? TakeProfitTriggerType { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// Stop loss trigger price
        /// </summary>
        [JsonPropertyName("stopLossTriggerPrice")]
        public decimal? StopLossTriggerPrice { get; set; }
        /// <summary>
        /// Stop loss trigger type
        /// </summary>
        [JsonPropertyName("stopLossTriggerType")]
        public TriggerPriceType? StopLossTriggerType { get; set; }
    }
}
