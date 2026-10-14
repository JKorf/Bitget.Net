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
        #region Subscribe To Kline Updates

        public SubscribeKlineOptions SubscribeKlineOptions { get; } = new SubscribeKlineOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot symbols", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(SubscribeKlineRequest request, Action<DataEvent<SharedKline>> handler, CancellationToken ct)
        {
            var validationError = SubscribeKlineOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var productType = GetCategory(request);
            var result = await _api.SubscribeToKlineUpdatesAsync(productType, symbols, (KlineUaInterval)request.Interval, update =>
            {
                if (update.UpdateType == SocketUpdateType.Snapshot)
                    return;

                foreach(var kline in update.Data)
                {
                    handler(update.ToType(
                        new SharedKline(
                            ExchangeSymbolCache.ParseSymbol(request.TradingMode == TradingMode.Spot ? _topicSpotId : _topicFuturesId, _api.EnvironmentName, null, update.Symbol),
                            update.Symbol!,
                            kline.OpenTime,
                            kline.ClosePrice,
                            kline.HighPrice,
                            kline.LowPrice,
                            kline.OpenPrice,
                            new SharedOrderQuantity(kline.Volume, kline.QuoteVolume)
                    )));
                }          
            }
            , ct).ConfigureAwait(false);

            return result;
                      
        }

        #endregion

    }
}
