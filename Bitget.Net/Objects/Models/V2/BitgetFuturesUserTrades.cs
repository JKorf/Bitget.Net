using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures user trades
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesUserTrades
    {
        /// <summary>
        /// ["<c>endId</c>"] End id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fillList</c>"] Trades
        /// </summary>
        [JsonPropertyName("fillList")]
        public BitgetFuturesUserTrade[] Trades { get; set; } = Array.Empty<BitgetFuturesUserTrade>();
    }

    /// <summary>
    /// Trade info
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesUserTrade
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
        /// ["<c>tradeId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Quantity
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>quoteVolume</c>"] Quote quantity
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// ["<c>profit</c>"] Profit
        /// </summary>
        [JsonPropertyName("profit")]
        public decimal Profit { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Entry point source
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EntryPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tradeSide</c>"] Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide TradeSide { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode PositionMode { get; set; }
        /// <summary>
        /// ["<c>tradeScope</c>"] Role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role Role { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ["<c>feeDetail</c>"] Fees
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetTradeFee[] Fees { get; set; } = Array.Empty<BitgetTradeFee>();

    }
}
