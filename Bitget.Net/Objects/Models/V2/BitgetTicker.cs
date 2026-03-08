using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ticker info
    /// </summary>
    [SerializationModel]
    public record BitgetTicker
    {
        /// <summary>
        /// ["<c>symbol</c>"] Symbol name
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>high24h</c>"] Highest price in 24h
        /// </summary>
        [JsonPropertyName("high24h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// ["<c>open</c>"] Open price 24h ago
        /// </summary>
        [JsonPropertyName("open")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// ["<c>low24h</c>"] Lowest price in 24h
        /// </summary>
        [JsonPropertyName("low24h")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// ["<c>lastPr</c>"] Last trade price
        /// </summary>
        [JsonPropertyName("lastPr")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// ["<c>quoteVolume</c>"] Volume in quote asset
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// ["<c>baseVolume</c>"] Volume in base asset
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal Volume { get; set; }
        /// <summary>
        /// ["<c>usdtVolume</c>"] Volume in USDT
        /// </summary>
        [JsonPropertyName("usdtVolume")]
        public decimal UsdtVolume { get; set; }
        /// <summary>
        /// ["<c>bidPr</c>"] Best bid price
        /// </summary>
        [JsonPropertyName("bidPr")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// ["<c>askPr</c>"] Best ask price
        /// </summary>
        [JsonPropertyName("askPr")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// ["<c>bidSz</c>"] Best bid quantity
        /// </summary>
        [JsonPropertyName("bidSz")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// ["<c>askSz</c>"] Best ask quantity
        /// </summary>
        [JsonPropertyName("askSz")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// ["<c>openUtc</c>"] Price at last UTC+0
        /// </summary>
        [JsonPropertyName("openUtc")]
        public decimal? OpenPriceUtc { get; set; }
        /// <summary>
        /// ["<c>ts</c>"] Data timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>changeUtc24h</c>"] Price change compared to UTC+0. Returned as factor, 0.01 means 1%.
        /// </summary>
        [JsonPropertyName("changeUtc24h")]
        public decimal? ChangePercentageUtc { get; set; }
        /// <summary>
        /// ["<c>change24h</c>"] Price change compared to 24h ago. Returned as factor, 0.01 means 1%.
        /// </summary>
        [JsonPropertyName("change24h")]
        public decimal? ChangePercentage24H { get; set; }
    }
}
