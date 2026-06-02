using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

internal record BitgetUaBatchResultWrapper
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaBatchResult[] List { get; set; } = [];
}

/// <summary>
/// Batch result
/// </summary>
public record BitgetUaBatchResult
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
    /// <summary>
    /// ["<c>code</c>"] Code
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }
    /// <summary>
    /// ["<c>msg</c>"] Msg
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}

