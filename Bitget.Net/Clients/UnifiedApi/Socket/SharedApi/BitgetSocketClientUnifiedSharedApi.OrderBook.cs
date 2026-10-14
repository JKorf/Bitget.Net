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
        #region Subscribe To Order Book Updates

        public SubscribeOrderBookOptions SubscribeOrderBookOptions { get; } = new SubscribeOrderBookOptions(_exchangeName, false, [1, 5])
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<DataEvent<SharedOrderBook>> handler, CancellationToken ct)
        {
            var validationError = SubscribeOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetCategory(request);
            var symbols = request.SymbolNames(FormatSymbol);
            var result = await _api.SubscribeToOrderBookUpdatesAsync(
                productType,
                symbols,
                request.Limit ?? 5,
                update =>
                {
                    foreach (var item in update.Data)
                    {
                        handler(update.ToType(new SharedOrderBook(
                            SharedQuantityType.BaseAsset,
                            item.Sequence,
                            item.Asks,
                            item.Bids
                            )));
                    }
                }
            , ct).ConfigureAwait(false);

            return result;
                
        }

        #endregion

        #region Subscribe To Order Book Updates

        public SubscribeIncrementalOrderBookOptions SubscribeIncrementalOrderBookOptions { get; } = new SubscribeIncrementalOrderBookOptions(_exchangeName, false, [50], SharedOrderBookSubscriptionType.SnapshotThenIncremental)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToIncrementalOrderBookUpdatesAsync(SubscribeOrderBookRequest request, Action<DataEvent<SharedIncrementalOrderBook>> handler, CancellationToken ct)
        {
            var validationError = SubscribeIncrementalOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetCategory(request);
            var symbols = request.SymbolNames(FormatSymbol);
            var result = await _api.SubscribeToOrderBookUpdatesAsync(
                productType,
                symbols,
                request.Limit ?? 50,
                update =>
                {
                    foreach (var item in update.Data)
                    {
                        handler(update.ToType(new SharedIncrementalOrderBook(
                            SharedQuantityType.BaseAsset,
                            null, // pseq doesn't seem to be provided in the update
                            item.Sequence,
                            item.Asks,
                            item.Bids
                            )));
                    }
                }
            , ct).ConfigureAwait(false);

            return result;

        }

        #endregion

        #region Subscribe To Order Book Updates

        public SubscribeBookTickerOptions SubscribeBookTickerOptions { get; } = new SubscribeBookTickerOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(SubscribeBookTickerRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var productType = GetCategory(request);
            var symbols = request.SymbolNames(FormatSymbol);
            var result = await _api.SubscribeToOrderBookUpdatesAsync(
                productType,
                symbols,
                1,
                update =>
                {
                    foreach (var item in update.Data)
                    {
                        var ask = item.Asks[0];
                        var bid = item.Bids[0];
                        handler(update.ToType(new SharedBookTicker(
                            ExchangeSymbolCache.ParseSymbol(request.TradingMode == TradingMode.Spot ? _topicSpotId : _topicFuturesId, _api.EnvironmentName, null, update.Symbol),
                            update.Symbol!,
                            ask.Price,
                            new SharedOrderQuantity(ask.Quantity),
                            bid.Price,
                            new SharedOrderQuantity(bid.Quantity)
                            )));
                    }
                }
            , ct).ConfigureAwait(false);

            return result;

        }

        #endregion
    }
}
