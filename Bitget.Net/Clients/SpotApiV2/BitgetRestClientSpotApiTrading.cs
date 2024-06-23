﻿using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;
using System.Collections.Generic;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            TimeInForce timeInForce,
            decimal? price = null,
            string? clientOrderId = null,
            decimal? triggerPrice = null,
            TakeProfitStopLossType? tpslType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddEnum("force", timeInForce);
            parameters.AddString("size", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptionalString("triggerPrice", triggerPrice);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("tpslType", tpslType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/place-order", BitgetExchange.RateLimiter.Overal, 1, true, 10, TimeSpan.FromSeconds(1));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result;

            _baseClient.InvokeOrderPlaced(new OrderId
            {
                Id = result.Data.OrderId!,
                SourceObject = result.Data
            });
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> PlaceMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetPlaceOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-orders", BitgetExchange.RateLimiter.Overal, 1, true, 5, TimeSpan.FromSeconds(1));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result;

            foreach (var item in result.Data.Success)
            {
                _baseClient.InvokeOrderPlaced(new OrderId
                {
                    Id = item.OrderId!,
                    SourceObject = item
                });
            }
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> CancelOrderAsync(
            string symbol,
            string? orderId = null,
            string? clientOrderId = null,
            TakeProfitStopLossType? tpslType = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("tpslType", tpslType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-order", BitgetExchange.RateLimiter.Overal, 1, true, 10, TimeSpan.FromSeconds(1));
            var result = await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result;

            _baseClient.InvokeOrderCanceled(new OrderId
            {
                Id = result.Data.OrderId!,
                SourceObject = result.Data
            });
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelMultipleOrdersAsync(
            string symbol,
            IEnumerable<BitgetCancelOrderRequest> orders,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.Add("orderList", orders);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-cancel-order", BitgetExchange.RateLimiter.Overal, 1, true, 10, TimeSpan.FromSeconds(1));
            var result = await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
            if (!result)
                return result;

            foreach (var item in result.Data.Success)
            {
                _baseClient.InvokeOrderPlaced(new OrderId
                {
                    Id = item.OrderId!,
                    SourceObject = item
                });
            }
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelOrdersBySymbolAsync(
            string symbol,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-symbol-order", BitgetExchange.RateLimiter.Overal, 1, true, 5, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/orderInfo", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOpenOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptionalEnum("tpslType", tpslType);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/unfilled-orders", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetClosedOrdersAsync(
            string? symbol = null,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            TakeProfitStopLossType? tpslType = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptionalEnum("tpslType", tpslType);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/history-orders", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetUserTrade>>> GetUserTradesAsync(
            string symbol,
            string? orderId = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/fills", BitgetExchange.RateLimiter.Overal, 1, true, 10, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetUserTrade>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> PlaceTriggerOrderAsync(
            string symbol,
            OrderSide side,
            OrderType type,
            decimal quantity,
            decimal triggerPrice,
            QuantityType? quantityType = null,
            TriggerPriceType? triggerPriceType = null,
            decimal? orderPrice = null,
            TimeInForce? timeInForce = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddOptionalString("executePrice", orderPrice);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalEnum("force", timeInForce);
            parameters.AddOptionalEnum("planType", quantityType);
            parameters.AddOptionalEnum("triggerType", triggerPriceType);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/place-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderId>> EditTriggerOrderAsync(
            decimal triggerPrice,
            OrderType orderType,
            decimal quantity,
            decimal? orderPrice = null,
            string? orderId = null,
            string? clientOrderId = null,            
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddEnum("orderType", orderType);
            parameters.AddOptionalString("executePrice", orderPrice);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/modify-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetOrderId>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelTriggerOrderAsync(
            string? orderId = null,
            string? clientOrderId = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/cancel-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderMultipleResult>> CancelAllTriggerOrdersAsync(
            IEnumerable<string>? symbols = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbols", symbols);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/spot/trade/batch-cancel-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetOrderMultipleResult>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderList>> GetOpenTriggerOrdersAsync(
            string symbol,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? idLessThan = null,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("idLessThan", idLessThan);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/current-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetTriggerSubOrder>>> GetTriggerSubOrdersAsync(
            string triggerOrderId,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("planOrderId", triggerOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/plan-sub-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<IEnumerable<BitgetTriggerSubOrder>>(request, parameters, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderList>> GetClosedTriggerOrdersAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            int? limit = null,
            CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddMilliseconds("startTime", startTime);
            parameters.AddMilliseconds("endTime", endTime);
            parameters.AddOptional("limit", limit);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/spot/trade/history-plan-order", BitgetExchange.RateLimiter.Overal, 1, true, 20, TimeSpan.FromSeconds(1));
            return await _baseClient.SendAsync<BitgetOrderList>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}
