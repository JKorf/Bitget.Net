using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Operation side
/// </summary>
[JsonConverter(typeof(EnumConverter<Operation>))]
public enum Operation
{
    /// <summary>
    /// ["<c>add</c>"] Add
    /// </summary>
    [Map("add")]
    Add,
    /// <summary>
    /// ["<c>remove</c>"] Remove
    /// </summary>
    [Map("remove")]
    Remove,
}
