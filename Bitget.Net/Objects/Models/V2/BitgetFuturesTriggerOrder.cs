using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures orders
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesTriggerOrders
    {
        /// <summary>
        /// ["<c>endId</c>"] End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>entrustedList</c>"] Order list
        /// </summary>
        [JsonPropertyName("entrustedList")]
        public BitgetFuturesTriggerOrder[] Orders { get; set; } = Array.Empty<BitgetFuturesTriggerOrder>();
    }

    /// <summary>
    /// Future order info
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesTriggerOrder
    {
        /// <summary>
        /// ["<c>planType</c>"] Plan type
        /// </summary>
        [JsonPropertyName("planType")]
        public TriggerOrderPlanType PlanType { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>executeOrderId</c>"] Executed order id
        /// </summary>
        [JsonPropertyName("executeOrderId")]
        public string? ExecutedOrderId { get; set; }
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>executePrice</c>"] Execute price
        /// </summary>
        [JsonPropertyName("executePrice")]
        public decimal? ExecutePrice { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Average price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Quantity filled
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? QuantityFilled { get; set; }
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
        /// ["<c>planStatus</c>"] Trigger order status
        /// </summary>
        [JsonPropertyName("planStatus")]
        public TriggerOrderStatus? Status { get; set; }
        /// <summary>
        /// ["<c>callbackRatio</c>"] Callback ratio
        /// </summary>
        [JsonPropertyName("callbackRatio")]
        public decimal? CallbackRatio { get; set; }
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
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode? MarginMode { get; set; }
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
        /// ["<c>orderSource</c>"] Source
        /// </summary>
        [JsonPropertyName("orderSource")]
        public string Source { get; set; } = string.Empty;

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
        /// ["<c>stopSurplusExecutePrice</c>"] Take profit execute price
        /// </summary>
        [JsonPropertyName("stopSurplusExecutePrice")]
        public decimal? TakeProfitExecutePrice { get; set; }
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
        /// ["<c>stopLossExecutePrice</c>"] Stop loss execute price
        /// </summary>
        [JsonPropertyName("stopLossExecutePrice")]
        public decimal? StopLossExecutePrice { get; set; }
        /// <summary>
        /// ["<c>stopLossTriggerType</c>"] Stop loss trigger type
        /// </summary>
        [JsonPropertyName("stopLossTriggerType")]
        public TriggerPriceType? StopLossTriggerType { get; set; }
    }
}
