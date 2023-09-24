using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order type
    /// </summary>
    public enum BitgetOrderType
    {
        /// <summary>
        /// Limit
        /// </summary>
        [Map("limit")]
        Limit,
        /// <summary>
        /// Market
        /// </summary>
        [Map("market")]
        Market
    }
}
