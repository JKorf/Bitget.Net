using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetFuturesKlineInterval>))]
    public enum BitgetFuturesKlineInterval
    {
        /// <summary>
        /// ["<c>1m</c>"] 1 minute
        /// </summary>
        [Map("1m")]
        OneMinute = 60,
        /// <summary>
        /// ["<c>3m</c>"] 3 minutes
        /// </summary>
        [Map("3m")]
        ThreeMinutes = 60 * 3,
        /// <summary>
        /// ["<c>5m</c>"] 5 minutes
        /// </summary>
        [Map("5m")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// ["<c>15m</c>"] 15 minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// ["<c>30m</c>"] 30 minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// ["<c>1H</c>"] 1 hour
        /// </summary>
        [Map("1H")]
        OneHour = 60 * 60,
        /// <summary>
        /// ["<c>4H</c>"] 4 hours
        /// </summary>
        [Map("4H")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// ["<c>6H</c>"] 6 hours
        /// </summary>
        [Map("6H")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// ["<c>12H</c>"] 12 hours
        /// </summary>
        [Map("12H")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// ["<c>1D</c>"] 1 day
        /// </summary>
        [Map("1D")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// ["<c>3D</c>"] 3 days
        /// </summary>
        [Map("3D")]
        ThreeDays = 60 * 60 * 24 * 3,
        /// <summary>
        /// ["<c>1W</c>"] 1 week
        /// </summary>
        [Map("1W")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// ["<c>1M</c>"] 1 month
        /// </summary>
        [Map("1M")]
        OneMonth = 60 * 60 * 24 * 30,

        /// <summary>
        /// ["<c>6Hutc</c>"] 6 hour UTC 0
        /// </summary>
        [Map("6Hutc")]
        SixHourUtc,
        /// <summary>
        /// ["<c>12Hutc</c>"] 12 hour UTC 0
        /// </summary>
        [Map("12Hutc")]
        TwelfHourUtc,
        /// <summary>
        /// ["<c>1Dutc</c>"] 1 day UTC 0
        /// </summary>
        [Map("1Dutc")]
        OneDayUtc,
        /// <summary>
        /// ["<c>3Dutc</c>"] 3 day UTC 0
        /// </summary>
        [Map("3Dutc")]
        ThreeDayUTC,
        /// <summary>
        /// ["<c>1Wutc</c>"] 1 week UTC 0
        /// </summary>
        [Map("1Wutc")]
        OneWeekUtc,
        /// <summary>
        /// ["<c>1Mutc</c>"] 1 month UTC 0
        /// </summary>
        [Map("1Mutc")]
        OneMonthUtc
    }
}
