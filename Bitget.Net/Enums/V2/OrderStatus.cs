using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        [Map("init")]
        Initial,
        /// <summary>
        /// Pending match
        /// </summary>
        [Map("live")]
        Live,
        /// <summary>
        /// Unfilled, waiting for match
        /// </summary>
        [Map("new")]
        New,
        /// <summary>
        /// Partially filled
        /// </summary>
        [Map("partially_filled")]
        PartiallyFilled,
        /// <summary>
        /// Filled
        /// </summary>
        [Map("filled")]
        Filled,
        /// <summary>
        /// Canceled
        /// </summary>
        [Map("cancelled")]
        Canceled
    }
}
