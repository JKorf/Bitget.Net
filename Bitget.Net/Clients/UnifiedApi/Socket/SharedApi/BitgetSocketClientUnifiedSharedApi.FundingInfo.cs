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
        #region Subscribe To Funding Info Updates

        public SubscribeFundingInfoOptions SubscribeFundingInfoOptions { get; } = new SubscribeFundingInfoOptions(_exchangeName, false)
        {
            SupportsMultipleSymbols = true,
            MaxSymbolCount = 50,
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToFundingInfoUpdatesAsync(SubscribeFundingInfoRequest request, Action<DataEvent<SharedFundingInfo>> handler, CancellationToken ct)
        {
            var validationError = SubscribeFundingInfoOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var symbols = request.Symbols?.Length > 0 ? request.Symbols.Select(x => x.GetSymbol(FormatSymbol)).ToArray() : [request.Symbol!.GetSymbol(FormatSymbol)];
            var productType = GetCategory(request);
            var result = await _api.SubscribeToFuturesTickerUpdatesAsync(productType, symbols, update =>
            {
                foreach (var item in update.Data)
                {
                    handler(update.ToType(new SharedFundingInfo(item.FundingRate ?? 0, item.NextFundingTime, null)));
                }
            }
            , ct).ConfigureAwait(false);

            return result;
                      
        }

        #endregion

    }
}
