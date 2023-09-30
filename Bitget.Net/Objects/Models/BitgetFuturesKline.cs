using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bitget.Net.Objects.Models
{
    /// <summary>
    /// Kline info
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BitgetFuturesKline
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Open price
        /// </summary>
        [ArrayProperty(1)]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// High price
        /// </summary>
        [ArrayProperty(2)]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Low price
        /// </summary>
        [ArrayProperty(3)]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price
        /// </summary>
        [ArrayProperty(4)]
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Base volume
        /// </summary>
        [ArrayProperty(5)]
        public decimal BaseVolume { get; set; }
        /// <summary>
        /// Quote volume
        /// </summary>
        [ArrayProperty(6)]
        public decimal QuoteVolume { get; set; }
    }
}
