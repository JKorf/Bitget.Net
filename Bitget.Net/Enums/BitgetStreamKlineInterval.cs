using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetStreamKlineInterval>))]
    public enum BitgetStreamKlineInterval
    {
        /// <summary>
        /// One minute
        /// </summary>
        [Map("1m")]
        OneMinute,
        /// <summary>
        /// Five minute
        /// </summary>
        [Map("5m")]
        FiveMinutes,
        /// <summary>
        /// Fifteen minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes,
        /// <summary>
        /// Thirty minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes,
        /// <summary>
        /// One hour
        /// </summary>
        [Map("1H")]
        OneHour,
        /// <summary>
        /// Four hours
        /// </summary>
        [Map("4H")]
        FourHours,
        /// <summary>
        /// Twelve hours
        /// </summary>
        [Map("12H")]
        TwelveHours,
        /// <summary>
        /// One day
        /// </summary>
        [Map("1D")]
        OneDay,
        /// <summary>
        /// One week
        /// </summary>
        [Map("1W")]
        OneWeek
    }
}
