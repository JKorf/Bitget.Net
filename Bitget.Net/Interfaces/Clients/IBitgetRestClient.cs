using Bitget.Net.Objects;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;

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
        SpotApiV2.IBitgetRestClientSpotApi SpotApiV2 { get; }
        /// <summary>
        /// Futures API endpoints
        /// </summary>
        FuturesApiV2.IBitgetRestClientFuturesApi FuturesApiV2 { get; }
        /// <summary>
        /// Copy Trading Futures API endpoints
        /// </summary>
        CopyTradingApiV2.IBitgetRestClientCopyTradingApi CopyTradingFuturesV2 { get; }

        /// <summary>
        /// Update specific options
        /// </summary>
        /// <param name="options">Options to update. Only specific options are changeable after the client has been created</param>
        void SetOptions(UpdateOptions options);

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(ApiCredentials credentials);
    }
}
