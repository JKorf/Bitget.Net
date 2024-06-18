using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;

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

            Overal.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate Overal { get; private set; }
    }
}
