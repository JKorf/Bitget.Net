using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Convert records
/// </summary>
public record BitgetUaConvertRecords
{
    /// <summary>
    /// ["<c>list</c>"] Records
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaConvertRecord[] Records { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;
}

/// <summary>
/// Convert record
/// </summary>
public record BitgetUaConvertRecord
{
    /// <summary>
    /// ["<c>fromCoin</c>"] From asset
    /// </summary>
    [JsonPropertyName("fromCoin")]
    public string FromAsset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fromCoinSize</c>"] From asset quantity
    /// </summary>
    [JsonPropertyName("fromCoinSize")]
    public decimal FromAssetQuantity { get; set; }
    /// <summary>
    /// ["<c>toCoin</c>"] To asset
    /// </summary>
    [JsonPropertyName("toCoin")]
    public string ToAsset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>toCoinSize</c>"] To asset quantity
    /// </summary>
    [JsonPropertyName("toCoinSize")]
    public decimal ToAssetQuantity { get; set; }
    /// <summary>
    /// ["<c>price</c>"] Price
    /// </summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}

