using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Repay type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<RepayType>))]
    public enum RepayType
    {
        /// <summary>
        /// Auto repayment
        /// </summary>
        [Map("auto_repay")]
        AutoRepay,
        /// <summary>
        /// Manual repayment
        /// </summary>
        [Map("manual_repay")]
        ManualRepay,
        /// <summary>
        /// Liquidation repayment
        /// </summary>
        [Map("liq_repay")]
        LiquidationRepay,
        /// <summary>
        /// Forced repayment
        /// </summary>
        [Map("force_repay")]
        ForcedRepay,
    }
}
