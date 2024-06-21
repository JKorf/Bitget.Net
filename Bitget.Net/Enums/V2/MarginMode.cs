using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Margin mode
    /// </summary>
    public enum MarginMode
    {
        /// <summary>
        /// Cross margin
        /// </summary>
        [Map("cross")]
        CrossMargin,
        /// <summary>
        /// Isolated margin
        /// </summary>
        [Map("isolated")]
        IsolatedMargin
    }
}
