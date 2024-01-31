using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Order side
    /// </summary>
    public enum BitgetFuturesOrderSide
    {
        /// <summary>
        /// Open long position
        /// </summary>
        [Map("open_long")]
        OpenLong,
        /// <summary>
        /// Open short position
        /// </summary>
        [Map("open_short")]
        OpenShort,
        /// <summary>
        /// Close long position
        /// </summary>
        [Map("close_long")]
        CloseLong,
        /// <summary>
        /// Close short position
        /// </summary>
        [Map("close_short")]
        CloseShort,
        /// <summary>
        /// Buy under SingleHold mode
        /// </summary>
        [Map("buy_single")]
        BuySingle,
        /// <summary>
        /// Sell under SingleHold mode
        /// </summary>
        [Map("sell_single")]
        SellSingle
    }
}
