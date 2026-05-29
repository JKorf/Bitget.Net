using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums;

/// <summary>
/// Permission type
/// </summary>
[JsonConverter(typeof(EnumConverter<PermissionType>))]
public enum PermissionType
{
    /// <summary>
    /// ["<c>read-and-write</c>"] Read write
    /// </summary>
    [Map("read-and-write")]
    ReadWrite,
    /// <summary>
    /// ["<c>read-only</c>"] Read only
    /// </summary>
    [Map("read-only")]
    ReadOnly,
}
