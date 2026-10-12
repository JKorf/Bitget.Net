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
        #region Get Funding Info

        public GetFundingInfoOptions GetFundingInfoOptions { get; } = new GetFundingInfoOptions(_exchangeName, false, false, false, 1, false);

        async Task<IExchangeCallResult<SharedFundingInfo>> IGetFundingInfo.GetFundingInfoAsync(GetFundingInfoRequest request, CancellationToken ct)
            => await GetFundingInfoAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFundingInfo>> GetFundingInfoAsync(GetFundingInfoRequest request, CancellationToken ct)
        {
            var validationError = GetFundingInfoOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFundingInfo>(Exchange, validationError);

            // Get data
            var result = await _api.ExchangeData.GetFundingRateAsync(request.SymbolName(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFundingInfo>(result);

            var symbolInfo = result.Data.FirstOrDefault();
            if (symbolInfo == null)
                return HttpResult.Fail<SharedFundingInfo>(Exchange, new ServerError(ErrorType.UnknownSymbol, "No funding info found for the specified symbol."));

            // Return
            return HttpResult.Ok(result, new SharedFundingInfo(symbolInfo.FundingRate, symbolInfo.NextUpdate, symbolInfo.FundingRateInterval));
        }

        #endregion

        #region Get Funding Rate History

        public GetFundingRateHistoryOptions GetFundingRateHistoryOptions { get; } = new GetFundingRateHistoryOptions(_exchangeName, false,  true, false, 100, false)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ],
            MaxAge = TimeSpan.FromDays(90)
        };

        async Task<IExchangeCallResult<SharedFundingRate[]>> IGetFundingRateHistory.GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetFundingRateHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFundingRate[]>> GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetFundingRateHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFundingRate[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            // Get data
            var result = await _api.ExchangeData.GetFundingRateHistoryAsync(
                GetCategory(request), 
                request.SymbolName(FormatSymbol),
                page: pageParams.Page,
                pageSize: limit,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFundingRate[]>(result);
            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromPage(pageParams)!,
                result.Data.Length,
                result.Data.Select(x => x.Timestamp),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.Timestamp, request.StartTime, request.EndTime, direction)
                        .Select(x =>
                            new SharedFundingRate(x.FundingRate, x.Timestamp))
                       .ToArray(), nextPageRequest);
        }

        #endregion

    }
}
