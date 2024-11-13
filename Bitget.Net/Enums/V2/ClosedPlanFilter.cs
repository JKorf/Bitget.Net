using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Closed plan status filter
    /// </summary>
    public enum ClosedPlanFilter
    {
        /// <summary>
        /// Executed
        /// </summary>
        [Map("executed")]
        Executed,
        /// <summary>
        /// Trigger failed
        /// </summary>
        [Map("fail_trigger")]
        Failed,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled
    }
}
