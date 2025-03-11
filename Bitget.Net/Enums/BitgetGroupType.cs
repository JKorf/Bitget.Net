using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Group type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetGroupType>))]
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
