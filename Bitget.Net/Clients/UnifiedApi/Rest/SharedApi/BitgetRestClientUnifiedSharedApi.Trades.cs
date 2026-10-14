using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetRestClientUnifiedSharedApi
    {
        #region Get Recent Trades

        async Task<IExchangeCallResult<SharedTrade[]>> IGetRecentTrades.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
            => await ((IGetRecentTradesRest)this).GetRecentTradesAsync(request, ct).ConfigureAwait(false);

        public GetRecentTradesOptions GetRecentTradesOptions { get; } = new GetRecentTradesOptions(_exchangeName, 100, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<HttpResult<SharedTrade[]>> GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            var validationError = GetRecentTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTrade[]>(Exchange, validationError);

            var symbolName = request.SymbolName(FormatSymbol);
            var category = GetCategory(request);
            var result = await _api.ExchangeData.GetRecentTradesAsync(
                category,
                symbolName,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTrade[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x =>
                new SharedTrade(
                    request.Symbol,
                    symbolName,
                    new SharedOrderQuantity(
                        baseAssetQuantity: category == ProductCategory.CoinFutures ? null : x.Quantity,
                        quoteAssetQuantity: category == ProductCategory.CoinFutures ? x.Quantity : null),
                    x.Price,
                    x.Timestamp)
                {
                }).ToArray());            
        }

        #endregion

    }
}
