using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
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

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    internal partial class BitgetSocketClientFuturesApi : SocketApiClient, IBitgetSocketClientFuturesApi
    {
        private static readonly MessagePath _eventPath = MessagePath.Get().Property("event");
        private static readonly MessagePath _actionPath = MessagePath.Get().Property("action");
        private static readonly MessagePath _instTypePath = MessagePath.Get().Property("arg").Property("instType");
        private static readonly MessagePath _channelPath = MessagePath.Get().Property("arg").Property("channel");
        private static readonly MessagePath _instIdPath = MessagePath.Get().Property("arg").Property("instId");

        #region ctor
        internal BitgetSocketClientFuturesApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.FuturesOptions)
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
        protected override IByteMessageAccessor CreateAccessor() => new SystemTextJsonByteMessageAccessor(SerializerOptions.WithConverters(BitgetExchange.SerializerContext));
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange.SerializerContext));

        public IBitgetSocketClientFuturesApiShared SharedClient => this;

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

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
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(productType, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default)
        {
            var internalHandler = (DataEvent<BitgetFuturesTickerUpdate[]> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item).WithDataTimestamp(data.DataTime));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "ticker" },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetTradeUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(productType, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "trade" },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }
        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, string symbol, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<BitgetFuturesKlineUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(productType, new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, BitgetStreamKlineIntervalV2 interval, Action<DataEvent<BitgetFuturesKlineUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "candle" + EnumConverter.GetString(interval) },
                        { "instId", s },
                    }).ToArray()
            , false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(productType, new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default)
        {
            limit?.ValidateIntValues(nameof(limit), 1, 5, 15);

            var internalHandler = (DataEvent<BitgetOrderBookUpdate[]> data) =>
            {
                foreach (var item in data.Data)
                    handler(data.As(item).WithDataTimestamp(data.DataTime));
            };

            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "books" + limit?.ToString() },
                        { "instId", s },
                    }).ToArray()
            , false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesBalanceUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "account" },
                        { "coin", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "positions" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesUserTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "fill" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "orders" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesTriggerOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "orders-algo" },
                        { "instId", "default" },
                    } }
            , true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionHistoryUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionHistoryUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "positions-history" },
                        { "instId", "default" },
                    } }
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
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProviderV2(credentials);

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            var time = DateTimeConverter.ConvertToSeconds(DateTime.UtcNow).Value;
            var authProvider = (BitgetAuthenticationProviderV2)AuthenticationProvider!;
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
