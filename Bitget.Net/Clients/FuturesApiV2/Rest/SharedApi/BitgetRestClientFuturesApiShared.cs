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
    internal partial class BitgetRestClientFuturesSharedApi : 
        SharedApiBase,
        IBitgetRestClientFuturesApiShared,
        IBitgetRestClientFuturesSharedApi
    {
        private readonly BitgetRestClientFuturesApi _api;

        private const string _topicId = "BitgetFutures";
        private const string _exchangeName = "Bitget";
        public override SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);

        public BitgetRestClientFuturesSharedApi(BitgetRestClientFuturesApi api)
            : base(
                  SharedTransport.Rest,
                  api.Exchange,
                  new[] { TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse },
                  () => api.Authenticated,
                  api.FormatSymbol)
        {
            _api = api;

            SetCapabilities(
                GetBalancesOptions,
                GetFuturesTickerOptions,
                GetAllFuturesTickersOptions,
                GetBookTickerOptions,
                GetFuturesSymbolsOptions,
                GetKlinesOptions,
                GetRecentTradesOptions,
                GetLeverageOptions,
                SetLeverageOptions,
                GetMarkPriceKlinesOptions,
                GetIndexPriceKlinesOptions,
                GetOrderBookOptions,
                GetOpenInterestOptions,
                GetFundingRateHistoryOptions,
                PlaceFuturesOrderOptions,
                GetFuturesOrderOptions,
                GetOpenFuturesOrdersOptions,
                GetClosedFuturesOrdersOptions,
                GetFuturesOrderTradesOptions,
                GetFuturesUserTradeHistoryOptions,
                CancelFuturesOrderOptions,
                GetPositionsOptions,
                ClosePositionOptions,
                GetFuturesOrderByClientOrderIdOptions,
                CancelFuturesOrderByClientOrderIdOptions,
                GetPositionModeOptions,
                SetPositionModeOptions,
                GetPositionHistoryOptions,
                GetFeeOptions,
                PlaceFuturesTriggerOrderOptions,
                GetFuturesTriggerOrderOptions,
                CancelFuturesTriggerOrderOptions,
                SetFuturesTpSlOptions,
                CancelFuturesTpSlOptions
                );
        }

        private BitgetProductTypeV2 GetProductType(TradingMode? tradingMode, ExchangeParameters? exchangeParameters)
        {
            if (tradingMode == TradingMode.PerpetualInverse || tradingMode == TradingMode.DeliveryInverse)
            {
                return BitgetProductTypeV2.CoinFutures;
            }

            var productTypeStr = ExchangeParameters.GetValue<string>(exchangeParameters, Exchange, "ProductType");
            return (BitgetProductTypeV2)Enum.Parse(typeof(BitgetProductTypeV2), productTypeStr!);
        }

        private ProductCategory GetProductCategory(TradingMode? tradingMode, ExchangeParameters? exchangeParameters)
        {
            var productType = GetProductType(tradingMode, exchangeParameters);
            if (productType == BitgetProductTypeV2.CoinFutures)
                return ProductCategory.CoinFutures;
            else if(productType == BitgetProductTypeV2.UsdtFutures)
                return ProductCategory.UsdtFutures;
            else if (productType == BitgetProductTypeV2.UsdcFutures)
                return ProductCategory.UsdcFutures;

            throw new ArgumentException("ProductType", $"Invalid product type {productType} for futures");
        }
    }
}
