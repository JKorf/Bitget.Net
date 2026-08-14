using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Spot symbol
/// </summary>
public record BitgetUaSpotSymbol
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
    public int QuotePrecision { get; set; }
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
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public InstrumentStatus Status { get; set; }
    /// <summary>
    /// ["<c>maintainTime</c>"] Maintenance time
    /// </summary>
    [JsonPropertyName("maintainTime")]
    public DateTime? MaintainTime { get; set; }
    /// <summary>
    /// ["<c>maxPositionNum</c>"] Max positions
    /// </summary>
    [JsonPropertyName("maxPositionNum")]
    public int? MaxPositions { get; set; }
    /// <summary>
    /// ["<c>symbolType</c>"] Symbol type
    /// </summary>
    [JsonPropertyName("symbolType")]
    public SymbolType SymbolType { get; set; }
    /// <summary>
    /// ["<c>launchTime</c>"] Launch time
    /// </summary>
    [JsonPropertyName("launchTime")]
    public DateTime? LaunchTime { get; set; }
    /// <summary>
    /// ["<c>areaSymbol</c>"] Is area restricted
    /// </summary>
    [JsonPropertyName("areaSymbol")]
    public bool? AreaSymbol { get; set; }
    /// <summary>
    /// ["<c>isReality</c>"] Is realty
    /// </summary>
    [JsonPropertyName("isReality")]
    public bool? IsRealty { get; set; }
}

