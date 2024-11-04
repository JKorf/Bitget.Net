using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Self trade prevention mode
    /// </summary>
    public enum SelfTradePreventionMode
    {
        /// <summary>
        /// None
        /// </summary>
        [Map("none")]
        None,
        /// <summary>
        /// Cancel taker order
        /// </summary>
        [Map("cancel_taker")]
        CancelTaker,
        /// <summary>
        /// Cancel maker order
        /// </summary>
        [Map("cancel_maker")]
        CancelMaker,
        /// <summary>
        /// Cancel both 
        /// </summary>
        [Map("cancel_both")]
        CancelBoth
    }
}
