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
        private readonly IServiceProvider _serviceProvider;

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
            IKlineRestClient restClient;
            IKlineSocketClient socketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                restClient = _serviceProvider.GetRequiredService<IBitgetRestClient>().SpotApiV2.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBitgetSocketClient>().SpotApiV2.SharedClient;
            }
            else
            {
                restClient = _serviceProvider.GetRequiredService<IBitgetRestClient>().FuturesApiV2.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBitgetSocketClient>().FuturesApiV2.SharedClient;
            }

            return new KlineTracker(
                _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                restClient,
                socketClient,
                symbol,
                interval,
                limit,
                period
                );
        }

        /// <inheritdoc />
        public ITradeTracker CreateTradeTracker(SharedSymbol symbol, int? limit = null, TimeSpan? period = null)
        {
            IRecentTradeRestClient restClient;
            ITradeSocketClient socketClient;
            if (symbol.TradingMode == TradingMode.Spot)
            {
                restClient = _serviceProvider.GetRequiredService<IBitgetRestClient>().SpotApiV2.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBitgetSocketClient>().SpotApiV2.SharedClient;
            }
            else
            {
                restClient = _serviceProvider.GetRequiredService<IBitgetRestClient>().FuturesApiV2.SharedClient;
                socketClient = _serviceProvider.GetRequiredService<IBitgetSocketClient>().FuturesApiV2.SharedClient;
            }

            return new TradeTracker(
                _serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                restClient,
                socketClient,
                symbol,
                limit,
                period
                );
        }
    }
}
