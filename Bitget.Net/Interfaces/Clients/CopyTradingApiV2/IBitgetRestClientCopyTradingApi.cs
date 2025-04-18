using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.CopyTradingApiV2
{
    /// <summary>
    /// CopyTrading API endpoints
    /// </summary>
    public interface IBitgetRestClientCopyTradingApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to copy trading settings, info or actions
        /// </summary>
        /// <see cref="IBitgetRestClientCopyTradingApiTrader"/>
        public IBitgetRestClientCopyTradingApiTrader Trader { get; }
    }
}
