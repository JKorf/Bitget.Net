using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// User trade update
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesUserTradeUpdate
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
        /// Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Profit
        /// </summary>
        [JsonPropertyName("profit")]
        public decimal Profit { get; set; }
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
        /// Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide TradeSide { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role Role { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetUserTradeFee[] Fees { get; set; } = null!;
    }
}
