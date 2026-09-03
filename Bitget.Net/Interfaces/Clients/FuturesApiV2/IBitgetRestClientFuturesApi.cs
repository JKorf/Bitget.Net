using CryptoExchange.Net.Interfaces.Clients;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Futures API endpoints
    /// </summary>
    public interface IBitgetRestClientFuturesApi : IRestApiClient<BitgetCredentials>, IDisposable
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
        /// [V1] Get the shared rest requests client. For new implementations prefer using <see cref="SharedApi"/>
        /// </summary>
        public IBitgetRestClientFuturesApiShared SharedClient { get; }
        /// <summary>
        /// [V2] Gets the aggregate Shared API interface. Shared APIs provide a common,
        /// exchange-independent contract for accessing functionality across different
        /// exchange client libraries.
        /// </summary>
        public IBitgetRestClientFuturesSharedApi SharedApi { get; }
    }
}
