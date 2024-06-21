using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trigger plan type
    /// </summary>
    public enum QuantityType
    {
        /// <summary>
        /// Base asset quantity
        /// </summary>
        [Map("amount")]
        BaseAsset,
        /// <summary>
        /// Quote asset quantity
        /// </summary>
        [Map("total")]
        QuoteAsset
    }
}
