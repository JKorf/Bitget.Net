using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Margin order update
    /// </summary>
    [SerializationModel]
    public record BitgetMarginOrderUpdate
    {
        /// <summary>
        /// ["<c>force</c>"] Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>quoteSize</c>"] Quote quantity
        /// </summary>
        [JsonPropertyName("quoteSize")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide MarginOrderSide { get; set; }
        /// <summary>
        /// ["<c>feeDetail</c>"] Fee detail
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetTradeFee[] FeeDetail { get; set; } = Array.Empty<BitgetTradeFee>();
        /// <summary>
        /// ["<c>enterPointSource</c>"] Enter point source
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>status</c>"] Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// ["<c>baseSize</c>"] Quantity
        /// </summary>
        [JsonPropertyName("baseSize")]
        public decimal Quantity { get; set; }
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
        /// ["<c>clientOid</c>"] Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOid { get; set; }
        /// <summary>
        /// ["<c>fillPrice</c>"] Average fill price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Filled quantity
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// ["<c>fillTotalAmount</c>"] Filled quantity in quote asset
        /// </summary>
        [JsonPropertyName("fillTotalAmount")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// ["<c>loanType</c>"] Loan type
        /// </summary>
        [JsonPropertyName("loanType")]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// ["<c>orderId</c>"] Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>stpMode</c>"] Self trade prevention mode
        /// </summary>
        [JsonPropertyName("stpMode")]
        public SelfTradePreventionMode SelfTradePreventionMode { get; set; }
    }

}
