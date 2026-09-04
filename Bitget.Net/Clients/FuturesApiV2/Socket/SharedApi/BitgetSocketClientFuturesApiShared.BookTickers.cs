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
        #region Subscribe To Book Ticker Updates

        public SubscribeBookTickerOptions SubscribeBookTickerOptions { get; } = new SubscribeBookTickerOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
            var result = await _api.SubscribeToTickerUpdatesAsync(productType, symbols, update =>
            {
                foreach (var item in update.Data)
                {
                    handler(update.ToType(
                        new SharedBookTicker(
                            ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, item.Symbol),
                            item.Symbol,
                            item.BestAskPrice ?? 0,
                            new SharedOrderQuantity(item.BestAskQuantity ?? 0),
                            item.BestBidPrice ?? 0,
                            new SharedOrderQuantity(item.BestBidQuantity ?? 0))
                        ));
                }
            }, ct).ConfigureAwait(false);
            
            return result;
        }

        #endregion
    }
}
