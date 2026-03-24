using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bitget websocket API
    /// </summary>
    public interface IBitgetSocketClient : ISocketClient<BitgetCredentials>
    {
        /// <summary>
        /// Spot streams
        /// </summary>
        /// <see cref="IBitgetSocketClientSpotApi"/>
        IBitgetSocketClientSpotApi SpotApiV2 { get; set; }
        /// <summary>
        /// Futures streams
        /// </summary>
        /// <see cref="IBitgetSocketClientFuturesApi"/>
        IBitgetSocketClientFuturesApi FuturesApiV2 { get; set; }    
    }
}