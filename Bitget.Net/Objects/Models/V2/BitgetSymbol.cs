using CryptoExchange.Net.Converters.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Bitget.Net.Converters;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Symbol info
    /// </summary>
    [SerializationModel]
    public record BitgetSymbol
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
        /// Minimal order quantity
        /// </summary>
        [JsonPropertyName("minTradeAmount")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// Maximal order quantity
        /// </summary>
        [JsonPropertyName("maxTradeAmount")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// The number of decimals used for price
        /// </summary>
        [JsonPropertyName("pricePrecision"), JsonConverter(typeof(IntConverter))]
        public int? PricePrecision { get; set; }
        /// <summary>
        /// The number of decimals used for quantity
        /// </summary>
        [JsonPropertyName("quantityPrecision"), JsonConverter(typeof(IntConverter))]
        public int? QuantityPrecision { get; set; }
        /// <summary>
        /// The number of decimals used for quote quantity
        /// </summary>
        [JsonPropertyName("quotePrecision"), JsonConverter(typeof(IntConverter))]
        public int? QuoteQuantityPrecision { get; set; }
        /// <summary>
        /// Minimal order value in USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinOrderValue { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// Max percentage spread between buy limit price and current price
        /// </summary>
        [JsonPropertyName("buyLimitPriceRatio")]
        public decimal? BuyLimitPriceRatio { get; set; }
        /// <summary>
        /// Max percentage spread between sell limit price and current price
        /// </summary>
        [JsonPropertyName("sellLimitPriceRatio")]
        public decimal? SellLimitPriceRatio { get; set; }
    }
}
