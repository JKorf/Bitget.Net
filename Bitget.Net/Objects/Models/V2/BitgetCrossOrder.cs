using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Cross margin order info
    /// </summary>
    [SerializationModel]
    public record BitgetCrossOrder
    {
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>enterPointSource</c>"] Enter point source
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>clientOid</c>"] Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string ClientOid { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>loanType</c>"] Loan type
        /// </summary>
        [JsonPropertyName("loanType")]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide OrderSide { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// ["<c>baseSize</c>"] Base asset quantity
        /// </summary>
        [JsonPropertyName("baseSize")]
        public decimal BaseQuantity { get; set; }
        /// <summary>
        /// ["<c>quoteSize</c>"] Quote asset quantity
        /// </summary>
        [JsonPropertyName("quoteSize")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// ["<c>priceAvg</c>"] Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal PriceAverage { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity filled
        /// </summary>
        [JsonPropertyName("size")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>amount</c>"] Quantity filled in quote asset
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// ["<c>force</c>"] Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
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


}
