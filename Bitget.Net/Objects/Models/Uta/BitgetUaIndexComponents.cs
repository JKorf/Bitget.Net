using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Index components
/// </summary>
public record BitgetUaIndexComponents
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>componentList</c>"] Components
    /// </summary>
    [JsonPropertyName("componentList")]
    public BitgetUaIndexComponent[] Components { get; set; } = [];
}

/// <summary>
/// Index component
/// </summary>
public record BitgetUaIndexComponent
{
    /// <summary>
    /// ["<c>exchange</c>"] Exchange
    /// </summary>
    [JsonPropertyName("exchange")]
    public string Exchange { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>spotPair</c>"] Spot pair
    /// </summary>
    [JsonPropertyName("spotPair")]
    public string SpotPair { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>equivalentPrice</c>"] Equivalent price
    /// </summary>
    [JsonPropertyName("equivalentPrice")]
    public decimal EquivalentPrice { get; set; }
    /// <summary>
    /// ["<c>weight</c>"] Weight
    /// </summary>
    [JsonPropertyName("weight")]
    public decimal Weight { get; set; }
}

