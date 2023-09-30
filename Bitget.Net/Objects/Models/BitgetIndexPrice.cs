using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Index price
    /// </summary>
    public class BitgetIndexPrice
    {
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Index price
        /// </summary>
        [JsonProperty("index")]
        public decimal Index { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
