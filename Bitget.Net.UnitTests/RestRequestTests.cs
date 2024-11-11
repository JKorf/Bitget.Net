using Bitget.Net.Clients;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitget.Net.UnitTests
{
    [TestFixture]
    public class RestRequestTests
    {
        [Test]
        public async Task ValidateSpotAccountCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Spot/Account", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetAssetsValuationAsync(), "GetAssetsValuation");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetFundingBalancesAsync(), "GetFundingBalances");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetTradeFeeAsync("ETHUSDT", Enums.BitgetBusinessType.Spot), "GetTradeFee");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetAccountInfoAsync(), "GetAccountInfo");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetSpotBalancesAsync(), "GetSpotBalances");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.SetDepositAccountAsync("ETH", Enums.V2.AccountType.Spot), "SetDepositAccount");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetLedgerAsync(), "GetLedger");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.TransferAsync("ETH", Enums.V2.TransferAccountType.UsdcFutures, Enums.V2.TransferAccountType.CoinFutures, 1), "Transfer");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetTransferableAssetsAsync(Enums.V2.TransferAccountType.Spot, Enums.V2.TransferAccountType.Spot), "GetTransferableAssets");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.WithdrawAsync("ETH", Enums.V2.TransferType.OnChain, "123", 1), "Withdraw");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetTransferHistoryAsync("ETH", Enums.V2.TransferAccountType.Spot), "GetTransferRecords");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.SetBgbDeductEnabledAsync(true), "SetBgbDeductEnabled");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetDepositAddressAsync("ETH"), "GetDepositAddress");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetBgbDeductEnabledAsync(), "GetBgbDeductEnabled", ignoreProperties: new List<string> { "deduct" });
            await tester.ValidateAsync(client => client.SpotApiV2.Account.CancelWithdrawalAsync("123"), "CancelWithdrawal");
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetWithdrawalHistoryAsync(DateTime.UtcNow, DateTime.UtcNow), "GetWithdrawalHistory", ignoreProperties: new List<string> { "type" });
            await tester.ValidateAsync(client => client.SpotApiV2.Account.GetDepositHistoryAsync(DateTime.UtcNow, DateTime.UtcNow), "GetDepositHistory", ignoreProperties: new List<string> { "type" });

        }

        [Test]
        public async Task ValidateSpotMarginCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Spot/Margin", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetMarginSymbolsAsync(), "GetMarginSymbols", nestedJsonProperty: "data", ignoreProperties: new List<string> { "isBorrowable" });
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossBorrowHistoryAsync(), "GetCrossBorrowHistory", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossRepayHistoryAsync(), "GetCrossRepayHistory", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossInterestHistoryAsync(), "GetCrossInterestHistory", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossLiquidationHistoryAsync(), "GetCrossLiquidationHistory", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossFinancialHistoryAsync(), "GetCrossFinancialHistory", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossBalancesAsync(), "GetCrossBalances", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.CrossBorrowAsync("123", 0.1m, "123"), "CrossBorrow", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.CrossRepayAsync("123", 0.1m), "CrossRepay", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossRiskRateAsync(), "GetCrossRiskRate", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossMaxBorrowableAsync("123"), "GetCrossMaxBorrowable", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossMaxTransferableAsync("123"), "GetCrossMaxTransferable", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossInterestAndLimitAsync("123"), "GetCrossInterestAndLimit", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossTierConfigAsync("123"), "GetCrossTierConfig", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.CrossFlashRepayAsync(), "CrossFlashRepay", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossFlashRepayStatusAsync("123"), "GetCrossFlashRepayStatus", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.PlaceCrossOrderAsync("123", LoanType.Normal, OrderSide.Buy, OrderType.Limit, TimeInForce.PostOnly), "PlaceCrossOrder", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.CancelCrossOrderAsync("123"), "CancelCrossOrder", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossOpenOrdersAsync("123"), "GetCrossOpenOrders", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossClosedOrdersAsync("123"), "GetCrossClosedOrders", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossUserTradesAsync("123"), "GetCrossUserTrades", nestedJsonProperty: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Margin.GetCrossLiquidationOrdersAsync(), "GetCrossLiquidationOrders", nestedJsonProperty: "data.resultList");
        }

        [Test]
        public async Task ValidateSpotExchangeDataCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Spot/ExchangeData", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetServerTimeAsync(), "GetServerTime", "data.serverTime");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetAssetsAsync(), "GetAssets");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetSymbolsAsync(), "GetSymbols");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetVipFeeRatesAsync(), "GetVipFeeRates");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetTickersAsync(), "GetTickers");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetOrderBookAsync("ETHUSDT"), "GetOrderBook");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetKlinesAsync("ETHUSDT", KlineInterval.OneDay), "GetKlines");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetHistoricalKlinesAsync("ETHUSDT", KlineInterval.OneDay, DateTime.UtcNow), "GetHistoricalKlines");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetRecentTradesAsync("ETHUSDT"), "GetRecentTrades");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetTradesAsync("ETHUSDT"), "GetTrades");

        }

        [Test]
        public async Task ValidateSpotTradingCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Spot/Trading", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.PlaceOrderAsync("ETHUSDT", Enums.V2.OrderSide.Buy, Enums.V2.OrderType.Market, 1, Enums.V2.TimeInForce.FillOrKill), "PlaceOrder");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.CancelOrderAsync("ETHUSDT", "123"), "CancelOrder");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.CancelOrdersBySymbolAsync("ETHUSDT"), "CancelOrdersBySymbol");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetOrderAsync("ETHUSDT", "123"), "GetOrder", ignoreProperties: new List<string> { "feeDetail" });
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetOpenOrdersAsync("ETHUSDT"), "GetOpenOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetClosedOrdersAsync("ETHUSDT"), "GetClosedOrders", ignoreProperties: new List<string> { "feeDetail" });
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetUserTradesAsync("ETHUSDT"), "GetUserTrades", ignoreProperties: new List<string> { "deduction" });
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.PlaceMultipleOrdersAsync("ETHUSDT", new[] { new BitgetPlaceOrderRequest() }), "PlaceMultipleOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.CancelMultipleOrdersAsync("ETHUSDT", new[] { new BitgetCancelOrderRequest() }), "CancelMultipleOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.PlaceTriggerOrderAsync("ETHUSDT", OrderSide.Sell, OrderType.Market, 1, 1), "PlaceTriggerOrder");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.EditTriggerOrderAsync(1, OrderType.Market, 1), "EditTriggerOrder");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.CancelTriggerOrderAsync("12"), "CancelTriggerOrder");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetOpenTriggerOrdersAsync("ETHUSDT"), "GetOpenTriggerOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetClosedTriggerOrdersAsync("ETHUSDT", DateTime.UtcNow, DateTime.UtcNow), "GetClosedTriggerOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.CancelAllTriggerOrdersAsync(), "CancelAllTriggerOrders");
            await tester.ValidateAsync(client => client.SpotApiV2.Trading.GetTriggerSubOrdersAsync("123"), "GetTriggerSubOrders");

        }

        [Test]
        public async Task ValidateFuturesAccountCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Futures/Account", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.GetBalancesAsync(Enums.BitgetProductTypeV2.UsdtFutures), "GetBalances");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.GetBalanceAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT"), "GetBalance");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.SetLeverageAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", 10), "SetLeverage");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.AdjustMarginAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", 10), "AdjustMargin");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.SetMarginModeAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", MarginMode.IsolatedMargin), "SetMarginMode");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.SetPositionModeAsync(Enums.BitgetProductTypeV2.UsdtFutures, PositionMode.OneWay), "SetPositionMode");
            await tester.ValidateAsync(client => client.FuturesApiV2.Account.GetLedgerAsync(Enums.BitgetProductTypeV2.UsdtFutures), "GetLedger");
        }

        [Test]
        public async Task ValidateFuturesExchangeDataCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Futures/ExchangeData", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetContractsAsync(Enums.BitgetProductTypeV2.UsdtFutures), "GetContracts");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetVipFeeRatesAsync(), "GetVipFeeRates");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetOrderBookAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetOrderBook", ignoreProperties: new List<string> { "isMaxPrecision" });
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetTickerAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetTicker", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetTickersAsync(Enums.BitgetProductTypeV2.UsdtFutures), "GetTickers");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetRecentTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetRecentTrades");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetTrades");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.TwelveHours), "GetKlines");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetHistoricalKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.TwelveHours), "GetHistoricalKlines");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetHistoricalIndexPriceKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.TwelveHours), "GetHistoricalIndexPriceKlines");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetHistoricalMarkPriceKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.TwelveHours), "GetHistoricalMarkPriceKlines");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetOpenInterestAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetOpenInterest", nestedJsonProperty: "data.openInterestList", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetNextFundingTimeAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetNextFundingTime", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetPricesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetPrices", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetHistoricalFundingRateAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetHistoricalFundingRate");
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetFundingRateAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetFundingRate", useSingleArrayItem: true);
            await tester.ValidateAsync(client => client.FuturesApiV2.ExchangeData.GetPositionTiersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetPositionTiers");
        }

        [Test]
        public async Task ValidateFuturesTradingCalls()
        {
            var client = new BitgetRestClient(opts =>
            {
                opts.AutoTimestamp = false;
                opts.ApiCredentials = new BitgetApiCredentials("123", "456", "789");
            });
            var tester = new RestRequestValidator<BitgetRestClient>(client, "Endpoints/Futures/Trading", "https://api.bitget.com", IsAuthenticated, stjCompare: true, nestedPropertyForCompare: "data");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetPositionAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT"), "GetPosition");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetPositionsAsync(Enums.BitgetProductTypeV2.UsdtFutures, "USDT"), "GetPositions");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetPositionHistoryAsync(Enums.BitgetProductTypeV2.UsdtFutures, "USDT"), "GetPositionHistory");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.PlaceOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", OrderSide.Sell, OrderType.Market, MarginMode.CrossMargin, 1), "PlaceOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.PlaceMultipleOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", MarginMode.IsolatedMargin, new[] { new BitgetFuturesPlaceOrderRequest() }), "PlaceMultipleOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.EditOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT"), "EditOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.CancelOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT"), "CancelOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.CancelMultipleOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, new[] { new BitgetCancelOrderRequest() }), "CancelMultipleOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.CancelAllOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures), "CancelAllOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetOrder", ignoreProperties: new List<string> { "reduceOnly" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetOpenOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetOpenOrders", ignoreProperties: new List<string> { "reduceOnly" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetOpenOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetOpenOrders2", ignoreProperties: new List<string> { "reduceOnly" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetClosedOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetClosedOrders", ignoreProperties: new List<string> { "reduceOnly" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetUserTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetUserTrades", ignoreProperties: new List<string> { "deduction" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetHistoricalUserTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "GetHistoricalUserTrades", ignoreProperties: new List<string> { "deduction" });
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.ClosePositionsAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT"), "ClosePosition");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.PlaceTpSlOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", PlanType.TailingStop, 1, 1, oneWaySide: OrderSide.Buy), "PlaceTpSlOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.PlaceTriggerOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", TriggerPlanType.Normal, MarginMode.CrossMargin, OrderSide.Buy, OrderType.Market, 1, 1), "PlaceTriggerOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetTriggerSubOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "1", TriggerPlanType.Normal), "GetTriggerSubOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.EditTriggerOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures), "EditTriggerOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.EditTpSlOrderAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT"), "EditTpSlOrder");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetOpenTriggerOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, TriggerPlanTypeFilter.Trigger), "GetOpenTriggerOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.GetClosedTriggerOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, TriggerPlanTypeFilter.Trigger), "GetClosedTriggerOrders");
            await tester.ValidateAsync(client => client.FuturesApiV2.Trading.CancelTriggerOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, CancelTriggerPlanTypeFilter.Trigger), "CancelTriggerOrders");
        }

        private bool IsAuthenticated(WebCallResult result)
        {
            return result.RequestHeaders.Any(x => x.Key == "ACCESS-SIGN");
        }
    }
}
