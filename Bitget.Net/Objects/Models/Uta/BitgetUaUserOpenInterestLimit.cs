using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// User max open interest limit
/// </summary>
public record BitgetUaUserOpenInterestLimit
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>singleUserLimit</c>"] Single user limit
    /// </summary>
    [JsonPropertyName("singleUserLimit")]
    public decimal SingleUserLimit { get; set; }
    /// <summary>
    /// ["<c>masterSubLimit</c>"] Master sub limit
    /// </summary>
    [JsonPropertyName("masterSubLimit")]
    public decimal MasterSubLimit { get; set; }
    /// <summary>
    /// ["<c>marketMakerLimit</c>"] Market maker limit
    /// </summary>
    [JsonPropertyName("marketMakerLimit")]
    public decimal MarketMakerLimit { get; set; }
}

