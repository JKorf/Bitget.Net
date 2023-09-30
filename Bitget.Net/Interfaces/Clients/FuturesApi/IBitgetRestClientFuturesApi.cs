using Bitget.Net.Interfaces.Clients.FuturesApi;
using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Futures API endpoints
    /// </summary>
    public interface IBitgetRestClientFuturesApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientFuturesApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IBitgetRestClientFuturesApiExchangeData ExchangeData { get; }


        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientFuturesApiTrading Trading { get; }
    }
}
