using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Futures ticker update
    /// </summary>
    public class BitgetFuturesTickerUpdate
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
        public decimal? LastTradePrice { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("bestAsk")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bestBid")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// High price in last 24h
        /// </summary>
        [JsonProperty("high24h")]
        public decimal? HighPrice24h { get; set; }
        /// <summary>
        /// Low price in last 24h
        /// </summary>
        [JsonProperty("low24h")]
        public decimal? LowPrice24h { get; set; }
        /// <summary>
        /// Price change percentage last 24h
        /// </summary>
        [JsonProperty("priceChangePercent")]
        public decimal? ChangePercentage24h { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonProperty("capitalRate")]
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Next settlement time
        /// </summary>
        [JsonProperty("nextSettleTime")]
        public DateTime? NextSettlementTime { get; set; }
        /// <summary>
        /// System time
        /// </summary>
        [JsonProperty("systemTime")]
        public DateTime? SystemTime { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonProperty("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonProperty("indexPrice")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// Open interest
        /// </summary>
        [JsonProperty("holding")]
        public decimal? OpenInterest { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [JsonProperty("baseVolume")]
        public decimal? BaseVolume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [JsonProperty("quoteVolume")]
        public decimal? QuoteVolume { get; set; }
        /// <summary>
        /// Open price at UTC 00:00
        /// </summary>
        [JsonProperty("openUtc")]
        public decimal? OpenPriceUtc0 { get; set; }
        /// <summary>
        /// Price change since UTC 00:00
        /// </summary>
        [JsonProperty("chgUTC")]
        public decimal? PriceChangeUtc0 { get; set; }
        /// <summary>
        /// Type of symbol
        /// </summary>
        [JsonProperty("symbolType")]
        public BitgetFuturesSymbolType? SymbolType { get; set; }
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbolId")]
        public string SymbolId { get; set; } = string.Empty;
        /// <summary>
        /// Delivery price (0 if perpetual)
        /// </summary>
        [JsonProperty("deliveryPrice")]
        public decimal? DeliveryPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonProperty("bidSz")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonProperty("askSz")]
        public decimal? BestAskQuantity { get; set; }
    }
}
