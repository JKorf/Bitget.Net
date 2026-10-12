using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetRestClientUnifiedSharedApi
    {
        #region Get Ledger

        public GetLedgerOptions GetLedgerOptions { get; } = new GetLedgerOptions(_exchangeName, false, true, true, 100)
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Optional<ProductCategory>("ProductCategory", "The product category, required for non-spot data", ProductCategory.UsdtFutures)
                ],
            MaxAge = TimeSpan.FromDays(90)
        };
        async Task<IExchangeCallResult<SharedLedgerEntry[]>> IGetLedger.GetLedgerAsync(GetLedgerRequest request, PageRequest? pageRequest, CancellationToken ct)
            => await GetLedgerAsync(request, pageRequest, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedLedgerEntry[]>> GetLedgerAsync(GetLedgerRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = GetLedgerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedLedgerEntry[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            // Get data
            var time = DateTime.UtcNow;
            var result = await _api.Account.GetFinancialRecordsAsync(
                GetCategory(request),
                startTime: pageParams.Cursor != null ? null : request.StartTime,
                endTime: pageParams.Cursor != null ? null : request.EndTime,
                asset: request.Asset,
                limit: limit,
                cursor: pageParams.Cursor,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedLedgerEntry[]>(result);

            var records = result.Data.Records ?? [];
            var nextPageRequest = Pagination.GetNextPageRequest(
                () => result.Data.Cursor == null ? null : Pagination.NextPageFromCursor(result.Data.Cursor),
                records.Length,
                records.Select(x => x.Timestamp),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(30));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(records, x => x.Timestamp, request.StartTime, request.EndTime, direction)
                        .Select(x =>
                            new SharedLedgerEntry(
                                x.Asset,
                                x.Quantity,
                                ParseLedgerEntryType(x.Type),
                                EnumConverter.GetString(x.Type),
                                x.Timestamp                                
                            ))
                       .ToArray(), nextPageRequest);
        }

        private SharedLedgerEntryType ParseLedgerEntryType(FinancialEntryType type)
        {
            if (type == FinancialEntryType.TransferIn
                || type == FinancialEntryType.TransferOut)
            {
                return SharedLedgerEntryType.Transfer;
            }

            if (type == FinancialEntryType.OrderDealtFrozenOut
                || type == FinancialEntryType.OrderDealtIn
                || type == FinancialEntryType.OpenLong
                || type == FinancialEntryType.OpenShort
                || type == FinancialEntryType.CloseLong
                || type == FinancialEntryType.CloseShort
                || type == FinancialEntryType.MarginOpenLong
                || type == FinancialEntryType.MarginOpenShort
                || type == FinancialEntryType.MarinBuyDeal
                || type == FinancialEntryType.MarinSellDeal
                || type == FinancialEntryType.BuyDeal
                || type == FinancialEntryType.SellDeal)
            {
                return SharedLedgerEntryType.Trade;
            }

            if (type == FinancialEntryType.ContractMainSettleFeeUserIn
                || type == FinancialEntryType.ContractMainSettleFeeUserOut
                || type == FinancialEntryType.MarginSettleFeeUserIn
                || type == FinancialEntryType.MarginSettleFeeUserOut)
            {
                return SharedLedgerEntryType.FundingFee;
            }

            if (type == FinancialEntryType.LiqFee)
            {
                return SharedLedgerEntryType.Fee;
            }

            return SharedLedgerEntryType.Unknown;
        }

        #endregion

    }
}
