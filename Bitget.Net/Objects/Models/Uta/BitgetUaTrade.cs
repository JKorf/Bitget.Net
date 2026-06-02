using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Trade info
/// </summary>
public record BitgetUaTrade
{
    /// <summary>
    /// ["<c>execId</c>"] Trade id
    /// </summary>
    [JsonPropertyName("execId")]
    public string TradeId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>execLinkId</c>"] Trade link id
    /// </summary>
    [JsonPropertyName("execLinkId")]
    public string TradeLinkId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>price</c>"] Price
    /// </summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    /// <summary>
    /// ["<c>size</c>"] Quantity
    /// </summary>
    [JsonPropertyName("size")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>side</c>"] Side
    /// </summary>
    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }
    /// <summary>
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>
    /// ["<c>isRPI</c>"] Is RPI trade
    /// </summary>
    [JsonPropertyName("isRPI")]
    public bool IsRPI { get; set; }
}

