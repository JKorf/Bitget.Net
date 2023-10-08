using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Trigger type
    /// </summary>
    public enum BitgetTriggerType
    {
        /// <summary>
        /// Fill price
        /// </summary>
        [Map("fill_price", "last")]
        FillPrice,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("market_price", "mark")]
        MarkPrice
    }
}
