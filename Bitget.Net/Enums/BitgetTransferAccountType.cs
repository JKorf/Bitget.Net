using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetTransferAccountType>))]
    public enum BitgetTransferAccountType
    {
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("spot")]
        Spot,
        /// <summary>
        /// USDT futures account
        /// </summary>
        [Map("mix_usdt")]
        UsdtMix,
        /// <summary>
        /// USD futures account
        /// </summary>
        [Map("mix_usd")]
        UsdMix,
        /// <summary>
        /// USDC futures account
        /// </summary>
        [Map("mix_usdc")]
        UsdcMix,
        /// <summary>
        /// Cross margin account
        /// </summary>
        [Map("margin_cross")]
        MarginCross,
        /// <summary>
        /// Isolated margin account
        /// </summary>
        [Map("margin_isolated")]
        MarginIsolated
    }
}
