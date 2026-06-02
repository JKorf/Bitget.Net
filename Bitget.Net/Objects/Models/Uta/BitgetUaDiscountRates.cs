using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Discount rate
/// </summary>
public record BitgetUaDiscountRates
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaDiscountRateValue[] List { get; set; } = [];
}

/// <summary>
/// Rate value
/// </summary>
public record BitgetUaDiscountRateValue
{
    /// <summary>
    /// ["<c>tierStartValue</c>"] Tier start value
    /// </summary>
    [JsonPropertyName("tierStartValue")]
    public decimal TierStartValue { get; set; }
    /// <summary>
    /// ["<c>discountRate</c>"] Discount rate
    /// </summary>
    [JsonPropertyName("discountRate")]
    public decimal DiscountRate { get; set; }
}

