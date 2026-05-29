using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Address book entry type
/// </summary>
[JsonConverter(typeof(EnumConverter<AddressBookType>))]
public enum AddressBookType
{
    /// <summary>
    /// ["<c>EVM</c>"] EVM
    /// </summary>
    [Map("EVM")]
    Evm,
    /// <summary>
    /// ["<c>regular</c>"] Regular
    /// </summary>
    [Map("regular")]
    Regular,
    /// <summary>
    /// ["<c>universal</c>"] Universal
    /// </summary>
    [Map("universal")]
    Universal,
    /// <summary>
    /// ["<c>internal</c>"] Internal
    /// </summary>
    [Map("internal")]
    Internal,
}
