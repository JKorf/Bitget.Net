using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Max transferable quantity for an asset
/// </summary>
public record BitgetUaMaxTransferable
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>maxTransfer</c>"] Max transfer
    /// </summary>
    [JsonPropertyName("maxTransfer")]
    public decimal MaxTransfer { get; set; }
    /// <summary>
    /// ["<c>borrowMaxTransfer</c>"] Borrow max transfer
    /// </summary>
    [JsonPropertyName("borrowMaxTransfer")]
    public decimal BorrowMaxTransfer { get; set; }
}

