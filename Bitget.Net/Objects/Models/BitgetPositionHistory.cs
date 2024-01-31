using Bitget.Net.Enums;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Position history
    /// </summary>
    public class BitgetPositionHistory
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Margin asset
        /// </summary>
        [JsonProperty("marginCoin")]
        public string MarginAsset { get; set; } = string.Empty;
        /// <summary>
        /// Hold side
        /// </summary>
        [JsonProperty("holdSide")]
        public BitgetPositionSide Side { get; set; }
        /// <summary>
        /// Average open price
        /// </summary>
        [JsonProperty("openAvgPrice")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>
        /// Average close price
        /// </summary>
        [JsonProperty("closeAvgPrice")]
        public decimal CloseOpenPrice { get; set; }
        /// <summary>
        /// Margin mode
        /// </summary>
        [JsonProperty("marginMode")]
        public BitgetMarginMode MarginMode { get; set; }
        /// <summary>
        /// Open position size
        /// </summary>
        [JsonProperty("openTotalPos")]
        public decimal OpenPositionSize { get; set; }
        /// <summary>
        /// Close position size
        /// </summary>
        [JsonProperty("closeTotalPos")]
        public decimal ClosePositionSize { get; set; }
        /// <summary>
        /// Profit and loss
        /// </summary>
        [JsonProperty("pnl")]
        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// Net profit
        /// </summary>
        [JsonProperty("netProfit")]
        public decimal Netprofit { get; set; }
        /// <summary>
        /// Total funding cost
        /// </summary>
        [JsonProperty("totalFunding")]
        public decimal TotalFundingCost { get; set; }
        /// <summary>
        /// Opening fee
        /// </summary>
        [JsonProperty("openFee")]
        public decimal OpeningFee { get; set; }
        /// <summary>
        /// Closing fee
        /// </summary>
        [JsonProperty("closeFee")]
        public decimal ClosingFee { get; set; }
        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("ctime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Update time
        /// </summary>
        [JsonProperty("utime")]
        public DateTime? UpdateTime { get; set; }
    }
}
