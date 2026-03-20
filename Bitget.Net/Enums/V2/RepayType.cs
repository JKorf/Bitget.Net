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
        /// ["<c>auto_repay</c>"] Auto repayment
        /// </summary>
        [Map("auto_repay")]
        AutoRepay,
        /// <summary>
        /// ["<c>manual_repay</c>"] Manual repayment
        /// </summary>
        [Map("manual_repay")]
        ManualRepay,
        /// <summary>
        /// ["<c>liq_repay</c>"] Liquidation repayment
        /// </summary>
        [Map("liq_repay")]
        LiquidationRepay,
        /// <summary>
        /// ["<c>force_repay</c>"] Forced repayment
        /// </summary>
        [Map("force_repay")]
        ForcedRepay,
    }
}
