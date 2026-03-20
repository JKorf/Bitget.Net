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
        /// ["<c>buy</c>"] Buy order
        /// </summary>
        [Map("buy")]
        Buy,
        /// <summary>
        /// ["<c>sell</c>"] Sell order
        /// </summary>
        [Map("sell")]
        Sell,
        /// <summary>
        /// ["<c>liquidation-buy</c>"] Liquidation buy
        /// </summary>
        [Map("liquidation-buy")]
        LiquidationBuy,
        /// <summary>
        /// ["<c>liquidation-sell</c>"] Liquidation sell
        /// </summary>
        [Map("liquidation-sell")]
        LiquidationSell,
        /// <summary>
        /// ["<c>systemRepay-buy</c>"] System buy
        /// </summary>
        [Map("systemRepay-buy")]
        SytemBuy,
        /// <summary>
        /// ["<c>systemRepay-sell</c>"] System sell
        /// </summary>
        [Map("systemRepay-sell")]
        SytemSell
    }
}
