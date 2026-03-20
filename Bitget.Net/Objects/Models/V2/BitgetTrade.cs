using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Trade info
    /// </summary>
    [SerializationModel]
    public record BitgetTrade
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>tradeId</c>"] Trade id
        /// </summary>
        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>side</c>"] Side
        /// </summary>
        [JsonPropertyName("side")]
        public BitgetOrderSide Side { get; set; }
        /// <summary>
        /// ["<c>price</c>"] Trade price
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// ["<c>size</c>"] Trade quantity
        /// </summary>
        [JsonPropertyName("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>ts</c>"] Trade time
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
    }
}
