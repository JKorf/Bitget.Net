using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;
using Bitget.Net.Converters;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Contract info
    /// </summary>
    public record BitgetContract
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Max percentage spread between buy limit price and current price
        /// </summary>
        [JsonPropertyName("buyLimitPriceRatio")]
        public decimal BuyLimitPriceRatio { get; set; }
        /// <summary>
        /// Max percentage spread between sell limit price and current price
        /// </summary>
        [JsonPropertyName("sellLimitPriceRatio")]
        public decimal SellLimitPriceRatio { get; set; }
        /// <summary>
        /// Transaction fee increase ratio
        /// </summary>
        [JsonPropertyName("feeRateUpRatio")]
        public decimal FeeRateUpRatio { get; set; }
        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// Opening cost increase ratio
        /// </summary>
        [JsonPropertyName("openCostUpRatio")]
        public decimal OpenCostUpRatio { get; set; }
        /// <summary>
        /// Supported margin assets
        /// </summary>
        [JsonPropertyName("supportMarginCoins")]
        public IEnumerable<string> SupportMarginAsset { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Minimal position open quantity
        /// </summary>
        [JsonPropertyName("minTradeNum")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Price step
        /// </summary>
        [JsonPropertyName("priceEndStep")]
        public decimal PriceStep { get; set; }
        /// <summary>
        /// Quantity decimal places
        /// </summary>
        [JsonPropertyName("volumePlace")]
        public decimal QuantityDecimals { get; set; }
        /// <summary>
        /// Price decimal places
        /// </summary>
        [JsonPropertyName("pricePlace")]
        public decimal PriceDecimals { get; set; }
        /// <summary>
        /// Quantity step
        /// </summary>
        [JsonPropertyName("sizeMultiplier")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// Contract type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public ContractType ContractType { get; set; }
        /// <summary>
        /// Minimal trade value in USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinTradeValue { get; set; }
        /// <summary>
        /// Max open orders on symbol
        /// </summary>
        [JsonPropertyName("maxSymbolOrderNum")]
        public int MaxSymbolOpenOrders { get; set; }
        /// <summary>
        /// Max open orders on product
        /// </summary>
        [JsonPropertyName("maxProductOrderNum")]
        public int MaxProductOpenOrders { get; set; }
        /// <summary>
        /// Max number of positions
        /// </summary>
        [JsonPropertyName("maxPositionNum")]
        public int MaxPositions { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("symbolStatus")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Removal time
        /// </summary>
        [JsonPropertyName("offTime")]
        public DateTime? OfflineTime { get; set; }
        /// <summary>
        /// Planned order restriction time
        /// </summary>
        [JsonPropertyName("limitOpenTime")]
        public DateTime? LimitOpenTime { get; set; }
        /// <summary>
        /// Delivery time
        /// </summary>
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// Delivery start time
        /// </summary>
        [JsonPropertyName("deliveryStartTime")]
        public DateTime? DeliveryStartTime { get; set; }
        /// <summary>
        /// Delivery period
        /// </summary>
        [JsonPropertyName("deliveryPeriod")]
        public DeliveryPeriod? DeliveryPeriod { get; set; }
        /// <summary>
        /// Listing time
        /// </summary>
        [JsonPropertyName("launchTime")]
        public DateTime? LaunchTime { get; set; }
        /// <summary>
        /// Funding interval
        /// </summary>
        [JsonPropertyName("fundInterval"), System.Text.Json.Serialization.JsonConverter(typeof(IntConverter))]
        public int? FundingInterval { get; set; }
        /// <summary>
        /// Minimal leverage
        /// </summary>
        [JsonPropertyName("minLever")]
        public decimal? MinLeverage { get; set; }
        /// <summary>
        /// Maximal leverage
        /// </summary>
        [JsonPropertyName("maxLever")]
        public decimal? MaxLeverage { get; set; }
        /// <summary>
        /// Position limit
        /// </summary>
        [JsonPropertyName("posLimit")]
        public decimal? PosLimit { get; set; }
        /// <summary>
        /// Planned maintenance time
        /// </summary>
        [JsonPropertyName("maintainTime")]
        public DateTime? MaintenanceTime { get; set; }
    }
}
