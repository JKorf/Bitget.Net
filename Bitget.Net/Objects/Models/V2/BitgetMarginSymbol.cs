using CryptoExchange.Net.Converters.SystemTextJson;
using Bitget.Net.Enums.V2;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Margin Symbol
    /// </summary>
    [SerializationModel]
    public record BitgetMarginSymbol
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
        /// ["<c>maxCrossedLeverage</c>"] Max crossed leverage
        /// </summary>
        [JsonPropertyName("maxCrossedLeverage")]
        public decimal MaxCrossedLeverage { get; set; }
        /// <summary>
        /// ["<c>maxIsolatedLeverage</c>"] Max isolated leverage
        /// </summary>
        [JsonPropertyName("maxIsolatedLeverage")]
        public decimal MaxIsolatedLeverage { get; set; }
        /// <summary>
        /// ["<c>warningRiskRatio</c>"] Warning risk ratio
        /// </summary>
        [JsonPropertyName("warningRiskRatio")]
        public decimal WarningRiskRatio { get; set; }
        /// <summary>
        /// ["<c>liquidationRiskRatio</c>"] Liquidation risk ratio
        /// </summary>
        [JsonPropertyName("liquidationRiskRatio")]
        public decimal LiquidationRiskRatio { get; set; }
        /// <summary>
        /// ["<c>minTradeAmount</c>"] Min trade quantity
        /// </summary>
        [JsonPropertyName("minTradeAmount")]
        public decimal MinTradeQuantity { get; set; }
        /// <summary>
        /// ["<c>maxTradeAmount</c>"] Max trade quantity
        /// </summary>
        [JsonPropertyName("maxTradeAmount")]
        public decimal MaxTradeQuantity { get; set; }
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
        /// ["<c>pricePrecision</c>"] Price precision
        /// </summary>
        [JsonPropertyName("pricePrecision")]
        public decimal PricePrecision { get; set; }
        /// <summary>
        /// ["<c>quantityPrecision</c>"] Quantity precision
        /// </summary>
        [JsonPropertyName("quantityPrecision")]
        public decimal QuantityPrecision { get; set; }
        /// <summary>
        /// ["<c>minTradeUSDT</c>"] Min trade USDT
        /// </summary>
        [JsonPropertyName("minTradeUSDT")]
        public decimal MinTradeUSDT { get; set; }
        /// <summary>
        /// ["<c>userMinBorrow</c>"] User min borrow
        /// </summary>
        [JsonPropertyName("userMinBorrow")]
        public decimal UserMinBorrow { get; set; }
        /// <summary>
        /// ["<c>status</c>"] Status
        /// </summary>
        [JsonPropertyName("status")]
        public MarginSymbolStatus? Status { get; set; }
        /// <summary>
        /// ["<c>isIsolatedBaseBorrowable</c>"] Is isolated base borrowable
        /// </summary>
        [JsonPropertyName("isIsolatedBaseBorrowable")]
        public bool IsIsolatedBaseBorrowable { get; set; }
        /// <summary>
        /// ["<c>isIsolatedQuoteBorrowable</c>"] Is isolated quote borrowable
        /// </summary>
        [JsonPropertyName("isIsolatedQuoteBorrowable")]
        public bool IsIsolatedQuoteBorrowable { get; set; }
        /// <summary>
        /// ["<c>isCrossBorrowable</c>"] Is cross borrowable
        /// </summary>
        [JsonPropertyName("isCrossBorrowable")]
        public bool IsCrossBorrowable { get; set; }
    }


}
