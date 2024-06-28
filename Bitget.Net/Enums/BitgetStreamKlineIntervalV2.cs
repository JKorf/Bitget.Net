using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    public enum BitgetStreamKlineIntervalV2
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
        /// Six hours
        /// </summary>
        [Map("6H")]
        SixHours,
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
        /// Three days
        /// </summary>
        [Map("3D")]
        ThreeDays,
        /// <summary>
        /// One week
        /// </summary>
        [Map("1W")]
        OneWeek,
        /// <summary>
        /// One month
        /// </summary>
        [Map("1M")]
        OneMonth,

        /// <summary>
        /// Six hours UTC
        /// </summary>
        [Map("6Hutc")]
        SixHoursUtc,
        /// <summary>
        /// Twelve hours UTC
        /// </summary>
        [Map("12Hutc")]
        TwelveHoursUtc,
        /// <summary>
        /// One day UTC
        /// </summary>
        [Map("1Dutc")]
        OneDayUtc,
        /// <summary>
        /// Three day UTC
        /// </summary>
        [Map("3Dutc")]
        ThreeDayUtc,
        /// <summary>
        /// One week UTC
        /// </summary>
        [Map("1Wutc")]
        OneWeekUtc,
        /// <summary>
        /// One month UTC
        /// </summary>
        [Map("1Mutc")]
        OneMonthUtc
    }
}
