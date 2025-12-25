using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures orders
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesOrders
    {
        /// <summary>
        /// End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// Order list
        /// </summary>
        [JsonPropertyName("entrustedList")]
        public BitgetFuturesOrder[] Orders { get; set; } = Array.Empty<BitgetFuturesOrder>();
    }

    /// <summary>
    /// Future order info
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesOrder
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
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
        /// Quantity filled
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// Fee paid
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        [JsonInclude, JsonPropertyName("state")]
        internal OrderStatus State { set => Status = value; get => Status; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Total profit and loss
        /// </summary>
        [JsonPropertyName("totalProfits")]
        public decimal? TotalProfitAndLoss { get; set; }
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
        /// Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// Quote quantity filled
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// Liquidation price (only available for historic orders)
        /// </summary>
        [JsonPropertyName("liqPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// Reduce only
        /// </summary>
        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }
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
        /// Source
        /// </summary>
        [JsonPropertyName("orderSource")]
        public string Source { get; set; } = string.Empty;

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
    }
}
