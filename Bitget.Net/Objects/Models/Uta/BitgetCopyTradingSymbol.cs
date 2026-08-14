using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Copy-trading symbol
/// </summary>
public record BitgetCopyTradingSymbol
{
    /// <summary>
    /// ["<c>symbol</c>"] Symbol name
    /// </summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>leverage</c>"] Leverage multiplier
    /// </summary>
    [JsonPropertyName("leverage")]
    public int Leverage { get; set; }
    /// <summary>
    /// ["<c>marginDetails</c>"] Margin details list
    /// </summary>
    [JsonPropertyName("marginDetails")]
    public BitgetCopyTradingMarginDetails[] MarginDetails { get; set; } = [];
}

/// <summary>
/// Margin details list
/// </summary>
public record BitgetCopyTradingMarginDetails
{
    /// <summary>
    /// ["<c>marginCoin</c>"] Margin currency e.g. USDT
    /// </summary>
    [JsonPropertyName("marginCoin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>maxLongCount</c>"] Maximum long position size
    /// </summary>
    [JsonPropertyName("maxLongCount")]
    public int MaxLongCount { get; set; }
    /// <summary>
    /// ["<c>remainingLongCount</c>"] Remaining long position size
    /// </summary>
    [JsonPropertyName("remainingLongCount")]
    public int RemainingLongCount { get; set; }
    /// <summary>
    /// ["<c>maxShortCount</c>"] Maximum short position size
    /// </summary>
    [JsonPropertyName("maxShortCount")]
    public int MaxShortCount { get; set; }
    /// <summary>
    /// ["<c>remainingShortCount</c>"] Remaining short position size
    /// </summary>
    [JsonPropertyName("remainingShortCount")]
    public int RemainingShortCount { get; set; }
}