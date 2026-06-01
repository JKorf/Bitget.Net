using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Orders
/// </summary>
public record BitgetUaOrders
{
    /// <summary>
    /// ["<c>list</c>"] List
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaOrder[] List { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
}

/// <summary>
/// Order info
/// </summary>
public record BitgetUaOrder
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
    /// ["<c>price</c>"] Price
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    /// <summary>
    /// ["<c>qty</c>"] Quantity
    /// </summary>
    [JsonPropertyName("qty")]
    public decimal Quantity { get; set; }
    /// <summary>
    /// ["<c>amount</c>"] Quote quantity
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal QuoteQuantity { get; set; }
    /// <summary>
    /// ["<c>cumExecQty</c>"] Quantity executed
    /// </summary>
    [JsonPropertyName("cumExecQty")]
    public decimal QuantityFilled { get; set; }
    /// <summary>
    /// ["<c>cumExecValue</c>"] Quote quantity filled
    /// </summary>
    [JsonPropertyName("cumExecValue")]
    public decimal QuoteQuantityFilled { get; set; }
    /// <summary>
    /// ["<c>avgPrice</c>"] Average price
    /// </summary>
    [JsonPropertyName("avgPrice")]
    public decimal AveragePrice { get; set; }
    /// <summary>
    /// ["<c>timeInForce</c>"] Time in force
    /// </summary>
    [JsonPropertyName("timeInForce")]
    public TimeInForce TimeInForce { get; set; }
    /// <summary>
    /// ["<c>orderStatus</c>"] Order status
    /// </summary>
    [JsonPropertyName("orderStatus")]
    public OrderStatus Status { get; set; }
    /// <summary>
    /// ["<c>posSide</c>"] Position side
    /// </summary>
    [JsonPropertyName("posSide")]
    public PositionSide? PositionSide { get; set; }
    [JsonInclude, JsonPropertyName("holdSide")]
    internal PositionSide? HoldSide
    {
        set => PositionSide = value;
    }

    /// <summary>
    /// ["<c>holdMode</c>"] Hold mode
    /// </summary>
    [JsonPropertyName("holdMode")]
    public HoldingMode? HoldMode { get; set; }
    /// <summary>
    /// ["<c>tradeSide</c>"] Trade side
    /// </summary>
    [JsonPropertyName("tradeSide")]
    public TradeSide? TradeSide { get; set; }
    /// <summary>
    /// ["<c>reduceOnly</c>"] Reduce only
    /// </summary>
    [JsonPropertyName("reduceOnly")]
    public bool ReduceOnly { get; set; }
    /// <summary>
    /// ["<c>marginMode</c>"] Margin mode
    /// </summary>
    [JsonPropertyName("marginMode")]
    public MarginMode MarginMode { get; set; }
    /// <summary>
    /// ["<c>marginCoin</c>"] Margin asset
    /// </summary>
    [JsonPropertyName("marginCoin")]
    public string? MarginAsset { get; set; }
    /// <summary>
    /// ["<c>totalProfit</c>"] Total profit
    /// </summary>
    [JsonPropertyName("totalProfit")]
    public decimal? TotalProfit { get; set; }
    /// <summary>
    /// ["<c>leverage</c>"] Leverage
    /// </summary>
    [JsonPropertyName("leverage")]
    public decimal? Leverage { get; set; }
    /// <summary>
    /// ["<c>stpMode</c>"] Stp mode
    /// </summary>
    [JsonPropertyName("stpMode")]
    public StpMode StpMode { get; set; }
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
    /// ["<c>tpTriggerBy</c>"] Take profit trigger by
    /// </summary>
    [JsonPropertyName("tpTriggerBy")]
    public TriggerPriceType? TpTriggerBy { get; set; }
    /// <summary>
    /// ["<c>slTriggerBy</c>"] Stop loss trigger by
    /// </summary>
    [JsonPropertyName("slTriggerBy")]
    public TriggerPriceType? SlTriggerBy { get; set; }
    /// <summary>
    /// ["<c>tpOrderType</c>"] Take profit order type
    /// </summary>
    [JsonPropertyName("tpOrderType")]
    public OrderType? TpOrderType { get; set; }
    /// <summary>
    /// ["<c>slOrderType</c>"] Stop loss order type
    /// </summary>
    [JsonPropertyName("slOrderType")]
    public OrderType? SlOrderType { get; set; }
    /// <summary>
    /// ["<c>tpLimitPrice</c>"] Take profit limit price
    /// </summary>
    [JsonPropertyName("tpLimitPrice")]
    public decimal? TpLimitPrice { get; set; }
    /// <summary>
    /// ["<c>slLimitPrice</c>"] Stop loss limit price
    /// </summary>
    [JsonPropertyName("slLimitPrice")]
    public decimal? SlLimitPrice { get; set; }
    /// <summary>
    /// ["<c>feeDetail</c>"] Fee detail
    /// </summary>
    [JsonPropertyName("feeDetail")]
    public BitgetUaOrderFee[] FeeDetail { get; set; } = [];
    /// <summary>
    /// ["<c>cancelReason</c>"] Cancel reason
    /// </summary>
    [JsonPropertyName("cancelReason")]
    public string? CancelReason { get; set; }
    /// <summary>
    /// ["<c>delegateType</c>"] Delegate type
    /// </summary>
    [JsonPropertyName("delegateType")]
    public string? DelegateType { get; set; }
    /// <summary>
    /// ["<c>execType</c>"] Exec type
    /// </summary>
    [JsonPropertyName("execType")]
    public ExecutionType? ExecType { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Created time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// ["<c>updatedTime</c>"] Updated time
    /// </summary>
    [JsonPropertyName("updatedTime")]
    public DateTime? UpdateTime { get; set; }
}

/// <summary>
/// Fee info
/// </summary>
public record BitgetUaOrderFee
{
    /// <summary>
    /// ["<c>feeCoin</c>"] Fee asset
    /// </summary>
    [JsonPropertyName("feeCoin")]
    public string FeeAsset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>fee</c>"] Fee
    /// </summary>
    [JsonPropertyName("fee")]
    public decimal? Fee { get; set; }
}

