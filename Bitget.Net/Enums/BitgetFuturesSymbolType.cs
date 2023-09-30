using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol type
    /// </summary>
    public enum BitgetFuturesSymbolType
    {
        /// <summary>
        /// Perpetual contract
        /// </summary>
        [Map("perpetual")]
        Perpetual,
        /// <summary>
        /// Delivery contract
        /// </summary>
        [Map("delivery")]
        Delivery
    }
}
