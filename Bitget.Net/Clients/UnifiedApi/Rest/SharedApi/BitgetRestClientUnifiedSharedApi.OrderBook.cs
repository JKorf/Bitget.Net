using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetRestClientUnifiedSharedApi
    {
        #region Get Book Ticker

        async Task<IExchangeCallResult<SharedBookTicker>> IGetBookTicker.GetBookTickerAsync(GetBookTickerRequest request, CancellationToken ct)
            => await ((IGetBookTickerRest)this).GetBookTickerAsync(request, ct).ConfigureAwait(false);

        public GetBookTickerOptions GetBookTickerOptions { get; } = new GetBookTickerOptions(_exchangeName, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedBookTicker>> GetBookTickerAsync(GetBookTickerRequest request, CancellationToken ct)
        {
            var validationError = GetBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBookTicker>(Exchange, validationError);

            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await _api.ExchangeData.GetOrderBookAsync(
                GetCategory(request),
                symbol,
                1,
                ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedBookTicker>(result);

            var bid = result.Data.Bids[0];
            var ask = result.Data.Asks[0];
            return HttpResult.Ok(result,
                new SharedBookTicker(
                    request.Symbol,
                    symbol,
                    ask.Price,
                    new SharedOrderQuantity(ask.Quantity),
                    bid.Price,
                    new SharedOrderQuantity(bid.Quantity)
                    ));
        }

        #endregion

        #region Get Order Book

        async Task<IExchangeCallResult<SharedOrderBook>> IGetOrderBook.GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
            => await ((IGetOrderBookRest)this).GetOrderBookAsync(request, ct).ConfigureAwait(false);

        public GetOrderBookOptions GetOrderBookOptions { get; } = new GetOrderBookOptions(_exchangeName, 1, 1000, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedOrderBook>> GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
        {
            var validationError = GetOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedOrderBook>(Exchange, validationError);

            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await _api.ExchangeData.GetOrderBookAsync(
                GetCategory(request),
                symbol,
                request.Limit ?? 20,
                ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedOrderBook>(result);

            return HttpResult.Ok(result,
                new SharedOrderBook(
                    SharedQuantityType.BaseAsset,
                    null,
                    result.Data.Asks,
                    result.Data.Bids
                    ));
        }

        #endregion

    }
}
