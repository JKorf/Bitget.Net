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
        /// ["<c>spot</c>"] Spot account
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// ["<c>p2p</c>"] P2P/funding account
        /// </summary>
        [Map("p2p")]
        Funding,
        /// <summary>
        /// ["<c>coin_futures</c>"] Coin-M futures account
        /// </summary>
        [Map("coin_futures")]
        CoinFutures,
        /// <summary>
        /// ["<c>usdt_futures</c>"] USDT-M futures account
        /// </summary>
        [Map("usdt_futures")]
        UsdtFutures,
        /// <summary>
        /// ["<c>usdc_futures</c>"] USDC-M futures account
        /// </summary>
        [Map("usdc_futures")]
        UsdcFutures,
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
