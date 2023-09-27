using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Trade update
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BitgetTradeUpdate
    {
        /// <summary>
        /// Side
        /// </summary>
        [JsonProperty("side"), JsonConverter(typeof(EnumConverter))]
        [ArrayProperty(3)]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("sz")]
        [ArrayProperty(2)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("px")]
        [ArrayProperty(1)]
        public decimal Price { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts"), JsonConverter(typeof(DateTimeConverter))]
        [ArrayProperty(0)]
        public DateTime Timestamp { get; set; }
    }
}
