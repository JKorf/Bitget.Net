using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Kline type
    /// </summary>
    public enum KlineType
    {
        /// <summary>
        /// Market price
        /// </summary>
        [Map("MARKET")]
        Market,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("MARK")]
        Mark,
        /// <summary>
        /// Index price
        /// </summary>
        [Map("INDEX")]
        Index
    }
}
