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
        #region Get Mark Price

        async Task<IExchangeCallResult<SharedMarkPrice>> IGetMarkPrice.GetMarkPriceAsync(GetMarkPriceRequest request, CancellationToken ct)
            => await ((IGetMarkPriceRest)this).GetMarkPriceAsync(request, ct).ConfigureAwait(false);

        public GetMarkPriceOptions GetMarkPriceOptions { get; } = new GetMarkPriceOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedMarkPrice>> GetMarkPriceAsync(GetMarkPriceRequest request, CancellationToken ct)
        {
            var validationError = GetMarkPriceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedMarkPrice>(Exchange, validationError);

            var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedMarkPrice>(result);

            var MarkPrice = result.Data.Single();
            return HttpResult.Ok(result,
                new SharedMarkPrice(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, MarkPrice.Symbol),
                    MarkPrice.Symbol,
                    MarkPrice.MarkPrice));            
        }

        #endregion

        #region Get All Mark Prices

        async Task<IExchangeCallResult<SharedMarkPrice[]>> IGetAllMarkPrices.GetAllMarkPricesAsync(GetAllMarkPricesRequest request, CancellationToken ct)
            => await ((IGetAllMarkPricesRest)this).GetAllMarkPricesAsync(request, ct).ConfigureAwait(false);

        public GetAllMarkPricesOptions GetAllMarkPricesOptions { get; } = new GetAllMarkPricesOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<HttpResult<SharedMarkPrice[]>> GetAllMarkPricesAsync(GetAllMarkPricesRequest request, CancellationToken ct)
        {
            var validationError = GetAllMarkPricesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedMarkPrice[]>(Exchange, validationError);

            var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedMarkPrice[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x =>
                new SharedMarkPrice(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    x.MarkPrice)
                {
                }).ToArray());
            
        }

        #endregion

    }
}
