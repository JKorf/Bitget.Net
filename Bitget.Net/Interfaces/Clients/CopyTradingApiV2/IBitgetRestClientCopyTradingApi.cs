using CryptoExchange.Net.Interfaces.Clients;

namespace Bitget.Net.Interfaces.Clients.CopyTradingApiV2
{
    /// <summary>
    /// CopyTrading API endpoints
    /// </summary>
    public interface IBitgetRestClientCopyTradingApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to copy trading lead settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientCopyTradingApiTrader"/>
        public IBitgetRestClientCopyTradingApiTrader Trader { get; }

        /// <summary>
        /// Endpoints related to copy trading follow settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientCopyTradingApiTrader"/>
        public IBitgetRestClientCopyTradingApiFollower Follower { get; }
    }
}
