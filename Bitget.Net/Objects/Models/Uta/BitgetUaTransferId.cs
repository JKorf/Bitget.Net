using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Transfer id
/// </summary>
public record BitgetUaTransferId
{
    /// <summary>
    /// ["<c>transferId</c>"] Transfer id
    /// </summary>
    [JsonPropertyName("transferId")]
    public string TransferId { get; set; } = string.Empty;
}

