using Bitget.Net.Clients;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Trackers.Klines;
using CryptoExchange.Net.Trackers.Trades;
using CryptoExchange.Net.Trackers.UserData;
using CryptoExchange.Net.Trackers.UserData.Interfaces;
using CryptoExchange.Net.Trackers.UserData.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

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
        public bool CanCreateKlineTracker(SharedSymbol symbol, SharedKlineInterval interval)
        {
            var client = (_serviceProvider?.GetRequiredService<IBitgetSocketClient>() ?? new BitgetSocketClient());
            SubscribeKlineOptions klineOptions = symbol.TradingMode == TradingMode.Spot ? client.SpotApiV2.SharedClient.SubscribeKlineOptions : client.FuturesApiV2.SharedClient.SubscribeKlineOptions;
            return klineOptions.IsSupported(interval);
        }

        /// <inheritdoc />
        public bool CanCreateTradeTracker(SharedSymbol symbol) => true;

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

            IRecentTradeRestClient sharedRestClient;
            ITradeSocketClient sharedSocketClient;
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

            return new TradeTracker(
                _serviceProvider?.GetRequiredService<ILoggerFactory>().CreateLogger(restClient.Exchange),
                sharedRestClient,
                null,
                sharedSocketClient,
                symbol,
                limit,
                period
                );
        }

        /// <inheritdoc />
        public IUserSpotDataTracker CreateUserSpotDataTracker(SpotUserDataTrackerConfig? config = null)
        {
            var restClient = _serviceProvider?.GetRequiredService<IBitgetRestClient>() ?? new BitgetRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBitgetSocketClient>() ?? new BitgetSocketClient();
            return new BitgetUserSpotDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BitgetUserSpotDataTracker>>() ?? new NullLogger<BitgetUserSpotDataTracker>(),
                restClient,
                socketClient,
                null,
                config
                );
        }

        /// <inheritdoc />
        public IUserSpotDataTracker CreateUserSpotDataTracker(string userIdentifier, ApiCredentials credentials, SpotUserDataTrackerConfig? config = null, BitgetEnvironment? environment = null)
        {
            var clientProvider = _serviceProvider?.GetRequiredService<IBitgetUserClientProvider>() ?? new BitgetUserClientProvider();
            var restClient = clientProvider.GetRestClient(userIdentifier, credentials, environment);
            var socketClient = clientProvider.GetSocketClient(userIdentifier, credentials, environment);
            return new BitgetUserSpotDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BitgetUserSpotDataTracker>>() ?? new NullLogger<BitgetUserSpotDataTracker>(),
                restClient,
                socketClient,
                userIdentifier,
                config
                );
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker CreateUserFuturesDataTracker(BitgetProductTypeV2 productType, FuturesUserDataTrackerConfig? config = null)
        {
            var exchangeParams = new ExchangeParameters(new ExchangeParameter("Bitget", "ProductType", productType.ToString()));

            var restClient = _serviceProvider?.GetRequiredService<IBitgetRestClient>() ?? new BitgetRestClient();
            var socketClient = _serviceProvider?.GetRequiredService<IBitgetSocketClient>() ?? new BitgetSocketClient();
            return new BitgetUserFuturesDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BitgetUserFuturesDataTracker>>() ?? new NullLogger<BitgetUserFuturesDataTracker>(),
                restClient,
                socketClient,
                null,
                config,
                exchangeParams
                );
        }

        /// <inheritdoc />
        public IUserFuturesDataTracker CreateUserFuturesDataTracker(string userIdentifier, ApiCredentials credentials, BitgetProductTypeV2 productType, FuturesUserDataTrackerConfig? config = null, BitgetEnvironment? environment = null)
        {
            var exchangeParams = new ExchangeParameters(new ExchangeParameter("Bitget", "ProductType", productType.ToString()));

            var clientProvider = _serviceProvider?.GetRequiredService<IBitgetUserClientProvider>() ?? new BitgetUserClientProvider();
            var restClient = clientProvider.GetRestClient(userIdentifier, credentials, environment);
            var socketClient = clientProvider.GetSocketClient(userIdentifier, credentials, environment);
            return new BitgetUserFuturesDataTracker(
                _serviceProvider?.GetRequiredService<ILogger<BitgetUserFuturesDataTracker>>() ?? new NullLogger<BitgetUserFuturesDataTracker>(),
                restClient,
                socketClient,
                userIdentifier,
                config,
                exchangeParams
                );
        }
    }
}
