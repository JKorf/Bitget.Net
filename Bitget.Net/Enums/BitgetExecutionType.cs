using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Execution type
    /// </summary>
    public enum BitgetExecutionType
    {
        /// <summary>
        /// Taker
        /// </summary>
        [Map("T")]
        Taker,
        /// <summary>
        /// Maker
        /// </summary>
        [Map("M")]
        Maker
    }
}
