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
        #region Get Index Price Klines

        public GetIndexPriceKlinesOptions GetIndexPriceKlinesOptions { get; } = new GetIndexPriceKlinesOptions(_exchangeName, false, true, true, 200, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };

        async Task<ICallResult<SharedFuturesKline[]>> IGetIndexPriceKlines.GetIndexPriceKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetIndexPriceKlinesAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesKline[]>> GetIndexPriceKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;

            var validationError = GetMarkPriceKlinesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesKline[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 200;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            var result = await _api.ExchangeData.GetHistoricalIndexPriceKlinesAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                 symbol,
                 interval,
                 startTime: pageParams.StartTime,
                 endTime: pageParams.EndTime,
                 limit: limit,
                 ct: ct
                 ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesKline[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.Min(x => x.OpenTime)),
                    result.Data.Length,
                    result.Data.Select(x => x.OpenTime),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.OpenTime, request.StartTime, request.EndTime, direction)
                   .Select(x =>
                        new SharedFuturesKline(
                            request.Symbol,
                            symbol,
                            x.OpenTime,
                            x.ClosePrice,
                            x.HighPrice,
                            x.LowPrice,
                            x.OpenPrice))
                   .ToArray(), nextPageRequest);
        }

        #endregion

    }
}
