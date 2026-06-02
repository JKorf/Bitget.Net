using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Fee rates
/// </summary>
public record BitgetUaFeeRate
{
    /// <summary>
    /// ["<c>makerFeeRate</c>"] Maker fee rate
    /// </summary>
    [JsonPropertyName("makerFeeRate")]
    public decimal MakerFeeRate { get; set; }
    /// <summary>
    /// ["<c>takerFeeRate</c>"] Taker fee rate
    /// </summary>
    [JsonPropertyName("takerFeeRate")]
    public decimal TakerFeeRate { get; set; }
}

