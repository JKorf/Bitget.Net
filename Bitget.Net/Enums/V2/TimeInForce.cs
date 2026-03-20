using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Time in force
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TimeInForce>))]
    public enum TimeInForce
    {
        /// <summary>
        /// ["<c>gtc</c>"] Good till canceled
        /// </summary>
        [Map("gtc")]
        GoodTillCanceled,
        /// <summary>
        /// ["<c>post_only</c>"] Post only
        /// </summary>
        [Map("post_only")]
        PostOnly,
        /// <summary>
        /// ["<c>fok</c>"] Fill or kill
        /// </summary>
        [Map("fok")]
        FillOrKill,
        /// <summary>
        /// ["<c>ioc</c>"] Immediate or cancel
        /// </summary>
        [Map("ioc")]
        ImmediateOrCancel
    }
}
