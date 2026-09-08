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
    internal partial class BitgetRestClientSpotSharedApi :
        SharedApiBase,
        IBitgetRestClientSpotApiShared,
        IBitgetRestClientSpotSharedApi
    {
        private readonly BitgetRestClientSpotApi _api;

        private const string _topicId = "BitgetSpot";
        private const string _exchangeName = "Bitget";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);
        private static HashSet<string> _exchangeSupportedFiatCurrencies = ["EUR", "USD", "BRL"];

        public BitgetRestClientSpotSharedApi(BitgetRestClientSpotApi api)
            : base(
                  SharedTransport.Rest,
                  api.Exchange,
                  new[] { TradingMode.Spot },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                GetKlinesOptions,
                GetSpotSymbolsOptions,
                GetTickerOptions,
                GetAllTickersOptions,
                GetBookTickerOptions,
                GetRecentTradesOptions,
                GetBalancesOptions,
                PlaceSpotOrderOptions,
                GetSpotOrderOptions,
                GetOpenSpotOrdersOptions,
                GetClosedSpotOrdersOptions,
                GetSpotOrderTradesOptions,
                GetSpotUserTradeHistoryOptions,
                CancelSpotOrderOptions,
                GetSpotOrderByClientOrderIdOptions,
                CancelSpotOrderByClientOrderIdOptions,
                GetAssetOptions,
                GetAllAssetsOptions,
                GetDepositAddressesOptions,
                GetDepositHistoryOptions,
                GetOrderBookOptions,
                GetTradeHistoryOptions,
                GetWithdrawalHistoryOptions,
                GetFeeOptions,
                PlaceSpotTriggerOrderOptions,
                GetSpotTriggerOrderOptions,
                CancelSpotTriggerOrderOptions,
                TransferOptions,
                WithdrawOptions
                );
        }
    }
}
