using Bitget.Net.Interfaces.Clients.CopyTradingApiV2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;

namespace Bitget.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the Bitget API. 
    /// </summary>
    public interface IBitgetRestClient : IRestClient<BitgetCredentials>
    {
        /// <summary>
        /// Spot API endpoints
        /// </summary>
        /// <see cref="IBitgetRestClientSpotApi"/>
        IBitgetRestClientSpotApi SpotApiV2 { get; }
        /// <summary>
        /// Futures API endpoints
        /// </summary>
        /// <see cref="IBitgetRestClientFuturesApi"/>
        IBitgetRestClientFuturesApi FuturesApiV2 { get; }
        /// <summary>
        /// Copy Trading Futures API endpoints
        /// </summary>
        /// <see cref="IBitgetRestClientCopyTradingApi"/>
        IBitgetRestClientCopyTradingApi CopyTradingFuturesV2 { get; }
    }
}
