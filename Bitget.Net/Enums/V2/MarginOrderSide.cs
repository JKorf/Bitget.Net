using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Margin order side
    /// </summary>
    [JsonConverter(typeof(EnumConverter<MarginOrderSide>))]
    public enum MarginOrderSide
    {
        /// <summary>
        /// Buy order
        /// </summary>
        [Map("buy")]
        Buy,
        /// <summary>
        /// Sell order
        /// </summary>
        [Map("sell")]
        Sell,
        /// <summary>
        /// Liquidation buy
        /// </summary>
        [Map("liquidation-buy")]
        LiquidationBuy,
        /// <summary>
        /// Liquidation sell
        /// </summary>
        [Map("liquidation-sell")]
        LiquidationSell,
        /// <summary>
        /// System buy
        /// </summary>
        [Map("systemRepay-buy")]
        SytemBuy,
        /// <summary>
        /// System sell
        /// </summary>
        [Map("systemRepay-sell")]
        SytemSell
    }
}
