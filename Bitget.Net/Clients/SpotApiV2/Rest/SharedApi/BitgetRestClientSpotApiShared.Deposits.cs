using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetRestClientSpotSharedApi
    {
        #region Get Deposit Addresses

        Task<HttpResult<SharedDeposit[]>> IDepositRestClient.GetDepositsAsync(GetDepositsRequest request, PageRequest? nextPageToken, CancellationToken ct)
            => GetDepositHistoryAsync(request, nextPageToken, ct);
        GetDepositHistoryOptions IDepositRestClient.GetDepositsOptions => GetDepositHistoryOptions;

        public GetDepositAddressesOptions GetDepositAddressesOptions { get; } = new GetDepositAddressesOptions(_exchangeName, true);
        async Task<ICallResult<SharedDepositAddress[]>> IGetDepositAddresses.GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
            => await GetDepositAddressesAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedDepositAddress[]>> GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
        {
            var validationError = GetDepositAddressesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDepositAddress[]>(Exchange, validationError);

            var depositAddresses = await _api.Account.GetDepositAddressAsync(request.Asset, request.Network).ConfigureAwait(false);
            if (!depositAddresses.Success)
                return HttpResult.Fail<SharedDepositAddress[]>(depositAddresses);

            return HttpResult.Ok(depositAddresses, new[] { new SharedDepositAddress(depositAddresses.Data.Asset, depositAddresses.Data.Address)
            {
                TagOrMemo = depositAddresses.Data.Tag,
                Network = depositAddresses.Data.Network
            }
            });
        }

        #endregion

        #region Get Deposit History

        public GetDepositHistoryOptions GetDepositHistoryOptions { get; } = new GetDepositHistoryOptions(_exchangeName, false, true, true, 100);
        async Task<ICallResult<SharedDeposit[]>> IGetDepositHistory.GetDepositHistoryAsync(GetDepositsRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetDepositHistoryAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedDeposit[]>> GetDepositHistoryAsync(GetDepositsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetDepositHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDeposit[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(90));

            // Get data
            var time = DateTime.UtcNow;
            var result = await _api.Account.GetDepositHistoryAsync(
                startTime: pageParams.StartTime ?? time.AddDays(-90),
                endTime: pageParams.EndTime ?? time,
                asset: request.Asset,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedDeposit[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => long.Parse(x.OrderId))),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedDeposit(
                                x.Asset,
                                x.Quantity,
                                x.Status == TransferStatus.Success,
                                x.CreateTime,
                                ParseTransferStatus(x.Status))
                            {
                                Id = x.OrderId,
                                Network = x.Network,
                                TransactionId = x.TransactionId,
                            })
                       .ToArray(), nextPageRequest);
        }

        #endregion

        private SharedTransferStatus ParseTransferStatus(TransferStatus status)
        {
            if (status == TransferStatus.Success)
                return SharedTransferStatus.Completed;
            if (status == TransferStatus.Failed)
                return SharedTransferStatus.Failed;
            if (status == TransferStatus.Processing)
                return SharedTransferStatus.InProgress;

            return SharedTransferStatus.Unknown;
        }

    }
}
