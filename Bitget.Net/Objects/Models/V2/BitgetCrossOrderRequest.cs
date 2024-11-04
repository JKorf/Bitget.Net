using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Cross margin order request
    /// </summary>
    public record BitgetCrossOrderRequest
    {
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType"), JsonConverter(typeof(EnumConverter))]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Loan type
        /// </summary>
        [JsonPropertyName("loanType"), JsonConverter(typeof(EnumConverter))]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side"), JsonConverter(typeof(EnumConverter))]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force"), JsonConverter(typeof(EnumConverter))]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("stpMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonConverter(typeof(EnumConverter))]
        public SelfTradePreventionMode? SelfTradePreventionMode { get; set; }
        /// <summary>
        /// Order price
        /// </summary>
        [JsonPropertyName("price"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? Price { get; set; }
        /// <summary>
        /// Order quantity
        /// </summary>
        [JsonPropertyName("baseSize"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? Quantity { get; set; }
        /// <summary>
        /// Quote quantity
        /// </summary>
        [JsonPropertyName("quoteSize"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonConverter(typeof(DecimalStringWriterConverter))]
        public decimal? QuoteQuantity { get; set; }
        /// <summary>
        /// Client order id
        /// </summary>
        [JsonPropertyName("clientOid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClientOrderId { get; set; }
    }
}
