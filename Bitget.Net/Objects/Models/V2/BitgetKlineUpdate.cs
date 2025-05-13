using Bitget.Net.Converters;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Bitget.Net.Objects.Models.V2
{
    /// <summary>
    /// Kline update
    /// </summary>
    [JsonConverter(typeof(ArrayConverter<BitgetKlineUpdate>))]
    [SerializationModel]
    public record BitgetKlineUpdate
    {
        /// <summary>
        /// Open time
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(CryptoExchange.Net.Converters.SystemTextJson.DateTimeConverter))]
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [ArrayProperty(1)]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Highest price
        /// </summary>
        [ArrayProperty(2)]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Lowest price
        /// </summary>
        [ArrayProperty(3)]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [ArrayProperty(4)]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Volume in base asset
        /// </summary>
        [ArrayProperty(5)]
        public decimal Volume { get; set; }
        /// <summary>
        /// Volume in quote asset
        /// </summary>
        [ArrayProperty(6)]
        public decimal QuoteVolume { get; set; }
        /// <summary>
        /// Volume in USDT
        /// </summary>
        [ArrayProperty(7)]
        public decimal UsdtVolume { get; set; }
    }
}
