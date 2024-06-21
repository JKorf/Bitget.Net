using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums
{
    /// <summary>
    /// Kline interval
    /// </summary>
    public enum BitgetFuturesKlineInterval
    {
        /// <summary>
        /// 1 minute
        /// </summary>
        [Map("1m")]
        OneMinute = 60,
        /// <summary>
        /// 3 minutes
        /// </summary>
        [Map("3m")]
        ThreeMinutes = 60 * 3,
        /// <summary>
        /// 5 minutes
        /// </summary>
        [Map("5m")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// 15 minutes
        /// </summary>
        [Map("15m")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// 30 minutes
        /// </summary>
        [Map("30m")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// 1 hour
        /// </summary>
        [Map("1H")]
        OneHour = 60 * 60,
        /// <summary>
        /// 4 hours
        /// </summary>
        [Map("4H")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// 6 hours
        /// </summary>
        [Map("6H")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// 12 hours
        /// </summary>
        [Map("12H")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// 1 day
        /// </summary>
        [Map("1D")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// 3 days
        /// </summary>
        [Map("3D")]
        ThreeDays = 60 * 60 * 24 * 3,
        /// <summary>
        /// 1 week
        /// </summary>
        [Map("1W")]
        OneWeek = 60 * 60 * 24 * 7,
        /// <summary>
        /// 1 month
        /// </summary>
        [Map("1M")]
        OneMonth = 60 * 60 * 24 * 30,

        /// <summary>
        /// 6 hour UTC 0
        /// </summary>
        [Map("6Hutc")]
        SixHourUtc,
        /// <summary>
        /// 12 hour UTC 0
        /// </summary>
        [Map("12Hutc")]
        TwelfHourUtc,
        /// <summary>
        /// 1 day UTC 0
        /// </summary>
        [Map("1Dutc")]
        OneDayUtc,
        /// <summary>
        /// 3 day UTC 0
        /// </summary>
        [Map("3Dutc")]
        ThreeDayUTC,
        /// <summary>
        /// 1 week UTC 0
        /// </summary>
        [Map("1Wutc")]
        OneWeekUtc,
        /// <summary>
        /// 1 month UTC 0
        /// </summary>
        [Map("1Mutc")]
        OneMonthUtc
    }
}
