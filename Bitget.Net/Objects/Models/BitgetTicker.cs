using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Ticker info
    /// </summary>
    public class BitgetTicker
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// High price in last 24h
        /// </summary>
        [JsonProperty("high24h")]
        public decimal HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        [JsonProperty("low24h")]
        public decimal LowPrice24h { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("close")]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("quoteVol")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonProperty("baseVol")]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Usdt volume
        /// </summary>
        [JsonProperty("usdtVol")]
        public decimal UsdtVolume { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("buyOne")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bidSz")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best sell price
        /// </summary>
        [JsonProperty("sellOne")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askSz")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// Open price at UTC 0
        /// </summary>
        [JsonProperty("openUtc0")]
        public decimal OpenPriceUtc0 { get; set; }
        /// <summary>
        /// Change percentage since UTC 0, 0.01 means 1%
        /// </summary>
        [JsonProperty("changeUtc")]
        public decimal ChangePercentageUtc0 { get; set; }
        /// <summary>
        /// Change percentage, 0.01 means 1%
        /// </summary>
        [JsonProperty("change")]
        public decimal ChangePercentage { get; set; }
    }
}
