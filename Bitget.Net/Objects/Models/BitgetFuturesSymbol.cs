using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Futures symbol
    /// </summary>
    public class BitgetFuturesSymbol
    {
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbol")]
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Symbol name
        /// </summary>
        [JsonProperty("symbolName")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Base asset
        /// </summary>
        [JsonProperty("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quote asset
        /// </summary>
        [JsonProperty("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// Buy limit price ratio
        /// </summary>
        [JsonProperty("buyLimitPriceRatio")]
        public decimal BuyLimitPriceRatio { get; set; }
        /// <summary>
        /// Sell limit price ratio
        /// </summary>
        [JsonProperty("sellLimitPriceRatio")]
        public decimal SellLimitPriceRatio { get; set; }
        /// <summary>
        /// Rate of increase in handling fee, 0.005 means 0.5%
        /// </summary>
        [JsonProperty("feeRateUpRatio")]
        public decimal FeeRateUpRatio { get; set; }
        /// <summary>
        /// Maker fee rate, 0.0002 means 0.02%
        /// </summary>
        [JsonProperty("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// Taker fee rate, 0.0006 means 0.06%
        /// </summary>
        [JsonProperty("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// Percentage of increase in opening cost, 0.01 means 1%
        /// </summary>
        [JsonProperty("openCostUpRatio")]
        public decimal OpenCostUpRatio { get; set; }
        /// <summary>
        /// 	Support margin currency array
        /// </summary>
        [JsonProperty("supportMarginCoins")]
        public IEnumerable<string> SupportMarginAssets { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Minimum number of openings(Base Currency)
        /// </summary>
        [JsonProperty("minTradeNum")]
        public decimal MinTradeNum { get; set; }
        /// <summary>
        /// Price step, i.e. when pricePlace=1, priceEndStep=5 means the price would only accept numbers like 10.0, 10.5, and reject numbers like 10.2(10.2 divided by 0.5 not equals to 0)
        /// </summary>
        [JsonProperty("priceEndStep")]
        public decimal PriceEndStep { get; set; }
        /// <summary>
        /// Number of decimal places
        /// </summary>
        [JsonProperty("volumePlace")]
        public decimal QuantityDecimals { get; set; }
        /// <summary>
        /// Price scale precision, i.e. 1 means 0.1; 2 means 0.01
        /// </summary>
        [JsonProperty("pricePlace")]
        public decimal PriceDecimals { get; set; }
        /// <summary>
        /// Quantity Multiplier The order size must be greater than minTradeNum and satisfy the multiple of sizeMultiplier
        /// </summary>
        [JsonProperty("sizeMultiplier")]
        public decimal SizeMultiplier { get; set; }
        /// <summary>
        /// Futures symbol type
        /// </summary>
        [JsonProperty("symbolType"), JsonConverter(typeof(EnumConverter))]
        public BitgetFuturesSymbolType Type { get; set; }
        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonProperty("symbolStatus"), JsonConverter(typeof(EnumConverter))]
        public BitgetFuturesSymbolStatus Status { get; set; }
        /// <summary>
        /// Delist time
        /// </summary>
        [JsonProperty("offTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DelistTime { get; set; }
        /// <summary>
        /// Prohibit create order time
        /// </summary>
        [JsonProperty("limitOpenTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LimitOpenTime { get; set; }
    }
}
