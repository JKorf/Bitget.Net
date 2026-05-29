using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Position history
/// </summary>
public record BitgetUaPositionHistory
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaPositionHistoryEntry[] List { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;
}

/// <summary>
/// Position history entry
/// </summary>
public record BitgetUaPositionHistoryEntry
{
    /// <summary>
    /// ["<c>positionId</c>"] Position id
    /// </summary>
    [JsonPropertyName("positionId")]
    public string PositionId { get; set; } = string.Empty;
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
    /// ["<c>posSide</c>"] Pos side
    /// </summary>
    [JsonPropertyName("posSide")]
    public PositionSide? PosSide { get; set; }
    /// <summary>
    /// ["<c>marginMode</c>"] Margin mode
    /// </summary>
    [JsonPropertyName("marginMode")]
    public MarginMode MarginMode { get; set; }
    /// <summary>
    /// ["<c>openPriceAvg</c>"] Open price average
    /// </summary>
    [JsonPropertyName("openPriceAvg")]
    public decimal OpenPriceAverage { get; set; }
    /// <summary>
    /// ["<c>closePriceAvg</c>"] Close price average
    /// </summary>
    [JsonPropertyName("closePriceAvg")]
    public decimal ClosePriceAverage { get; set; }
    /// <summary>
    /// ["<c>openTotalPos</c>"] Open total pos
    /// </summary>
    [JsonPropertyName("openTotalPos")]
    public decimal OpenTotalPos { get; set; }
    /// <summary>
    /// ["<c>closeTotalPos</c>"] Close total pos
    /// </summary>
    [JsonPropertyName("closeTotalPos")]
    public decimal CloseTotalPos { get; set; }
    /// <summary>
    /// ["<c>cumRealisedPnl</c>"] Realised pnl
    /// </summary>
    [JsonPropertyName("cumRealisedPnl")]
    public decimal RealisedPnl { get; set; }
    /// <summary>
    /// ["<c>netProfit</c>"] Net profit
    /// </summary>
    [JsonPropertyName("netProfit")]
    public decimal NetProfit { get; set; }
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

