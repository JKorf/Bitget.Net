using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order book update
    /// </summary>
    [SerializationModel]
    public record BitgetOrderBookUpdate
    {
        /// <summary>
        /// ["<c>asks</c>"] Asks
        /// </summary>
        [JsonPropertyName("asks")]
        public BitgetOrderBookEntry[] Asks { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// ["<c>bids</c>"] Bids
        /// </summary>
        [JsonPropertyName("bids")]
        public BitgetOrderBookEntry[] Bids { get; set; } = Array.Empty<BitgetOrderBookEntry>();
        /// <summary>
        /// ["<c>ts</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>checksum</c>"] Checksum
        /// </summary>
        [JsonPropertyName("checksum")]
        public long Checksum { get; set; }
        /// <summary>
        /// ["<c>seq</c>"] Sequence number
        /// </summary>
        [JsonPropertyName("seq")]
        public long? Sequence { get; set; }
    }
}
