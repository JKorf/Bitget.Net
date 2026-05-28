using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Account info
/// </summary>
public record BitgetUaAccountInfo
{
    /// <summary>
    /// ["<c>uid</c>"] Unique id
    /// </summary>
    [JsonPropertyName("uid")]
    public decimal Uid { get; set; }
    /// <summary>
    /// ["<c>accountMode</c>"] Account mode
    /// </summary>
    [JsonPropertyName("accountMode")]
    public AccountMode AccountMode { get; set; }
    /// <summary>
    /// ["<c>assetMode</c>"] Asset mode
    /// </summary>
    [JsonPropertyName("assetMode")]
    public string AssetMode { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>accountLevel</c>"] Account level
    /// </summary>
    [JsonPropertyName("accountLevel")]
    public AccountLevel AccountLevel { get; set; }
    /// <summary>
    /// ["<c>holdMode</c>"] Hold mode
    /// </summary>
    [JsonPropertyName("holdMode")]
    public HoldingMode HoldMode { get; set; }
    /// <summary>
    /// ["<c>stpMode</c>"] Self trade prevention mode
    /// </summary>
    [JsonPropertyName("stpMode")]
    public StpMode StpMode { get; set; }
    /// <summary>
    /// ["<c>symbolConfigList</c>"] Symbol configurations
    /// </summary>
    [JsonPropertyName("symbolConfigList")]
    public BitgetUaAccountInfoSymbol[] SymbolConfigs { get; set; } = [];
    /// <summary>
    /// ["<c>coinConfigList</c>"] Asset configurations
    /// </summary>
    [JsonPropertyName("coinConfigList")]
    public BitgetUaAccountInfoAsset[] AssetConfigs { get; set; } = [];
}

/// <summary>
/// 
/// </summary>
public record BitgetUaAccountInfoSymbol
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
    /// ["<c>marginMode</c>"] Margin mode
    /// </summary>
    [JsonPropertyName("marginMode")]
    public MarginMode MarginMode { get; set; }
    /// <summary>
    /// ["<c>leverage</c>"] Leverage
    /// </summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
}

/// <summary>
/// Asset info
/// </summary>
public record BitgetUaAccountInfoAsset
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>leverage</c>"] Leverage
    /// </summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
}

