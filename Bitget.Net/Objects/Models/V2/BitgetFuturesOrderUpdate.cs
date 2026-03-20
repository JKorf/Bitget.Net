using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures order update
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesOrderUpdate
    {
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
        /// ["<c>tradeId</c>"] Last trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string? LastTradeId { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Quantity filled of last trade
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? LastTradeQuantity { get; set; }
        /// <summary>
        /// ["<c>tradeScope</c>"] Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role? LastTradeRole { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
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
        /// ["<c>notionalUsd</c>"] Estimated USD value of orders
        /// </summary>
        [JsonPropertyName("notionalUsd")]
        public decimal? QuoteQuantity { get; set; }
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
        /// ["<c>pnl</c>"] Profit and loss
        /// </summary>
        [JsonPropertyName("pnl")]
        public decimal ProfitAndLoss { get; set; }
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
        /// ["<c>accBaseVolume</c>"] Total filled quantity
        /// </summary>
        [JsonPropertyName("accBaseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>fillFee</c>"] Last trade fee
        /// </summary>
        [JsonPropertyName("fillFee")]
        public decimal LastTradeFee { get; set; }
        /// <summary>
        /// ["<c>fillFeeCoin</c>"] Last trade fee asset
        /// </summary>
        [JsonPropertyName("fillFeeCoin")]
        public string LastTradeFeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fillNotionalUsd</c>"] Last trade usd value
        /// </summary>
        [JsonPropertyName("fillNotionalUsd")]
        public decimal LastTradeUsdValue { get; set; }
        /// <summary>
        /// ["<c>fillPrice</c>"] Last trade fill price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal? LastTradeFillPrice { get; set; }
        /// <summary>
        /// ["<c>fillTime</c>"] Last trade fill time
        /// </summary>
        [JsonPropertyName("fillTime")]
        public DateTime? LastTradeFillTime { get; set; }
        /// <summary>
        /// ["<c>feeDetail</c>"] Total filled quantity
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetOrderFeeQuantity[] Fees { get; set; } = Array.Empty<BitgetOrderFeeQuantity>();
    }

    /// <summary>
    /// Fee info
    /// </summary>
    public record BitgetOrderFeeQuantity
    {
        /// <summary>
        /// ["<c>feeCoin</c>"] Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fee</c>"] Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
    }
}
