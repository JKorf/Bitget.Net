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
        #region Get Leverage

        public GetLeverageOptions GetLeverageOptions { get; } = new GetLeverageOptions(_exchangeName, true);

        async Task<IExchangeCallResult<SharedLeverage>> IGetLeverage.GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
            => await GetLeverageAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedLeverage>> GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
        {
            var validationError = GetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            // Get data
            var result = await _api.Account.GetAccountConfigAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            var symbolName = request.SymbolName(FormatSymbol);
            var symbolConfig = result.Data.SymbolConfigs.FirstOrDefault(s => s.Symbol == symbolName);
            if (symbolConfig == null)
                return HttpResult.Fail<SharedLeverage>(result, new ServerError(ErrorType.UnknownSymbol, $"Symbol {symbolName} not found in account config"));

            var leverage = request.PositionSide == SharedPositionSide.Long ? symbolConfig.LongLeverage : symbolConfig.ShortLeverage;

            // Return
            return HttpResult.Ok(result, new SharedLeverage(leverage ?? symbolConfig.Leverage));
        }

        #endregion

        #region Set Leverage

        public SetLeverageOptions SetLeverageOptions { get; } = new SetLeverageOptions(_exchangeName);

        public SharedLeverageSettingMode LeverageSettingType => SharedLeverageSettingMode.PerSide;

        async Task<IExchangeCallResult<SharedLeverage>> ISetLeverage.SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
            => await SetLeverageAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedLeverage>> SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
        {
            var validationError = SetLeverageOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLeverage>(Exchange, validationError);

            // Set data
            var result = await _api.Account.SetLeverageAsync(
                GetCategory(request),
                request.SymbolName(FormatSymbol),
                leverage: request.Leverage,
                shortLeverage: request.Side == SharedPositionSide.Long ? request.Leverage : (int?)null,
                longLeverage: request.Side == SharedPositionSide.Short ? request.Leverage : (int?)null,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLeverage>(result);

            // Return
            return HttpResult.Ok(result, new SharedLeverage(request.Leverage));
        }

        #endregion
    }
}
