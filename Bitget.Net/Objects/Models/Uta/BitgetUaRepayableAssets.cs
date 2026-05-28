using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Repayable assets
/// </summary>
public record BitgetUaRepayableAssets
{
    /// <summary>
    /// ["<c>repayableCoinList</c>"] Assets
    /// </summary>
    [JsonPropertyName("repayableCoinList")]
    public BitgetUaRepayableAsset[] Assets { get; set; } = [];
    /// <summary>
    /// ["<c>maxSelection</c>"] Max selection
    /// </summary>
    [JsonPropertyName("maxSelection")]
    public int MaxSelection { get; set; }
}

/// <summary>
/// Asset
/// </summary>
public record BitgetUaRepayableAsset
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>size</c>"] Quantity
    /// </summary>
    [JsonPropertyName("size")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>amount</c>"] Usd value
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal UsdValue { get; set; }
}

