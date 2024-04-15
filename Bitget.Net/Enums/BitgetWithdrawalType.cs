using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Withdrawal type
    /// </summary>
    public enum BitgetWithdrawalType
    {
        /// <summary>
        /// External transfer
        /// </summary>
        [Map("on_chain")]
        External,
        /// <summary>
        /// Internal transfer
        /// </summary>
        [Map("internal_transfer")]
        Internal,
    }
}
