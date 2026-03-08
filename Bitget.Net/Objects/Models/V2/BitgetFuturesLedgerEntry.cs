using CryptoExchange.Net.Converters.SystemTextJson;
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
        /// ["<c>endId</c>"] The final transaction ID.
        /// </summary>
        [JsonPropertyName("endId")]
        public long? EndId { get; set; }
        /// <summary>
        /// ["<c>bills</c>"] Entries
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
        /// ["<c>billId</c>"] Bill id
        /// </summary>
        [JsonPropertyName("billId")]
        public long Id { get; set; }
        /// <summary>
        /// ["<c>cTime</c>"] Timestamp
        /// </summary>
        [JsonPropertyName("cTime")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// ["<c>symbol</c>"] Symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>businessType</c>"] Business type
        /// </summary>
        [JsonPropertyName("businessType")]
        public string BusinessType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>amount</c>"] Quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// ["<c>fee</c>"] Fees
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fees { get; set; }
        /// <summary>
        /// ["<c>feeByCoupon</c>"] Fees paid with coupon
        /// </summary>
        [JsonPropertyName("feeByCoupon")]
        public decimal? CouponFees { get; set; }
        /// <summary>
        /// ["<c>balance</c>"] Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}
