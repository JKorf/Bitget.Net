using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Max open available info
/// </summary>
public record BitgetUaMaxOpenAvailable
{
    /// <summary>
    /// ["<c>available</c>"] Available
    /// </summary>
    [JsonPropertyName("available")]
    public decimal Available { get; set; }
    /// <summary>
    /// ["<c>maxOpen</c>"] Max open
    /// </summary>
    [JsonPropertyName("maxOpen")]
    public decimal? MaxOpen { get; set; }
    /// <summary>
    /// ["<c>buyOpenCost</c>"] Buy open cost
    /// </summary>
    [JsonPropertyName("buyOpenCost")]
    public decimal? BuyOpenCost { get; set; }
    /// <summary>
    /// ["<c>sellOpenCost</c>"] Sell open cost
    /// </summary>
    [JsonPropertyName("sellOpenCost")]
    public decimal? SellOpenCost { get; set; }
    /// <summary>
    /// ["<c>maxBuyOpen</c>"] Max buy open
    /// </summary>
    [JsonPropertyName("maxBuyOpen")]
    public decimal? MaxBuyOpen { get; set; }
    /// <summary>
    /// ["<c>maxSellOpen</c>"] Max sell open
    /// </summary>
    [JsonPropertyName("maxSellOpen")]
    public decimal? MaxSellOpen { get; set; }
    /// <summary>
    /// ["<c>maxBuyAvailable</c>"] Max buy available
    /// </summary>
    [JsonPropertyName("maxBuyAvailable")]
    public decimal? MaxBuyAvailable { get; set; }
    /// <summary>
    /// ["<c>maxSellAvailable</c>"] Max sell available
    /// </summary>
    [JsonPropertyName("maxSellAvailable")]
    public decimal? MaxSellAvailable { get; set; }
}

