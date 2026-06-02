using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Enums.Uta;

/// <summary>
/// Execution type
/// </summary>
[JsonConverter(typeof(EnumConverter<ExecutionType>))]
public enum ExecutionType
{
    /// <summary>
    /// ["<c>normal</c>"] Normal trade
    /// </summary>
    [Map("normal")]
    Normal,
    /// <summary>
    /// ["<c>offset</c>"] Netting of hedged positions
    /// </summary>
    [Map("offset")]
    Offset,
    /// <summary>
    /// ["<c>reduce</c>"] Forced reduction
    /// </summary>
    [Map("reduce")]
    Reduce,
    /// <summary>
    /// ["<c>liquidation</c>"] Liquidation
    /// </summary>
    [Map("liquidation")]
    Liquidation,
    /// <summary>
    /// ["<c>delivery</c>"] Delivery
    /// </summary>
    [Map("delivery")]
    Delivery,
}
