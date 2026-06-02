using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Interest rate
/// </summary>
public record BitgetUaLoanInterestRate
{
    /// <summary>
    /// ["<c>dailyInterest</c>"] Daily interest
    /// </summary>
    [JsonPropertyName("dailyInterest")]
    public decimal DailyInterest { get; set; }
    /// <summary>
    /// ["<c>annualInterest</c>"] Annual interest
    /// </summary>
    [JsonPropertyName("annualInterest")]
    public decimal AnnualInterest { get; set; }
    /// <summary>
    /// ["<c>limit</c>"] Limit
    /// </summary>
    [JsonPropertyName("limit")]
    public decimal Limit { get; set; }
}

