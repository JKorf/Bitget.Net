using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using ContractType = Bitget.Net.Enums.V2.ContractType;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesSharedApi
    {
        #region Get Balances

        public GetBalancesOptions GetBalancesOptions { get; } = new GetBalancesOptions(_exchangeName, AccountTypeFilter.Futures);

        async Task<ICallResult<SharedBalance[]>> IGetBalances.GetBalancesAsync(GetBalancesRequest request, CancellationToken ct)
            => await GetBalancesAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedBalance[]>> GetBalancesAsync(GetBalancesRequest request, CancellationToken ct)
        {
            var validationError = GetBalancesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBalance[]>(Exchange, validationError);

            var resultUsdt = _api.Account.GetBalancesAsync(BitgetProductTypeV2.UsdtFutures, ct: ct);
            var resultUsdc = _api.Account.GetBalancesAsync(BitgetProductTypeV2.UsdcFutures, ct: ct);
            await Task.WhenAll(resultUsdt, resultUsdc).ConfigureAwait(false);
            if (!resultUsdt.Result.Success)
                return HttpResult.Fail<SharedBalance[]>(resultUsdt.Result);
            if (!resultUsdc.Result.Success)
                return HttpResult.Fail<SharedBalance[]>(resultUsdc.Result);

            var result = new List<SharedBalance>();
            result.AddRange(resultUsdt.Result.Data.Select(x => new SharedBalance(
                        SupportedTradingModes, 
                        "USDT",
                        x.MaxTransferable, 
                        x.Available)));
            result.AddRange(resultUsdc.Result.Data.Select(x => new SharedBalance(
                        SupportedTradingModes, 
                        "USDC", 
                        x.MaxTransferable,
                        x.Available)));
            return HttpResult.Ok(resultUsdt.Result, result.ToArray());
        }

        #endregion

    }
}
