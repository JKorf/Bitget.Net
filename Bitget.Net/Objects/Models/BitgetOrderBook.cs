using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Order book
    /// </summary>
    public class BitgetOrderBook
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
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public record BitgetOrderBookEntry : ISymbolOrderBookEntry
    {
        /// <summary>
        /// Price
        /// </summary>
        [ArrayProperty(0)]
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [ArrayProperty(1)]
        public decimal Quantity { get; set; }
    }
}
