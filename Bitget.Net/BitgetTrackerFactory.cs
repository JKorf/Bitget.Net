﻿using Bitget.Net.Clients;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Bitget.Net
{
    /// <inheritdoc />
    public class BitgetTrackerFactory : IBitgetTrackerFactory
    {
        private readonly IServiceProvider? _serviceProvider;

        /// <summary>
        /// ctor
        /// </summary>
        public BitgetTrackerFactory()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BitgetTrackerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public IKlineTracker CreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval, int? limit = null, TimeSpan? period = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBitgetRestClient>() ?? new BitgetRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBitgetSocketClient>() ?? new BitgetSocketClient();

            IKlineRestClient sharedRestClient;
            IKlineSocketClient sharedSocketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                sharedRestClient = restClient.SpotApiV2.SharedClient;
                sharedSocketClient = socketClient.SpotApiV2.SharedClient;
            }
            else
            {
                sharedRestClient = restClient.FuturesApiV2.SharedClient;
                sharedSocketClient = socketClient.FuturesApiV2.SharedClient;
            }

            return new KlineTracker(
                _serviceProvider?.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                sharedRestClient,
                sharedSocketClient,
                symbol,
                interval,
                limit,
                period
                );
        }

        /// <inheritdoc />
        public ITradeTracker CreateTradeTracker(SharedSymbol symbol, int? limit = null, TimeSpan? period = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBitgetRestClient>() ?? new BitgetRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBitgetSocketClient>() ?? new BitgetSocketClient();

            IRecentTradeRestClient sharedrestClient;
            ITradeSocketClient sharedSocketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                sharedrestClient = restClient.SpotApiV2.SharedClient;
                sharedSocketClient = socketClient.SpotApiV2.SharedClient;
            }
            else
            {
                sharedrestClient = restClient.FuturesApiV2.SharedClient;
                sharedSocketClient = socketClient.FuturesApiV2.SharedClient;
            }

            return new TradeTracker(
                _serviceProvider?.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                sharedrestClient,
                null,
                sharedSocketClient,
                symbol,
                limit,
                period
                );
        }
    }
}
