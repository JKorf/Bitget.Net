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
    public class BitgetFuturesTicker
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
        /// Last price
        /// </summary>
        [JsonProperty("last")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonProperty("baseVolume")]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Usdt volume
        /// </summary>
        [JsonProperty("usdtVolume")]
        public decimal UsdtVolume { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bestBid")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bidSz")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best sell price
        /// </summary>
        [JsonProperty("bestAsk")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("askSz")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// Open price at UTC 0
        /// </summary>
        [JsonProperty("openUtc")]
        public decimal OpenPriceUtc0 { get; set; }
        /// <summary>
        /// Change percentage since UTC 0, 0.01 means 1%
        /// </summary>
        [JsonProperty("chgUtc")]
        public decimal ChangePercentageUtc0 { get; set; }
        /// <summary>
        /// Change percentage, 0.01 means 1%
        /// </summary>
        [JsonProperty("priceChangePercent")]
        public decimal ChangePercentage { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonProperty("indexPrice")]
        public decimal IndexPrice { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonProperty("fundingRate")]
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Holding amount
        /// </summary>
        [JsonProperty("holdingAmount")]
        public decimal HoldingAmount { get; set; }
    }
}
