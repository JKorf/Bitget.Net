using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// ADL rank
/// </summary>
public record BitgetUaAdlRank
{
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
    /// ["<c>adlRank</c>"] Adl rank
    /// </summary>
    [JsonPropertyName("adlRank")]
    public decimal AdlRank { get; set; }
    /// <summary>
    /// ["<c>holdSide</c>"] Hold side
    /// </summary>
    [JsonPropertyName("holdSide")]
    public PositionSide PositionSide { get; set; }
}

