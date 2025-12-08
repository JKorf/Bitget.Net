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
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Enter point source
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string ClientOid { get; set; } = string.Empty;
        /// <summary>
        /// Loan type
        /// </summary>
        [JsonPropertyName("loanType")]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide OrderSide { get; set; }
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Base asset quantity
        /// </summary>
        [JsonPropertyName("baseSize")]
        public decimal BaseQuantity { get; set; }
        /// <summary>
        /// Quote asset quantity
        /// </summary>
        [JsonPropertyName("quoteSize")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonPropertyName("priceAvg")]
        public decimal PriceAverage { get; set; }
        /// <summary>
        /// Quantity filled
        /// </summary>
        [JsonPropertyName("size")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Quantity filled in quote asset
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonPropertyName("uTime")]
        public DateTime? UpdateTime { get; set; }
    }


}
