using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// User trade info
    /// </summary>
    [SerializationModel]
    public record BitgetCrossUserTrade
    {
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
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide OrderSide { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Price average
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal PriceAverage { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>amount</c>"] Quantity in quote asset
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// ["<c>tradeScope</c>"] Trade role
        /// </summary>
        [JsonPropertyName("tradeScope")]
        public Role Role { get; set; }
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
        /// <summary>
        /// ["<c>feeDetail</c>"] Fee detail
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetTradeFee FeeDetail { get; set; } = null!;
    }
}
