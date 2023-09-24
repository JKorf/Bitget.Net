using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Business type
    /// </summary>
    public enum BitgetBusinessType
    {
        /// <summary>
        /// Mix
        /// </summary>
        [Map("mix")]
        Mix,
        /// <summary>
        /// Spot
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// Spot margin
        /// </summary>
        [Map("margin")]
        SpotMargin
    }
}
