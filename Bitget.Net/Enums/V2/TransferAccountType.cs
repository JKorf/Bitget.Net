using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Transfer account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TransferAccountType>))]
    public enum TransferAccountType
    {
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// P2P/funding account
        /// </summary>
        [Map("p2p")]
        Funding,
        /// <summary>
        /// Coin-M futures account
        /// </summary>
        [Map("coin_futures")]
        CoinFutures,
        /// <summary>
        /// USDT-M futures account
        /// </summary>
        [Map("usdt_futures")]
        UsdtFutures,
        /// <summary>
        /// USDC-M futures account
        /// </summary>
        [Map("usdc_futures")]
        UsdcFutures,
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
