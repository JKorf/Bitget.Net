using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Strategy sub orders
/// </summary>
public record BitgetUaStrategySubOrders
{
    /// <summary>
    /// ["<c>list</c>"] Orders
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaStrategySubOrder[] Orders { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    [JsonConverter(typeof(NumberStringConverter))]
    public string? Cursor { get; set; }
}

/// <summary>
/// Strategy sub order
/// </summary>
public record BitgetUaStrategySubOrder
{
    /// <summary>
    /// ["<c>subOrderId</c>"] Sub order id
    /// </summary>
    [JsonPropertyName("subOrderId")]
    public string SubOrderId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>subClientOid</c>"] Sub client oid
    /// </summary>
    [JsonPropertyName("subClientOid")]
    public string? SubClientOrderId { get; set; }
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
    /// ["<c>price</c>"] Order price
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    /// <summary>
    /// ["<c>qty</c>"] Quantity
    /// </summary>
    [JsonPropertyName("qty")]
    public decimal? Quantity { get; set; }
    /// <summary>
    /// ["<c>cumExecQty</c>"] Quantity filled
    /// </summary>
    [JsonPropertyName("cumExecQty")]
    public decimal? QuantityFilled { get; set; }
    /// <summary>
    /// ["<c>avgPrice</c>"] Average price
    /// </summary>
    [JsonPropertyName("avgPrice")]
    public decimal? AveragePrice { get; set; }
    /// <summary>
    /// ["<c>side</c>"] Order side
    /// </summary>
    [JsonPropertyName("side")]
    public OrderSide? Side { get; set; }
    /// <summary>
    /// ["<c>posSide</c>"] Position side
    /// </summary>
    [JsonPropertyName("posSide")]
    public PositionSide? PositionSide { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public OrderStatus Status { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Create time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Update time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdateTime { get; set; }
}

