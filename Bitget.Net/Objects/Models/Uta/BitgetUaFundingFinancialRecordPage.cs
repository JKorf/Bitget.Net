using System;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Funding account financial record page
/// </summary>
public record BitgetUaFundingFinancialRecordPage
{
    /// <summary>
    /// ["<c>list</c>"] Records
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaFundingFinancialRecord[] Records { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

/// <summary>
/// Funding account financial record
/// </summary>
public record BitgetUaFundingFinancialRecord
{
    /// <summary>
    /// ["<c>id</c>"] Id
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string? Asset { get; set; }
    /// <summary>
    /// ["<c>groupType</c>"] Group type
    /// </summary>
    [JsonPropertyName("groupType")]
    public string? GroupType { get; set; }
    /// <summary>
    /// ["<c>type</c>"] Type
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    /// <summary>
    /// ["<c>amount</c>"] Quantity
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>balance</c>"] Balance
    /// </summary>
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}
