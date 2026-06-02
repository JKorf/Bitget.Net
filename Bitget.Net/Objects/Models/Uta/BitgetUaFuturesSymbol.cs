using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// 
/// </summary>
public record BitgetUaFuturesSymbol
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>category</c>"] Category
    /// </summary>
    [JsonPropertyName("category")]
    public ProductCategory Category { get; set; }
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
    /// ["<c>isRwa</c>"] Is rwa
    /// </summary>
    [JsonPropertyName("isRwa")]
    public bool IsRwa { get; set; }
    /// <summary>
    /// ["<c>buyLimitPriceRatio</c>"] Buy limit price ratio
    /// </summary>
    [JsonPropertyName("buyLimitPriceRatio")]
    public decimal BuyLimitPriceRatio { get; set; }
    /// <summary>
    /// ["<c>sellLimitPriceRatio</c>"] Sell limit price ratio
    /// </summary>
    [JsonPropertyName("sellLimitPriceRatio")]
    public decimal SellLimitPriceRatio { get; set; }
    /// <summary>
    /// ["<c>feeRateUpRatio</c>"] Fee rate up ratio
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
    /// ["<c>openCostUpRatio</c>"] Open cost up ratio
    /// </summary>
    [JsonPropertyName("openCostUpRatio")]
    public decimal OpenCostUpRatio { get; set; }
    /// <summary>
    /// ["<c>minOrderQty</c>"] Min order quantity
    /// </summary>
    [JsonPropertyName("minOrderQty")]
    public decimal MinOrderQuantity { get; set; }
    /// <summary>
    /// ["<c>maxOrderQty</c>"] Max order quantity
    /// </summary>
    [JsonPropertyName("maxOrderQty")]
    public decimal MaxOrderQuantity { get; set; }
    /// <summary>
    /// ["<c>pricePrecision</c>"] Price precision
    /// </summary>
    [JsonPropertyName("pricePrecision")]
    public int PricePrecision { get; set; }
    /// <summary>
    /// ["<c>quantityPrecision</c>"] Quantity precision
    /// </summary>
    [JsonPropertyName("quantityPrecision")]
    public int QuantityPrecision { get; set; }
    /// <summary>
    /// ["<c>quotePrecision</c>"] Quote precision
    /// </summary>
    [JsonPropertyName("quotePrecision")]
    public int? QuotePrecision { get; set; }
    /// <summary>
    /// ["<c>priceMultiplier</c>"] Price multiplier
    /// </summary>
    [JsonPropertyName("priceMultiplier")]
    public decimal PriceMultiplier { get; set; }
    /// <summary>
    /// ["<c>quantityMultiplier</c>"] Quantity multiplier
    /// </summary>
    [JsonPropertyName("quantityMultiplier")]
    public decimal QuantityMultiplier { get; set; }
    /// <summary>
    /// ["<c>type</c>"] Type
    /// </summary>
    [JsonPropertyName("type")]
    public ContractType Type { get; set; }
    /// <summary>
    /// ["<c>minOrderAmount</c>"] Min order value
    /// </summary>
    [JsonPropertyName("minOrderAmount")]
    public decimal MinOrderValue { get; set; }
    /// <summary>
    /// ["<c>maxSymbolOrderNum</c>"] Max symbol orders
    /// </summary>
    [JsonPropertyName("maxSymbolOrderNum")]
    public int? MaxSymbolOrders { get; set; }
    /// <summary>
    /// ["<c>maxProductOrderNum</c>"] Max product orders
    /// </summary>
    [JsonPropertyName("maxProductOrderNum")]
    public int? MaxProductOrders { get; set; }
    /// <summary>
    /// ["<c>maxPositionNum</c>"] Max positions
    /// </summary>
    [JsonPropertyName("maxPositionNum")]
    public int? MaxPositions { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public InstrumentStatus Status { get; set; }
    /// <summary>
    /// ["<c>offTime</c>"] Trading halt time
    /// </summary>
    [JsonPropertyName("offTime")]
    public DateTime? OfflineTime { get; set; }
    /// <summary>
    /// ["<c>limitOpenTime</c>"] Restricted open time
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
    /// ["<c>launchTime</c>"] Launch time
    /// </summary>
    [JsonPropertyName("launchTime")]
    public DateTime? LaunchTime { get; set; }
    /// <summary>
    /// ["<c>fundInterval</c>"] Fund interval
    /// </summary>
    [JsonPropertyName("fundInterval")]
    public int FundInterval { get; set; }
    /// <summary>
    /// ["<c>minLeverage</c>"] Min leverage
    /// </summary>
    [JsonPropertyName("minLeverage")]
    public decimal MinLeverage { get; set; }
    /// <summary>
    /// ["<c>maxLeverage</c>"] Max leverage
    /// </summary>
    [JsonPropertyName("maxLeverage")]
    public decimal MaxLeverage { get; set; }
    /// <summary>
    /// ["<c>maintainTime</c>"] Maintenance time
    /// </summary>
    [JsonPropertyName("maintainTime")]
    public DateTime MaintainTime { get; set; }
    /// <summary>
    /// ["<c>symbolType</c>"] Symbol type
    /// </summary>
    [JsonPropertyName("symbolType")]
    public SymbolType SymbolType { get; set; }
    /// <summary>
    /// ["<c>maxMarketOrderQty</c>"] Max market order quantity
    /// </summary>
    [JsonPropertyName("maxMarketOrderQty")]
    public decimal MaxMarketOrderQuantity { get; set; }
}

