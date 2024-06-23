using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Transfer account type
    /// </summary>
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
