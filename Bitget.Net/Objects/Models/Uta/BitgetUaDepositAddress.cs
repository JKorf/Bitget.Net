using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Deposit address
/// </summary>
public record BitgetUaDepositAddress
{
    /// <summary>
    /// ["<c>address</c>"] Address
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>chain</c>"] Network
    /// </summary>
    [JsonPropertyName("chain")]
    public string Network { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>tag</c>"] Tag
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
    /// <summary>
    /// ["<c>url</c>"] Url
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

