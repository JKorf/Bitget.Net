using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// User trades
/// </summary>
public record BitgetUaUserTrades
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaUserTrade[] List { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public decimal Cursor { get; set; }
}

/// <summary>
/// Trade info
/// </summary>
public record BitgetUaUserTrade
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
    /// ["<c>orderType</c>"] Order type
    /// </summary>
    [JsonPropertyName("orderType")]
    public OrderType OrderType { get; set; }
    /// <summary>
    /// ["<c>side</c>"] Side
    /// </summary>
    [JsonPropertyName("side")]
    public OrderSide Side { get; set; }
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
    /// ["<c>execValue</c>"] Trade value
    /// </summary>
    [JsonPropertyName("execValue")]
    public decimal Value { get; set; }
    /// <summary>
    /// ["<c>tradeScope</c>"] Trade scope
    /// </summary>
    [JsonPropertyName("tradeScope")]
    public Role TradeScope { get; set; }
    /// <summary>
    /// ["<c>tradeSide</c>"] Trade side
    /// </summary>
    [JsonPropertyName("tradeSide")]
    public TradeSide TradeSide { get; set; }
    /// <summary>
    /// ["<c>holdSize</c>"] Position side
    /// </summary>
    [JsonPropertyName("holdSide")]
    public PositionSide? PositionSide { get; set; }
    /// <summary>
    /// ["<c>feeDetail</c>"] Fee detail
    /// </summary>
    [JsonPropertyName("feeDetail")]
    public BitgetUaOrderFee[] FeeDetail { get; set; } = [];
    /// <summary>
    /// ["<c>createdTime</c>"] Create time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Updated time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdatedTime { get; set; }
    /// <summary>
    /// ["<c>execTime</c>"] Trade timestamp
    /// </summary>
    [JsonPropertyName("execTime")]
    public DateTime? TradeTime { get; set; }
    /// <summary>
    /// ["<c>execPnl</c>"] Profit and loss
    /// </summary>
    [JsonPropertyName("execPnl")]
    public decimal? Pnl { get; set; }
    /// <summary>
    /// ["<c>isRPI</c>"] Is RPI
    /// </summary>
    [JsonPropertyName("isRPI")]
    public bool IsRPI { get; set; }
}


