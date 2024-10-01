using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Status of a symbol
    /// </summary>
    public enum BitgetSymbolStatus
    {
        /// <summary>
        /// Offline
        /// </summary>
        [Map("offline")]
        Offline,
        /// <summary>
        /// Gray
        /// </summary>
        [Map("gray")]
        Gray,
        /// <summary>
        /// Online
        /// </summary>
        [Map("online")]
        Online

        /// <summary>
        /// Halt
        /// </summary>
        [Map("halt")]
        Halt
    }
}
