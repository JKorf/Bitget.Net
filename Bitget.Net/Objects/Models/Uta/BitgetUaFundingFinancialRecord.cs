using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Funding account financial record
/// </summary>
public record BitgetUaFundingFinancialRecord
{
    /// <summary>
    /// ["<c>id</c>"] Record ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>groupType</c>"] Financial record group
    /// </summary>
    [JsonPropertyName("groupType")]
    public string GroupType { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>type</c>"] Financial record type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>amount</c>"] Signed change in asset quantity
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>balance</c>"] Asset balance after the change
    /// </summary>
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
    /// <summary>
    /// ["<c>ts</c>"] Creation timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}
