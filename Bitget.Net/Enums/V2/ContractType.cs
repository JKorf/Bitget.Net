using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Contract type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<ContractType>))]
    public enum ContractType
    {
        /// <summary>
        /// ["<c>perpetual</c>"] Perpetual futures
        /// </summary>
        [Map("perpetual", "1")]
        Perpetual,
        /// <summary>
        /// ["<c>delivery</c>"] Delivery futures
        /// </summary>
        [Map("delivery", "2")]
        Delivery
    }
}
