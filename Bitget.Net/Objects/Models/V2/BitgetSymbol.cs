using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
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
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>baseCoin</c>"] Base asset
        /// </summary>
        [JsonPropertyName("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>quoteCoin</c>"] Quote asset
        /// </summary>
        [JsonPropertyName("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>minTradeAmount</c>"] Minimal order quantity
        /// </summary>
        [JsonPropertyName("minTradeAmount")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxTradeAmount</c>"] Maximal order quantity
        /// </summary>
        [JsonPropertyName("maxTradeAmount")]
        public decimal MaxOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>takerFeeRate</c>"] Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>pricePrecision</c>"] The number of decimals used for price
        /// </summary>
        [JsonPropertyName("pricePrecision"), JsonConverter(typeof(IntConverter))]
        public int? PricePrecision { get; set; }
        /// <summary>
        /// ["<c>quantityPrecision</c>"] The number of decimals used for quantity
        /// </summary>
        [JsonPropertyName("quantityPrecision"), JsonConverter(typeof(IntConverter))]
        public int? QuantityPrecision { get; set; }
        /// <summary>
        /// ["<c>quotePrecision</c>"] The number of decimals used for quote quantity
        /// </summary>
        [JsonPropertyName("quotePrecision"), JsonConverter(typeof(IntConverter))]
        public int? QuoteQuantityPrecision { get; set; }
        /// <summary>
        /// ["<c>minTradeUSDT</c>"] Minimal order value in USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinOrderValue { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public SymbolStatus Status { get; set; }
        /// <summary>
        /// ["<c>buyLimitPriceRatio</c>"] Max percentage spread between buy limit price and current price
        /// </summary>
        [JsonPropertyName("buyLimitPriceRatio")]
        public decimal? BuyLimitPriceRatio { get; set; }
        /// <summary>
        /// ["<c>sellLimitPriceRatio</c>"] Max percentage spread between sell limit price and current price
        /// </summary>
        [JsonPropertyName("sellLimitPriceRatio")]
        public decimal? SellLimitPriceRatio { get; set; }
        /// <summary>
        /// ["<c>orderQuantity</c>"] Max number of orders allowed
        /// </summary>
        [JsonPropertyName("orderQuantity")]
        public int? MaxOrders { get; set; }
        /// <summary>
        /// ["<c>areaSymbol</c>"] Area symbol
        /// </summary>
        [JsonPropertyName("areaSymbol")]
        public bool? AreaSymbol { get; set; }
        /// <summary>
        /// ["<c>openTime</c>"] Open time
        /// </summary>
        [JsonPropertyName("openTime")]
        public DateTime? OpenTime { get; set; }
        /// <summary>
        /// ["<c>offTime</c>"] Offline time
        /// </summary>
        [JsonPropertyName("offTime")]
        public DateTime? OfflineTime { get; set; }
    }
}
