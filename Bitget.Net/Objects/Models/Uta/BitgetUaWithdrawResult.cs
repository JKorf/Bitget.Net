using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Withdraw result
/// </summary>
public record BitgetUaWithdrawResult
{
    /// <summary>
    /// ["<c>orderId</c>"] Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>clientOid</c>"] Client oid
    /// </summary>
    [JsonPropertyName("clientOid")]
    public string? ClientOrderId { get; set; }
}

