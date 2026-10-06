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
        #region Get Fees

        public GetFeeOptions GetFeeOptions { get; } = new GetFeeOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };

        async Task<IExchangeCallResult<SharedFee>> IGetFees.GetFeesAsync(GetFeeRequest request, CancellationToken ct)
            => await GetFeesAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFee>> GetFeesAsync(GetFeeRequest request, CancellationToken ct)
        {
            var validationError = GetFeeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFee>(Exchange, validationError);

            // Get data
            var result = await _api.Account.GetFeeAsync(GetCategory(request), request.SymbolName(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFee>(result);

            // Return
            return HttpResult.Ok(result, new SharedFee(result.Data.MakerFeeRate * 100, result.Data.TakerFeeRate * 100));
        }

        #endregion

    }
}
