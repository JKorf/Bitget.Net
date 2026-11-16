using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// User open interest limit
/// </summary>
public record BitgetUaOpenInterestLimitUpdate
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>notionalValue</c>"] Notional value
    /// </summary>
    [JsonPropertyName("notionalValue")]
    public decimal NotionalValue { get; set; }
    /// <summary>
    /// ["<c>singlePositionRatio</c>"] Single position ratio
    /// </summary>
    [JsonPropertyName("singlePositionRatio")]
    public decimal SinglePositionRatio { get; set; }
    /// <summary>
    /// ["<c>totalNotionalValue</c>"] Total notional value
    /// </summary>
    [JsonPropertyName("totalNotionalValue")]
    public decimal TotalNotionalValue { get; set; }
    /// <summary>
    /// ["<c>totalPositionRatio</c>"] Total position ratio
    /// </summary>
    [JsonPropertyName("totalPositionRatio")]
    public decimal TotalPositionRatio { get; set; }
}

