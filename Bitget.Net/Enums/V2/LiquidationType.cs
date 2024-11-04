using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Liquidation type
    /// </summary>
    public enum LiquidationType
    {
        /// <summary>
        /// Place order
        /// </summary>
        [Map("place_order")]
        PlaceOrder,
        /// <summary>
        /// Swap
        /// </summary>
        [Map("swap")]
        Swap
    }
}
