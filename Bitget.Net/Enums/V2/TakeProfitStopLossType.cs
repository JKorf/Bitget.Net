using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Tpsl type
    /// </summary>
    public enum TakeProfitStopLossType
    {
        /// <summary>
        /// Normal order
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Take profit/Stop loss order
        /// </summary>
        [Map("tpsl")]
        Tpsl
    }
}
