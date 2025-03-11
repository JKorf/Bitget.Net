using CryptoExchange.Net.Converters.SystemTextJson;
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
    [SerializationModel]
    public record BitgetFuturesLedger
    {
        /// <summary>
        /// The final transaction ID.
        /// </summary>
        [JsonPropertyName("endId")]
        public long? EndId { get; set; }
        /// <summary>
        /// Entries
        /// </summary>
        [JsonPropertyName("bills")]
        public BitgetFuturesLedgerEntry[] Entries { get; set; } = Array.Empty<BitgetFuturesLedgerEntry>();
    }

    /// <summary>
    /// Ledger entry
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesLedgerEntry
    {
        /// <summary>
        /// Bill id
        /// </summary>
        [JsonPropertyName("billId")]
        public long Id { get; set; }
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
        /// Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}
