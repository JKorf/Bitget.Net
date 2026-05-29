using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Delta info
/// </summary>
public record BitgetUaDeltaInfo
{
    /// <summary>
    /// ["<c>deltaEquityRatio</c>"] Delta equity ratio
    /// </summary>
    [JsonPropertyName("deltaEquityRatio")]
    public decimal DeltaEquityRatio { get; set; }
    /// <summary>
    /// ["<c>deltaThreshold</c>"] Delta threshold
    /// </summary>
    [JsonPropertyName("deltaThreshold")]
    public decimal DeltaThreshold { get; set; }
    /// <summary>
    /// ["<c>positionThreshold</c>"] Position threshold
    /// </summary>
    [JsonPropertyName("positionThreshold")]
    public decimal PositionThreshold { get; set; }
    /// <summary>
    /// ["<c>list</c>"] Assets
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaDeltaInfoAsset[] Assets { get; set; } = [];
}

/// <summary>
/// Delta asset
/// </summary>
public record BitgetUaDeltaInfoAsset
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>positionRatio</c>"] Position ratio
    /// </summary>
    [JsonPropertyName("positionRatio")]
    public decimal PositionRatio { get; set; }
}

