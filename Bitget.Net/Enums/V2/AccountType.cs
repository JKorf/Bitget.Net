using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<AccountType>))]
    public enum AccountType
    {
        /// <summary>
        /// ["<c>spot</c>"] Spot account
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// ["<c>funding</c>"] Funding account
        /// </summary>
        [Map("funding")]
        Funding,
        /// <summary>
        /// ["<c>coin-futures</c>"] Coin futures
        /// </summary>
        [Map("coin-futures")]
        CoinFutures,
        /// <summary>
        /// ["<c>usdt-futures</c>"] USDT futures
        /// </summary>
        [Map("usdt-futures")]
        UsdtFutures,
        /// <summary>
        /// ["<c>usdc-futures</c>"] USDC futures
        /// </summary>
        [Map("usdc-futures")]
        UsdcFutures,
        /// <summary>
        /// ["<c>p2p</c>"] P2P account
        /// </summary>
        [Map("p2p")]
        P2P,
        /// <summary>
        /// ["<c>crossed_margin</c>"] Cross margin account
        /// </summary>
        [Map("crossed_margin")]
        CrossMargin,
        /// <summary>
        /// ["<c>isolated_margin</c>"] Isolated margin account
        /// </summary>
        [Map("isolated_margin")]
        IsolatedMargin
    }
}
