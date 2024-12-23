using Bitget.Net.Objects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bitget websocket API
    /// </summary>
    public interface IBitgetSocketClient : ISocketClient
    {
        /// <summary>
        /// Spot streams
        /// </summary>
        SpotApi.IBitgetSocketClientSpotApi SpotApi { get; set; }
        /// <summary>
        /// Spot streams
        /// </summary>
        SpotApiV2.IBitgetSocketClientSpotApi SpotApiV2 { get; set; }
        /// <summary>
        /// Futures streams
        /// </summary>
        FuturesApi.IBitgetSocketClientFuturesApi FuturesApi { get; set; }
        /// <summary>
        /// Futures streams
        /// </summary>
        FuturesApiV2.IBitgetSocketClientFuturesApi FuturesApiV2 { get; set; }

        /// <summary>
        /// Update specific options
        /// </summary>
        /// <param name="options">Options to update. Only specific options are changable after the client has been created</param>
        void SetOptions(UpdateOptions options);

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(BitgetApiCredentials credentials);
    }
}