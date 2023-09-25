using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum BitgetOrderStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// New
        /// </summary>
        [Map("new")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("partial_fill")]
        PartiallyFilled,
        /// <summary>
        /// Filled
        /// </summary>
        [Map("full_fill")]
        Filled,
        /// <summary>
        /// Cancelled
        /// </summary>
        [Map("cancelled")]
        Cancelled
    }
}
