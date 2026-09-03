using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Bitget.Net.Enums.V2;
using CryptoExchange.Net;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetSocketClientSpotSharedApi
    {
        #region Book Ticker client

        public SubscribeBookTickerOptions SubscribeBookTickerOptions { get; } = new SubscribeBookTickerOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await _api.SubscribeToTickerUpdatesAsync(symbols, update =>
            {
                foreach (var item in update.Data)
                {
                    handler(update.ToType(
                        new SharedBookTicker(ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, item.Symbol), 
                        item.Symbol,
                        item.BestAskPrice,
                        new SharedOrderQuantity(item.BestAskQuantity),
                        item.BestBidPrice,
                        new SharedOrderQuantity(item.BestBidQuantity))));
                }
            }, ct).ConfigureAwait(false);
            
            return result;
        }
        #endregion
    }
}
