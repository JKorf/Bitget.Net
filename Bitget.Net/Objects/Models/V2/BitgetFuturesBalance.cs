using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.V2;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures balance
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesBalance
    {
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity locked
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// Quantity available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// Maximum available balance to open positions under the cross margin mode
        /// </summary>
        [JsonPropertyName("crossedMaxAvailable")]
        public decimal CrossMarginMaxAvailable { get; set; }
        /// <summary>
        /// Maximum available balance to open positions under the isolated margin mode
        /// </summary>
        [JsonPropertyName("isolatedMaxAvailable")]
        public decimal IsolatedMarginMaxAvailable { get; set; }
        /// <summary>
        /// Max transferable quantity
        /// </summary>
        [JsonPropertyName("maxTransferOut")]
        public decimal MaxTransferable { get; set; }
        /// <summary>
        /// Account equity
        /// </summary>
        [JsonPropertyName("accountEquity")]
        public decimal Equity { get; set; }
        /// <summary>
        /// Usdt equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// BTC equity
        /// </summary>
        [JsonPropertyName("btcEquity")]
        public decimal BtcEquity { get; set; }
        /// <summary>
        /// Risk ratio in cross margin mode
        /// </summary>
        [JsonPropertyName("crossedRiskRate")]
        public decimal CrossMarginRiskRate { get; set; }
        /// <summary>
        /// Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal? UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Unrealized profit and loss cross margin
        /// </summary>
        [JsonPropertyName("crossedUnrealizedPL")]
        public decimal? CrossMarginUnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// Unrealized profit and loss isolated margin
        /// </summary>
        [JsonPropertyName("isolatedUnrealizedPL")]
        public decimal? IsolatedMarginProfitAndLoss { get; set; }
        /// <summary>
        /// Trading bonus
        /// </summary>
        [JsonPropertyName("coupon")]
        public decimal? Coupon { get; set; }
        /// <summary>
        /// Cross margin leverage
        /// </summary>
        [JsonPropertyName("crossedMarginLeverage")]
        public decimal? CrossMarginLeverage { get; set; }
        /// <summary>
        /// Isolated margin long leverage
        /// </summary>
        [JsonPropertyName("isolatedLongLever")]
        public decimal? IsolatedMarginLongLeverage { get; set; }
        /// <summary>
        /// Isolated margin short leverage
        /// </summary>
        [JsonPropertyName("isolatedShortLever")]
        public decimal? IsolatedMarginShortLeverage { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode? MarginMode { get; set; }
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode? PositionMode { get; set; }
    }
}
