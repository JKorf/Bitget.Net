using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Position mode
    /// </summary>
    public enum PositionMode
    {
        /// <summary>
        /// One way mode
        /// </summary>
        [Map("one_way_mode")]
        OneWay,
        /// <summary>
        /// Hedge mode
        /// </summary>
        [Map("hedge_mode")]
        Hedge
    }
}
