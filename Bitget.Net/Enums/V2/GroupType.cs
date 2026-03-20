using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Group type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<GroupType>))]
    public enum GroupType
    {
        /// <summary>
        /// ["<c>deposit</c>"] Deposit
        /// </summary>
        [Map("deposit")]
        Deposit,
        /// <summary>
        /// ["<c>withdraw</c>"] Withdraw
        /// </summary>
        [Map("withdraw")]
        Withdraw,
        /// <summary>
        /// ["<c>transaction</c>"] Transaction
        /// </summary>
        [Map("transaction")]
        Transaction,
        /// <summary>
        /// ["<c>transfer</c>"] Transfer
        /// </summary>
        [Map("transfer")]
        Transfer,
        /// <summary>
        /// ["<c>other</c>"] Other
        /// </summary>
        [Map("other")]
        Other
    }
}
