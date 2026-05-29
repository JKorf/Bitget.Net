using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Trade update
/// </summary>
public record BitgetUaTradeUpdate
{
    /// <summary>
    /// ["<c>p</c>"] Price
    /// </summary>
    [JsonPropertyName("p")]
    public decimal Price { get; set; }
    /// <summary>
    /// ["<c>S</c>"] Side
    /// </summary>
    [JsonPropertyName("S")]
    public OrderSide Side { get; set; }
    /// <summary>
    /// ["<c>T</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("T")]
    public DateTime Timestamp { get; set; }
    /// <summary>
    /// ["<c>v</c>"] Quantity
    /// </summary>
    [JsonPropertyName("v")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>i</c>"] Trade id
    /// </summary>
    [JsonPropertyName("i")]
    public string TradeId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>L</c>"] Trade link id
    /// </summary>
    [JsonPropertyName("L")]
    public string TradeLinkId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>isRPI</c>"] Is RPI
    /// </summary>
    [JsonPropertyName("isRPI")]
    public bool IsRPI { get; set; }
}

