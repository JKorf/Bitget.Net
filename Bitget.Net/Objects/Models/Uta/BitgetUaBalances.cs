using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Balance info
/// </summary>
public record BitgetUaBalances
{
    /// <summary>
    /// ["<c>accountEquity</c>"] Account equity
    /// </summary>
    [JsonPropertyName("accountEquity")]
    public decimal AccountEquity { get; set; }
    /// <summary>
    /// ["<c>usdtEquity</c>"] Usdt equity
    /// </summary>
    [JsonPropertyName("usdtEquity")]
    public decimal UsdtEquity { get; set; }
    /// <summary>
    /// ["<c>btcEquity</c>"] Btc equity
    /// </summary>
    [JsonPropertyName("btcEquity")]
    public decimal BtcEquity { get; set; }
    /// <summary>
    /// ["<c>unrealisedPnl</c>"] Unrealised profit and loss
    /// </summary>
    [JsonPropertyName("unrealisedPnl")]
    public decimal UnrealisedPnl { get; set; }
    /// <summary>
    /// ["<c>usdtUnrealisedPnl</c>"] Usdt unrealised profit and loss
    /// </summary>
    [JsonPropertyName("usdtUnrealisedPnl")]
    public decimal UsdtUnrealisedPnl { get; set; }
    /// <summary>
    /// ["<c>btcUnrealizedPnl</c>"] Btc unrealized profit and loss
    /// </summary>
    [JsonPropertyName("btcUnrealizedPnl")]
    public decimal BtcUnrealizedPnl { get; set; }
    /// <summary>
    /// ["<c>effEquity</c>"] Effective equity
    /// </summary>
    [JsonPropertyName("effEquity")]
    public decimal EffectiveEquity { get; set; }
    /// <summary>
    /// ["<c>mmr</c>"] Maintenance margin rate
    /// </summary>
    [JsonPropertyName("mmr")]
    public decimal Mmr { get; set; }
    /// <summary>
    /// ["<c>imr</c>"] Initial margin rate
    /// </summary>
    [JsonPropertyName("imr")]
    public decimal Imr { get; set; }
    /// <summary>
    /// ["<c>mgnRatio</c>"] Margin ratio
    /// </summary>
    [JsonPropertyName("mgnRatio")]
    public decimal MarginRatio { get; set; }
    /// <summary>
    /// ["<c>positionMgnRatio</c>"] Position margin ratio
    /// </summary>
    [JsonPropertyName("positionMgnRatio")]
    public decimal PositionMarginRatio { get; set; }
    /// <summary>
    /// ["<c>assets</c>"] Assets
    /// </summary>
    [JsonPropertyName("assets")]
    public BitgetUaBalancesAsset[] Assets { get; set; } = [];
}

/// <summary>
/// Asset balance
/// </summary>
public record BitgetUaBalancesAsset
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>equity</c>"] Equity
    /// </summary>
    [JsonPropertyName("equity")]
    public decimal Equity { get; set; }
    /// <summary>
    /// ["<c>usdValue</c>"] Usd value
    /// </summary>
    [JsonPropertyName("usdValue")]
    public decimal UsdValue { get; set; }
    /// <summary>
    /// ["<c>balance</c>"] Balance
    /// </summary>
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
    /// <summary>
    /// ["<c>available</c>"] Available
    /// </summary>
    [JsonPropertyName("available")]
    public decimal Available { get; set; }
    /// <summary>
    /// ["<c>debt</c>"] Debt
    /// </summary>
    [JsonPropertyName("debt")]
    public decimal Debt { get; set; }
    /// <summary>
    /// ["<c>locked</c>"] Locked
    /// </summary>
    [JsonPropertyName("locked")]
    public decimal Locked { get; set; }
}

