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
        OneMinute = 60,
        /// <summary>
        /// Five minute
        /// </summary>
        [Map("5m")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// Fifteen minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// Thirty minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// One hour
        /// </summary>
        [Map("1H")]
        OneHour = 60 * 60,
        /// <summary>
        /// Four hours
        /// </summary>
        [Map("4H")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// Six hours
        /// </summary>
        [Map("6H")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// Twelve hours
        /// </summary>
        [Map("12H")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// One day
        /// </summary>
        [Map("1D")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// Three days
        /// </summary>
        [Map("3D")]
        ThreeDays = 60 * 60 * 24 * 3,
        /// <summary>
        /// One week
        /// </summary>
        [Map("1W")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// One month
        /// </summary>
        [Map("1M")]
        OneMonth = 60 * 60 * 24 * 30,

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
