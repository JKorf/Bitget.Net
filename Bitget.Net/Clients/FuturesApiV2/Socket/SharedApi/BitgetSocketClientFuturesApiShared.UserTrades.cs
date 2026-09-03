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
        #region User Trade client

        public SubscribeUserTradeOptions SubscribeUserTradeOptions { get; } = new SubscribeUserTradeOptions(_exchangeName, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(SubscribeUserTradeRequest request, Action<DataEvent<SharedUserTrade[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeUserTradeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
            var result = await _api.SubscribeToUserTradeUpdatesAsync(
                productType,
                update => handler(update.ToType<SharedUserTrade[]>(update.Data.Select(x =>
                    new SharedUserTrade(
                        ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol),
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.TradeId.ToString(),
                        x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                        new SharedOrderQuantity(x.Quantity),
                        x.Price,
                        x.UpdateTime ?? x.CreateTime)
                    {
                        ClientOrderId = x.ClientOrderId,
                        Fee = Math.Abs(x.Fees.First().TotalFee),
                        FeeAsset = x.Fees.First().FeeAsset,
                        Role = x.Role == Role.Maker ? SharedRole.Maker : SharedRole.Taker
                    }
                ).ToArray())),
                ct: ct).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
