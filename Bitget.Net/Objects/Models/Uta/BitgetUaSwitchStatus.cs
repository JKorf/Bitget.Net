using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Switch status
/// </summary>
public record BitgetUaSwitchStatus
{
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public SwitchStatus Status { get; set; }
    /// <summary>
    /// ["<c>reason</c>"] Reason
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = string.Empty;
}

