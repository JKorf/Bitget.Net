using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
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
        #region Subscribe To UserTrade Updates

        public SubscribeUserTradeOptions SubscribeUserTradeOptions { get; } = new SubscribeUserTradeOptions(_exchangeName, true);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(SubscribeUserTradeRequest request, Action<DataEvent<SharedUserTrade[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeUserTradeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToUserTradeUpdatesAsync(
                update =>
                {
                    handler(update.ToType(update.Data.Select(x =>
                        new SharedUserTrade(
                            ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                            x.Symbol!,
                            x.OrderId,
                            x.TradeId,
                            x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                            new SharedOrderQuantity(x.Quantity),
                            x.Price,
                            x.CreateTime)
                        {
                            ClientOrderId = x.ClientOrderId,
                            Fee = x.FeeDetail.FirstOrDefault()?.Fee,
                            FeeAsset = x.FeeDetail.FirstOrDefault()?.FeeAsset,
                            Role = x.TradeScope == Role.Maker ? SharedRole.Maker : SharedRole.Taker
                        }
                    ).ToArray()));
                }
            , ct).ConfigureAwait(false);

            return result;         
        }

        #endregion

    }
}
