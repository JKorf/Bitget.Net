using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Future trigger order update
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesTriggerOrderUpdate
    {
        /// <summary>
        /// ["<c>planType</c>"] Plan type
        /// </summary>
        [JsonPropertyName("planType")]
        public UpdatePlanType PlanType { get; set; }
        /// <summary>
        /// ["<c>instId</c>"] Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>actualSize</c>"] Quantity
        /// </summary>
        [JsonPropertyName("actualSize")]
        public decimal ActualQuantity { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>triggerPrice</c>"] Trigger price
        /// </summary>
        [JsonPropertyName("triggerPrice")]
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// ["<c>triggerType</c>"] Trigger type
        /// </summary>
        [JsonPropertyName("triggerType")]
        public TriggerPriceType? TriggerType { get; set; }
        /// <summary>
        /// ["<c>triggerTime</c>"] Trigger time
        /// </summary>
        [JsonPropertyName("triggerTime")]
        public DateTime? TriggerTime { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Trigger order status
        /// </summary>
        [JsonPropertyName("status")]
        public TriggerOrderStatus? Status { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>posSide</c>"] Position side
        /// </summary>
        [JsonPropertyName("posSide")]
        public PositionSide PositionSide { get; set; }
        /// <summary>
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;        
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tradeSide</c>"] Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide? TradeSide { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode? PositionMode { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Last update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// ["<c>presetStopSurplusPrice</c>"] Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// ["<c>stopSurplusTriggerPrice</c>"] Take profit trigger price
        /// </summary>
        [JsonPropertyName("stopSurplusTriggerPrice")]
        public decimal? TakeProfitTriggerPrice { get; set; }
        /// <summary>
        /// ["<c>stopSurplusTriggerType</c>"] Take profit trigger type
        /// </summary>
        [JsonPropertyName("stopSurplusTriggerType")]
        public TriggerPriceType? TakeProfitTriggerType { get; set; }
        /// <summary>
        /// ["<c>presetStopLossPrice</c>"] Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// ["<c>stopLossTriggerPrice</c>"] Stop loss trigger price
        /// </summary>
        [JsonPropertyName("stopLossTriggerPrice")]
        public decimal? StopLossTriggerPrice { get; set; }
        /// <summary>
        /// ["<c>stopLossTriggerType</c>"] Stop loss trigger type
        /// </summary>
        [JsonPropertyName("stopLossTriggerType")]
        public TriggerPriceType? StopLossTriggerType { get; set; }
    }
}
