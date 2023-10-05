using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan order status
    /// </summary>
    public enum BitgetPlanOrderStatus
    {
        /// <summary>
        /// Not triggered
        /// </summary>
        [Map("not_trigger")]
        NotTriggered,
        /// <summary>
        /// Triggered
        /// </summary>
        [Map("triggered")]
        Triggered,
        /// <summary>
        /// Failed trigger
        /// </summary>
        [Map("fail_trigger")]
        FailTrigger,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancel")]
        Cancel
    }
}
