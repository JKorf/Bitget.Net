using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Current Tracking Orders
    /// </summary>
    public class BitgetCopyTradingCurrentOrders
    {
        /// <summary>
        /// Order tracking list
        /// </summary>
        [JsonPropertyName("trackingList")]
        public BitgetCopyTradingCurrentOrdersTrackingItem[]? TrackingList { get; set; }

        /// <summary>
        /// Current page end Id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
    }
}
