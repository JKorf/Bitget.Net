using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Time in force
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetTimeInForce>))]
    public enum BitgetTimeInForce
    {
        /// <summary>
        /// Good till canceled
        /// </summary>
        [Map("normal")]
        GoodTillCanceled,
        /// <summary>
        /// Post only
        /// </summary>
        [Map("post_only")]
        PostOnly,
        /// <summary>
        /// Fill or kill
        /// </summary>
        [Map("fok")]
        FillOrKill,
        /// <summary>
        /// Immediate or cancel
        /// </summary>
        [Map("ioc")]
        ImmediatOrCancel
    }
}
