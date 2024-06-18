using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bitget API. 
    /// </summary>
    public interface IBitgetRestClient : IRestClient
    {
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        SpotApi.IBitgetRestClientSpotApi SpotApi { get; }
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        SpotApiV2.IBitgetRestClientSpotApi SpotApiV2 { get; }
        /// <summary>
        /// Futures API endpoints
        /// </summary>
        FuturesApi.IBitgetRestClientFuturesApi FuturesApi { get; }

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
