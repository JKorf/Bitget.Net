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
        /// ["<c>endId</c>"] End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>entrustedList</c>"] Order list
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
        /// ["<c>baseVolume</c>"] Quantity filled
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// ["<c>fee</c>"] Fee paid
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal? Fee { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        [JsonInclude, JsonPropertyName("state")]
        internal OrderStatus State { set => Status = value; get => Status; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>force</c>"] Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// ["<c>totalProfits</c>"] Total profit and loss
        /// </summary>
        [JsonPropertyName("totalProfits")]
        public decimal? TotalProfitAndLoss { get; set; }
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
        /// ["<c>presetStopSurplusPrice</c>"] Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// ["<c>presetStopLossPrice</c>"] Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>
        /// ["<c>quoteVolume</c>"] Quote quantity filled
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal? QuoteQuantityFilled { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>leverage</c>"] Leverage
        /// </summary>
        [JsonPropertyName("leverage")]
        public decimal Leverage { get; set; }
        /// <summary>
        /// ["<c>liqPrice</c>"] Liquidation price (only available for historic orders)
        /// </summary>
        [JsonPropertyName("liqPrice")]
        public decimal? LiquidationPrice { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode MarginMode { get; set; }
        /// <summary>
        /// ["<c>reduceOnly</c>"] Reduce only
        /// </summary>
        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }
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
    }
}
