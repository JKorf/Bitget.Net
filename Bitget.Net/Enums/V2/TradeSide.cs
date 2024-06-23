using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trade side
    /// </summary>
    public enum TradeSide
    {
        /// <summary>
        /// Open
        /// </summary>
        [Map("open")]
        Open,
        /// <summary>
        /// Close
        /// </summary>
        [Map("close")]
        Close,
        /// <summary>
        /// Reduce close long
        /// </summary>
        [Map("reduce_close_long")]
        ReduceCloseLong,
        /// <summary>
        /// Reduce close short
        /// </summary>
        [Map("reduce_close_short")]
        ReduceCloseShort,
        /// <summary>
        /// Offset close long
        /// </summary>
        [Map("offset_close_long")]
        OffsetCloseLong,
        /// <summary>
        /// Offset close short
        /// </summary>
        [Map("offset_close_short")]
        OffsetCloseShort,
        /// <summary>
        /// Burst close long
        /// </summary>
        [Map("burst_close_long")]
        BurstCloseLong,
        /// <summary>
        /// Burst close short
        /// </summary>
        [Map("burst_close_short")]
        BurstCloseShort,
        /// <summary>
        /// Delivery close long
        /// </summary>
        [Map("delivery_close_long")]
        DeliveryCloseLong,
        /// <summary>
        /// Delivery close short
        /// </summary>
        [Map("delivery_close_short")]
        DeliveryCloseShort,
        /// <summary>
        /// Buy single
        /// </summary>
        [Map("buy_single")]
        BuySingle,
        /// <summary>
        /// Sell single
        /// </summary>
        [Map("sell_single")]
        SellSingle
    }
}
