using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger order price type
    /// </summary>
    public enum TriggerPriceType
    {
        /// <summary>
        /// Last fill price
        /// </summary>
        [Map("fill_price")]
        LastPrice,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("mark_price")]
        MarkPrice
    }
}
