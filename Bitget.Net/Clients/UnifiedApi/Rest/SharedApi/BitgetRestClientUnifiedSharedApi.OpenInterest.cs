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
        #region Get OpenInterest

        async Task<IExchangeCallResult<SharedOpenInterest>> IGetOpenInterest.GetOpenInterestAsync(GetOpenInterestRequest request, CancellationToken ct)
            => await ((IGetOpenInterestRest)this).GetOpenInterestAsync(request, ct).ConfigureAwait(false);

        public GetOpenInterestOptions GetOpenInterestOptions { get; } = new GetOpenInterestOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedOpenInterest>> GetOpenInterestAsync(GetOpenInterestRequest request, CancellationToken ct)
        {
            var validationError = GetOpenInterestOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedOpenInterest>(Exchange, validationError);

            var result = await _api.ExchangeData.GetOpenInterestAsync(GetCategory(request), request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedOpenInterest>(result);

            var symbolData = result.Data.List.FirstOrDefault();
            if (symbolData == null)
                return HttpResult.Fail<SharedOpenInterest>(result, new ServerError(ErrorType.UnknownSymbol, $"No open interest data found for symbol"));

            return HttpResult.Ok(result,
                new SharedOpenInterest(
                    new SharedOrderQuantity(symbolData.OpenInterest)));            
        }

        #endregion

    }
}
