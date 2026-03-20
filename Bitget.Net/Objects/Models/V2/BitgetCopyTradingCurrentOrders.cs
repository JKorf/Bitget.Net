using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Current Tracking Orders
    /// </summary>
    public record BitgetCopyTradingCurrentOrders
    {
        /// <summary>
        /// ["<c>trackingList</c>"] Order tracking list
        /// </summary>
        [JsonPropertyName("trackingList")]
        public BitgetCopyTradingCurrentOrdersTrackingItem[]? TrackingList { get; set; }

        /// <summary>
        /// ["<c>endId</c>"] Current page end Id
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
    }
}
