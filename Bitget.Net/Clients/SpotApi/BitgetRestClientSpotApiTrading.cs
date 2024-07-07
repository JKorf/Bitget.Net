using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Objects;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    internal class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, BitgetTimeInForce timeInForce, decimal? price = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddEnum("force", timeInForce);
            parameters.AddString("quantity", quantity);
            parameters.AddOptionalString("price", price);
            parameters.AddOptional("clientOrderId", clientOrderId);

            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>("/api/spot/v1/trade/orders", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>("/api/spot/v1/trade/cancel-order-v2", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);

            return await _baseClient.ExecuteAsync("/api/spot/v1/trade/cancel-symbol-order", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrder>> GetOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            var result = await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>("/api/spot/v1/trade/orderInfo", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<BitgetOrder>(default);

            return result.As(result.Data.First());
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrdersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol ?? "");

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>("/api/spot/v1/trade/open-orders", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetOrder>>> GetOrderHistoryAsync(string symbol, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("after", endId);
            parameters.AddOptional("before", startId);
            parameters.AddOptional("limit", limit);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetOrder>>("/api/spot/v1/trade/history", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = null, string? startId = null, string? endId = null, int? limit = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("after", endId);
            parameters.AddOptional("before", startId);
            parameters.AddOptional("limit", limit);

            return await _baseClient.ExecuteAsync<IEnumerable<BitgetUserTrade>>("/api/spot/v1/trade/fills", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, decimal triggerPrice, BitgetTriggerType triggerType, decimal? executePrice = null, BitgetTimeInForce? timeInForce = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("orderType", type);
            parameters.AddEnum("triggerType", triggerType);
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddOptionalString("executePrice", executePrice);
            parameters.AddOptionalEnum("timeInForceValue", timeInForce);
            parameters.AddOptional("clientOrderId", clientOrderId);

            var result = await _baseClient.ExecuteAsync<BitgetOrderResult>("/api/spot/v1/plan/placePlan", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            var parameters = new ParameterCollection();
            parameters.AddEnum("orderType", type);
            parameters.AddString("size", quantity);
            parameters.AddString("triggerPrice", triggerPrice);
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);
            parameters.AddOptionalString("executePrice", executePrice);

            return await _baseClient.ExecuteAsync<BitgetOrderResult>("/api/spot/v1/plan/modifyPlan", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult> CancelPlanOrderAsync(string? orderId, string? clientOrderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("orderId", orderId);
            parameters.AddOptional("clientOid", clientOrderId);

            return await _baseClient.ExecuteAsync("/api/spot/v1/plan/cancelPlan", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrdersAsync(string symbol, int pageSize, string? fromId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddString("pageSize", pageSize);
            parameters.AddOptional("lastEndId", fromId);

            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetPlanOrder>>("/api/spot/v1/plan/currentPlan", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetPlanOrder>>> GetPlanOrderHistoryAsync(string symbol, int pageSize, DateTime startTime, DateTime endTime, string? fromId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddString("pageSize", pageSize);
            parameters.AddMillisecondsString("startTime", startTime);
            parameters.AddMillisecondsString("endTime", endTime);
            parameters.AddOptional("lastEndId", fromId);

            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetPlanOrder>>("/api/spot/v1/plan/currentPlan", HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
