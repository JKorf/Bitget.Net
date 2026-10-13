using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Interfaces.Clients.UnifiedApi;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.UnifiedApi
{
    internal partial class BitgetRestClientUnifiedSharedApi :
        SharedApiBase,
        IBitgetRestClientUnifiedSharedApi
    {
        private readonly BitgetRestClientUnifiedApi _api;

        private const string _topicSpotId = "BitgetUnifiedSpot";
        private const string _topicFuturesId = "BitgetUnifiedFutures";
        private const string _exchangeName = "Bitget";

        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);
        private static HashSet<string> _exchangeSupportedFiatCurrencies = ["EUR", "USD", "BRL"];

        public BitgetRestClientUnifiedSharedApi(BitgetRestClientUnifiedApi api)
            : base(
                  SharedTransport.Rest,
                  api,
                  new[] { TradingMode.Spot, TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                GetTickerOptions,
                GetAllTickersOptions,
                GetBalancesOptions,
                GetDepositAddressesOptions,
                GetDepositHistoryOptions,
                GetFeeOptions,
                GetFundingInfoOptions,
                GetFundingRateHistoryOptions,
                GetIndexPriceOptions,
                GetAllIndexPricesOptions,
                GetMarkPriceOptions,
                GetAllMarkPricesOptions,
                GetKlinesOptions,
                GetMarkPriceKlinesOptions,
                GetIndexPriceKlinesOptions,
                GetLedgerOptions,
                GetLeverageOptions,
                SetLeverageOptions,
                GetOpenInterestOptions,
                GetBookTickerOptions,
                GetOrderBookOptions,
                GetPositionModeOptions,
                SetPositionModeOptions,
                GetFuturesSymbolsOptions,
                GetSpotSymbolsOptions,
                GetRecentTradesOptions,
                WithdrawOptions,

                PlaceSpotOrderOptions,
                GetSpotOrderOptions,
                GetSpotOrderByClientOrderIdOptions,
                GetOpenSpotOrdersOptions,
                GetClosedSpotOrdersOptions,
                GetSpotUserTradeHistoryOptions,
                GetSpotOrderTradesOptions,
                CancelSpotOrderOptions,
                CancelSpotOrderByClientOrderIdOptions,
                CancelAllSpotOrdersOptions,
                CancelAllSpotSymbolOrdersOptions,
                EditSpotOrderOptions,
                EditSpotOrderByClientOrderIdOptions,

                PlaceFuturesOrderOptions,
                GetFuturesOrderOptions,
                GetFuturesOrderByClientOrderIdOptions,
                GetOpenFuturesOrdersOptions,
                GetClosedFuturesOrdersOptions,
                GetFuturesUserTradeHistoryOptions,
                GetFuturesOrderTradesOptions,
                CancelFuturesOrderOptions,
                CancelFuturesOrderByClientOrderIdOptions,
                CancelAllFuturesOrdersOptions,
                CancelAllFuturesSymbolOrdersOptions,
                EditFuturesOrderOptions,
                EditFuturesOrderByClientOrderIdOptions,
                CloseFullPositionOptions,
                GetPositionHistoryOptions,
                GetPositionsOptions
                );
        }

        private ProductCategory GetCategory(SharedRequest request)
        {
            if (request.TradingMode == TradingMode.Spot)
                return ProductCategory.Spot;

            var category = request.GetParamValue<ProductCategory?>(Exchange, "ProductCategory");
            return category ?? ProductCategory.UsdtFutures;
        }
    }
}
