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
        #region Transfer

        public TransferOptions TransferOptions { get; } = new TransferOptions(_exchangeName, [
            SharedAccountType.Funding,
            SharedAccountType.Spot,
            SharedAccountType.PerpetualLinearFutures,
            SharedAccountType.PerpetualInverseFutures,
            SharedAccountType.DeliveryLinearFutures,
            SharedAccountType.DeliveryInverseFutures,
            SharedAccountType.CrossMargin,
            SharedAccountType.IsolatedMargin
            ])
        {
            ExchangeParameterRules = [
                ExchangeParameterRule.Required("ProductType", "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            ]
        };
        async Task<ICallResult<SharedId>> ITransfer.TransferAsync(TransferRequest request, CancellationToken ct)
            => await TransferAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedId>> TransferAsync(TransferRequest request, CancellationToken ct)
        {
            var validationError = TransferOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var productType = ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "ProductType")!;
            var fromAccount = GetTransferType(request.FromAccountType, productType);
            var toAccount = GetTransferType(request.ToAccountType, productType);
            if (fromAccount == null || toAccount == null)
                return HttpResult.Fail<SharedId>(Exchange, ArgumentError.Invalid("To/From AccountType", "invalid to/from account combination"));

            // Get data
            var transfer = await _api.Account.TransferAsync(
                request.Asset,
                fromAccount.Value,
                toAccount.Value,
                request.Quantity,
                ct: ct).ConfigureAwait(false);
            if (!transfer.Success)
                return HttpResult.Fail<SharedId>(transfer);

            return HttpResult.Ok(transfer, new SharedId(transfer.Data.TransferId));
        }

        #endregion

        private TransferAccountType? GetTransferType(SharedAccountType type, string productType)
        {
            if (type == SharedAccountType.Funding) return TransferAccountType.Funding;
            if (type == SharedAccountType.Spot) return TransferAccountType.Spot;
            if (type == SharedAccountType.CrossMargin) return TransferAccountType.CrossMargin;
            if (type == SharedAccountType.IsolatedMargin) return TransferAccountType.IsolatedMargin;
            if (type == SharedAccountType.PerpetualInverseFutures || type == SharedAccountType.DeliveryInverseFutures) return TransferAccountType.CoinFutures;
            if ((type == SharedAccountType.PerpetualLinearFutures || type == SharedAccountType.DeliveryLinearFutures) && productType == "UsdcFutures") return TransferAccountType.UsdcFutures;
            if ((type == SharedAccountType.PerpetualLinearFutures || type == SharedAccountType.DeliveryLinearFutures) && productType == "UsdtFutures") return TransferAccountType.UsdtFutures;
            return null;
        }

    }
}
