using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    [JsonConverter(typeof(EnumConverter<BitgetStreamKlineIntervalV2>))]
    public enum BitgetStreamKlineIntervalV2
    {
        /// <summary>
        /// ["<c>1m</c>"] One minute
        /// </summary>
        [Map("1m")]
        OneMinute = 60,
        /// <summary>
        /// ["<c>5m</c>"] Five minute
        /// </summary>
        [Map("5m")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// ["<c>15m</c>"] Fifteen minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// ["<c>30m</c>"] Thirty minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// ["<c>1H</c>"] One hour
        /// </summary>
        [Map("1H")]
        OneHour = 60 * 60,
        /// <summary>
        /// ["<c>4H</c>"] Four hours
        /// </summary>
        [Map("4H")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// ["<c>6H</c>"] Six hours
        /// </summary>
        [Map("6H")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// ["<c>12H</c>"] Twelve hours
        /// </summary>
        [Map("12H")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// ["<c>1D</c>"] One day
        /// </summary>
        [Map("1D")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// ["<c>3D</c>"] Three days
        /// </summary>
        [Map("3D")]
        ThreeDays = 60 * 60 * 24 * 3,
        /// <summary>
        /// ["<c>1W</c>"] One week
        /// </summary>
        [Map("1W")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// ["<c>1M</c>"] One month
        /// </summary>
        [Map("1M")]
        OneMonth = 60 * 60 * 24 * 30,

        /// <summary>
        /// ["<c>6Hutc</c>"] Six hours UTC
        /// </summary>
        [Map("6Hutc")]
        SixHoursUtc,
        /// <summary>
        /// ["<c>12Hutc</c>"] Twelve hours UTC
        /// </summary>
        [Map("12Hutc")]
        TwelveHoursUtc,
        /// <summary>
        /// ["<c>1Dutc</c>"] One day UTC
        /// </summary>
        [Map("1Dutc")]
        OneDayUtc,
        /// <summary>
        /// ["<c>3Dutc</c>"] Three day UTC
        /// </summary>
        [Map("3Dutc")]
        ThreeDayUtc,
        /// <summary>
        /// ["<c>1Wutc</c>"] One week UTC
        /// </summary>
        [Map("1Wutc")]
        OneWeekUtc,
        /// <summary>
        /// ["<c>1Mutc</c>"] One month UTC
        /// </summary>
        [Map("1Mutc")]
        OneMonthUtc
    }
}
