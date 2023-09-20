using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    public interface IBitgetRestClientSpotApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }
    }
}
