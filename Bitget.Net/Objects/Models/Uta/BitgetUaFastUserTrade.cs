using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Trade info
/// </summary>
public record BitgetUaFastUserTrade
{
    /// <summary>
    /// ["<c>execId</c>"] Trade id
    /// </summary>
    [JsonPropertyName("execId")]
    public string TradeId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>orderId</c>"] Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>clientOid</c>"] Client order id
    /// </summary>
    [JsonPropertyName("clientOid")]
    public string? ClientOrderId { get; set; }
    /// <summary>
    /// ["<c>category</c>"] Category
    /// </summary>
    [JsonPropertyName("category")]
    public ProductCategory Category { get; set; }
    /// <summary>
    /// ["<c>symbol</c>"] Symbol
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>side</c>"] Side
    /// </summary>
    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }
    /// <summary>
    /// ["<c>holdSide</c>"] Position side
    /// </summary>
    [JsonPropertyName("holdSide")]
    public PositionSide PositionSide { get; set; }
    /// <summary>
    /// ["<c>execPrice</c>"] Trade price
    /// </summary>
    [JsonPropertyName("execPrice")]
    public decimal Price { get; set; }
    /// <summary>
    /// ["<c>execQty</c>"] Quantity
    /// </summary>
    [JsonPropertyName("execQty")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>tradeScope</c>"] Trade scope
    /// </summary>
    [JsonPropertyName("tradeScope")]
    public Role TradeScope { get; set; }
    /// <summary>
    /// ["<c>execTime</c>"] Trade time
    /// </summary>
    [JsonPropertyName("execTime")]
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Updated time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdatedTime { get; set; }
}


