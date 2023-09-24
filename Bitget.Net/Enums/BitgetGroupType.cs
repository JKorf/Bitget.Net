using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Group type
    /// </summary>
    public enum BitgetGroupType
    {
        /// <summary>
        /// Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// Withdrawal
        /// </summary>
        [Map("withdraw")]
        Withdrawal,
        /// <summary>
        /// Trade
        /// </summary>
        [Map("transaction")]
        Trade,
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
