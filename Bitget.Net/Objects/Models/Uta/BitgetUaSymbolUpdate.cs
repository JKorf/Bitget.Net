using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using System;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// 
/// </summary>
public record BitgetUaSymbolUpdate
{
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
    /// ["<c>marketPriceRatio</c>"] Market price ratio
    /// </summary>
    [JsonPropertyName("marketPriceRatio")]
    public decimal MarketPriceRatio { get; set; }
    /// <summary>
    /// ["<c>priceProtectThreshold</c>"] Price protect threshold
    /// </summary>
    [JsonPropertyName("priceProtectThreshold")]
    public decimal PriceProtectThreshold { get; set; }
    /// <summary>
    /// ["<c>feeRateUpRatio</c>"] Fee rate up ratio
    /// </summary>
    [JsonPropertyName("feeRateUpRatio")]
    public decimal FeeRateUpRatio { get; set; }
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
    /// ["<c>minOrderAmount</c>"] Min order amount
    /// </summary>
    [JsonPropertyName("minOrderAmount")]
    public decimal MinOrderAmount { get; set; }
    /// <summary>
    /// ["<c>maxMarketOrderQty</c>"] Max market order quantity
    /// </summary>
    [JsonPropertyName("maxMarketOrderQty")]
    public decimal MaxMarketOrderQuantity { get; set; }
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
    public int QuotePrecision { get; set; }
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
    /// ["<c>type</c>"] Contract type
    /// </summary>
    [JsonPropertyName("type")]
    public ContractType ContractType { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public InstrumentStatus Status { get; set; }
    /// <summary>
    /// ["<c>openTime</c>"] Open time
    /// </summary>
    [JsonPropertyName("openTime")]
    public DateTime OpenTime { get; set; }
    /// <summary>
    /// ["<c>offTime</c>"] Offline time
    /// </summary>
    [JsonPropertyName("offTime")]
    public DateTime? OffTime { get; set; }
    /// <summary>
    /// ["<c>limitOpenTime</c>"] Limit open time
    /// </summary>
    [JsonPropertyName("limitOpenTime")]
    public DateTime? LimitOpenTime { get; set; }
}

