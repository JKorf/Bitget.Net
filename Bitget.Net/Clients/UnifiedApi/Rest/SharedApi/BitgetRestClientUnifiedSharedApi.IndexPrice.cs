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
        #region Get Index Price

        async Task<IExchangeCallResult<SharedIndexPrice>> IGetIndexPrice.GetIndexPriceAsync(GetIndexPriceRequest request, CancellationToken ct)
            => await ((IGetIndexPriceRest)this).GetIndexPriceAsync(request, ct).ConfigureAwait(false);

        public GetIndexPriceOptions GetIndexPriceOptions { get; } = new GetIndexPriceOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedIndexPrice>> GetIndexPriceAsync(GetIndexPriceRequest request, CancellationToken ct)
        {
            var validationError = GetIndexPriceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedIndexPrice>(Exchange, validationError);

            var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedIndexPrice>(result);

            var indexPrice = result.Data.Single();
            return HttpResult.Ok(result,
                new SharedIndexPrice(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, indexPrice.Symbol),
                    indexPrice.Symbol,
                    indexPrice.IndexPrice));            
        }

        #endregion

        #region Get All Index Prices

        async Task<IExchangeCallResult<SharedIndexPrice[]>> IGetAllIndexPrices.GetAllIndexPricesAsync(GetAllIndexPricesRequest request, CancellationToken ct)
            => await ((IGetAllIndexPricesRest)this).GetAllIndexPricesAsync(request, ct).ConfigureAwait(false);

        public GetAllIndexPricesOptions GetAllIndexPricesOptions { get; } = new GetAllIndexPricesOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<HttpResult<SharedIndexPrice[]>> GetAllIndexPricesAsync(GetAllIndexPricesRequest request, CancellationToken ct)
        {
            var validationError = GetAllIndexPricesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedIndexPrice[]>(Exchange, validationError);

            var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedIndexPrice[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x =>
                new SharedIndexPrice(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    x.IndexPrice)
                {
                }).ToArray());
            
        }

        #endregion

    }
}
