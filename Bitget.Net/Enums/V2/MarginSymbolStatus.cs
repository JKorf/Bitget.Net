using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Status
    /// </summary>
    public enum MarginSymbolStatus
    {
        /// <summary>
        /// Tradable
        /// </summary>
        [Map("1")]
        Tradable,
        /// <summary>
        /// Under maintenance
        /// </summary>
        [Map("2")]
        Maintenance
    }
}
