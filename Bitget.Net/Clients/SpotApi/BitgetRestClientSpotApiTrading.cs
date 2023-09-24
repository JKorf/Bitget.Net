using Bitget.Net.Enums;
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
    public class BitgetRestClientSpotApiTrading : IBitgetRestClientSpotApiTrading
    {
        private readonly BitgetRestClientSpotApi _baseClient;

        internal BitgetRestClientSpotApiTrading(BitgetRestClientSpotApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, BitgetOrderSide side, BitgetOrderType type, decimal quantity, BitgetTimeInForce timeInForce, decimal? price, string? clientOrderId = null, CancellationToken ct = default)
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
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/trade/orders"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
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
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/trade/cancel-order-v2"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }
    }
}
