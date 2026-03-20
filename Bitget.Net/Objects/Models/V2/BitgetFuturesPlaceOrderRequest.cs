using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order request
    /// </summary>
    public record BitgetFuturesPlaceOrderRequest
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
        /// ["<c>tradeSide</c>"] Trade side
        /// </summary>
        [JsonPropertyName("tradeSide")]
        public TradeSide TradeSide { get; set; }
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
        /// ["<c>reduceOnly</c>"] Reduce only, YES or NO
        /// </summary>
        [JsonPropertyName("reduceOnly"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ReduceOnly { get; set; }
        /// <summary>
        /// ["<c>presetStopSurplusPrice</c>"] Take profit price
        /// </summary>
        [JsonPropertyName("presetStopSurplusPrice"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>
        /// ["<c>presetStopLossPrice</c>"] Stop loss price
        /// </summary>
        [JsonPropertyName("presetStopLossPrice"), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DecimalStringWriterConverter)), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal? StopLossPrice { get; set; }
    }
}
