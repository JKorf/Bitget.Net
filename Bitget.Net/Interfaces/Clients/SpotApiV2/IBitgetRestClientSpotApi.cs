using CryptoExchange.Net.Interfaces.Clients;

namespace Bitget.Net.Interfaces.Clients.SpotApiV2
{
    /// <summary>
    /// Spot API endpoints
    /// </summary>
    public interface IBitgetRestClientSpotApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientSpotApiAccount"/>
        public IBitgetRestClientSpotApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to margin trading
        /// </summary>
        /// <see cref="IBitgetRestClientSpotApiMargin"/>
        public IBitgetRestClientSpotApiMargin Margin { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        /// <see cref="IBitgetRestClientSpotApiExchangeData"/>
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientSpotApiTrading"/>
        public IBitgetRestClientSpotApiTrading Trading { get; }

        /// <summary>
        /// Get the shared rest requests client. This interface is shared with other exchanges to allow for a common implementation for different exchanges.
        /// </summary>
        IBitgetRestClientSpotApiShared SharedClient { get; }

    }
}
