using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Tpsl type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TakeProfitStopLossType>))]
    public enum TakeProfitStopLossType
    {
        /// <summary>
        /// Normal order
        /// </summary>
        [Map("normal")]
        Normal,
        /// <summary>
        /// Take profit/Stop loss order
        /// </summary>
        [Map("tpsl")]
        Tpsl
    }
}
