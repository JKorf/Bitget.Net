using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Payment assets
/// </summary>
public record BitgetUaPaymentAssets
{
    /// <summary>
    /// ["<c>paymentCoinList</c>"] Payment assets
    /// </summary>
    [JsonPropertyName("paymentCoinList")]
    public BitgetUaPaymentAsset[] PaymentAssets { get; set; } = [];
    /// <summary>
    /// ["<c>maxSelection</c>"] Max selection
    /// </summary>
    [JsonPropertyName("maxSelection")]
    public int MaxSelection { get; set; }
}

/// <summary>
/// Payment asset
/// </summary>
public record BitgetUaPaymentAsset
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
    /// ["<c>amount</c>"] USD value
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal UsdValue { get; set; }
}

