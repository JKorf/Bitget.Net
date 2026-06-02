using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Withdraw status
/// </summary>
[JsonConverter(typeof(EnumConverter<WithdrawStatus>))]
public enum WithdrawStatus
{
    /// <summary>
    /// ["<c>success</c>"] Success
    /// </summary>
    [Map("success")]
    Success,
    /// <summary>
    /// ["<c>pending</c>"] Pending
    /// </summary>
    [Map("pending")]
    Pending,
    /// <summary>
    /// ["<c>fail</c>"] Failed
    /// </summary>
    [Map("fail")]
    Failed,
}
