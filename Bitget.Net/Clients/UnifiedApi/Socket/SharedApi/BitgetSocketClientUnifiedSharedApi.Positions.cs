using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using static CryptoExchange.Net.SharedApis.SharedCapabilities;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetSocketClientUnifiedSharedApi
    {
        #region Subscribe To Position Updates

        public SubscribePositionOptions SubscribePositionOptions { get; } = new SubscribePositionOptions(_exchangeName, true);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(SubscribePositionRequest request, Action<DataEvent<SharedPosition[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribePositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToPositionUpdatesAsync(
                update =>
                {
                    handler(update.ToType(update.Data.Select(x => 
                        new SharedPosition(
                            ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol!,
                            new SharedOrderQuantity(x.Quantity),
                            x.UpdateTime
                        )
                        {
                            Leverage = x.Leverage,
                            PositionSide = x.PositionSide == PositionSide.Oneway ? default : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                            AverageOpenPrice = x.AveragePrice,
                            LiquidationPrice = x.LiquidationPrice,
                            PositionMode = x.HoldMode == HoldingMode.HedgeMode ? SharedPositionMode.HedgeMode : SharedPositionMode.OneWay,
                            UnrealizedPnl = x.UnrealisedPnl
                        }
                    ).ToArray()));
                }
            , ct).ConfigureAwait(false);

            return result;         
        }
        #endregion

    }
}
