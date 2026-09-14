using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Sub-account transfer records
/// </summary>
public record BitgetUaSubTransferRecords
{
    /// <summary>
    /// ["<c>list</c>"] Records
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaSubTransferRecord[] Records { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;
}

/// <summary>
/// Sub-account transfer record
/// </summary>
public record BitgetUaSubTransferRecord
{
    /// <summary>
    /// ["<c>transferId</c>"] Transfer id
    /// </summary>
    [JsonPropertyName("transferId")]
    public string TransferId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fromType</c>"] Transferring account type
    /// </summary>
    [JsonPropertyName("fromType")]
    public TransferAccountType FromType { get; set; }
    /// <summary>
    /// ["<c>toType</c>"] Receiving account type
    /// </summary>
    [JsonPropertyName("toType")]
    public TransferAccountType ToType { get; set; }
    /// <summary>
    /// ["<c>amount</c>"] Amount to transfer in
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fromUserId</c>"] Transferring account uid
    /// </summary>
    [JsonPropertyName("fromUserId")]
    public string FromUserId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>toUserId</c>"] Receiving account uid
    /// </summary>
    [JsonPropertyName("toUserId")]
    public string ToUserId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>status</c>"] Transfer status: Successful, Failed, Processing
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>clientOid</c>"] Custom id
    /// </summary>
    [JsonPropertyName("clientOid")]
    public string? ClientOrderId { get; set; }
    /// <summary>
    /// ["<c>oldTransferId</c>"] Old transfer id
    /// </summary>
    [JsonPropertyName("oldTransferId")]
    public string? OldTransferId { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Transfer creation time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Transfer update time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdateTime { get; set; }
}
