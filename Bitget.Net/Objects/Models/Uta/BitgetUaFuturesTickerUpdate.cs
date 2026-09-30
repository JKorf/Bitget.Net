using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Futures ticker update
/// </summary>
public record BitgetUaFuturesTickerUpdate : BitgetUaTickerUpdate
{
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
    /// ["<c>deliveryTime</c>"] Delivery time
    /// </summary>
    [JsonPropertyName("deliveryTime")]
    public DateTime? DeliveryTime { get; set; }
    /// <summary>
    /// ["<c>deliveryStartTime</c>"] Delivery start time
    /// </summary>
    [JsonPropertyName("deliveryStartTime")]
    public DateTime? DeliveryStartTime { get; set; }
    /// <summary>
    /// ["<c>deliveryStatus</c>"] Delivery status
    /// </summary>
    [JsonPropertyName("deliveryStatus")]
    public DeliveryStatus? DeliveryStatus { get; set; }
    /// <summary>
    /// ["<c>nextFundingTime</c>"] Next funding time
    /// </summary>
    [JsonPropertyName("nextFundingTime")]
    public DateTime? NextFundingTime { get; set; }
}

