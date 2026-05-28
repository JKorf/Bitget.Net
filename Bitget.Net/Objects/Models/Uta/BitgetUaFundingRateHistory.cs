using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

internal record BitgetUaFundingRateHistoryWrapper
{
    /// <summary>
    /// ["<c>resultList</c>"] Result list
    /// </summary>
    [JsonPropertyName("resultList")]
    public BitgetUaFundingRateHistory[] ResultList { get; set; } = [];
}

/// <summary>
/// Funding rate history
/// </summary>
public record BitgetUaFundingRateHistory
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
    /// ["<c>fundingRateTimestamp</c>"] Funding rate timestamp
    /// </summary>
    [JsonPropertyName("fundingRateTimestamp")]
    public DateTime Timestamp { get; set; }
}

