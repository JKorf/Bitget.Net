using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Account update
/// </summary>
public record BitgetUaAccountUpdate
{
    /// <summary>
    /// ["<c>unrealisedPnL</c>"] Unrealised profit and loss
    /// </summary>
    [JsonPropertyName("unrealisedPnL")]
    public decimal UnrealisedPnL { get; set; }
    /// <summary>
    /// ["<c>totalEquity</c>"] Total equity
    /// </summary>
    [JsonPropertyName("totalEquity")]
    public decimal TotalEquity { get; set; }
    /// <summary>
    /// ["<c>positionMgnRatio</c>"] Position mgn ratio
    /// </summary>
    [JsonPropertyName("positionMgnRatio")]
    public decimal PositionMgnRatio { get; set; }
    /// <summary>
    /// ["<c>mmr</c>"] Maintenance margin
    /// </summary>
    [JsonPropertyName("mmr")]
    public decimal Mmr { get; set; }
    /// <summary>
    /// ["<c>effEquity</c>"] Effective equity
    /// </summary>
    [JsonPropertyName("effEquity")]
    public decimal EffectiveEquity { get; set; }
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
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public BitgetUaAccountUpdateAsset[] Asset { get; set; } = [];
}

/// <summary>
/// Account asset
/// </summary>
public record BitgetUaAccountUpdateAsset
{
    /// <summary>
    /// ["<c>debts</c>"] Debts
    /// </summary>
    [JsonPropertyName("debts")]
    public decimal Debts { get; set; }
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
    /// ["<c>borrow</c>"] Borrow
    /// </summary>
    [JsonPropertyName("borrow")]
    public decimal Borrow { get; set; }
    /// <summary>
    /// ["<c>locked</c>"] Locked
    /// </summary>
    [JsonPropertyName("locked")]
    public decimal Locked { get; set; }
    /// <summary>
    /// ["<c>equity</c>"] Equity
    /// </summary>
    [JsonPropertyName("equity")]
    public decimal Equity { get; set; }
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>usdValue</c>"] Usd value
    /// </summary>
    [JsonPropertyName("usdValue")]
    public decimal UsdValue { get; set; }
}

