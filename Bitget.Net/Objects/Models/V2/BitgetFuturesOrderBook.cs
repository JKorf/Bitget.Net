using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Order book info
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesOrderBook
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
        /// ["<c>scale</c>"] Scale
        /// </summary>
        [JsonPropertyName("scale")]
        public decimal Scale { get; set; }
        /// <summary>
        /// ["<c>precision</c>"] Precision
        /// </summary>
        [JsonPropertyName("precision")]
        public string? Precision { get; set; }
        /// <summary>
        /// ["<c>isMaxPrecision</c>"] Is max precision
        /// </summary>
        [JsonPropertyName("isMaxPrecision")]
        public bool IsMaxPrecision { get; set; }
    }

}
