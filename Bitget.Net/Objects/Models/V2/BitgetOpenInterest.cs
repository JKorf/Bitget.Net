using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    [SerializationModel]
    internal record BitgetOpenInterestResult
    {
        [JsonPropertyName("openInterestList")]
        public BitgetOpenInterest[] OpenInterest { get; set; } = Array.Empty<BitgetOpenInterest>();
    }

    /// <summary>
    /// Open interest
    /// </summary>
    [SerializationModel]
    public record BitgetOpenInterest
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>size</c>"] Open interest quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
    }
}
