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
        #region Get Leverage

        public SharedLeverageSettingMode LeverageSettingType => SharedLeverageSettingMode.PerSide;

        public GetLeverageOptions GetLeverageOptions { get; } = new GetLeverageOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                ExchangeParameterRule.Required("MarginAsset", "The margin asset to be used", "USDC", ["marginCoin"])
            ]
        };
        async Task<ICallResult<SharedLeverage>> IGetLeverage.GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
            => await GetLeverageAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedLeverage>> GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
        {
            var validationError = GetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var result = await _api.Trading.GetPositionAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                marginAsset: request.GetParamValue<string>(Exchange, "MarginAsset", "marginCoin")!,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            var position = result.Data.SingleOrDefault(x => x.PositionSide == (request.PositionSide == null ? PositionSide.Oneway : request.PositionSide == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long));

            return HttpResult.Ok(result, new SharedLeverage(position?.Leverage ?? 0));
        }

        #endregion

        #region Set Leverage

        public SetLeverageOptions SetLeverageOptions { get; } = new SetLeverageOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                ExchangeParameterRule.Required("MarginAsset", "The margin asset to be used", "USDC", ["marginCoin"])
            ]
        };
        async Task<ICallResult<SharedLeverage>> ISetLeverage.SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
            => await SetLeverageAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedLeverage>> SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
        {
            var validationError = SetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            var result = await _api.Account.SetLeverageAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                marginAsset: request.GetParamValue<string>(Exchange, "MarginAsset", "marginCoin")!,
                (int)request.Leverage,
                side: request.Side == null ? null : request.Side == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            return HttpResult.Ok(result, new SharedLeverage(request.Leverage)
            {
                Side = request.Side
            });
        }

        #endregion
    }
}
