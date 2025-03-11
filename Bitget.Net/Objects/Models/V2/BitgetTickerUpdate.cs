using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ticker update
    /// </summary>
    [SerializationModel]
    public record BitgetTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPr")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonPropertyName("askSz")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonPropertyName("askPr")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonPropertyName("bidSz")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bidPr")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [JsonPropertyName("open24h")]
        public decimal OpenPrice24h { get; set; }
        /// <summary>
        /// Open price at UTC 0
        /// </summary>
        [JsonPropertyName("openUtc")]
        public decimal OpenPriceUtc0 { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonPropertyName("high24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonPropertyName("low24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Change rate since 24h
        /// </summary>
        [JsonPropertyName("change24h")]
        public decimal ChangePercentage { get; set; }
        /// <summary>
        /// Change rate since openUtc, that is: (last - openUtc) / openUtc, scale e-5
        /// </summary>
        [JsonPropertyName("changeUtc24h")]
        public decimal ChangePercentageUtc0 { get; set; }
    }
}
