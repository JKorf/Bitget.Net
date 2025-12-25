using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Replace order request
    /// </summary>
    public record BitgetReplaceOrderRequest
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        [JsonPropertyName("price"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("size"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Order id of order to cancel
        /// </summary>
        [JsonPropertyName("orderId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? OrderId { get; set; }
        /// <summary>
        /// Client order id of order to cancel
        /// </summary>
        [JsonPropertyName("clientOid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// Client order id for the new order
        /// </summary>
        [JsonPropertyName("newClientOid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? NewClientOrderId { get; set; }
        /// <summary>
        /// Take profit price
        /// </summary>
        [JsonPropertyName("presetTakeProfitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? PresetTakeProfitPrice { get; set; }
        /// <summary>
        /// Execute take profit price
        /// </summary>
        [JsonPropertyName("executeTakeProfitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? ExecuteTakeProfitPrice { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? PresetStopLossPrice { get; set; }
        /// <summary>
        /// Execute stop loss price
        /// </summary>
        [JsonPropertyName("executeStopLossPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? ExecuteStopLossPrice { get; set; }
    }
}
