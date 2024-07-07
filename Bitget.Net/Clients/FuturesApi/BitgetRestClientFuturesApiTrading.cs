using Bitget.Net.Clients.FuturesApi;
using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Globalization;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApiTrading : IBitgetRestClientFuturesApiTrading
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
                { "size", quantity.ToString(CultureInfo.InvariantCulture) },
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
        public async Task<WebCallResult<IEnumerable<BitgetFuturesOrder>>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
            };

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesOrder>>(_baseClient.GetUri("/api/mix/v1/order/current"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesOrder>>> GetOpenOrdersByProductAsync(BitgetProductType type, string? marginAsset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) },
            };
            parameters.AddOptionalParameter("marginCoin", marginAsset?.ToUpperInvariant());
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesOrder>>(_baseClient.GetUri("/api/mix/v1/order/marginCoinCurrent"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
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

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetFuturesOrderSide side,
                                                                BitgetOrderType type,
                                                                BitgetTriggerType triggerType,
                                                                decimal quantity,
                                                                decimal triggerPrice,
                                                                decimal? executePrice = null,
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
                { "size", quantity.ToString(CultureInfo.InvariantCulture) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "triggerType", EnumConverter.GetString(triggerType) },
            };

            parameters.AddOptionalParameter("executePrice", executePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("reduceOnly", reduceOnly);
            parameters.AddOptionalParameter("presetTakeProfitPrice", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("presetStopLossPrice", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/placePlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                decimal triggerPrice,
                                                                BitgetTriggerType triggerType,
                                                                BitgetOrderType orderType,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                decimal? executePrice = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginAsset", marginAsset.ToUpperInvariant() },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "triggerType", EnumConverter.GetString(triggerType) },
                { "orderType", EnumConverter.GetString(orderType) },
            };
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("executePrice", executePrice?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/order/modifyOrder"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> EditPlanOrderTpSlAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                decimal? takeProfitPrice = null,
                                                                decimal? stopLossPrice = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginAsset", marginAsset.ToUpperInvariant() },
            };
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("presetTakeProfitPrice", takeProfitPrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("presetStopLossPrice", stopLossPrice?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/order/modifyPlanPreset"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                BitgetPositionSide side,
                                                                BitgetTriggerType? triggerType = null,
                                                                decimal? quantity = null,
                                                                decimal? executePrice = null,
                                                                decimal? rangeRate = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "holdSide", EnumConverter.GetString(side) },
                { "planType", EnumConverter.GetString(planType) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) }
            };

            parameters.AddOptionalParameter("executePrice", executePrice?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("triggerType", EnumConverter.GetString(triggerType));
            parameters.AddOptionalParameter("size", quantity?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("rangeRate", rangeRate?.ToString(CultureInfo.InvariantCulture));
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/placeTPSL"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceTrailingStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                decimal triggerPrice,
                                                                BitgetFuturesOrderSide side,
                                                                decimal quantity,
                                                                decimal rangeRate,
                                                                BitgetTriggerType? triggerType = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "side", EnumConverter.GetString(side) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "size", quantity.ToString(CultureInfo.InvariantCulture) },
                { "rangeRate", rangeRate.ToString(CultureInfo.InvariantCulture) }
            };

            parameters.AddOptionalParameter("triggerType", EnumConverter.GetString(triggerType));
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/placeTrailStop"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlacePositionTpSlAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                BitgetTriggerType triggerType,
                                                                BitgetPositionSide side,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "planType", EnumConverter.GetString(planType) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                { "holdSide", EnumConverter.GetString(side) },
                { "triggerType", EnumConverter.GetString(triggerType) },
            };

            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/placePositionsTPSL"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> EditStopOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                decimal triggerPrice,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "planType", EnumConverter.GetString(planType) },
                { "triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/placePositionsTPSL"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> CancelPlanOrderAsync(
                                                                string symbol,
                                                                string marginAsset,
                                                                BitgetPlanType planType,
                                                                string? orderId = null,
                                                                string? clientOrderId = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "planType", EnumConverter.GetString(planType) },
            };

            parameters.AddOptionalParameter("orderId", orderId);
            parameters.AddOptionalParameter("clientOid", clientOrderId);
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/mix/v1/plan/cancelPlan"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesPlanOrder>>> GetPlanOrderHistoryAsync(
                                                                DateTime startTime,
                                                                DateTime endTime,
                                                                BitgetProductType? type = null,
                                                                string? symbol = null,
                                                                int? pageSize = null,
                                                                CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) }
            };
            parameters.AddOptionalParameter("type", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("pageSize", pageSize);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesPlanOrder>>(_baseClient.GetUri("/api/mix/v1/plan/historyPlan"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesPlanOrder>>> GetPlanOrdersAsync(string? symbol, BitgetProductType? type = null, BitgetPlanFilter? planType = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("productType", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("isPlan", EnumConverter.GetString(planType));

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesPlanOrder>>(_baseClient.GetUri("/api/mix/v1/plan/currentPlan"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
