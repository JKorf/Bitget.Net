using CryptoExchange.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Group type
    /// </summary>
    public enum GroupType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// Withdraw
        /// </summary>
        [Map("withdraw")]
        Withdraw,
        /// <summary>
        /// Transaction
        /// </summary>
        [Map("transaction")]
        Transaction,
        /// <summary>
        /// Transfer
        /// </summary>
        [Map("transfer")]
        Transfer,
        /// <summary>
        /// Other
        /// </summary>
        [Map("other")]
        Other
    }
}
