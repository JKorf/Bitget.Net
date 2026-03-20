using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Trade side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<TradeSide>))]
    public enum TradeSide
    {
        /// <summary>
        /// ["<c>open</c>"] Open
        /// </summary>
        [Map("open")]
        Open,
        /// <summary>
        /// ["<c>close</c>"] Close
        /// </summary>
        [Map("close")]
        Close,
        /// <summary>
        /// ["<c>reduce_close_long</c>"] Reduce close long
        /// </summary>
        [Map("reduce_close_long")]
        ReduceCloseLong,
        /// <summary>
        /// ["<c>reduce_close_short</c>"] Reduce close short
        /// </summary>
        [Map("reduce_close_short")]
        ReduceCloseShort,
        /// <summary>
        /// ["<c>offset_close_long</c>"] Offset close long
        /// </summary>
        [Map("offset_close_long")]
        OffsetCloseLong,
        /// <summary>
        /// ["<c>offset_close_short</c>"] Offset close short
        /// </summary>
        [Map("offset_close_short")]
        OffsetCloseShort,
        /// <summary>
        /// ["<c>burst_close_long</c>"] Burst close long
        /// </summary>
        [Map("burst_close_long")]
        BurstCloseLong,
        /// <summary>
        /// ["<c>burst_close_short</c>"] Burst close short
        /// </summary>
        [Map("burst_close_short")]
        BurstCloseShort,
        /// <summary>
        /// ["<c>delivery_close_long</c>"] Delivery close long
        /// </summary>
        [Map("delivery_close_long")]
        DeliveryCloseLong,
        /// <summary>
        /// ["<c>delivery_close_short</c>"] Delivery close short
        /// </summary>
        [Map("delivery_close_short")]
        DeliveryCloseShort,
        /// <summary>
        /// ["<c>buy_single</c>"] Buy single
        /// </summary>
        [Map("buy_single")]
        BuySingle,
        /// <summary>
        /// ["<c>sell_single</c>"] Sell single
        /// </summary>
        [Map("sell_single")]
        SellSingle
    }
}
