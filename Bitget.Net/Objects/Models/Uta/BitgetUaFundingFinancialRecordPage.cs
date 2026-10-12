using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Funding account financial record page
/// </summary>
public record BitgetUaFundingFinancialRecordPage
{
    /// <summary>
    /// ["<c>list</c>"] Records; can be null when no records match
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaFundingFinancialRecord[]? Records { get; set; }
    /// <summary>
    /// ["<c>cursor</c>"] Cursor for the next page
    /// </summary>
    [JsonPropertyName("cursor")]
    [JsonConverter(typeof(NumberStringConverter))]
    public string? Cursor { get; set; }
}
