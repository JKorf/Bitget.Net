using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonPropertyName("quoteSize")]
        public decimal QuoteQuantity { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        [JsonPropertyName("side")]
        public MarginOrderSide MarginOrderSide { get; set; }
        /// <summary>
        /// Fee detail
        /// </summary>
        [JsonPropertyName("feeDetail")]
        public BitgetTradeFee[] FeeDetail { get; set; } = Array.Empty<BitgetTradeFee>();
        /// <summary>
        /// Enter point source
        /// </summary>
        [JsonPropertyName("enterPointSource")]
        public string EnterPointSource { get; set; } = string.Empty;
        /// <summary>
        /// Order status
        /// </summary>
        [JsonPropertyName("status")]
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("baseSize")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Client oid
        /// </summary>
        [JsonPropertyName("clientOid")]
        public string? ClientOid { get; set; }
        /// <summary>
        /// Average fill price
        /// </summary>
        [JsonPropertyName("fillPrice")]
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// Filled quantity
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Filled quantity in quote asset
        /// </summary>
        [JsonPropertyName("fillTotalAmount")]
        public decimal QuoteQuantityFilled { get; set; }
        /// <summary>
        /// Loan type
        /// </summary>
        [JsonPropertyName("loanType")]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>
        /// Self trade prevention mode
        /// </summary>
        [JsonPropertyName("stpMode")]
        public SelfTradePreventionMode SelfTradePreventionMode { get; set; }
    }

}
