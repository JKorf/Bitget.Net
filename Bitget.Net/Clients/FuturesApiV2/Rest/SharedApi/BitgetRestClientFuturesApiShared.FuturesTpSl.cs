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
        #region Set Futures Tp Sl

        public SetFuturesTpSlOptions SetFuturesTpSlOptions { get; } = new SetFuturesTpSlOptions(_exchangeName, true)
        {
            RequiredRequestParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "PositionMode the account is in", SharedPositionMode.OneWay)
            },
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription(["MarginAsset", "marginCoin"], typeof(string), "The margin asset to be used", "USDC")
            }
        };

        async Task<ICallResult<SharedId>> ISetFuturesTpSl.SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
            => await SetFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
        {
            var validationError = SetFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await _api.Trading.PlaceTpSlOrderAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                request.Symbol!.GetSymbol(FormatSymbol),
                request.GetParamValue<string>(Exchange, "MarginAsset", "marginCoin")!,
                request.TpSlSide == SharedTpSlSide.TakeProfit ? PlanType.PositionTakeProfit : PlanType.PositionStopLoss,
                null,
                request.TriggerPrice,
                hedgeModePositionSide: request.PositionMode != SharedPositionMode.HedgeMode ? null : request.PositionSide == SharedPositionSide.Long ? PositionSide.Long : PositionSide.Short,
                oneWaySide: request.PositionMode != SharedPositionMode.OneWay ? null : request.PositionSide == SharedPositionSide.Long ? OrderSide.Buy: OrderSide.Sell,
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
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ICallResult<bool>> ICancelFuturesTpSl.CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
            => await CancelFuturesTpSlAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<bool>> CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
        {
            var validationError = CancelFuturesTpSlOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<bool>(Exchange, validationError);

            var result = await _api.Trading.CancelTriggerOrdersAsync(
                GetProductType(request.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol!.GetSymbol(FormatSymbol),
                orderIds: [new BitgetCancelOrderRequest {
                    OrderId = request.OrderId
                }],
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<bool>(result);

            // Return
            return HttpResult.Ok(result, true);
        }

        #endregion

    }
}
