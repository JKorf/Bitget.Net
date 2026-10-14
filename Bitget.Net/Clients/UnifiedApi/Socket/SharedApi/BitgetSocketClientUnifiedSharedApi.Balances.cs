using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using static CryptoExchange.Net.SharedApis.SharedCapabilities;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetSocketClientUnifiedSharedApi
    {
        #region Subscribe To Balance Updates

        public SubscribeBalanceOptions SubscribeBalanceOptions { get; } = new SubscribeBalanceOptions(_exchangeName, true);
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(SubscribeBalancesRequest request, Action<DataEvent<SharedBalance[]>> handler, CancellationToken ct)
        {
            var validationError = SubscribeBalanceOptions.ValidateRequest(request, this);
            if (validationError != null)
                return WebSocketResult.Fail<UpdateSubscription>(_exchangeName, validationError);

            var result = await _api.SubscribeToAccountUpdatesAsync(
                update =>
                {
                    foreach (var item in update.Data)
                    {
                        handler(update.ToType(item.Asset.Select(x =>
                            new SharedBalance(SupportedTradingModes, x.Asset, x.Available, x.BalanceOriginal)
                                ).ToArray()));
                    }
                }
            , ct).ConfigureAwait(false);

            return result;         
        }

        #endregion

    }
}
