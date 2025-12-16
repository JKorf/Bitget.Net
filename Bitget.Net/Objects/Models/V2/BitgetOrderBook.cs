using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order book info
    /// </summary>
    [SerializationModel]
    public record BitgetOrderBook
    {
        /// <summary>
        /// Asks
        /// </summary>
        [JsonPropertyName("asks")]
        public BitgetOrderBookEntry[] Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Bids
        /// </summary>
        [JsonPropertyName("bids")]
        public BitgetOrderBookEntry[] Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<BitgetOrderBookEntry>))]
    [SerializationModel]
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
