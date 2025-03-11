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
        /// Spot account
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// Funding account
        /// </summary>
        [Map("funding")]
        Funding,
        /// <summary>
        /// Coin futures
        /// </summary>
        [Map("coin-futures")]
        CoinFutures,
        /// <summary>
        /// USDT futures
        /// </summary>
        [Map("usdt-futures")]
        UsdtFutures,
        /// <summary>
        /// USDC futures
        /// </summary>
        [Map("usdc-futures")]
        UsdcFutures,
        /// <summary>
        /// P2P account
        /// </summary>
        [Map("p2p")]
        P2P,
        /// <summary>
        /// Cross margin account
        /// </summary>
        [Map("crossed_margin")]
        CrossMargin,
        /// <summary>
        /// Isolated margin account
        /// </summary>
        [Map("isolated_margin")]
        IsolatedMargin
    }
}
