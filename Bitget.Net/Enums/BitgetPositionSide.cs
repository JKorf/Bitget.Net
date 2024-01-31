using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Position side
    /// </summary>
    public enum BitgetPositionSide
    {
        /// <summary>
        /// Long position
        /// </summary>
        [Map("long")]
        Long,
        /// <summary>
        /// Short position
        /// </summary>
        [Map("short")]
        Short,
        /// <summary>
        /// Net
        /// </summary>
        [Map("net")]
        Net
    }
}
