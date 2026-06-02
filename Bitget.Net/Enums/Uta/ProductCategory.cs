using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Product category
/// </summary>
[JsonConverter(typeof(EnumConverter<ProductCategory>))]
public enum ProductCategory
{
    /// <summary>
    /// ["<c>SPOT</c>"] Spot
    /// </summary>
    [Map("SPOT", "spot")]
    Spot,
    /// <summary>
    /// ["<c>MARGIN</c>"] Margin
    /// </summary>
    [Map("MARGIN", "margin")]
    Margin,
    /// <summary>
    /// ["<c>USDT-FUTURES</c>"] USDT futures
    /// </summary>
    [Map("USDT-FUTURES", "usdt-futures")]
    UsdtFutures,
    /// <summary>
    /// ["<c>COIN-FUTURES</c>"] Coin futures
    /// </summary>
    [Map("COIN-FUTURES", "coin-futures")]
    CoinFutures,
    /// <summary>
    /// ["<c>USDC-FUTURES</c>"] USDC futures
    /// </summary>
    [Map("USDC-FUTURES", "usdc-futures")]
    UsdcFutures,
}
