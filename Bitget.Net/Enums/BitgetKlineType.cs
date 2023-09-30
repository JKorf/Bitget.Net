using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline type
    /// </summary>
    public enum BitgetKlineType
    {
        /// <summary>
        /// Market price
        /// </summary>
        [Map("market")]
        Market,
        /// <summary>
        /// Mark price
        /// </summary>
        [Map("amrk")]
        Mark,
        /// <summary>
        /// Index price
        /// </summary>
        [Map("market")]
        Index
    }
}
