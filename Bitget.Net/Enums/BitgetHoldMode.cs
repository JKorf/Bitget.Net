using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Hold mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetHoldMode>))]
    public enum BitgetHoldMode
    {
        /// <summary>
        /// Single hold
        /// </summary>
        [Map("single_hold")]
        SingleHold,
        /// <summary>
        /// Double hold
        /// </summary>
        [Map("double_hold")]
        DoubleHold
    }
}
