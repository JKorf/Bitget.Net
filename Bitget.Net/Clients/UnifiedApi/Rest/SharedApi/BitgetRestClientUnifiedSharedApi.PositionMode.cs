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
        public SharedPositionModeSelection PositionModeSettingType => SharedPositionModeSelection.PerAccount;

        #region Get Position Mode

        public GetPositionModeOptions GetPositionModeOptions { get; } = new GetPositionModeOptions(_exchangeName);

        async Task<IExchangeCallResult<SharedPositionModeResult>> IGetPositionMode.GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
            => await GetPositionModeAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPositionModeResult>> GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = GetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            // Get data
            var result = await _api.Account.GetAccountConfigAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            // Return
            return HttpResult.Ok(result, new SharedPositionModeResult(result.Data.HoldMode == HoldingMode.HedgeMode ? SharedPositionMode.HedgeMode : SharedPositionMode.OneWay));
        }

        #endregion

        #region Set Position Mode

        public SetPositionModeOptions SetPositionModeOptions { get; } = new SetPositionModeOptions(_exchangeName);

        async Task<IExchangeCallResult<SharedPositionModeResult>> ISetPositionMode.SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
            => await SetPositionModeAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPositionModeResult>> SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = SetPositionModeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionModeResult>(Exchange, validationError);

            // Set data
            var result = await _api.Account.SetHoldModeAsync(
                request.PositionMode == SharedPositionMode.HedgeMode ? HoldingMode.HedgeMode : HoldingMode.OneWayMode,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionModeResult>(result);

            // Return
            return HttpResult.Ok(result, new SharedPositionModeResult(request.PositionMode));
        }

        #endregion
    }
}
