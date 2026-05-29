using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Deduct status
/// </summary>
public record BitgetUaDeductStatus
{
    /// <summary>
    /// ["<c>deduct</c>"] Deduct
    /// </summary>
    [JsonPropertyName("deduct")]
    public bool Deduct { get; set; }
}

