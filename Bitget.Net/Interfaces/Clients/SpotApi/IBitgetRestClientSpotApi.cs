using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Spot API endpoints
    /// </summary>
    public interface IBitgetRestClientSpotApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientSpotApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }


        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientSpotApiTrading Trading { get; }
    }
}
