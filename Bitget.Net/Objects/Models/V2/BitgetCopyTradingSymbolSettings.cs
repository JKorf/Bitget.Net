using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Copy Trade Symbol Settings
    /// </summary>
    [SerializationModel]
    public record BitgetCopyTradingSymbolSettings
    {
        /// <summary>
        /// ["<c>symbol</c>"] Trading pair
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>openTrader</c>"] Activates copy trading or not
        /// </summary>
        [JsonPropertyName("openTrader")]
        public bool OpenTrader { get; set; }
        /// <summary>
        /// ["<c>minOpenCount</c>"] Minimum opening amount of elite traders
        /// </summary>
        [JsonPropertyName("minOpenCount")]
        public decimal? MinOpenCount { get; set; }
        /// <summary>
        /// ["<c>maxLeverage</c>"] Maximum leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal? MaxLeverage { get; set; }
        /// <summary>
        /// ["<c>stopSurplusRatio</c>"] Value set for take profit (value is a positive integer, 120 means 120%)
        /// </summary>
        [JsonPropertyName("stopSurplusRatio")]
        public int? StopSurplusRatio { get; set; }
        /// <summary>
        /// ["<c>stopLossRatio</c>"] Value set for stop-loss ratio (the value is a positive integer, 40 means 40%)
        /// </summary>
        [JsonPropertyName("stopLossRatio")]
        public int? StopLossRatio { get; set; }
    }
}
