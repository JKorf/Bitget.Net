using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Open interest symbol list
/// </summary>
public record BitgetUaOpenInterest
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaOpenInterestSymbol[] List { get; set; } = [];
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Open interest
/// </summary>
public record BitgetUaOpenInterestSymbol
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>openInterest</c>"] Open interest
    /// </summary>
    [JsonPropertyName("openInterest")]
    public decimal OpenInterest { get; set; }
}

