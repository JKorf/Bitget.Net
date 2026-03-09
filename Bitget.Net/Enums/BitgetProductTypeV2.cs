using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetProductTypeV2>))]
    public enum BitgetProductTypeV2
    {
        /// <summary>
        /// ["<c>USDT-FUTURES</c>"] USDT futures
        /// </summary>
        [Map("USDT-FUTURES")]
        UsdtFutures,
        /// <summary>
        /// ["<c>COIN-FUTURES</c>"] Mixed futures
        /// </summary>
        [Map("COIN-FUTURES")]
        CoinFutures,
        /// <summary>
        /// ["<c>USDC-FUTURES</c>"] USDC Futures
        /// </summary>
        [Map("USDC-FUTURES")]
        UsdcFutures,
        /// <summary>
        /// ["<c>SUSDT-FUTURES</c>"] DEMO USDT futures
        /// </summary>
        [Map("SUSDT-FUTURES")]
        SimUsdtFutures,
        /// <summary>
        /// ["<c>SCOIN-FUTURES</c>"] DEMO Mixed futures
        /// </summary>
        [Map("SCOIN-FUTURES")]
        SimCoinFutures,
        /// <summary>
        /// ["<c>SUSDC-FUTURES</c>"] DEMO USDC futures
        /// </summary>
        [Map("SUSDC-FUTURES")]
        SimUsdcFutures
    }
}
