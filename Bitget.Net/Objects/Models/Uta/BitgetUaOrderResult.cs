using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Order result
/// </summary>
public record BitgetUaOrderResult
{
    /// <summary>
    /// ["<c>clientOid</c>"] Client oid
    /// </summary>
    [JsonPropertyName("clientOid")]
    public string? ClientOrderId { get; set; }
    /// <summary>
    /// ["<c>orderId</c>"] Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = string.Empty;
}

/// <summary>
/// Order websocket result
/// </summary>
public record BitgetUaSocketOrderResult: BitgetUaOrderResult
{
    /// <summary>
    /// ["<c>cTime</c>"] Order create time
    /// </summary>
    [JsonPropertyName("cTime")]
    public DateTime? CreateTime { get; set; }
    /// <summary>
    /// ["<c>receiveTime</c>"] Gateway receive time
    /// </summary>
    [JsonPropertyName("receiveTime")]
    public DateTime? ReceiveTime { get; set; }
    /// <summary>
    /// ["<c>pushTime</c>"] Gateway push time
    /// </summary>
    [JsonPropertyName("pushTime")]
    public DateTime? PushTime { get; set; }
}