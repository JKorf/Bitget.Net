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
        /// Trading pair
        /// </summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Activates copy trading or not
        /// </summary>
        [JsonPropertyName("openTrader")]
        public bool OpenTrader { get; set; }
        /// <summary>
        /// Minimum opening amount of elite traders
        /// </summary>
        [JsonPropertyName("minOpenCount")]
        public decimal? MinOpenCount { get; set; }
        /// <summary>
        /// Maximum leverage
        /// </summary>
        [JsonPropertyName("maxLeverage")]
        public decimal? MaxLeverage { get; set; }
        /// <summary>
        /// Value set for take profit (value is a positive integer, 120 means 120%)
        /// </summary>
        [JsonPropertyName("stopSurplusRatio")]
        public int? StopSurplusRatio { get; set; }
        /// <summary>
        /// Value set for stop-loss ratio (the value is a positive integer, 40 means 40%)
        /// </summary>
        [JsonPropertyName("stopLossRatio")]
        public int? StopLossRatio { get; set; }
    }
}
