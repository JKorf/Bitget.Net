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
        #region Subscribe To Mark Price Updates

        public SubscribeMarkPriceOptions SubscribeMarkPriceOptions { get; } = new SubscribeMarkPriceOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToMarkPriceUpdatesAsync(SubscribeMarkPriceRequest request, Action<DataEvent<SharedMarkPrice>> handler, CancellationToken ct)
        {
            var validationError = SubscribeMarkPriceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var productType = GetCategory(request);
            var result = await _api.SubscribeToFuturesTickerUpdatesAsync(productType, symbols, update =>
            {
                foreach (var item in update.Data)
                {
                    handler(update.ToType(new SharedMarkPrice(
                        ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, update.Symbol),
                        update.Symbol!, 
                        item.MarkPrice)));
                }
            }
            , ct).ConfigureAwait(false);

            return result;
                      
        }

        #endregion

    }
}
