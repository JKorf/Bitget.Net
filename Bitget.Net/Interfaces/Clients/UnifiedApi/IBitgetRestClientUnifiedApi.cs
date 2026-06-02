using CryptoExchange.Net.Interfaces.Clients;

namespace Bitget.Net.Interfaces.Clients.UnifiedApi
{
    /// <summary>
    /// Unified API endpoints
    /// </summary>
    public interface IBitgetRestClientUnifiedApi : IRestApiClient<BitgetCredentials>, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientUnifiedApiAccount"/>
        public IBitgetRestClientUnifiedApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        /// <see cref="IBitgetRestClientUnifiedApiExchangeData"/>
        public IBitgetRestClientUnifiedApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientUnifiedApiTrading"/>
        public IBitgetRestClientUnifiedApiTrading Trading { get; }
    }
}
