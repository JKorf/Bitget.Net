using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Symbol status
    /// </summary>
    public enum SymbolStatus
    {
        /// <summary>
        /// Normal
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// In maintenance
        /// </summary>
        [Map("maintain")]
        Maintainance,
        /// <summary>
        /// Order placement restricted
        /// </summary>
        [Map("limit_open")]
        Limited,
        /// <summary>
        /// API order placement restricted
        /// </summary>
        [Map("restrictedAPI")]
        RestrictedApi
    }
}
