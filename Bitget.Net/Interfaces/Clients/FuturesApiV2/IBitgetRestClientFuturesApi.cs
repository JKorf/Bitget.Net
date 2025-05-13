using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Futures API endpoints
    /// </summary>
    public interface IBitgetRestClientFuturesApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientFuturesApiAccount"/>
        public IBitgetRestClientFuturesApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        /// <see cref="IBitgetRestClientFuturesApiExchangeData"/>
        public IBitgetRestClientFuturesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientFuturesApiTrading"/>
        public IBitgetRestClientFuturesApiTrading Trading { get; }

        /// <summary>
        /// Get the shared rest requests client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        public IBitgetRestClientFuturesApiShared SharedClient { get; }
    }
}
