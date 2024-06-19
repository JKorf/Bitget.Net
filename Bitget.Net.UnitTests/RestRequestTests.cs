using Bitget.Net.Clients;
using Bitget.Net.Objects;
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
            await tester.ValidateAsync(client => client.SpotApiV2.Account.WithdrawAsync("ETH", Enums.V2.TransferType.OnChain, "123", 1), "Withdraw");

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
            
        }


        private bool IsAuthenticated(WebCallResult result)
        {
            return result.RequestHeaders.Any(x => x.Key == "ACCESS-SIGN");
        }
    }
}
