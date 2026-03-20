using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order update
    /// </summary>
    [SerializationModel]
    public record BitgetOrderUpdate
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
        /// ["<c>price</c>"] Order price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Order amount. When Side = Buy, it represents the amount of quote asset; When Side = Sell, it represents the amount of base asset.
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>newSize</c>"] Order quantity
        /// </summary>
        [JsonPropertyName("newSize")]
        public decimal? OrderQuantity { get; set; }
        /// <summary>
        /// ["<c>notional</c>"] Buy value for market order
        /// </summary>
        [JsonPropertyName("notional")]
        public decimal? Notional { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        [JsonPropertyName("ordType")]
        internal OrderType OrderTypeInt { set => OrderType = value; }
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>force</c>"] Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// ["<c>fillPrice</c>"] Last trade price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal? LastTradePrice { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Number of latest filled orders
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal? BaseVolume { get; set; }
        /// <summary>
        /// ["<c>tradeId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string? TradeId { get; set; }
        /// <summary>
        /// ["<c>fillTime</c>"] Last trade time
        /// </summary>
        [JsonPropertyName("fillTime")]
        public DateTime? LastTradeTime { get; set; }
        /// <summary>
        /// ["<c>fillFee</c>"] Last trade fee
        /// </summary>
        [JsonPropertyName("fillFee")]
        public decimal? LastTradeFee { get; set; }
        /// <summary>
        /// ["<c>fillFeeCoin</c>"] Fee asset
        /// </summary>
        [JsonPropertyName("fillFeeCoin")]
        public string? FeeAsset { get; set; }
        /// <summary>
        /// ["<c>tradeScope</c>"] Last trade role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role? LastTradeRole { get; set; }
        /// <summary>
        /// ["<c>accBaseVolume</c>"] Total quantity filled
        /// </summary>
        [JsonPropertyName("accBaseVolume")]
        public decimal? QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Average trade price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal? AveragePrice { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Entry point
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>feeDetail</c>"] Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetOrderUpdateFee[] Fees { get; set; } = Array.Empty<BitgetOrderUpdateFee>();
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>uTime</c>"] Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }

    /// <summary>
    /// Trade fee
    /// </summary>
    [SerializationModel]
    public record BitgetOrderUpdateFee
    {
        /// <summary>
        /// ["<c>fee</c>"] Fee
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>
        /// ["<c>feeCoin</c>"] Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
    }
}
