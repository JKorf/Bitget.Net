using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Instrument type
    /// </summary>
    public enum BitgetInstrumentType
    {
        /// <summary>
        /// USDT Perpetual Contract
        /// </summary>
        [Map("UMCBL")]
        UsdtPerpetual,
        /// <summary>
        /// Coin Margin Perpetual Contract
        /// </summary>
        [Map("DMCBL")]
        CoinPerpetual,
        /// <summary>
        /// USDC margin Perpetual Contract
        /// </summary>
        [Map("CMCBL")]
        UsdcPerpetual,
        /// <summary>
        /// USDT simulation perpetual contract
        /// </summary>
        [Map("SUMCBL")]
        UsdtPerpetualSimulated,
        /// <summary>
        /// Universal margin simulation perpetual contract
        /// </summary>
        [Map("SDMCBL")]
        CoinPerpetualSimulated,
        /// <summary>
        /// USDC simulation perpetual contract
        /// </summary>
        [Map("SCMCBL")]
        UsdcPerpetualSimulated
    }
}
