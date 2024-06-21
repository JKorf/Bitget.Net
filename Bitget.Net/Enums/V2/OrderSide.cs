using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Order side
    /// </summary>
    public enum OrderSide
    {
        /// <summary>
        /// Buy order
        /// </summary>
        [Map("buy")]
        Buy,
        /// <summary>
        /// Sell order
        /// </summary>
        [Map("sell")]
        Sell
    }
}
