using Bitget.Net.Enums;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Agent customer
    /// </summary>
    [SerializationModel]
    public record BitgetBrokerAgentDirectCommissionItem
    {
        /// <summary>
        /// Referred User UID
        /// </summary>
        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        /// <summary>
        /// Commission return date (UTC+8)
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// coin
        /// </summary>
        [JsonPropertyName("coin")]
        public string? Coin { get; set; }

        /// <summary>
        /// symbol
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        /// <summary>
        /// productType
        /// </summary>
        [JsonPropertyName("productType")]
        public BitgetProductTypeV2 ProductType { get; set; }

        /// <summary>
        /// Trading amount(maker+taker)
        /// </summary>
        [JsonPropertyName("dealAmount")]
        public decimal DealAmount { get; set; }

        /// <summary>
        /// Trading fee(maker+taker)
        /// </summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Trading fee deducted(maker+taker)
        /// </summary>
        [JsonPropertyName("feeDeduction")]
        public decimal FeeDeduction { get; set; }

        /// <summary>
        /// Fees offset by experience funds
        /// </summary>
        [JsonPropertyName("activityBonusDeduct")]
        public decimal ActivityBonusDeduct { get; set; }

        /// <summary>
        /// Fees offset by spot cashback coupons
        /// </summary>
        [JsonPropertyName("spotCouponDeduct")]
        public decimal SpotCouponDeduct { get; set; }

        /// <summary>
        /// Fees offset by contract airdrop coupons
        /// </summary>
        [JsonPropertyName("futuresCouponDeduct")]
        public decimal FuturesCouponDeduct { get; set; }

        /// <summary>
        /// Fees reduced by spot fee discounts
        /// </summary>
        [JsonPropertyName("spotFeeDiscountDeduct")]
        public decimal SpotFeeDiscountDeduct { get; set; }

        /// <summary>
        /// Fees offset by negative maker fees
        /// </summary>
        [JsonPropertyName("negativeMakerFeeDeduct")]
        public decimal NegativeMakerFeeDeduct { get; set; }

        /// <summary>
        /// Fees actually paid(maker+taker)
        /// </summary>
        [JsonPropertyName("feePaid")]
        public decimal FeePaid { get; set; }

        /// <summary>
        /// Partner's commission(maker+taker)
        /// </summary>
        [JsonPropertyName("rebateAmount")]
        public decimal RebateAmount { get; set; }

        /// <summary>
        /// User's commission(maker+taker)
        /// </summary>
        [JsonPropertyName("userTotalRebateAmount")]
        public decimal UserTotalRebateAmount { get; set; }

        /// <summary>
        /// Total commission for the day.(maker+taker)
        /// </summary>
        [JsonPropertyName("dayTotalRebateAmount")]
        public decimal DayTotalRebateAmount { get; set; }

        /// <summary>
        /// Total commission accumulated over all days(maker+taker)
        /// </summary>
        [JsonPropertyName("totalRebateAmount")]
        public decimal TotalRebateAmount { get; set; }
    }
}
