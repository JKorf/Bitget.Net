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
        #region Close Full Position

        public CloseFullPositionOptions CloseFullPositionOptions { get; } = new CloseFullPositionOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };
        async Task<IExchangeCallResult<SharedId>> ICloseFullPosition.CloseFullPositionAsync(CloseFullPositionRequest request, CancellationToken ct)
            => await CloseFullPositionAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> CloseFullPositionAsync(CloseFullPositionRequest request, CancellationToken ct)
        {
            var validationError = CloseFullPositionOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var category = GetCategory(request);
            var order = await _api.Trading.ClosePositionsAsync(
                category,
                request.SymbolName(FormatSymbol),
                positionSide: request.PositionSide == null ? null : request.PositionSide == SharedPositionSide.Long ? PositionSide.Long : PositionSide.Short,
                ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.FirstOrDefault()?.OrderId));
        }

        #endregion

        #region Get Positions

        public GetPositionsOptions GetPositionsOptions { get; } = new GetPositionsOptions(_exchangeName, true)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        async Task<IExchangeCallResult<SharedPosition[]>> IGetPositions.GetPositionsAsync(GetPositionsRequest request, CancellationToken ct)
            => await GetPositionsAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPosition[]>> GetPositionsAsync(GetPositionsRequest request, CancellationToken ct)
        {
            var validationError = GetPositionsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPosition[]>(Exchange, validationError);

            var category = GetCategory(request);
            var result = await _api.Trading.GetPositionsAsync(category, request.Symbol?.GetSymbol(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPosition[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x =>
                new SharedPosition(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    new SharedOrderQuantity(x.Total),
                    x.UpdateTime
                    )
                {
                    AverageOpenPrice = x.AveragePrice,
                    UnrealizedPnl = x.UnrealisedPnl,
                    PositionSide = x.PositionSide == null ? default : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                    PositionMode = x.HoldMode == Enums.Uta.HoldingMode.OneWayMode ? SharedPositionMode.OneWay : SharedPositionMode.HedgeMode,
                    LiquidationPrice = x.LiquidationPrice,
                    Leverage = x.Leverage
                }).ToArray());            
        }

        #endregion

        #region Get Position History

        public GetPositionHistoryOptions GetPositionHistoryOptions { get; } = new GetPositionHistoryOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90),
            ExchangeParameterRules = [
                ExchangeParameterRule.Required<ProductCategory>("ProductCategory", "The product category", ProductCategory.UsdtFutures)
                ]
        };

        async Task<IExchangeCallResult<SharedPositionHistory[]>> IGetPositionHistory.GetPositionHistoryAsync(GetPositionHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetPositionHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedPositionHistory[]>> GetPositionHistoryAsync(GetPositionHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetPositionHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedPositionHistory[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, maxPeriod: TimeSpan.FromDays(30));

            var category = GetCategory(request);
            var result = await _api.Trading.GetPositionHistoryAsync(
                category,
                request.Symbol?.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedPositionHistory[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.Cursor == null ? null : Pagination.NextPageFromCursor(result.Data.Cursor),
                result.Data.List.Length,
                result.Data.List.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxPeriod: TimeSpan.FromDays(30),
                maxAge: TimeSpan.FromDays(90));

            return HttpResult.Ok(result, result.Data.List.Select(x =>
                new SharedPositionHistory(
                    ExchangeSymbolCache.ParseSymbol(_topicFuturesId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    x.PosSide == PositionSide.Oneway ? default : x.PosSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                    x.OpenPriceAverage,
                    x.ClosePriceAverage,
                    new SharedOrderQuantity(x.CloseTotalPos),
                    x.RealisedPnl,
                    x.UpdateTime ?? x.CreateTime
                    )
                {
                    PositionId = x.PositionId
                }).ToArray(), nextPageRequest);
        }

        #endregion
    }
}
