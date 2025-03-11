using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Execution type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetExecutionType>))]
    public enum BitgetExecutionType
    {
        /// <summary>
        /// Taker
        /// </summary>
        [Map("T", "taker")]
        Taker,
        /// <summary>
        /// Maker
        /// </summary>
        [Map("M", "maker")]
        Maker
    }
}
