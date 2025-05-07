using CryptoExchange.Net.Converters.SystemTextJson;
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
    [SerializationModel]
    public record BitgetCrossOrderRequest
    {
        /// <summary>
        /// Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// Loan type
        /// </summary>
        [JsonPropertyName("loanType")]
        public LoanType LoanType { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide OrderSide { get; set; }
        /// <summary>
        /// Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// Order side
        /// </summary>
        [JsonPropertyName("stpMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
