using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Hold mode
    /// </summary>
    public enum BitgetHoldMode
    {
        /// <summary>
        /// Single hold
        /// </summary>
        [Map("single_hold")]
        SingleHold,
        /// <summary>
        /// Double hold
        /// </summary>
        [Map("double_hold")]
        DoubleHold
    }
}
