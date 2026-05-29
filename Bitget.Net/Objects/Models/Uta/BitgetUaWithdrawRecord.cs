using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Withdrawal record
/// </summary>
public record BitgetUaWithdrawRecord
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
    /// ["<c>recordId</c>"] Record id
    /// </summary>
    [JsonPropertyName("recordId")]
    public string RecordId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>type</c>"] Type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>dest</c>"] Destination
    /// </summary>
    [JsonPropertyName("dest")]
    public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>size</c>"] Quantity
    /// </summary>
    [JsonPropertyName("size")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public WithdrawStatus Status { get; set; }
    /// <summary>
    /// ["<c>fromAddress</c>"] From address
    /// </summary>
    [JsonPropertyName("fromAddress")]
    public string FromAddress { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>toAddress</c>"] To address
    /// </summary>
    [JsonPropertyName("toAddress")]
    public string ToAddress { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>chain</c>"] Network
    /// </summary>
    [JsonPropertyName("chain")]
    public string Network { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fee</c>"] Fee
    /// </summary>
    [JsonPropertyName("fee")]
    public decimal Fee { get; set; }
    /// <summary>
    /// ["<c>confirm</c>"] Confirmations
    /// </summary>
    [JsonPropertyName("confirm")]
    public int? Confirm { get; set; }
    /// <summary>
    /// ["<c>tag</c>"] Tag
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Create time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Update time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdateTime { get; set; }
}

