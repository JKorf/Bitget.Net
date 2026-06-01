using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Orders
/// </summary>
public record BitgetUaStrategyOrders
{
    /// <summary>
    /// ["<c>list</c>"] Orders
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaStrategyOrder[] Orders { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

/// <summary>
/// Strategy order
/// </summary>
public record BitgetUaStrategyOrder
{
    /// <summary>
    /// ["<c>orderId</c>"] Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>clientOid</c>"] Client oid
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
    /// ["<c>qty</c>"] Quantity
    /// </summary>
    [JsonPropertyName("qty")]
    public decimal? Quantity { get; set; }
    /// <summary>
    /// ["<c>posSide</c>"] Position side
    /// </summary>
    [JsonPropertyName("posSide")]
    public PositionSide? PositionSide { get; set; }
    /// <summary>
    /// ["<c>side</c>"] Order side
    /// </summary>
    [JsonPropertyName("side")]
    public OrderSide? Side { get; set; }
    /// <summary>
    /// Reduce only
    /// </summary>
    [JsonPropertyName("reduceOnly")]
    public bool ReduceOnly { get; set; }
    /// <summary>
    /// ["<c>status</c>"] Status
    /// </summary>
    [JsonPropertyName("status")]
    public StrategyStatus Status { get; set; }
    /// <summary>
    /// ["<c>type</c>"] Strategy type
    /// </summary>
    [JsonPropertyName("type")]
    public StrategyType? Type { get; set; }
    /// <summary>
    /// ["<c>tpTriggerBy</c>"] Take profit trigger by
    /// </summary>
    [JsonPropertyName("tpTriggerBy")]
    public PriceTriggerType? TpTriggerBy { get; set; }
    /// <summary>
    /// ["<c>slTriggerBy</c>"] Sl trigger by
    /// </summary>
    [JsonPropertyName("slTriggerBy")]
    public PriceTriggerType? SlTriggerBy { get; set; }
    /// <summary>
    /// ["<c>takeProfit</c>"] Take profit
    /// </summary>
    [JsonPropertyName("takeProfit")]
    public decimal? TakeProfit { get; set; }
    /// <summary>
    /// ["<c>stopLoss</c>"] Stop loss
    /// </summary>
    [JsonPropertyName("stopLoss")]
    public decimal? StopLoss { get; set; }
    /// <summary>
    /// ["<c>tpOrderType</c>"] Tp order type
    /// </summary>
    [JsonPropertyName("tpOrderType")]
    public OrderType? TpOrderType { get; set; }
    /// <summary>
    /// ["<c>slOrderType</c>"] Sl order type
    /// </summary>
    [JsonPropertyName("slOrderType")]
    public OrderType? SlOrderType { get; set; }
    /// <summary>
    /// ["<c>tpLimitPrice</c>"] Tp limit price
    /// </summary>
    [JsonPropertyName("tpLimitPrice")]
    public decimal? TpLimitPrice { get; set; }
    /// <summary>
    /// ["<c>slLimitPrice</c>"] Sl limit price
    /// </summary>
    [JsonPropertyName("slLimitPrice")]
    public decimal? SlLimitPrice { get; set; }
    /// <summary>
    /// ["<c>triggerType</c>"] Trigger type
    /// </summary>
    [JsonPropertyName("triggerType")]
    public TriggerType? TriggerType { get; set; }
    /// <summary>
    /// ["<c>triggerBy</c>"] Trigger by
    /// </summary>
    [JsonPropertyName("triggerBy")]
    public PriceTriggerType? TriggerBy { get; set; }
    /// <summary>
    /// ["<c>triggerPrice</c>"] Trigger price
    /// </summary>
    [JsonPropertyName("triggerPrice")]
    public decimal? TriggerPrice { get; set; }
    /// <summary>
    /// ["<c>triggerOrderType</c>"] Trigger order type
    /// </summary>
    [JsonPropertyName("triggerOrderType")]
    public OrderType? TriggerOrderType { get; set; }
    /// <summary>
    /// ["<c>triggerOrderPrice</c>"] Trigger order price
    /// </summary>
    [JsonPropertyName("triggerOrderPrice")]
    public decimal? TriggerOrderPrice { get; set; }
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

