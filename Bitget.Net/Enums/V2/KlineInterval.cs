using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Attributes;

namespace Bitget.Net.Enums.V2
{
    /// <summary>
    /// Kline interval
    /// </summary>
    [JsonConverter(typeof(EnumConverter<KlineInterval>))]
    public enum KlineInterval
    {
        /// <summary>
        /// ["<c>1min</c>"] 1 minute
        /// </summary>
        [Map("1min")]
        OneMinute = 60,
        /// <summary>
        /// ["<c>5min</c>"] 5 minutes
        /// </summary>
        [Map("5min")]
        FiveMinutes = 60 * 5,
        /// <summary>
        /// ["<c>15min</c>"] 15 minutes
        /// </summary>
        [Map("15min")]
        FifteenMinutes = 60 * 15,
        /// <summary>
        /// ["<c>30min</c>"] 30 minutes
        /// </summary>
        [Map("30min")]
        ThirtyMinutes = 60 * 30,
        /// <summary>
        /// ["<c>1h</c>"] 1 hour
        /// </summary>
        [Map("1h")]
        OneHour = 60 * 60,
        /// <summary>
        /// ["<c>4h</c>"] 4 hours
        /// </summary>
        [Map("4h")]
        FourHours = 60 * 60 * 4,
        /// <summary>
        /// ["<c>6h</c>"] 6 hours
        /// </summary>
        [Map("6h")]
        SixHours = 60 * 60 * 6,
        /// <summary>
        /// ["<c>12h</c>"] 12 hours
        /// </summary>
        [Map("12h")]
        TwelveHours = 60 * 60 * 12,
        /// <summary>
        /// ["<c>1day</c>"] 1 day
        /// </summary>
        [Map("1day")]
        OneDay = 60 * 60 * 24,
        /// <summary>
        /// ["<c>3day</c>"] 3 days
        /// </summary>
        [Map("3day")]
        ThreeDays = 60 * 60 * 24 * 3,
        /// <summary>
        /// ["<c>1week</c>"] 1 week
        /// </summary>
        [Map("1week")]
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
