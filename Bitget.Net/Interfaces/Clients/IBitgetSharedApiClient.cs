using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for the shared REST and WebSocket API implementations of Bitget
    /// </summary>
    public interface IBitgetSharedApiClient : ISharedApiClientBase
    {
        /// <summary>
        /// Spot REST shared API implementations
        /// </summary>
        IBitgetRestClientSpotSharedApi SpotRest { get; }

        /// <summary>
        /// Futures REST shared API implementations
        /// </summary>
        IBitgetRestClientFuturesSharedApi FuturesRest { get; }

        /// <summary>
        /// Spot WebSocket shared API implementations
        /// </summary>
        IBitgetSocketClientSpotSharedApi SpotSocket { get; }

        /// <summary>
        /// Futures WebSocket shared API implementations
        /// </summary>
        IBitgetSocketClientFuturesSharedApi FuturesSocket { get; }

        /// <summary>
        /// Unified REST shared API implementations
        /// </summary>
        IBitgetRestClientUnifiedSharedApi UnifiedRest { get; }

        /// <summary>
        /// Unified WebSocket shared API implementations
        /// </summary>
        IBitgetSocketClientUnifiedSharedApi UnifiedSocket { get; }
    }
}
