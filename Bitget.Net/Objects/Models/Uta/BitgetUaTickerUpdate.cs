using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// 
/// </summary>
public record BitgetUaTickerUpdate
{
    /// <summary>
    /// ["<c>bid1Price</c>"] Best bid price
    /// </summary>
    [JsonPropertyName("bid1Price")]
    public decimal BestBidPrice { get; set; }
    /// <summary>
    /// ["<c>lowPrice24h</c>"] Low price 24h
    /// </summary>
    [JsonPropertyName("lowPrice24h")]
    public decimal LowPrice { get; set; }
    /// <summary>
    /// ["<c>ask1Size</c>"] Best ask quantity
    /// </summary>
    [JsonPropertyName("ask1Size")]
    public decimal BestAskQuantity { get; set; }
    /// <summary>
    /// ["<c>volume24h</c>"] Volume 24h
    /// </summary>
    [JsonPropertyName("volume24h")]
    public decimal Volume { get; set; }
    /// <summary>
    /// ["<c>price24hPcnt</c>"] Price change percentage 24h
    /// </summary>
    [JsonPropertyName("price24hPcnt")]
    public decimal PriceChangePercentage { get; set; }
    /// <summary>
    /// ["<c>highPrice24h</c>"] High price 24h
    /// </summary>
    [JsonPropertyName("highPrice24h")]
    public decimal HighPrice { get; set; }
    /// <summary>
    /// ["<c>turnover24h</c>"] Turnover 24h
    /// </summary>
    [JsonPropertyName("turnover24h")]
    public decimal Turnover { get; set; }
    /// <summary>
    /// ["<c>bid1Size</c>"] Best bid quantity
    /// </summary>
    [JsonPropertyName("bid1Size")]
    public decimal BestBidQuantity { get; set; }
    /// <summary>
    /// ["<c>ask1Price</c>"] Best ask price
    /// </summary>
    [JsonPropertyName("ask1Price")]
    public decimal BestAskPrice { get; set; }
    /// <summary>
    /// ["<c>openPrice24h</c>"] Open price 24h
    /// </summary>
    [JsonPropertyName("openPrice24h")]
    public decimal OpenPrice { get; set; }
    /// <summary>
    /// ["<c>lastPrice</c>"] Last price
    /// </summary>
    [JsonPropertyName("lastPrice")]
    public decimal LastPrice { get; set; }
}

