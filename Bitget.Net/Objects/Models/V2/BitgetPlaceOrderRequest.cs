using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order request
    /// </summary>
    public record BitgetPlaceOrderRequest
    {
        /// <summary>
        /// ["<c>side</c>"] Order side
        /// </summary>
        [JsonPropertyName("side")]
        public OrderSide Side { get; set; }
        /// <summary>
        /// ["<c>orderType</c>"] Order type
        /// </summary>
        [JsonPropertyName("orderType")]
        public OrderType OrderType { get; set; }
        /// <summary>
        /// ["<c>force</c>"] Time in force
        /// </summary>
        [JsonPropertyName("force")]
        public TimeInForce TimeInForce { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Price
        /// </summary>
        [JsonPropertyName("price"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal? Price { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Quantity
        /// </summary>
        [JsonPropertyName("size"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>clientOid</c>"] Client order id
        /// </summary>
        [JsonPropertyName("clientOid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientOrderId { get; set; }
        /// <summary>
        /// ["<c>stpMode</c>"] Self Trade Prevention mode
        /// </summary>
        [JsonPropertyName("stpMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SelfTradePreventionMode? StpMode { get; set; }
        /// <summary>
        /// ["<c>presetTakeProfitPrice</c>"] Take profit price
        /// </summary>
        [JsonPropertyName("presetTakeProfitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? PresetTakeProfitPrice { get; set; }
        /// <summary>
        /// ["<c>executeTakeProfitPrice</c>"] Execute take profit price
        /// </summary>
        [JsonPropertyName("executeTakeProfitPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? ExecuteTakeProfitPrice { get; set; }
        /// <summary>
        /// ["<c>presetStopLossPrice</c>"] Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? PresetStopLossPrice { get; set; }
        /// <summary>
        /// ["<c>executeStopLossPrice</c>"] Execute stop loss price
        /// </summary>
        [JsonPropertyName("executeStopLossPrice"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter))]
        public decimal? ExecuteStopLossPrice { get; set; }
    }
}
