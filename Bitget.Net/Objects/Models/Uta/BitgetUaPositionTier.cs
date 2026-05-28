using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Position tier
/// </summary>
public record BitgetUaPositionTier
{
    /// <summary>
    /// ["<c>tier</c>"] Tier
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier { get; set; }
    /// <summary>
    /// ["<c>minTierValue</c>"] Min tier value
    /// </summary>
    [JsonPropertyName("minTierValue")]
    public decimal MinTierValue { get; set; }
    /// <summary>
    /// ["<c>maxTierValue</c>"] Max tier value
    /// </summary>
    [JsonPropertyName("maxTierValue")]
    public decimal MaxTierValue { get; set; }
    /// <summary>
    /// ["<c>leverage</c>"] Leverage
    /// </summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
    /// <summary>
    /// ["<c>mmr</c>"] Maintenance margin ratio
    /// </summary>
    [JsonPropertyName("mmr")]
    public decimal Mmr { get; set; }
}

