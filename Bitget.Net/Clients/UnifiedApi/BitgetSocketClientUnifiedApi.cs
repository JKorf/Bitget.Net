using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
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
using Microsoft.Extensions.Options;
using System.Net.WebSockets;

namespace Bitget.Net.Clients.UnifiedApi
{
    /// <inheritdoc />
    internal partial class BitgetSocketClientUnifiedApi : SocketApiClient<BitgetEnvironment, BitgetAuthenticationProviderV2, BitgetCredentials>, IBitgetSocketClientUnifiedApi
    {
        internal new BitgetSocketOptions ClientOptions => (BitgetSocketOptions)base.ClientOptions;

        protected override ErrorMapping ErrorMapping => BitgetErrors.UnifiedErrors;

        #region ctor
        internal BitgetSocketClientUnifiedApi(ILogger logger, BitgetSocketOptions options) :
            base(logger, options.Environment.SocketBaseAddress, options, options.UnifiedOptions)
        {
            RateLimiter = BitgetExchange.RateLimiter.Websocket;

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
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BitgetSocketUnifiedMessageConverter();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(ProductCategory type, string symbol, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTickerUpdatesAsync(type, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTickerUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type).ToLowerInvariant() },
                        { "topic", "ticker" },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(ProductCategory type, string symbol, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToKlineUpdatesAsync(type, new[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, KlineUaInterval interval, Action<DataEvent<BitgetUaKlineUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type).ToLowerInvariant() },
                        { "topic", "kline" },
                        { "symbol", s },
                        { "interval", EnumConverter.GetString(interval) },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(ProductCategory type, string symbol, int? limit, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToOrderBookUpdatesAsync(type, new[] { symbol }, limit, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetUaBookUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type).ToLowerInvariant() },
                        { "topic", "books" + limit?.ToString()  },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(ProductCategory type, string symbol, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync(type, new[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(ProductCategory type, IEnumerable<string> symbols, Action<DataEvent<BitgetUaTradeUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), symbols.Select(s => new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type).ToLowerInvariant() },
                        { "topic", "publicTrade"  },
                        { "symbol", s },
                    }).ToArray(),
            symbols, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToLiquidationUpdatesAsync(ProductCategory type, Action<DataEvent<BitgetUaLiquidationUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/public"), [new Dictionary<string, string>
                    {
                        { "instType", EnumConverter.GetString(type).ToLowerInvariant() },
                        { "topic", "liquidation"  }
                    }],
            null, false, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<BitgetUaAccountUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "account"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitgetUaPositionUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "position"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitgetUaOrder[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "order"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<BitgetUaUserTrade[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "fill"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToFastUserTradeUpdatesAsync(Action<DataEvent<BitgetUaFastUserTrade[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "fast-fill"  },
                        { "symbol", "default"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToStrategyOrderUpdatesAsync(Action<DataEvent<BitgetUaStrategyOrder[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "strategy-order"  },
                        { "symbol", "default"  }
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAdlUpdatesAsync(Action<DataEvent<BitgetUaAdlUpdate[]>> handler, CancellationToken ct = default)
        {
            return await SubscribeInternalAsync(BaseAddress.AppendPath("v3/ws/private"), [new Dictionary<string, string>
                    {
                        { "instType", "UTA" },
                        { "topic", "adl-notification"  },
                    }],
            null, true, handler, ct).ConfigureAwait(false);
        }

        #region Place Order

        /// <inheritdoc />
        public async Task<CallResult<BitgetUaOrderResult>> PlaceOrderAsync(
            ProductCategory category,
            string symbol,
            OrderSide side,
            OrderType orderType,
            decimal quantity,
            decimal? price = null,
            TimeInForce? timeInForce = null,
            PositionSide? positionSide = null,
            string? clientOrderId = null,
            bool? reduceOnly = null,
            StpMode? stpMode = null,
            PriceTriggerType? tpTriggerBy = null,
            PriceTriggerType? slTriggerBy = null,
            decimal? tpTriggerPrice = null,
            decimal? slTriggerPrice = null,
            OrderType? tpOrderType = null,
            OrderType? slOrderType = null,
            decimal? tpLimitPrice = null,
            decimal? slLimitPrice = null,
            MarginMode? marginMode = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", orderType);
            parameters.AddString("qty", quantity);
            parameters.AddOptional("price", price);
            parameters.AddOptionalEnum("timeInForce", timeInForce);
            parameters.AddOptionalEnum("posSide", positionSide);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptional("reduceOnly", reduceOnly == null ? null : reduceOnly.Value ? "yes" : "no");
            parameters.AddOptionalEnum("stpMode", stpMode);
            parameters.AddOptionalEnum("tpTriggerBy", tpTriggerBy);
            parameters.AddOptionalEnum("slTriggerBy", slTriggerBy);
            parameters.AddOptional("takeProfit", tpTriggerPrice);
            parameters.AddOptional("stopLoss", slTriggerPrice);
            parameters.AddOptionalEnum("tpOrderType", tpOrderType);
            parameters.AddOptionalEnum("slOrderType", slOrderType);
            parameters.AddOptional("tpLimitPrice", tpLimitPrice);
            parameters.AddOptional("slLimitPrice", slLimitPrice);
            parameters.AddOptionalEnum("marginMode", marginMode);

            var query = new BitgetIdQuery<BitgetUaOrderResult[]>(this, new BitgetIdSocketRequest
            {
                Id = ExchangeHelpers.NextId().ToString(),
                Category = category,
                Op = "trade",
                Topic = "place-order",
                ApiCode = LibraryHelpers.GetClientReference(() => ClientOptions.ChannelCode, BitgetExchange.ExchangeName),
                Args = [parameters]
            }, true);

            var result = await QueryAsync(BaseAddress.AppendPath("v3/ws/private"), query, ct).ConfigureAwait(false);
            return result.As<BitgetUaOrderResult>(result.Data?.SingleOrDefault());
        }

        #endregion

        #region Edit Order

        /// <inheritdoc />
        public async Task<CallResult<BitgetUaOrderResult>> EditOrderAsync(
            ProductCategory category,
            string? orderId = null,
            string? clientOrderId = null,
            decimal? quantity = null,
            decimal? price = null,
            bool? autoCancel = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalString("qty", quantity);
            parameters.AddOptional("price", price);
            parameters.AddOptional("autoCancel", autoCancel == null ? null : autoCancel.Value ? "yes" : "no");

            var query = new BitgetIdQuery<BitgetUaOrderResult[]>(this, new BitgetIdSocketRequest
            {
                Id = ExchangeHelpers.NextId().ToString(),
                Category = category,
                Op = "trade",
                Topic = "modify-order",
                Args = [parameters]
            }, true);

            var result = await QueryAsync(BaseAddress.AppendPath("v3/ws/private"), query, ct).ConfigureAwait(false);
            return result.As<BitgetUaOrderResult>(result.Data?.SingleOrDefault());
        }

        #endregion

        #region Cancel Order

        /// <inheritdoc />
        public async Task<CallResult<BitgetUaOrderResult>> CancelOrderAsync(
            ProductCategory category,
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            var query = new BitgetIdQuery<BitgetUaOrderResult[]>(this, new BitgetIdSocketRequest
            {
                Id = ExchangeHelpers.NextId().ToString(),
                Category = category,
                Op = "trade",
                Topic = "cancel-order",
                Args = [parameters]
            }, true);

            var result = await QueryAsync(BaseAddress.AppendPath("v3/ws/private"), query, ct).ConfigureAwait(false);
            return result.As<BitgetUaOrderResult>(result.Data?.SingleOrDefault());
        }

        #endregion

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
        protected override BitgetAuthenticationProviderV2 CreateAuthenticationProvider(BitgetCredentials credentials) 
            => new BitgetAuthenticationProviderV2(credentials);

    }
}
