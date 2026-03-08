using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Futures balance
    /// </summary>
    [SerializationModel]
    public record BitgetFuturesBalanceUpdate
    {
        /// <summary>
        /// ["<c>marginCoin</c>"] Margin asset
        /// </summary>
        [JsonPropertyName("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>frozen</c>"] Quantity locked
        /// </summary>
        [JsonPropertyName("frozen")]
        public decimal Frozen { get; set; }
        /// <summary>
        /// ["<c>available</c>"] Quantity available
        /// </summary>
        [JsonPropertyName("available")]
        public decimal Available { get; set; }
        /// <summary>
        /// ["<c>maxOpenPosAvailable</c>"] Maximum available balance to open positions
        /// </summary>
        [JsonPropertyName("maxOpenPosAvailable")]
        public decimal MaxOpenPosAvailable { get; set; }
        /// <summary>
        /// ["<c>maxTransferOut</c>"] Max transferable quantity
        /// </summary>
        [JsonPropertyName("maxTransferOut")]
        public decimal MaxTransferable { get; set; }
        /// <summary>
        /// ["<c>equity</c>"] Account equity
        /// </summary>
        [JsonPropertyName("equity")]
        public decimal Equity { get; set; }
        /// <summary>
        /// ["<c>usdtEquity</c>"] Usdt equity
        /// </summary>
        [JsonPropertyName("usdtEquity")]
        public decimal UsdtEquity { get; set; }
        /// <summary>
        /// ["<c>crossedRiskRate</c>"] Risk ratio in cross margin
        /// </summary>
        [JsonPropertyName("crossedRiskRate")]
        public decimal CrossRiskRate { get; set; }
        /// <summary>
        /// ["<c>unrealizedPL</c>"] Unrealized profit and loss
        /// </summary>
        [JsonPropertyName("unrealizedPL")]
        public decimal UnrealizedPnl { get; set; }
    }
}
