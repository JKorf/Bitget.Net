using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

internal record BitgetUaOpenInterestHistoryWrapper
{
    /// <summary>
    /// ["<c>list</c>"] Result list
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaOpenInterestHistory[] ResultList { get; set; } = [];
}

/// <summary>
/// Open interest history
/// </summary>
public record BitgetUaOpenInterestHistory
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
    /// <summary>
    /// ["<c>oneSideOpenInterest</c>"] One side open interest
    /// </summary>
    [JsonPropertyName("oneSideOpenInterest")]
    public decimal OneSideOpenInterest { get; set; }
    /// <summary>
    /// ["<c>openInterestValue</c>"] Open interest value
    /// </summary>
    [JsonPropertyName("openInterestValue")]
    public decimal OpenInterestValue { get; set; }
    /// <summary>
    /// ["<c>oneSideOpenInterestValue</c>"] One side open interest value
    /// </summary>
    [JsonPropertyName("oneSideOpenInterestValue")]
    public decimal OneSideOpenInterestValue { get; set; }
    /// <summary>
    /// ["<c>timestamp</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
}

