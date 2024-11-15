using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order status
    /// </summary>
    public enum TriggerOrderStatus
    {
        /// <summary>
        /// Not triggered yet
        /// </summary>
        [Map("live", "not_trigger")]
        Live,
        /// <summary>
        /// Order executing
        /// </summary>
        [Map("executing")]
        Executing,
        /// <summary>
        /// Order executed
        /// </summary>
        [Map("executed")]
        Executed,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled,
        /// <summary>
        /// Failed to execute
        /// </summary>
        [Map("fail_execute")]
        FailedExecute
    }
}
