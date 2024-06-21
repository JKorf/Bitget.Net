using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Delivery status
    /// </summary>
    public enum DeliveryStatus
    {
        /// <summary>
        /// Trading normally
        /// </summary>
        [Map("delivery_normal")]
        Normal,
        /// <summary>
        /// 10 minutes before delivery, opening positions are prohibited
        /// </summary>
        [Map("delivery_before")]
        DeliveryBefore,
        /// <summary>
        /// Delivery, opening, closing, and canceling orders are prohibited
        /// </summary>
        [Map("delivery_period")]
        DeliveryPeriod
    }
}
