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
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>locked</c>"] Quantity locked
        /// </summary>
        [JsonPropertyName("locked")]
        public decimal Locked { get; set; }
        /// <summary>
        /// ["<c>available</c>"] Quantity available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>crossedMaxAvailable</c>"] Maximum available balance to open positions under the cross margin mode
        /// </summary>
        [JsonPropertyName("crossedMaxAvailable")]
        public decimal CrossMarginMaxAvailable { get; set; }
        /// <summary>
        /// ["<c>isolatedMaxAvailable</c>"] Maximum available balance to open positions under the isolated margin mode
        /// </summary>
        [JsonPropertyName("isolatedMaxAvailable")]
        public decimal IsolatedMarginMaxAvailable { get; set; }
        /// <summary>
        /// ["<c>maxTransferOut</c>"] Max transferable quantity
        /// </summary>
        [JsonPropertyName("maxTransferOut")]
        public decimal MaxTransferable { get; set; }
        /// <summary>
        /// ["<c>accountEquity</c>"] Account equity
        /// </summary>
        [JsonPropertyName("accountEquity")]
        public decimal Equity { get; set; }
        /// <summary>
        /// ["<c>usdtEquity</c>"] Usdt equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// ["<c>btcEquity</c>"] BTC equity
        /// </summary>
        [JsonPropertyName("btcEquity")]
        public decimal BtcEquity { get; set; }
        /// <summary>
        /// ["<c>crossedRiskRate</c>"] Risk ratio in cross margin mode
        /// </summary>
        [JsonPropertyName("crossedRiskRate")]
        public decimal CrossMarginRiskRate { get; set; }
        /// <summary>
        /// ["<c>unrealizedPL</c>"] Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal? UnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>crossedUnrealizedPL</c>"] Unrealized profit and loss cross margin
        /// </summary>
        [JsonPropertyName("crossedUnrealizedPL")]
        public decimal? CrossMarginUnrealizedProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>isolatedUnrealizedPL</c>"] Unrealized profit and loss isolated margin
        /// </summary>
        [JsonPropertyName("isolatedUnrealizedPL")]
        public decimal? IsolatedMarginProfitAndLoss { get; set; }
        /// <summary>
        /// ["<c>coupon</c>"] Trading bonus
        /// </summary>
        [JsonPropertyName("coupon")]
        public decimal? Coupon { get; set; }
        /// <summary>
        /// ["<c>crossedMarginLeverage</c>"] Cross margin leverage
        /// </summary>
        [JsonPropertyName("crossedMarginLeverage")]
        public decimal? CrossMarginLeverage { get; set; }
        /// <summary>
        /// ["<c>isolatedLongLever</c>"] Isolated margin long leverage
        /// </summary>
        [JsonPropertyName("isolatedLongLever")]
        public decimal? IsolatedMarginLongLeverage { get; set; }
        /// <summary>
        /// ["<c>isolatedShortLever</c>"] Isolated margin short leverage
        /// </summary>
        [JsonPropertyName("isolatedShortLever")]
        public decimal? IsolatedMarginShortLeverage { get; set; }
        /// <summary>
        /// ["<c>marginMode</c>"] Margin mode
        /// </summary>
        [JsonPropertyName("marginMode")]
        public MarginMode? MarginMode { get; set; }
        /// <summary>
        /// ["<c>posMode</c>"] Position mode
        /// </summary>
        [JsonPropertyName("posMode")]
        public PositionMode? PositionMode { get; set; }
        /// <summary>
        /// Asset mode
        /// </summary>
        [JsonPropertyName("assetMode")]
        public AssetMode AssetMode { get; set; }
        /// <summary>
        /// ["<c>grant</c>"] Futures airdrop voucher amount
        /// </summary>
        [JsonPropertyName("grant")]
        public decimal? AirdropVoucher { get; set; }
        /// <summary>
        /// ["<c>isolatedMargin</c>"] Isolated margin used
        /// </summary>
        [JsonPropertyName("isolatedMargin")]
        public decimal? IsolatedMarginUsed { get; set; }
        /// <summary>
        /// ["<c>crossedMargin</c>"] Cross margin used
        /// </summary>
        [JsonPropertyName("crossedMargin")]
        public decimal? CrossMarginUsed { get; set; }
        /// <summary>
        /// ["<c>unionTotalMargin</c>"] Multi asset mode total margin used
        /// </summary>
        [JsonPropertyName("unionTotalMargin")]
        public decimal? MarginMultiAsset { get; set; }
        /// <summary>
        /// ["<c>unionAvailable</c>"] Available under multi-assets mode
        /// </summary>
        [JsonPropertyName("unionAvailable")]
        public decimal? AvailableMultiAsset { get; set; }
        /// <summary>
        /// ["<c>unionMm</c>"] Maintenance margin under multi-assets mode
        /// </summary>
        [JsonPropertyName("unionMm")]
        public decimal? MaintenanceMarginMultiAsset { get; set; }
        /// <summary>
        /// ["<c>assetList</c>"] Assets under multi-assets mode
        /// </summary>
        [JsonPropertyName("assetList")]
        public string[]? AssetListMultiMargin { get; set; }
    }
}
