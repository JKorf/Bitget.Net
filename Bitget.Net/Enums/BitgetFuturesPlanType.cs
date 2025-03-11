using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Plan type
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetFuturesPlanType>))]
    public enum BitgetFuturesPlanType
    {
        /// <summary>
        /// Profit order
        /// </summary>
        [Map("profit_plan")]
        ProfitPlan,
        /// <summary>
        /// Loss order
        /// </summary>
        [Map("loss_plan")]
        LossPlan,
        /// <summary>
        /// Plan order
        /// </summary>
        [Map("normal_plan")]
        NormalPlan,
        /// <summary>
        /// Position profit
        /// </summary>
        [Map("pos_profit")]
        PositionProfitPlan,
        /// <summary>
        /// Position loss
        /// </summary>
        [Map("pos_loss")]
        PositionLossPlan,
        /// <summary>
        /// Trailing TP/SL
        /// </summary>
        [Map("moving_plan")]
        MovingPlan,
        /// <summary>
        /// Trailing Stop
        /// </summary>
        [Map("track_plan")]
        TrackPlan
    }
}
