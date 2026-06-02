using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Repayment result
/// </summary>
public record BitgetUaRepayResult
{
    /// <summary>
    /// ["<c>result</c>"] Result success
    /// </summary>
    [JsonPropertyName("result")]
    public bool Result { get; set; }
    /// <summary>
    /// ["<c>repayAmount</c>"] Repay quantity
    /// </summary>
    [JsonPropertyName("repayAmount")]
    public decimal RepayQuantity { get; set; }
}

