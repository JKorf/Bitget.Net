using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Delivery period
    /// </summary>
    public enum DeliveryPeriod
    {
        /// <summary>
        /// This quarter
        /// </summary>
        [Map("this_quarter")]
        ThisQuarter,
        /// <summary>
        /// Next quarter
        /// </summary>
        [Map("next_quarter")]
        NextQuarter
    }
}
