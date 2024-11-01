using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Interest type
    /// </summary>
    public enum InterestType
    {
        /// <summary>
        /// Interest on initial borrowing
        /// </summary>
        [Map("first")]
        First,
        /// <summary>
        /// Scheduled
        /// </summary>
        [Map("scheduled")]
        Scheduled
    }
}
