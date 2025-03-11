using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetProductType>))]
    public enum BitgetProductType
    {
        /// <summary>
        /// Usdt perpetual contracts
        /// </summary>
        [Map("umcbl")]
        UsdtPerpetual,
        /// <summary>
        /// Universal margin perpetual contracts
        /// </summary>
        [Map("dmcbl")]
        UniversalMarginPerpetual,
        /// <summary>
        /// Usdc perpetual contracts
        /// </summary>
        [Map("cmcbl")]
        UsdcPerpetual,

        /// <summary>
        /// Simulation usdt perpetual contracts
        /// </summary>
        [Map("sumcbl")]
        SimUsdtPerpetual,
        /// <summary>
        /// Simulation universal margin perpetual contracts
        /// </summary>
        [Map("sdmcbl")]
        SimUniversalMarginPerpetual,
        /// <summary>
        /// Simulation usdc perpetual contracts
        /// </summary>
        [Map("scmcbl")]
        SimUsdcPerpetual,
    }
}
