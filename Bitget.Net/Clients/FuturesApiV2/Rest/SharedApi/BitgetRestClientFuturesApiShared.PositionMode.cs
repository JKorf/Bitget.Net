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
        #region Get Position Mode

        public SharedPositionModeSelection PositionModeSettingType => SharedPositionModeSelection.PerAccount;

        public GetPositionModeOptions GetPositionModeOptions { get; } = new GetPositionModeOptions(_exchangeName)
        {
            ParameterRuleOverrides = [
                RequestParameterRuleOverride<GetPositionModeRequest>.Required(x => x.Symbol)
            ],
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                ExchangeParameterRule.Required("MarginAsset", "The margin asset to be used", "USDC", ["marginCoin"])
            ]
        };
        async Task<ICallResult<SharedPositionModeResult>> IGetPositionMode.GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
            => await GetPositionModeAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPositionModeResult>> GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = GetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var productType = GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters);
            var result = await _api.Account.GetBalanceAsync(
                productType,
                request.Symbol!.GetSymbol(FormatSymbol),
                request.GetParamValue<string>(Exchange, "MarginAsset", "marginCoin")!,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            return HttpResult.Ok(result, new SharedPositionModeResult(result.Data.PositionMode == PositionMode.Hedge ? SharedPositionMode.HedgeMode : SharedPositionMode.OneWay));
        }

        #endregion

        #region Set Position Mode

        public SetPositionModeOptions SetPositionModeOptions { get; } = new SetPositionModeOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };
        async Task<ICallResult<SharedPositionModeResult>> ISetPositionMode.SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
            => await SetPositionModeAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPositionModeResult>> SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = SetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            var productType = GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters);
            var result = await _api.Account.SetPositionModeAsync(
                productType, 
                request.PositionMode == SharedPositionMode.HedgeMode ? PositionMode.Hedge : PositionMode.OneWay, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            return HttpResult.Ok(result, new SharedPositionModeResult(request.PositionMode));
        }

        #endregion
    }
}
