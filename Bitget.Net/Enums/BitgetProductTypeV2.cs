using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    public enum BitgetProductTypeV2
    {
        /// <summary>
        /// USDT futures
        /// </summary>
        [Map("USDT-FUTURES")]
        UsdtFutures,
        /// <summary>
        /// Mixed futures
        /// </summary>
        [Map("COIN-FUTURES")]
        CoinFutures,
        /// <summary>
        /// USDC Futures
        /// </summary>
        [Map("USDC-FUTURES")]
        UsdcFutures,
        /// <summary>
        /// DEMO USDT futures
        /// </summary>
        [Map("SUSDT-FUTURES")]
        SimUsdtFutures,
        /// <summary>
        /// DEMO Mixed futures
        /// </summary>
        [Map("SCOIN-FUTURES")]
        SimCoinFutures,
        /// <summary>
        /// DEMO USDC futures
        /// </summary>
        [Map("SUSDC-FUTURES")]
        SimUsdcFutures
    }
}
