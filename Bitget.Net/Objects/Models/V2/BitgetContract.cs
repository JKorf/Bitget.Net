using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Contract info
    /// </summary>
    [SerializationModel]
    public record BitgetContract
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
        /// ["<c>buyLimitPriceRatio</c>"] Max percentage spread between buy limit price and current price
        /// </summary>
        [JsonPropertyName("buyLimitPriceRatio")]
        public decimal BuyLimitPriceRatio { get; set; }
        /// <summary>
        /// ["<c>sellLimitPriceRatio</c>"] Max percentage spread between sell limit price and current price
        /// </summary>
        [JsonPropertyName("sellLimitPriceRatio")]
        public decimal SellLimitPriceRatio { get; set; }
        /// <summary>
        /// ["<c>feeRateUpRatio</c>"] Transaction fee increase ratio
        /// </summary>
        [JsonPropertyName("feeRateUpRatio")]
        public decimal FeeRateUpRatio { get; set; }
        /// <summary>
        /// ["<c>makerFeeRate</c>"] Maker fee rate
        /// </summary>
        [JsonPropertyName("makerFeeRate")]
        public decimal MakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>takerFeeRate</c>"] Taker fee rate
        /// </summary>
        [JsonPropertyName("takerFeeRate")]
        public decimal TakerFeeRate { get; set; }
        /// <summary>
        /// ["<c>openCostUpRatio</c>"] Opening cost increase ratio
        /// </summary>
        [JsonPropertyName("openCostUpRatio")]
        public decimal OpenCostUpRatio { get; set; }
        /// <summary>
        /// ["<c>supportMarginCoins</c>"] Supported margin assets
        /// </summary>
        [JsonPropertyName("supportMarginCoins")]
        public string[] SupportMarginAsset { get; set; } = Array.Empty<string>();
        /// <summary>
        /// ["<c>minTradeNum</c>"] Minimal position open quantity
        /// </summary>
        [JsonPropertyName("minTradeNum")]
        public decimal MinOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>priceEndStep</c>"] Price step
        /// </summary>
        [JsonPropertyName("priceEndStep")]
        public decimal PriceStep { get; set; }
        /// <summary>
        /// ["<c>volumePlace</c>"] Quantity decimal places
        /// </summary>
        [JsonPropertyName("volumePlace")]
        public int QuantityDecimals { get; set; }
        /// <summary>
        /// ["<c>pricePlace</c>"] Price decimal places
        /// </summary>
        [JsonPropertyName("pricePlace")]
        public int PriceDecimals { get; set; }
        /// <summary>
        /// ["<c>sizeMultiplier</c>"] Quantity step
        /// </summary>
        [JsonPropertyName("sizeMultiplier")]
        public decimal QuantityStep { get; set; }
        /// <summary>
        /// ["<c>symbolType</c>"] Contract type
        /// </summary>
        [JsonPropertyName("symbolType")]
        public ContractType ContractType { get; set; }
        /// <summary>
        /// ["<c>minTradeUSDT</c>"] Minimal trade value in USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinTradeValue { get; set; }
        /// <summary>
        /// ["<c>maxSymbolOrderNum</c>"] Max open orders on symbol
        /// </summary>
        [JsonPropertyName("maxSymbolOrderNum")]
        public int MaxSymbolOpenOrders { get; set; }
        /// <summary>
        /// ["<c>maxProductOrderNum</c>"] Max open orders on product
        /// </summary>
        [JsonPropertyName("maxProductOrderNum")]
        public int MaxProductOpenOrders { get; set; }
        /// <summary>
        /// ["<c>maxPositionNum</c>"] Max number of positions
        /// </summary>
        [JsonPropertyName("maxPositionNum")]
        public int MaxPositions { get; set; }
        /// <summary>
        /// ["<c>symbolStatus</c>"] Status
        /// </summary>
        [JsonPropertyName("symbolStatus")]
        public FuturesSymbolStatus Status { get; set; }
        /// <summary>
        /// ["<c>offTime</c>"] Removal time
        /// </summary>
        [JsonPropertyName("offTime")]
        public DateTime? OfflineTime { get; set; }
        /// <summary>
        /// ["<c>limitOpenTime</c>"] Planned order restriction time
        /// </summary>
        [JsonPropertyName("limitOpenTime")]
        public DateTime? LimitOpenTime { get; set; }
        /// <summary>
        /// ["<c>deliveryTime</c>"] Delivery time
        /// </summary>
        [JsonPropertyName("deliveryTime")]
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// ["<c>deliveryStartTime</c>"] Delivery start time
        /// </summary>
        [JsonPropertyName("deliveryStartTime")]
        public DateTime? DeliveryStartTime { get; set; }
        /// <summary>
        /// ["<c>deliveryPeriod</c>"] Delivery period
        /// </summary>
        [JsonPropertyName("deliveryPeriod")]
        public DeliveryPeriod? DeliveryPeriod { get; set; }
        /// <summary>
        /// ["<c>launchTime</c>"] Listing time
        /// </summary>
        [JsonPropertyName("launchTime")]
        public DateTime? LaunchTime { get; set; }
        /// <summary>
        /// ["<c>fundInterval</c>"] Funding interval
        /// </summary>
        [JsonPropertyName("fundInterval"), System.Text.Json.Serialization.JsonConverter(typeof(IntConverter))]
        public int? FundingInterval { get; set; }
        /// <summary>
        /// ["<c>minLever</c>"] Minimal leverage
        /// </summary>
        [JsonPropertyName("minLever")]
        public decimal? MinLeverage { get; set; }
        /// <summary>
        /// ["<c>maxLever</c>"] Maximal leverage
        /// </summary>
        [JsonPropertyName("maxLever")]
        public decimal? MaxLeverage { get; set; }
        /// <summary>
        /// ["<c>posLimit</c>"] Position limit
        /// </summary>
        [JsonPropertyName("posLimit")]
        public decimal? PosLimit { get; set; }
        /// <summary>
        /// ["<c>maintainTime</c>"] Planned maintenance time
        /// </summary>
        [JsonPropertyName("maintainTime")]
        public DateTime? MaintenanceTime { get; set; }
        /// <summary>
        /// ["<c>maxMarketOrderQty</c>"] Max size for a market order
        /// </summary>
        [JsonPropertyName("maxMarketOrderQty")]
        public decimal? MaxMarketOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>maxOrderQty</c>"] Max size for a limit order
        /// </summary>
        [JsonPropertyName("maxOrderQty")]
        public decimal? MaxLimitOrderQuantity { get; set; }
        /// <summary>
        /// ["<c>isRwa</c>"] Is RWA
        /// </summary>
        [JsonPropertyName("isRwa")]
        public bool IsRwa { get; set; }
        /// <summary>
        /// ["<c>openTime</c>"] Open time
        /// </summary>
        [JsonPropertyName("openTime")]
        public DateTime? OpenTime { get; set; }
    }
}
