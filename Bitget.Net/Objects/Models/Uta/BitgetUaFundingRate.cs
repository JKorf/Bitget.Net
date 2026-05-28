using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Funding rate
/// </summary>
public record BitgetUaFundingRate
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fundingRate</c>"] Funding rate
    /// </summary>
    [JsonPropertyName("fundingRate")]
    public decimal FundingRate { get; set; }
    /// <summary>
    /// ["<c>fundingRateInterval</c>"] Funding rate interval
    /// </summary>
    [JsonPropertyName("fundingRateInterval")]
    public int FundingRateInterval { get; set; }
    /// <summary>
    /// ["<c>nextUpdate</c>"] Next update
    /// </summary>
    [JsonPropertyName("nextUpdate")]
    public DateTime NextUpdate { get; set; }
    /// <summary>
    /// ["<c>minFundingRate</c>"] Min funding rate
    /// </summary>
    [JsonPropertyName("minFundingRate")]
    public decimal MinFundingRate { get; set; }
    /// <summary>
    /// ["<c>maxFundingRate</c>"] Max funding rate
    /// </summary>
    [JsonPropertyName("maxFundingRate")]
    public decimal MaxFundingRate { get; set; }
}

