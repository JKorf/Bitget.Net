using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ticker info
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesTickerUpdate
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonPropertyName("instId")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Open price 24h ago
        /// </summary>
        [JsonPropertyName("open24h")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Highest price in 24h
        /// </summary>
        [JsonPropertyName("high24h")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Lowest price in 24h
        /// </summary>
        [JsonPropertyName("low24h")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonPropertyName("lastPr")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Volume in quote asset
        /// </summary>
        [JsonPropertyName("quoteVolume")]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Volume in base asset
        /// </summary>
        [JsonPropertyName("baseVolume")]
        public decimal Volume { get; set; }
        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonPropertyName("bidPr")]
        public decimal? BestBidPrice { get; set; }
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonPropertyName("askPr")]
        public decimal? BestAskPrice { get; set; }
        /// <summary>
        /// Best bid quantity
        /// </summary>
        [JsonPropertyName("bidSz")]
        public decimal? BestBidQuantity { get; set; }
        /// <summary>
        /// Best ask quantity
        /// </summary>
        [JsonPropertyName("askSz")]
        public decimal? BestAskQuantity { get; set; }
        /// <summary>
        /// Price at last UTC+0
        /// </summary>
        [JsonPropertyName("openUtc")]
        public decimal? OpenPriceUtc { get; set; }
        /// <summary>
        /// Data timestamp
        /// </summary>
        [JsonPropertyName("ts")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Next funding time
        /// </summary>
        [JsonPropertyName("nextFundingTime")]
        public DateTime? NextFundingTime { get; set; }
        /// <summary>
        /// Price change compared to 24h ago. Returned as factor, 0.01 means 1%.
        /// </summary>
        [JsonPropertyName("change24h")]
        public decimal? ChangePercentage24H { get; set; }
        /// <summary>
        /// Mark price
        /// </summary>
        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// Index price
        /// </summary>
        [JsonPropertyName("indexPrice")]
        public decimal? IndexPrice { get; set; }
        /// <summary>
        /// Funding rate
        /// </summary>
        [JsonPropertyName("fundingRate")]
        public decimal? FundingRate { get; set; }
        /// <summary>
        /// Holding positions
        /// </summary>
        [JsonPropertyName("holdingAmount")]
        public decimal? HoldingPositions { get; set; }
        /// <summary>
        /// Delivery price
        /// </summary>
        [JsonPropertyName("deliveryPrice")]
        public decimal? DeliveryPrice { get; set; }
        /// <summary>
        /// Contract type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public ContractType ContractType { get; set; }
    }
}
