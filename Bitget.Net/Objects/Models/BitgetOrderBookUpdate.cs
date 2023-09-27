using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Book update
    /// </summary>
    public class BitgetOrderBookUpdate
    {
        /// <summary>
        /// Asks
        /// </summary>
        [JsonProperty("asks")]
        public IEnumerable<BitgetOrderBookEntry> Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Bids
        /// </summary>
        [JsonProperty("bids")]
        public IEnumerable<BitgetOrderBookEntry> Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
    }
}
