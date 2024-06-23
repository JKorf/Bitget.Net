using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Contract type
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// Perpetual futures
        /// </summary>
        [Map("perpetual", "1")]
        Perpetual,
        /// <summary>
        /// Delivery futures
        /// </summary>
        [Map("delivery", "2")]
        Delivery
    }
}
