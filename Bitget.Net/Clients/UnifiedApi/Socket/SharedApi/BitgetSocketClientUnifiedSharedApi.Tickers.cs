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
        #region Subscribe To Ticker Updates

        public SubscribeTickerOptions SubscribeTickerOptions { get; } = new SubscribeTickerOptions(_exchangeName)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(SubscribeTickerRequest request, Action<DataEvent<SharedTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            if (request.TradingMode == TradingMode.Spot)
            {
                var result = await _api.SubscribeToSpotTickerUpdatesAsync(
                    symbols,
                    update =>
                    {
                        foreach (var item in update.Data)
                        {
                            handler(update.ToType(new SharedTicker(
                                    ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, update.Symbol),
                                    update.Symbol!,
                                    item.LastPrice,
                                    item.HighPrice,
                                    item.LowPrice,
                                    new SharedOrderQuantity(item.Volume, item.Turnover),
                                    item.PriceChangePercentage * 100)
                                ));
                        }
                    }
                , ct).ConfigureAwait(false);

                return result;
            }
            else
            {
                var productType = GetCategory(request);
                var result = await _api.SubscribeToFuturesTickerUpdatesAsync(productType, symbols, update =>
                {
                    foreach (var item in update.Data)
                    {
                        handler(update.ToType(new SharedTicker(
                                ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, update.Symbol),
                                update.Symbol!,
                                item.LastPrice,
                                item.HighPrice,
                                item.LowPrice,
                                new SharedOrderQuantity(item.Volume, item.Turnover),
                                item.PriceChangePercentage * 100)
                            ));
                    }
                }
                , ct).ConfigureAwait(false);

                return result;
            }            
        }

        #endregion

    }
}
