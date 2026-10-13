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

        #region Set Futures Tp Sl

        public SetFuturesTpSlOptions SetFuturesTpSlOptions { get; } = new SetFuturesTpSlOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        async Task<IExchangeCallResult<SharedId>> ISetFuturesTpSl.SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
            => await SetFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
        {
            var validationError = SetFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var result = await _api.Trading.PlaceStrategyOrderAsync(
                category,
                request.Symbol!.GetSymbol(FormatSymbol),
                Enums.Uta.StrategyType.TpSl,
                tpslMode: Enums.Uta.TpslMode.Full,
                reduceOnly: true,
                takeProfit: request.TpSlSide == SharedTpSlSide.TakeProfit ? request.TriggerPrice : null,
                stopLoss: request.TpSlSide == SharedTpSlSide.StopLoss ? request.TriggerPrice : null,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        #endregion

        #region Cancel Futures Tp Sl

        public CancelFuturesTpSlOptions CancelFuturesTpSlOptions { get; } = new CancelFuturesTpSlOptions(_exchangeName, true)
        {
            ParameterRuleOverrides = [
                RequestParameterRuleOverride<CancelTpSlRequest>.Required(x => x.OrderId)
                ],
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        async Task<IExchangeCallResult<bool>> ICancelFuturesTpSl.CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
            => await CancelFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<bool>> CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<bool>(Exchange, validationError);

            var result = await _api.Trading.CancelStrategyOrderAsync(
                request.OrderId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<bool>(result);

            // Return
            return HttpResult.Ok(result, true);
        }

        #endregion
    }
}
