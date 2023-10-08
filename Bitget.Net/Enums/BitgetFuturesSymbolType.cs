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
        [Map("perpetual", "1")]
        Perpetual,
        /// <summary>
        /// Delivery contract
        /// </summary>
        [Map("delivery", "2")]
        Delivery
    }
}
