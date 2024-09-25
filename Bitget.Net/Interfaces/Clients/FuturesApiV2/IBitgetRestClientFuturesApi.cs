﻿using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Futures API endpoints
    /// </summary>
    public interface IBitgetRestClientFuturesApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientFuturesApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IBitgetRestClientFuturesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IBitgetRestClientFuturesApiTrading Trading { get; }

        /// <summary>
        /// Get the shared rest requests client. This interface is shared with other exhanges to allow for a common implementation for different exchanges.
        /// </summary>
        public IBitgetRestClientFuturesApiShared SharedClient { get; }
    }
}
