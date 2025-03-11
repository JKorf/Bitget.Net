using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetAccountType>))]
    public enum BitgetAccountType
    {
        /// <summary>
        /// Spot account
        /// </summary>
        [Map("EXCHANGE")]
        Exchange,
        /// <summary>
        /// Contract account
        /// </summary>
        [Map("CONTRACT")]
        Contract,
        /// <summary>
        /// USDT futures account
        /// </summary>
        [Map("USDT_MIX")]
        UsdtMix,
        /// <summary>
        /// USD futures account
        /// </summary>
        [Map("USD_MIX")]
        UsdMix,
        /// <summary>
        /// USDC futures account
        /// </summary>
        [Map("USDC_MIX")]
        UsdcMix,
        /// <summary>
        /// Cross margin account
        /// </summary>
        [Map("MARGIN_CROSS")]
        MarginCross,
        /// <summary>
        /// Isolated margin account
        /// </summary>
        [Map("MARGIN_ISOLATED")]
        MarginIsolated
    }
}
