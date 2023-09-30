using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Order book
    /// </summary>
    public class BitgetFuturesOrderBook
    {
        /// <summary>
        /// Ask entries
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<BitgetOrderBookEntry> Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();

        /// <summary>
        /// Bid entries
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<BitgetOrderBookEntry> Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Current gear, for example: scale 1
        /// </summary>
        [JsonProperty("precision")]
        public string Precision { get; set; } = string.Empty;
        /// <summary>
        /// Precision value
        /// </summary>
        [JsonProperty("scale")]
        public decimal Scale { get; set; }
        /// <summary>
        /// Is max precision
        /// </summary>
        [JsonProperty("isMaxPrecision"), JsonConverter(typeof(BoolConverter))]
        public bool IsMaxPrecision { get; set; }
    }
}
