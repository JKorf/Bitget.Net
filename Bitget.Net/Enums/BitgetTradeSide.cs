using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Trade side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetTradeSide>))]
    public enum BitgetTradeSide
    {
        /// <summary>
        /// Open long
        /// </summary>
        [Map("open_long")]
        OpenLong,
        /// <summary>
        /// Open short
        /// </summary>
        [Map("open_short")]
        OpenShot,
        /// <summary>
        /// Close long
        /// </summary>
        [Map("close_long")]
        CloseLong,
        /// <summary>
        /// Close short
        /// </summary>
        [Map("close_short")]
        CloseShort,
        /// <summary>
        /// Force reduce long position
        /// </summary>
        [Map("reduce_close_long")]
        ReduceCloseLong,
        /// <summary>
        /// Force reduce short position
        /// </summary>
        [Map("reduce_close_short")]
        ReduceCloseShort,
        /// <summary>
        /// Force netting: close long position
        /// </summary>
        [Map("offset_close_long")]
        OffSetCloseLong,
        /// <summary>
        /// Force netting: close short position
        /// </summary>
        [Map("offset_close_short")]
        OffsetCloseShort,
        /// <summary>
        /// Force liquidation: close long position
        /// </summary>
        [Map("burst_close_long")]
        BurstCloseLong,
        /// <summary>
        /// Force liquidation: close short position
        /// </summary>
        [Map("burst_close_short")]
        BurstCloseShort,
        /// <summary>
        /// Future delivery close long
        /// </summary>
        [Map("delivery_close_long")]
        DeliveryCloseLong,
        /// <summary>
        /// Future delivery close short
        /// </summary>
        [Map("delivery_close_short")]
        DeliveryCloseShort,
        /// <summary>
        /// Buy in SingleHold mode
        /// </summary>
        [Map("buy_single")]
        BuySingle,
        /// <summary>
        /// Sell in SingleHold mode
        /// </summary>
        [Map("sell_single")]
        SellSingle,
        /// <summary>
        /// Force reduce buy in SingleHold mode
        /// </summary>
        [Map("reduce_buy_single")]
        ReduceBuySingle,
        /// <summary>
        /// Force reduce sell in SingleHold mode
        /// </summary>
        [Map("reduce_sell_single")]
        ReduceSellSingle,
        /// <summary>
        /// Force liquidation: buy in SingleHold mode
        /// </summary>
        [Map("burst_buy_single")]
        BurstBuySingle,
        /// <summary>
        /// Force liquidation: sell in SingleHold mode
        /// </summary>
        [Map("burst_sell_single")]
        BurstSellSingle,
        /// <summary>
        /// Future delivery buy in SingleHold mode
        /// </summary>
        [Map("delivery_buy_single")]
        DeliveryBuySingle,
        /// <summary>
        /// Future delivery sell in SingleHold mode
        /// </summary>
        [Map("delivery_sell_single")]
        DeliverySellSingle
    }
}
