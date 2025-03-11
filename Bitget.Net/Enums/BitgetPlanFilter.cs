using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan filter
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetPlanFilter>))]
    public enum BitgetPlanFilter
    {
        /// <summary>
        /// Trailing stop plan
        /// </summary>
        [Map("plan")]
        TrailingStop,
        /// <summary>
        /// profit order, loss order, position profit, position loss, Trailing TP/SL
        /// </summary>
        [Map("profit_loss")]
        Other,
    }
}
