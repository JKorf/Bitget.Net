using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order book info
    /// </summary>
    public record BitgetOrderBook
    {
        /// <summary>
        /// Asks
        /// </summary>
        [JsonPropertyName("asks")]
        public IEnumerable<BitgetOrderBookEntry> Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Bids
        /// </summary>
        [JsonPropertyName("bids")]
        public IEnumerable<BitgetOrderBookEntry> Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Order book entry
    /// </summary>
    [JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.ArrayConverter))]
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
