using Bitget.Net.Clients.FuturesApi;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientFuturesApiTrading : IBitgetRestClientFuturesApiTrading
    {
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiTrading(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(
                                                                string symbol, 
                                                                string marginAsset, 
                                                                BitgetFuturesOrderSide side, 
                                                                BitgetOrderType type, 
                                                                decimal quantity, 
                                                                decimal? price = null,
                                                                BitgetTimeInForce? timeInForce = null,
                                                                bool? reduceOnly = null,
                                                                decimal? takeProfitPrice = null, 
                                                                decimal? stopLossPrice = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "side", EnumConverter.GetString(side) },
                { "orderType", EnumConverter.GetString(type) },
                { "quantity", quantity.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("clientOrderId", clientOrderId);
            parameters.AddOptionalParameter("reduceOnly", reduceOnly);
            parameters.AddOptionalParameter("presetTakeProfitPrice", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("presetStopLossPrice", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("timeInForceValue", EnumConverter.GetString(timeInForce));
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/order/placeOrder"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
            };
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("orderId", orderId);

            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/order/cancel-order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> EditOrderAsync(
                                                                string symbol,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                string? newClientOrderId = null,
                                                                decimal? price = null,
                                                                decimal? quantity = null,
                                                                decimal? takeProfitPrice = null,
                                                                decimal? stopLossPrice = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
            };
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("newClientOid", newClientOrderId);
            parameters.AddOptionalParameter("price", price?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("size", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("presetTakeProfitPrice", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("presetStopLossPrice", stopLossPrice?.ToString(CultureInfo.InvariantCulture));

            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/order/modifyOrder"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
            };

            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetFuturesOrder>>(_baseClient.GetUri("/api/mix/v1/order/current"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrder>> GetOpenOrdersAsync(BitgetProductType type, string? marginAsset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) },
            };
            parameters.AddOptionalParameter("marginCoin", marginAsset?.ToUpperInvariant());
            return await _baseClient.ExecuteAsync<BitgetFuturesOrder>(_baseClient.GetUri("/api/mix/v1/order/marginCoinCurrent"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(string symbol, DateTime startTime, DateTime endTime, int pageSize, string? endId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
                { "pageSize", pageSize.ToString() },
            };
            parameters.AddOptionalParameter("lastEndId", endId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetFuturesOrder>>(_baseClient.GetUri("/api/mix/v1/order/history"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(BitgetProductType type, DateTime startTime, DateTime endTime, int pageSize, string? endId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) },
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
                { "pageSize", pageSize.ToString() },
            };
            parameters.AddOptionalParameter("lastEndId", endId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetFuturesOrder>>(_baseClient.GetUri("/api/mix/v1/order/historyProductType"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesOrder>> GetOrderAsync(string symbol,
                                                                string? orderId = null,
                                                                string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("orderId", orderId);
            return await _baseClient.ExecuteAsync<BitgetFuturesOrder>(_baseClient.GetUri("/api/mix/v1/order/detail"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(string symbol,
                                                                string? orderId = null, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() }
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("lastEndId", endId);
            parameters.AddOptionalParameter("orderId", orderId);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesUserTrade>>(_baseClient.GetUri("/api/mix/v1/order/fills"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(BitgetProductType type, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) }
            };
            parameters.AddOptionalParameter("startTime", DateTimeConverter.ConvertToMilliseconds(startTime));
            parameters.AddOptionalParameter("endTime", DateTimeConverter.ConvertToMilliseconds(endTime));
            parameters.AddOptionalParameter("lastEndId", endId);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesUserTrade>>(_baseClient.GetUri("/api/mix/v1/order/allFills"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
