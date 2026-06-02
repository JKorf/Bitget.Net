using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

internal record BitgetUaPositionWrapper
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaPosition[] List { get; set; } = [];
}

/// <summary>
/// Position info
/// </summary>
public record BitgetUaPosition
{
    /// <summary>
    /// ["<c>category</c>"] Category
    /// </summary>
    [JsonPropertyName("category")]
    public ProductCategory Category { get; set; }
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>marginCoin</c>"] Margin asset
    /// </summary>
    [JsonPropertyName("marginCoin")]
    public string MarginAsset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>holdMode</c>"] Hold mode
    /// </summary>
    [JsonPropertyName("holdMode")]
    public HoldingMode HoldMode { get; set; }
    /// <summary>
    /// ["<c>posSide</c>"] Position side
    /// </summary>
    [JsonPropertyName("posSide")]
    public PositionSide? PositionSide { get; set; }
    /// <summary>
    /// ["<c>marginMode</c>"] Margin mode
    /// </summary>
    [JsonPropertyName("marginMode")]
    public MarginMode MarginMode { get; set; }
    /// <summary>
    /// ["<c>positionBalance</c>"] Position balance
    /// </summary>
    [JsonPropertyName("positionBalance")]
    public decimal PositionBalance { get; set; }
    /// <summary>
    /// ["<c>available</c>"] Available
    /// </summary>
    [JsonPropertyName("available")]
    public decimal Available { get; set; }
    /// <summary>
    /// ["<c>frozen</c>"] Frozen
    /// </summary>
    [JsonPropertyName("frozen")]
    public decimal Frozen { get; set; }
    /// <summary>
    /// ["<c>total</c>"] Total
    /// </summary>
    [JsonPropertyName("total")]
    public decimal Total { get; set; }
    /// <summary>
    /// ["<c>leverage</c>"] Leverage
    /// </summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
    /// <summary>
    /// ["<c>curRealisedPnl</c>"] Realized profit and loss
    /// </summary>
    [JsonPropertyName("curRealisedPnl")]
    public decimal RealisedPnl { get; set; }
    /// <summary>
    /// ["<c>avgPrice</c>"] Average entry price
    /// </summary>
    [JsonPropertyName("avgPrice")]
    public decimal AveragePrice { get; set; }
    /// <summary>
    /// ["<c>positionStatus</c>"] Position status
    /// </summary>
    [JsonPropertyName("positionStatus")]
    public string PositionStatus { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>unrealisedPnl</c>"] Unrealised profit and loss
    /// </summary>
    [JsonPropertyName("unrealisedPnl")]
    public decimal UnrealisedPnl { get; set; }
    /// <summary>
    /// ["<c>liquidationPrice</c>"] Liquidation price
    /// </summary>
    [JsonPropertyName("liquidationPrice")]
    public decimal LiquidationPrice { get; set; }
    /// <summary>
    /// ["<c>mmr</c>"] Mmr
    /// </summary>
    [JsonPropertyName("mmr")]
    public decimal Mmr { get; set; }
    /// <summary>
    /// ["<c>profitRate</c>"] Profit rate
    /// </summary>
    [JsonPropertyName("profitRate")]
    public decimal ProfitRate { get; set; }
    /// <summary>
    /// ["<c>markPrice</c>"] Mark price
    /// </summary>
    [JsonPropertyName("markPrice")]
    public decimal MarkPrice { get; set; }
    /// <summary>
    /// ["<c>breakEvenPrice</c>"] Break even price
    /// </summary>
    [JsonPropertyName("breakEvenPrice")]
    public decimal BreakEvenPrice { get; set; }
    /// <summary>
    /// ["<c>totalFunding</c>"] Total funding
    /// </summary>
    [JsonPropertyName("totalFunding")]
    public decimal TotalFunding { get; set; }
    /// <summary>
    /// ["<c>openFeeTotal</c>"] Open fee total
    /// </summary>
    [JsonPropertyName("openFeeTotal")]
    public decimal OpenFeeTotal { get; set; }
    /// <summary>
    /// ["<c>closeFeeTotal</c>"] Close fee total
    /// </summary>
    [JsonPropertyName("closeFeeTotal")]
    public decimal CloseFeeTotal { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Create time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Update time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdateTime { get; set; }
}

