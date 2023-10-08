using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, BitgetTimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "force", EnumConverter.GetString(timeInForce) },
                { "quantity", quantity.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("clientOrderId", clientOrderId);
            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/trade/orders"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
        public async Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/trade/cancel-order-v2"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
        public async Task<WebCallResult> CancelOrdersAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            return await _baseClient.ExecuteAsync(_baseClient.GetUri("/api/spot/v1/trade/cancel-symbol-order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrder>> GetOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            var result = await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>(_baseClient.GetUri("/api/spot/v1/trade/orderInfo"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<BitgetOrder>(default);

            return result.As(result.Data.First());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrdersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol ?? "" }
            };

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>(_baseClient.GetUri("/api/spot/v1/trade/open-orders"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderHistoryAsync(string symbol, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("after", endId);
            parameters.AddOptionalParameter("before", startId);
            parameters.AddOptionalParameter("limit", limit);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>(_baseClient.GetUri("/api/spot/v1/trade/history"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = null, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol }
            };
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("after", endId);
            parameters.AddOptionalParameter("before", startId);
            parameters.AddOptionalParameter("limit", limit);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetUserTrade>>(_baseClient.GetUri("/api/spot/v1/trade/fills"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, decimal triggerPrice, BitgetTriggerType triggerType, decimal? executePrice = null, BitgetTimeInForce? timeInForce = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "size", quantity.ToString(CultureInfo.InvariantCulture) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "triggerType", EnumConverter.GetString(triggerType) },
            };
            parameters.AddOptionalParameter("executePrice", executePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForceValue", EnumConverter.GetString(timeInForce));
            parameters.AddOptionalParameter("clientOrderId", clientOrderId);
            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/plan/placePlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
        public async Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(string? orderId, string? clientOrderId, BitgetOrderType type, decimal quantity, decimal triggerPrice, decimal? executePrice = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "orderType", EnumConverter.GetString(type) },
                { "size", quantity.ToString(CultureInfo.InvariantCulture) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("executePrice", executePrice?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/plan/modifyPlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelPlanOrderAsync(string? orderId, string? clientOrderId, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync(_baseClient.GetUri("/api/spot/v1/plan/cancelPlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrdersAsync(string symbol, int pageSize, string? fromId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "pageSize", pageSize.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("lastEndId", fromId);

            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetPlanOrder>>(_baseClient.GetUri("/api/spot/v1/plan/currentPlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrderHistoryAsync(string symbol, int pageSize, DateTime startTime, DateTime endTime, string? fromId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "pageSize", pageSize.ToString(CultureInfo.InvariantCulture) },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime).ToString() },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime).ToString() },
            };
            parameters.AddOptionalParameter("lastEndId", fromId);

            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetPlanOrder>>(_baseClient.GetUri("/api/spot/v1/plan/currentPlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
