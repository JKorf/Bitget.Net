using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order force
    /// </summary>
    public enum BitgetOrderForce
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Twap
        /// </summary>
        [Map("twap")]
        Twap,
        /// <summary>
        /// Adl
        /// </summary>
        [Map("adl")]
        Adl,
        /// <summary>
        /// Full liquidation
        /// </summary>
        [Map("full_liquidation")]
        FullLiquidation,
        /// <summary>
        /// Partial liquidation
        /// </summary>
        [Map("partial_liquidation")]
        PartialLiquidation
    }
}
