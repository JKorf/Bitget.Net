using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using Bitget.Net.Objects.Socket.Queries;
using Bitget.Net.Objects.Socket.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal partial class BitgetSocketClientSpotApi : SocketApiClient, IBitgetSocketClientSpotApi
    {
        private static readonly MessagePath _eventPath = MessagePath.Get().Property("event");
        private static readonly MessagePath _actionPath = MessagePath.Get().Property("action");
        private static readonly MessagePath _instTypePath = MessagePath.Get().Property("arg").Property("instType");
        private static readonly MessagePath _channelPath = MessagePath.Get().Property("arg").Property("channel");
        private static readonly MessagePath _instIdPath = MessagePath.Get().Property("arg").Property("instId");

        #region ctor
        internal BitgetSocketClientSpotApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.SpotOptions)
        {
            RateLimiter = BitgetExchange.RateLimiter.Websocket;

            RegisterPeriodicQuery(
                "Ping",
                TimeSpan.FromSeconds(30),
                x => new BitgetPingQuery(),
                (connection, result) =>
                {
                    if (result.Error?.Message.Equals("Query timeout") == true)
                    {
                        // Ping timeout, reconnect
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });
        }
        #endregion

        /// <inheritdoc />
        protected override IByteMessageAccessor CreateAccessor() => new SystemTextJsonByteMessageAccessor();
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        public IBitgetSocketClientSpotApiShared SharedClient => this;

        /// <inheritdoc />
        public override string GetListenerIdentifier(IMessageAccessor message)
        {
            if (!message.IsJson)
                return "pong";

            var evnt = message.GetValue<string>(_eventPath);
            if (string.Equals(evnt, "login", StringComparison.Ordinal))
                return evnt!;

            var channel = message.GetValue<string>(_channelPath);
            var instType = message.GetValue<string>(_instTypePath);
            var instId = message.GetValue<string>(_instIdPath);
            if (evnt != null)
                return $"{evnt}-{instType?.ToLowerInvariant()}-{channel?.ToLowerInvariant()}-{instId?.ToLowerInvariant()}";

            var action = message.GetValue<string>(_actionPath);
            return $"{action}-{instType?.ToLowerInvariant()}-{channel?.ToLowerInvariant()}-{instId?.ToLowerInvariant()}";
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<IEnumerable<BitgetTickerUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item).WithDataTimestamp(data.DataTime));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "ticker" },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "trade" },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "candle" + CryptoExchange.Net.Converters.SystemTextJson.EnumConverter.GetString(interval) },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            limit?.ValidateIntValues(nameof(limit), 1, 5, 15);

            var internalHandler = (DataEvent<IEnumerable<BitgetOrderBookUpdate>> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item).WithDataTimestamp(data.DataTime));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "books" + limit?.ToString() },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToMarginIndexPriceUpdatesAsync(Action<DataEvent<IEnumerable<BitgetIndexPriceUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), [new Dictionary<string, string>
                    {
                        { "instType", "MARGIN" },
                        { "channel", "index-price" },
                        { "instId", "default" },
                    }]
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BitgetOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "orders" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BitgetUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "fill" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(Action<DataEvent<IEnumerable<BitgetTriggerOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "orders-algo" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BitgetBalanceUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", "SPOT" },
                        { "channel", "account" },
                        { "coin", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToCrossMarginAccountUpdatesAsync(Action<DataEvent<IEnumerable<BitgetCrossAccountUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "MARGIN" },
                        { "channel", "account-crossed" },
                        { "coin", "default" },
                    }]
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToCrossMarginOrderUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetMarginOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), symbols.Select(x => new Dictionary<string, string>
                    {
                        { "instType", "MARGIN" },
                        { "channel", "orders-crossed" },
                        { "instId", x },
                    }).ToArray()
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToIsolatedMarginAccountUpdatesAsync(Action<DataEvent<IEnumerable<BitgetIsolatedAccountUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "MARGIN" },
                        { "channel", "account-isolated" },
                        { "coin", "default" },
                    }]
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToIsolatedMarginOrderUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetMarginOrderUpdate>>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), symbols.Select(x => new Dictionary<string, string>
                    {
                        { "instType", "MARGIN" },
                        { "channel", "orders-isolated" },
                        { "instId", x },
                    }).ToArray()
            , true, handler, ct).ConfigureAwait(false);
        }

        private async Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(
            string url,
            Dictionary<string, string>[] request,
            bool authenticated,
            Action<DataEvent<T>> handler,
            CancellationToken ct)
        {
            var subscription = new BitgetSubscription<T>(_logger, request, handler, authenticated);
            return await SubscribeAsync(url, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            var time = CryptoExchange.Net.Converters.SystemTextJson.DateTimeConverter.ConvertToSeconds(DateTime.UtcNow).Value;
            var authProvider = (BitgetAuthenticationProvider)AuthenticationProvider!;
            var signature = authProvider.GetWebsocketSignature(time);

            var socketRequest = new BitgetSocketRequest
            {
                Op = "login",
                Args = new[]
                {
                    new Dictionary<string, string>
                    {
                        { "apiKey", authProvider.ApiKey },
                        { "passphrase", authProvider.Passphrase },
                        { "timestamp", time.ToString() },
                        { "sign", signature },
                    }
                }
            };

            return Task.FromResult<Query?>(new BitgetAuthQuery(socketRequest));
        }
    }
}
