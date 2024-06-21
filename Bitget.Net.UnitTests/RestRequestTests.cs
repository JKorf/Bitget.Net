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
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetKlinesAsync("ETHUSDT", Enums.BitgetKlineInterval.OneDay), "GetKlines");
            await tester.ValidateAsync(client => client.SpotApiV2.ExchangeData.GetHistoricalKlinesAsync("ETHUSDT", Enums.BitgetKlineInterval.OneDay), "GetHistoricalKlines");
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


        private bool IsAuthenticated(WebCallResult result)
        {
            return result.RequestHeaders.Any(x => x.Key == "ACCESS-SIGN");
        }
    }
}
