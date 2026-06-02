using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums;

/// <summary>
/// Strategy order status
/// </summary>
[JsonConverter(typeof(EnumConverter<StrategyStatus>))]
public enum StrategyStatus
{
    /// <summary>
    /// ["<c>pending</c>"] Pending
    /// </summary>
    [Map("pending")]
    Pending,
    /// <summary>
    /// ["<c>success</c>"] Success
    /// </summary>
    [Map("success")]
    Success,
    /// <summary>
    /// ["<c>failed</c>"] Failed
    /// </summary>
    [Map("failed")]
    Failed,
    /// <summary>
    /// ["<c>cancelled</c>"] Cancelled
    /// </summary>
    [Map("cancelled")]
    Cancelled,
    /// <summary>
    /// ["<c>submitting</c>"] Submitting
    /// </summary>
    [Map("submitting")]
    Submitting,
}
