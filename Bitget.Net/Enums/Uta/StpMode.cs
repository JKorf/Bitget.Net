using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// STP mode
/// </summary>
[JsonConverter(typeof(EnumConverter<StpMode>))]
public enum StpMode
{
    /// <summary>
    /// ["<c>none</c>"] None
    /// </summary>
    [Map("none")]
    None,
    /// <summary>
    /// ["<c>cancel_taker</c>"] Cancel taker
    /// </summary>
    [Map("cancel_taker")]
    CancelTaker,
    /// <summary>
    /// ["<c>cancel_maker</c>"] Cancel maker
    /// </summary>
    [Map("cancel_maker")]
    CancelMaker,
    /// <summary>
    /// ["<c>cancel_both</c>"] Cancel both
    /// </summary>
    [Map("cancel_both")]
    CancelBoth,
}
