using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Margin mode
    /// </summary>
    public enum BitgetMarginMode
    {
        /// <summary>
        /// Isolated margin
        /// </summary>
        [Map("fixed")]
        IsolatedMargin,
        /// <summary>
        /// Cross margin
        /// </summary>
        [Map("crossed")]
        CrossMargin
    }
}
