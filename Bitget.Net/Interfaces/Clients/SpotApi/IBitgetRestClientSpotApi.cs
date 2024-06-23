using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;

namespace Bitget.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// DEPRECATED, use <see cref="SpotApiV2.IBitgetRestClientSpotApi">V2</see> instead. Spot API endpoints
    /// </summary>
    public interface IBitgetRestClientSpotApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// DEPRECATED, use <see cref="SpotApiV2.IBitgetRestClientSpotApi">V2</see> instead.Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientSpotApiAccount Account { get; }

        /// <summary>
        /// DEPRECATED, use <see cref="SpotApiV2.IBitgetRestClientSpotApi">V2</see> instead. Endpoints related to retrieving market and system data
        /// </summary>
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }

        /// <summary>
        /// DEPRECATED, use <see cref="SpotApiV2.IBitgetRestClientSpotApi">V2</see> instead. Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientSpotApiTrading Trading { get; }

        /// <summary>
        /// DEPRECATED, use <see cref="SpotApiV2.IBitgetRestClientSpotApi">V2</see> instead. Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
        /// </summary>
        /// <returns></returns>
        ISpotClient CommonSpotClient { get; }
    }
}
