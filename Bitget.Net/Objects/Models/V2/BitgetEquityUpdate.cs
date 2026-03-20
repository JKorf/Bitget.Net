using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Equity update
    /// </summary>
    public record BitgetEquityUpdate
    {
        /// <summary>
        /// ["<c>btcEquity</c>"] BTC equity
        /// </summary>
        [JsonPropertyName("btcEquity")]
        public decimal BtcEquity { get; set; }
        /// <summary>
        /// ["<c>usdtEquity</c>"] USDT equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// ["<c>unrealizedPL</c>"] Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>
        /// ["<c>unionTotalMargin</c>"] Total multi-asset margin
        /// </summary>
        [JsonPropertyName("unionTotalMargin")]
        public decimal UnionTotalMargin { get; set; }
        /// <summary>
        /// ["<c>unionAvailable</c>"] Available balance under multi-asset margin mode
        /// </summary>
        [JsonPropertyName("unionAvailable")]
        public decimal UnionAvailable { get; set; }
        /// <summary>
        /// ["<c>unionMm</c>"] Maintenance margin under multi-asset margin mode
        /// </summary>
        [JsonPropertyName("unionMm")]
        public decimal UnionMaintenanceMargin { get; set; }
    }
}
