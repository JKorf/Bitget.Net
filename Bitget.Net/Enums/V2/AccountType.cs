using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Account type
    /// </summary>
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
        UsdcFutures
    }
}
