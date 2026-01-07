using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using Bitget.Net.Objects.Socket;
using Bitget.Net.Objects.Socket.Queries;
using Bitget.Net.Objects.Socket.Subscriptions;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

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

        protected override ErrorMapping ErrorMapping => BitgetErrors.SocketErrors;

        #region ctor
        internal BitgetSocketClientFuturesApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.FuturesOptions)
        {
            RateLimiter = BitgetExchange.RateLimiter.Websocket;

            ProcessUnparsableMessages = true;

            RegisterPeriodicQuery(
                "Ping",
                TimeSpan.FromSeconds(30),
                x => new BitgetPingQuery(),
                (connection, result) =>
                {
                    if (result.Error?.ErrorType == ErrorType.Timeout)
                    {
                        // Ping timeout, reconnect
                        _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                        _ = connection.TriggerReconnectAsync();
                    }
                });
        }
        #endregion

        /// <inheritdoc />
        protected override IByteMessageAccessor CreateAccessor(WebSocketMessageType type) => new SystemTextJsonByteMessageAccessor(SerializerOptions.WithConverters(BitgetExchange._serializerContext));
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BitgetSocketFuturesMessageConverter();

        public IBitgetSocketClientFuturesApiShared SharedClient => this;

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public override string GetListenerIdentifier(IMessageAccessor message)
        {
            if (!message.IsValid)
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
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetFuturesTickerUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(productType, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "ticker" },
                        { "instId", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
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
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
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
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(productType, new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate[]>> handler, CancellationToken ct = default)
        {
            limit?.ValidateIntValues(nameof(limit), 1, 5, 15);

            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "books" + limit?.ToString() },
                        { "instId", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesBalanceUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "account" },
                        { "coin", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "positions" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesUserTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "fill" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "orders" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetFuturesTriggerOrderUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "orders-algo" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionHistoryUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetPositionHistoryUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "positions-history" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToEquityUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetEquityUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "equity" },
                        { "instId", "default" }
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAdlUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<BitgetAdlNotification[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v2/ws/private"), new[] { new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(productType) },
                        { "channel", "adl-noti" },
                        { "instId", "default" },
                    } },
            null, true, handler, ct).ConfigureAwait(false);
        }

        private async Task<CallResult<UpdateSubscription>> SubscribeInternalAsync<T>(
            string url,
            Dictionary<string, string>[] request,
            IEnumerable<string>? symbols,
            bool authenticated,
            Action<DataEvent<T>> handler,
            CancellationToken ct)
        {
            var subscription = new BitgetSubscription<T>(_logger, this, request, symbols?.ToArray(), handler, authenticated);
            return await SubscribeAsync(url, subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials) => new BitgetAuthenticationProviderV2(credentials);

    }
}
