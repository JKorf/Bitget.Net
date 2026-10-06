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
        #region Get Ticker

        async Task<IExchangeCallResult<SharedTicker>> IGetTicker.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
            => await ((IGetTickerRest)this).GetTickerAsync(request, ct).ConfigureAwait(false);

        public GetTickerOptions GetTickerOptions { get; } = new GetTickerOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };

        public async Task<HttpResult<SharedTicker>> GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTicker>(Exchange, validationError);

            if (request.Symbol!.TradingMode == TradingMode.Spot)
            {
                var result = await _api.ExchangeData.GetSpotTickersAsync(request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker>(result);

                var ticker = result.Data.Single();
                return HttpResult.Ok(result,
                    new SharedTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, ticker.Symbol),
                        ticker.Symbol,
                        ticker.LastPrice,
                        ticker.HighPrice,
                        ticker.LowPrice,
                        new SharedOrderQuantity(ticker.Volume, ticker.Turnover),
                        ticker.PriceChangePercentage * 100));
            }
            else
            {
                var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker>(result);

                var ticker = result.Data.Single();
                return HttpResult.Ok(result,
                    new SharedTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, ticker.Symbol),
                        ticker.Symbol,
                        ticker.LastPrice,
                        ticker.HighPrice,
                        ticker.LowPrice,
                        new SharedOrderQuantity(ticker.Volume, ticker.Turnover),
                        ticker.PriceChangePercentage * 100));
            }
        }

        #endregion

        #region Get All Tickers

        async Task<IExchangeCallResult<SharedTicker[]>> IGetAllTickers.GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
            => await ((IGetAllTickersRest)this).GetAllTickersAsync(request, ct).ConfigureAwait(false);

        public GetAllTickersOptions GetAllTickersOptions { get; } = new GetAllTickersOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ]
        };
        public async Task<HttpResult<SharedTicker[]>> GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTicker[]>(Exchange, validationError);

            if (request.TradingMode == TradingMode.Spot)
            {
                var result = await _api.ExchangeData.GetSpotTickersAsync(ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker[]>(result);

                return HttpResult.Ok(result, result.Data.Select(x =>
                    new SharedTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicSpotId, _api.EnvironmentName, null, x.Symbol),
                        x.Symbol,
                        x.LastPrice,
                        x.HighPrice,
                        x.LowPrice,
                        new SharedOrderQuantity(x.Volume, x.Turnover),
                        x.PriceChangePercentage * 100)
                    {
                    }).ToArray());
            }
            else
            {
                var result = await _api.ExchangeData.GetFuturesTickersAsync(GetCategory(request), ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedTicker[]>(result);

                return HttpResult.Ok(result, result.Data.Select(x =>
                    new SharedTicker(
                        ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                        x.Symbol,
                        x.LastPrice,
                        x.HighPrice,
                        x.LowPrice,
                        new SharedOrderQuantity(x.Volume, x.Turnover),
                        x.PriceChangePercentage * 100)
                    {
                    }).ToArray());
            }
        }

        #endregion

    }
}
