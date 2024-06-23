using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Type of transfer
    /// </summary>
    public enum TransferType
    {
        /// <summary>
        /// Withdraw on chain
        /// </summary>
        [Map("on_chain")]
        OnChain,
        /// <summary>
        /// Withdraw to another Bitget user
        /// </summary>
        [Map("internal_transfer")]
        InternalTransfer
    }
}
