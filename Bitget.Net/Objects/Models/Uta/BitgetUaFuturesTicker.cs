using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// 
/// </summary>
public record BitgetUaFuturesTicker
{
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
    /// ["<c>ts</c>"] Timestamp
    /// </summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>
    /// ["<c>lastPrice</c>"] Last price
    /// </summary>
    [JsonPropertyName("lastPrice")]
    public decimal LastPrice { get; set; }
    /// <summary>
    /// ["<c>openPrice24h</c>"] Open price 24h
    /// </summary>
    [JsonPropertyName("openPrice24h")]
    public decimal OpenPrice { get; set; }
    /// <summary>
    /// ["<c>highPrice24h</c>"] High price 24h
    /// </summary>
    [JsonPropertyName("highPrice24h")]
    public decimal HighPrice { get; set; }
    /// <summary>
    /// ["<c>lowPrice24h</c>"] Low price 24h
    /// </summary>
    [JsonPropertyName("lowPrice24h")]
    public decimal LowPrice { get; set; }
    /// <summary>
    /// ["<c>ask1Price</c>"] Best ask price
    /// </summary>
    [JsonPropertyName("ask1Price")]
    public decimal? BestAskPrice { get; set; }
    /// <summary>
    /// ["<c>bid1Price</c>"] Best bid price
    /// </summary>
    [JsonPropertyName("bid1Price")]
    public decimal? BestBidPrice { get; set; }
    /// <summary>
    /// ["<c>bid1Size</c>"] Best bid quantity
    /// </summary>
    [JsonPropertyName("bid1Size")]
    public decimal? BestBidQuantity { get; set; }
    /// <summary>
    /// ["<c>ask1Size</c>"] Best ask quantity
    /// </summary>
    [JsonPropertyName("ask1Size")]
    public decimal? BestAskQuantity { get; set; }
    /// <summary>
    /// ["<c>price24hPcnt</c>"] Price change percentage 24h
    /// </summary>
    [JsonPropertyName("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }
    /// <summary>
    /// ["<c>volume24h</c>"] Volume 24h
    /// </summary>
    [JsonPropertyName("volume24h")]
    public decimal Volume { get; set; }
    /// <summary>
    /// ["<c>turnover24h</c>"] Turnover 24h
    /// </summary>
    [JsonPropertyName("turnover24h")]
    public decimal Turnover { get; set; }
    /// <summary>
    /// ["<c>indexPrice</c>"] Index price
    /// </summary>
    [JsonPropertyName("indexPrice")]
    public decimal IndexPrice { get; set; }
    /// <summary>
    /// ["<c>markPrice</c>"] Mark price
    /// </summary>
    [JsonPropertyName("markPrice")]
    public decimal MarkPrice { get; set; }
    /// <summary>
    /// ["<c>fundingRate</c>"] Funding rate
    /// </summary>
    [JsonPropertyName("fundingRate")]
    public decimal? FundingRate { get; set; }
    /// <summary>
    /// ["<c>openInterest</c>"] Open interest
    /// </summary>
    [JsonPropertyName("openInterest")]
    public decimal OpenInterest { get; set; }
    /// <summary>
    /// ["<c>deliveryStartTime</c>"] Delivery start time
    /// </summary>
    [JsonPropertyName("deliveryStartTime")]
    public DateTime? DeliveryStartTime { get; set; }
    /// <summary>
    /// ["<c>deliveryTime</c>"] Delivery time
    /// </summary>
    [JsonPropertyName("deliveryTime")]
    public DateTime? DeliveryTime { get; set; }
    /// <summary>
    /// ["<c>deliveryStatus</c>"] Delivery status
    /// </summary>
    [JsonPropertyName("deliveryStatus")]
    public DeliveryStatus? DeliveryStatus { get; set; }
}

