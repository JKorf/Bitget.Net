using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Switch status
/// </summary>
[JsonConverter(typeof(EnumConverter<SwitchStatus>))]
public enum SwitchStatus
{
    /// <summary>
    /// ["<c>fail</c>"] Failed
    /// </summary>
    [Map("fail")]
    Failed,
    /// <summary>
    /// ["<c>process</c>"] Process
    /// </summary>
    [Map("process")]
    Processing,
    /// <summary>
    /// ["<c>success</c>"] Successful
    /// </summary>
    [Map("success")]
    Success,
}
