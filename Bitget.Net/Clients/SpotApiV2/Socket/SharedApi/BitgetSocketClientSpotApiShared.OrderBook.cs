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
        #region Subscribe To Order Book Updates

        public SubscribeOrderBookOptions SubscribeOrderBookOptions { get; } = new SubscribeOrderBookOptions(_exchangeName, false, new[] { 1, 5, 15 })
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<DataEvent<SharedOrderBook>> handler, CancellationToken ct)
        {
            var validationError = SubscribeOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var result = await _api.SubscribeToOrderBookUpdatesAsync(symbols, request.Limit ?? 15, update =>
            {
                foreach(var item in update.Data)
                    handler(update.ToType(new SharedOrderBook(SharedQuantityType.BaseAsset, item.Sequence, item.Asks, item.Bids)));
            }, ct).ConfigureAwait(false);
            
            return result;
        }

        #endregion
    }
}
