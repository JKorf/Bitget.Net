using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Ticker update
    /// </summary>
    public class BitgetTickerUpdate
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("last")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonProperty("askSz")]
        public decimal BestAskQuantity { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("bestAsk")]
        public decimal BestAskPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bidSz")]
        public decimal BestBidQuantity { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bestBid")]
        public decimal BestBidPrice { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("open24h")]
        public decimal OpenPrice24h { get; set; }
        /// <summary>
        /// Open price at UTC 0
        /// </summary>
        [JsonProperty("openUtc")]
        public decimal OpenPriceUtc0 { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [JsonProperty("high24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [JsonProperty("low24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonProperty("baseVolume")]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Label id
        /// </summary>
        [JsonProperty("labeId")]
        public string LabelId { get; set; } = string.Empty;
        /// <summary>
        /// Change rate since openUtc, that is: (last - openUtc) / openUtc, scale e-5
        /// </summary>
        [JsonProperty("chgUTC")]
        public decimal ChangePercentageUtc0 { get; set; }
    }
}
