using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetSocketClientFuturesSharedApi
    {
        #region Subscribe To Position Updates

        public SubscribePositionOptions SubscribePositionOptions { get; } = new SubscribePositionOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(SubscribePositionRequest request, Action<DataEvent<SharedPosition[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribePositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
            var result = await _api.SubscribeToPositionUpdatesAsync(productType!,
                update => {
                    handler(update.ToType<SharedPosition[]>(update.Data.Select(x => 
                        new SharedPosition(
                            ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol,
                            new SharedOrderQuantity(x.Total), 
                            x.UpdateTime)
                        {
                            AverageOpenPrice = x.AverageOpenPrice,
                            PositionMode = x.PositionSide == PositionSide.Oneway ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode,
                            PositionSide = x.PositionSide == PositionSide.Short ? SharedPositionSide.Short : SharedPositionSide.Long,
                            UnrealizedPnl = x.UnrealizedProfitAndLoss,
                            Leverage = x.Leverage,
                            LiquidationPrice = x.LiquidationPrice
                        }).ToArray()));
                    },
                ct: ct).ConfigureAwait(false);

            return result;
        }

        #endregion

    }
}
