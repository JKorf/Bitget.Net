using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using System;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Deposit info
/// </summary>
public record BitgetUaDeposit
{
    /// <summary>
    /// ["<c>orderId</c>"] Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = string.Empty;
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
    public TransferType Destination { get; set; }
    /// <summary>
    /// ["<c>size</c>"] Quantity
    /// </summary>
    [JsonPropertyName("size")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public TransferStatus Status { get; set; }
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

