using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Role
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Taker
        /// </summary>
        [Map("taker")]
        Taker,
        /// <summary>
        /// Maker
        /// </summary>
        [Map("maker")]
        Maker
    }
}
