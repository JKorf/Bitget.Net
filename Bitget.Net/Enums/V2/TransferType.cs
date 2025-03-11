using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Type of transfer
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TransferType>))]
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
