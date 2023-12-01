using Bitget.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Symbol info
    /// </summary>
    public class BitgetSymbol
    {
        /// <summary>
        /// Symbol id
        /// </summary>
        [JsonProperty("symbol")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Name
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
        /// Min order quantity
        /// </summary>
        [JsonProperty("minTradeAmount")]
        public decimal MinOrderQuantity { get; set; }

        /// <summary>
        /// Max order quantity
        /// </summary>
        [JsonProperty("maxTradeAmount")]
        public decimal MaxOrderQuantity { get; set; }

        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonProperty("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }

        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonProperty("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }

        /// <summary>
        /// Price decimals
        /// </summary>
        [JsonProperty("priceScale")]
        public int PriceDecimals { get; set; }

        /// <summary>
        /// Quantity decimals
        /// </summary>
        [JsonProperty("quantityScale")]
        public int QuantityDecimals { get; set; }

        /// <summary>
        /// Min value of the order in USDT
        /// </summary>
        [JsonProperty("minTradeUSDT")]
        public decimal MinOrderValueUsd { get; set; }

        /// <summary>
        /// Symbol status
        /// </summary>
        [JsonProperty("status"), JsonConverter(typeof(EnumConverter))]
        public BitgetSymbolStatus Status { get; set; }

        /// <summary>
        /// Buy price gap from market price, "0.05" means: 5%
        /// </summary>
        [JsonProperty("buyLimitPriceRatio")]
        public decimal? BuyLimitPriceRatio { get; set; }

        /// <summary>
        /// Sell price gap from market price, "0.05" means: 5%
        /// </summary>
        [JsonProperty("sellLimitPriceRatio")]
        public decimal? SellLimitPriceRatio { get; set; }

        /// <summary>
        /// Max number of orders
        /// </summary>
        [JsonProperty("maxOrderNum")]
        public int MaxOrders { get; set; }
    }
}
