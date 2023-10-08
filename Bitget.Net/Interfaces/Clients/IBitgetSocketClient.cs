using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects;
using CryptoExchange.Net.Interfaces;

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
        IBitgetSocketClientSpotApi SpotApi { get; set; }
        /// <summary>
        /// Futures streams
        /// </summary>
        IBitgetSocketClientFuturesApi FuturesApi { get; set; }

        /// <summary>
        /// Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.
        /// </summary>
        /// <param name="credentials">The credentials to set</param>
        void SetApiCredentials(BitgetApiCredentials credentials);
    }
}