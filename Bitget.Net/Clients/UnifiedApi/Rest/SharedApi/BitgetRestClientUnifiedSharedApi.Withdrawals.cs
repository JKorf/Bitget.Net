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
        #region Get Withdrawal History

        public GetWithdrawalHistoryOptions GetWithdrawalHistoryOptions { get; } = new GetWithdrawalHistoryOptions(_exchangeName, false, true, true, 100)
        {
            ParameterRuleOverrides = [
                RequestParameterRuleOverride<GetWithdrawalsRequest>.Required(x => x.StartTime),
                RequestParameterRuleOverride<GetWithdrawalsRequest>.Required(x => x.EndTime)
                ]
        };
        async Task<IExchangeCallResult<SharedWithdrawal[]>> IGetWithdrawalHistory.GetWithdrawalHistoryAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetWithdrawalHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedWithdrawal[]>> GetWithdrawalHistoryAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetWithdrawalHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedWithdrawal[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            // Get data
            var time = DateTime.UtcNow;
            var result = await _api.Account.GetWithdrawalRecordsAsync(
                startTime: pageParams.Cursor != null ? null : request.StartTime,
                endTime: pageParams.Cursor != null ? null : request.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedWithdrawal[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromCursor(result.Data.Min(x => x.OrderId)!),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                        .Where(x => x.Destination == TransferType.OnChain)
                        .Select(x =>
                            new SharedWithdrawal(
                                x.Asset,
                                x.ToAddress,
                                x.Quantity,
                                x.Status == Enums.Uta.WithdrawStatus.Success,
                                x.CreateTime,
                                ParseTransferStatus(x.Status))
                            {
                                Id = x.OrderId,
                                Network = x.Network,
                                TransactionId = x.RecordId
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        private SharedTransferStatus ParseTransferStatus(WithdrawStatus status)
        {
            if (status == WithdrawStatus.Success)
                return SharedTransferStatus.Completed;
            if (status == WithdrawStatus.Failed)
                return SharedTransferStatus.Failed;
            if (status == WithdrawStatus.Pending)
                return SharedTransferStatus.InProgress;

            return SharedTransferStatus.Unknown;
        }

    }
}
