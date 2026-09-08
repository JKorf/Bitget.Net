using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using ContractType = Bitget.Net.Enums.V2.ContractType;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesSharedApi
    {
        #region Get Ticker

        async Task<ICallResult<SharedTicker>> IGetTicker.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
            => await ((IGetTickerRest)this).GetTickerAsync(request, ct).ConfigureAwait(false);

        async Task<HttpResult<SharedTicker>> IGetTickerRest.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var result = await GetFuturesTickerAsync(request, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTicker>(result);

            return HttpResult.Ok<SharedTicker>(result, result.Data);
        }

        GetTickerOptions IFuturesTickerRestClient.GetFuturesTickerOptions => GetTickerOptions;

        public GetTickerOptions GetTickerOptions { get; } = new GetTickerOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };

        public async Task<HttpResult<SharedFuturesTicker>> GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker>(Exchange, validationError);

            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);

            var resultTicker = _api.ExchangeData.GetTickerAsync(productType, request.Symbol!.GetSymbol(FormatSymbol), ct);
            Task<HttpResult<BitgetFundingTime>> resultFunding = Task.FromResult<HttpResult<BitgetFundingTime>>(default!);
            if (!request.Symbol.TradingMode.IsDelivery())
                resultFunding = _api.ExchangeData.GetNextFundingTimeAsync(productType, request.Symbol.GetSymbol(FormatSymbol), ct);
            var resultPrices = _api.ExchangeData.GetPricesAsync(productType, request.Symbol.GetSymbol(FormatSymbol), ct);
            await Task.WhenAll(resultTicker, resultFunding, resultPrices).ConfigureAwait(false);

            if (!resultTicker.Result.Success)
                return HttpResult.Fail<SharedFuturesTicker>(resultTicker.Result);
            if (resultFunding.Result?.Success == false)
                return HttpResult.Fail<SharedFuturesTicker>(resultFunding.Result);
            if (!resultPrices.Result.Success)
                return HttpResult.Fail<SharedFuturesTicker>(resultPrices.Result);

            return HttpResult.Ok(resultTicker.Result, new SharedFuturesTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, resultTicker.Result.Data.Symbol),
                    resultTicker.Result.Data.Symbol,
                    resultTicker.Result.Data.LastPrice,
                    resultTicker.Result.Data.HighPrice,
                    resultTicker.Result.Data.LowPrice,
                    new SharedOrderQuantity(resultTicker.Result.Data.Volume, resultTicker.Result.Data.QuoteVolume),
                    resultTicker.Result.Data.ChangePercentage24H * 100)
                {
                    MarkPrice = resultPrices.Result.Data.MarkPrice,
                    IndexPrice = resultPrices.Result.Data.IndexPrice,
                    FundingRate = resultTicker.Result.Data.FundingRate,
                    NextFundingTime = resultFunding.Result!.Data!.NextFundingTime
                });
        }

        #endregion

        #region Get All Tickers

        async Task<ICallResult<SharedTicker[]>> IGetAllTickers.GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
            => await ((IGetAllTickersRest)this).GetAllTickersAsync(request, ct).ConfigureAwait(false);

        async Task<HttpResult<SharedTicker[]>> IGetAllTickersRest.GetAllTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var result = await GetAllFuturesTickersAsync(request, ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTicker[]>(result);

            return HttpResult.Ok<SharedTicker[]>(result, result.Data);
        }

        Task<HttpResult<SharedFuturesTicker[]>> IFuturesTickerRestClient.GetFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllFuturesTickersAsync(request, ct);
        GetAllTickersOptions IFuturesTickerRestClient.GetFuturesTickersOptions => GetAllTickersOptions;

        public GetAllTickersOptions GetAllTickersOptions { get; } = new GetAllTickersOptions(_exchangeName)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };

        public async Task<HttpResult<SharedFuturesTicker[]>> GetAllFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesTicker[]>(Exchange, validationError);

            var resultTickers = await _api.ExchangeData.GetTickersAsync(GetProductType(request.TradingMode, request.ExchangeParameters), ct: ct).ConfigureAwait(false);
            if (!resultTickers.Success)
                return HttpResult.Fail<SharedFuturesTicker[]>(resultTickers);

            IEnumerable<BitgetFuturesTicker> data = resultTickers.Data;
            if (request.TradingMode != null)
                data = data.Where(x => (request.TradingMode == TradingMode.DeliveryLinear || request.TradingMode == TradingMode.DeliveryInverse) ? x.DeliveryTime != null : x.DeliveryTime == null);

            return HttpResult.Ok(resultTickers, data.Select(x =>
             new SharedFuturesTicker(
                 ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol),
                 x.Symbol,
                 x.LastPrice,
                 x.HighPrice,
                 x.LowPrice,
                new SharedOrderQuantity(x.Volume, x.QuoteVolume),
                 x.ChangePercentage24H * 100)
                {
                    FundingRate = x.FundingRate,
                    IndexPrice = x.IndexPrice
                }
            ).ToArray());
        }

        #endregion

    }
}
