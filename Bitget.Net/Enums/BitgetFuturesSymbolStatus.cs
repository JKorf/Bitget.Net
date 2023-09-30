using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol status
    /// </summary>
    public enum BitgetFuturesSymbolStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Maintenance
        /// </summary>
        [Map("maintain")]
        Maintainance,
        /// <summary>
        /// Offline
        /// </summary>
        [Map("off")]
        Offline,
        /// <summary>
        /// Restricted API
        /// </summary>
        [Map("restrictedAPI")]
        Restricted,
        /// <summary>
        /// No new openings
        /// </summary>
        [Map("limit_open")]
        NoNewOrders
    }
}
