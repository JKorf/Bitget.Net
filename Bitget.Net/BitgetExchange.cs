using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net
{
    /// <summary>
    /// Bitget exchange information and configuration
    /// </summary>
    public static class BitgetExchange
    {
        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Bitget";

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string DisplayName => "Bitget";

        /// <summary>
        /// Url to exchange image
        /// </summary>
        public static string ImageUrl { get; } = "https://raw.githubusercontent.com/JKorf/Bitget.Net/master/Bitget.Net/Icon/icon.png";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.bitget.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://bitgetlimited.github.io/apidoc/en/mix/#welcome",
            "https://www.bitget.com/api-doc"
            };

        /// <summary>
        /// Format a base and quote asset to a Bitget recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            return baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + (deliverTime == null ? string.Empty : (ExchangeHelpers.GetDeliveryMonthSymbol(deliverTime.Value) + deliverTime.Value.ToString("yy")));
        }

        /// <summary>
        /// Rate limiter configuration for the Bitget API
        /// </summary>
        public static BitgetRateLimiters RateLimiter { get; } = new BitgetRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the GateIo API
    /// </summary>
    public class BitgetRateLimiters
    {
        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal BitgetRateLimiters()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Initialize();
        }

        private void Initialize()
        {
            Overal = new RateLimitGate("Overal")
                                    .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, Array.Empty<IGuardFilter>(), 6000, TimeSpan.FromSeconds(60), RateLimitWindowType.FixedAfterFirst)); // Overall limit of 6000 per ip per minute

            Websocket = new RateLimitGate("Websocket")
                                    .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, new LimitItemTypeFilter(RateLimitItemType.Connection), 300, TimeSpan.FromSeconds(300), RateLimitWindowType.FixedAfterFirst)) // Limit of 300 connection requests per 5 min
                                    .AddGuard(new RateLimitGuard(RateLimitGuard.PerConnection, new LimitItemTypeFilter(RateLimitItemType.Request), 240, TimeSpan.FromMinutes(60), RateLimitWindowType.FixedAfterFirst)) // Limit of 240 (subscription) requests per hour
                                    .AddGuard(new RateLimitGuard(RateLimitGuard.PerConnection, new LimitItemTypeFilter(RateLimitItemType.Request), 10, TimeSpan.FromSeconds(1), RateLimitWindowType.FixedAfterFirst)); // Limit of 10 messages per second

            Overal.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            Websocket.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate Overal { get; private set; }
        internal IRateLimitGate Websocket { get; private set; }
    }
}
