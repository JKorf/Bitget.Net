using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetSocketClientUnifiedSharedApi
    {
        #region Subscribe To Index Price Updates

        public SubscribeIndexPriceOptions SubscribeIndexPriceOptions { get; } = new SubscribeIndexPriceOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToIndexPriceUpdatesAsync(SubscribeIndexPriceRequest request, Action<DataEvent<SharedIndexPrice>> handler, CancellationToken ct)
        {
            var validationError = SubscribeIndexPriceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var productType = GetCategory(request);
            var result = await _api.SubscribeToFuturesTickerUpdatesAsync(productType, symbols, update =>
            {
                foreach (var item in update.Data)
                {
                    handler(update.ToType(new SharedIndexPrice(
                        ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, update.Symbol),
                        update.Symbol!, 
                        item.IndexPrice)));
                }
            }
            , ct).ConfigureAwait(false);

            return result;
                      
        }

        #endregion

    }
}
