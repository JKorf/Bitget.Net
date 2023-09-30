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
            return await _baseClient.ExecuteAsync<BitgetOrderResult>(_baseClient.GetUri("/api/spot/v1/trade/orders"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

    }
}
