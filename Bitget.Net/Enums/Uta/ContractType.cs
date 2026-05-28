using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Contract type
/// </summary>
[JsonConverter(typeof(EnumConverter<ContractType>))]
public enum ContractType
{
    /// <summary>
    /// ["<c>perpetual</c>"] Perpetual contract
    /// </summary>
    [Map("perpetual")]
    Perpetual,
    /// <summary>
    /// ["<c>delivery</c>"] Delivery contract
    /// </summary>
    [Map("delivery")]
    Delivery,
}
