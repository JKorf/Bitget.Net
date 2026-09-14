using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Transfer account type
/// </summary>
[JsonConverter(typeof(EnumConverter<TransferAccountType>))]
public enum TransferAccountType
{
    /// <summary>
    /// ["<c>spot</c>"] Spot account/Funding account
    /// </summary>
    [Map("spot")]
    Spot,
    /// <summary>
    /// ["<c>p2p</c>"] P2P account/OTC account
    /// </summary>
    [Map("p2p")]
    P2P,
    /// <summary>
    /// ["<c>usdt_futures</c>"] USDT-margined futures account
    /// </summary>
    [Map("usdt_futures")]
    UsdtFutures,
    /// <summary>
    /// ["<c>coin_futures</c>"] Coin-margined futures account
    /// </summary>
    [Map("coin_futures")]
    CoinFutures,
    /// <summary>
    /// ["<c>usdc_futures</c>"] USDC futures account
    /// </summary>
    [Map("usdc_futures")]
    UsdcFutures,
    /// <summary>
    /// ["<c>crossed_margin</c>"] Cross margin account
    /// </summary>
    [Map("crossed_margin")]
    CrossedMargin,
    /// <summary>
    /// ["<c>uta</c>"] Unified account (the docs say "unified" but the live API returns "uta")
    /// </summary>
    [Map("uta", "unified")]
    Unified,
}
