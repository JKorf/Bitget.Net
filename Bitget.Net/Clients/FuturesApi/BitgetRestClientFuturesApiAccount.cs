using Bitget.Net.Enums;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using System.Globalization;

namespace Bitget.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    public class BitgetRestClientFuturesApiAccount : IBitgetRestClientFuturesApiAccount
    {
        private readonly BitgetRestClientFuturesApi _baseClient;

        internal BitgetRestClientFuturesApiAccount(BitgetRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesAccountInfo>> GetAccountAsync (string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset },
            };
            return await _baseClient.ExecuteAsync<BitgetFuturesAccountInfo>(_baseClient.GetUri("/api/mix/v1/account/account"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetFuturesAccountInfo>>> GetAccountsAsync(BitgetProductType type, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) },
            };
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetFuturesAccountInfo>>(_baseClient.GetUri("/api/mix/v1/account/accounts"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetMaxPositions>> GetMaxOpenPositionsAsync(string symbol, string marginAsset, decimal openPrice, decimal openQuantity, decimal? leverage = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "marginCoin", marginAsset },
                { "openPrice", openPrice.ToString(CultureInfo.InvariantCulture) },
                { "openAmount", openQuantity.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("leverage", leverage?.ToString(CultureInfo.InvariantCulture));
            return await _baseClient.ExecuteAsync<BitgetMaxPositions>(_baseClient.GetUri("/api/mix/v1/account/open-count"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserLeverage>> SetLeverageAsync(string symbol, string marginAsset, decimal leverage, BitgetPositionSide? positionSide = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("holdSide", EnumConverter.GetString(positionSide));
            return await _baseClient.ExecuteAsync<BitgetUserLeverage>(_baseClient.GetUri("/api/mix/v1/account/setLeverage"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetResult>> SetMarginAsync(string symbol, string marginAsset, decimal margin, BitgetPositionSide? positionSide = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "amount", margin.ToString(CultureInfo.InvariantCulture) },
            };
            parameters.AddOptionalParameter("holdSide", EnumConverter.GetString(positionSide));
            return await _baseClient.ExecuteAsync<BitgetResult>(_baseClient.GetUri("/api/mix/v1/account/setMargin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetUserLeverage>> SetMarginModeAsync(string symbol, string marginAsset, BitgetMarginMode mode, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "marginMode", EnumConverter.GetString(mode) },
            };
            return await _baseClient.ExecuteAsync<BitgetUserLeverage>(_baseClient.GetUri("/api/mix/v1/account/setMarginMode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetResult>> SetAutoMarginAsync(string symbol, string marginAsset, BitgetPositionSide side, bool autoMargin, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol.ToUpperInvariant() },
                { "marginCoin", marginAsset.ToUpperInvariant() },
                { "holdSide", EnumConverter.GetString(side) },
                { "autoMargin", autoMargin ? "on" : "off" },
            };
            var result = await _baseClient.ExecuteAsync<string>(_baseClient.GetUri("/api/mix/v1/account/set-auto-margin"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return result.As<BitgetResult>(default);

            return result.As(new BitgetResult
            {
                Success = true
            });
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPositionMode>> SetHoldModeAsync(BitgetProductType type, BitgetHoldMode mode, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType",EnumConverter.GetString(type) },
                { "holdMode", EnumConverter.GetString(mode) },
            };
            return await _baseClient.ExecuteAsync<BitgetPositionMode>(_baseClient.GetUri("/api/mix/v1/account/setPositionMode"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionAsync(string symbol, string marginAsset, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "symbol", symbol },
                { "marginCoin", marginAsset },
            };
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetPosition>>(_baseClient.GetUri("/api/mix/v1/position/singlePosition-v2"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<IEnumerable<BitgetPosition>>> GetPositionsAsync(BitgetProductType type, string? marginAsset = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "productType", EnumConverter.GetString(type) }
            };
            parameters.AddOptionalParameter("marginCoin", marginAsset);
            return await _baseClient.ExecuteAsync<IEnumerable<BitgetPosition>>(_baseClient.GetUri("/api/mix/v1/position/allPosition-v2"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetPositionHistory>>> GetHistoryPositionAsync(DateTime startTime, DateTime endTime, BitgetProductType? type = null, string? symbol = null, int? pageSize = null, string? endId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
            };
            parameters.AddOptionalParameter("productType", EnumConverter.GetString(type));
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("pageSize", pageSize);
            parameters.AddOptionalParameter("lastEndId", endId);
            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetPositionHistory>>(_baseClient.GetUri("/api/mix/v1/position/history-position"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetFuturesBills>> GetBillsAsync(BitgetProductTypeV2 productType, string? symbol = null, string? asset = null, string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? endId = null, int? pageSize = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddEnum("productType", productType);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("coin", asset);
            parameters.AddOptional("businessType", bizType);
            parameters.AddOptional("idLessThan", endId);
            parameters.AddOptionalMillisecondsString("startTime", startTime);
            parameters.AddOptionalMillisecondsString("endTime", endTime);
            parameters.AddOptional("limit", pageSize);
            return await _baseClient.ExecuteAsync<BitgetFuturesBills>(_baseClient.GetUri("/api/v2/mix/account/bill"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetPagination<BitgetFuturesBill>>> GetBusinessBillsAsync(BitgetProductType type, DateTime startTime, DateTime endTime, int? pageSize = null, string? business = null, string? endId = null, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "startTime", DateTimeConverter.ConvertToMilliseconds(startTime) },
                { "endTime", DateTimeConverter.ConvertToMilliseconds(endTime) },
                { "productType", EnumConverter.GetString(type) }
            };
            parameters.AddOptionalParameter("pageSize", pageSize);
            parameters.AddOptionalParameter("lastEndId", endId);
            parameters.AddOptionalParameter("business", business);
            return await _baseClient.ExecuteAsync<BitgetPagination<BitgetFuturesBill>>(_baseClient.GetUri("/api/mix/v1/account/accountBusinessBill"), HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
