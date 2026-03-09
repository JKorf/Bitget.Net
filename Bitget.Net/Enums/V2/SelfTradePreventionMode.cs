using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Self trade prevention mode
    /// </summary>
    [JsonConverter(typeof(EnumConverter<SelfTradePreventionMode>))]
    public enum SelfTradePreventionMode
    {
        /// <summary>
        /// ["<c>none</c>"] None
        /// </summary>
        [Map("none")]
        None,
        /// <summary>
        /// ["<c>cancel_taker</c>"] Cancel taker order
        /// </summary>
        [Map("cancel_taker")]
        CancelTaker,
        /// <summary>
        /// ["<c>cancel_maker</c>"] Cancel maker order
        /// </summary>
        [Map("cancel_maker")]
        CancelMaker,
        /// <summary>
        /// ["<c>cancel_both</c>"] Cancel both 
        /// </summary>
        [Map("cancel_both")]
        CancelBoth
    }
}
