using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Open interest limit
/// </summary>
public record BitgetUaOpenInterestLimit
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
    /// ["<c>totalNotionalValue</c>"] Total notional value
    /// </summary>
    [JsonPropertyName("totalNotionalValue")]
    public decimal TotalNotionalValue { get; set; }
}

