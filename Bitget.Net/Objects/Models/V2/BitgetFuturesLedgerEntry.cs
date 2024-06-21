using Bitget.Net.Enums.V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Ledger
    /// </summary>
    public record BitgetFuturesLedger
    {
        /// <summary>
        /// The final transaction order ID.
        /// </summary>
        [JsonPropertyName("endId")]
        public string EndId { get; set; } = string.Empty;
        /// <summary>
        /// Entries
        /// </summary>
        [JsonPropertyName("bills")]
        public IEnumerable<BitgetFuturesLedgerEntry> Entries { get; set; } = Array.Empty<BitgetFuturesLedgerEntry>();
    }

    /// <summary>
    /// Ledger entry
    /// </summary>
    public record BitgetFuturesLedgerEntry
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Business type
        /// </summary>
        [JsonPropertyName("businessType")]
        public string BusinessType { get; set; } = string.Empty;
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fees { get; set; }
        /// <summary>
        /// Fees paid with coupon
        /// </summary>
        [JsonPropertyName("feeByCoupon")]
        public decimal? CouponFees { get; set; }
        /// <summary>
        /// Fee asset
        /// </summary>
        [JsonPropertyName("feeCoin")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>
        /// Order id
        /// </summary>
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;
    }
}
