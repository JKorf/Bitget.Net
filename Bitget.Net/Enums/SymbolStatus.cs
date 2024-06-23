using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Symbol status
    /// </summary>
    public enum SymbolStatus
    {
        /// <summary>
        /// Maintenance/offline
        /// </summary>
        [Map("offline")]
        Maintenance,
        /// <summary>
        /// Gray scale
        /// </summary>
        [Map("gray")]
        Gray,
        /// <summary>
        /// Halted
        /// </summary>
        [Map("halt")]
        Halt,
        /// <summary>
        /// Online
        /// </summary>
        [Map("online")]
        Online
    }
}
