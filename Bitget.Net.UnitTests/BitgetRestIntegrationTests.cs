using Bitget.Net.Clients;
using Bitget.Net.Objects;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitget.Net.UnitTests
{
    [NonParallelizable]
    internal class BitgetRestIntegrationTests : RestIntergrationTest<BitgetRestClient>
    {
        public override bool Run { get; set; }

        public BitgetRestIntegrationTests()
        {
        }

        public override BitgetRestClient GetClient(ILoggerFactory loggerFactory)
        {
            var key = Environment.GetEnvironmentVariable("APIKEY");
            var sec = Environment.GetEnvironmentVariable("APISECRET");
            var pass = Environment.GetEnvironmentVariable("APIPASS");

            Authenticated = key != null && sec != null;
            return new BitgetRestClient(null, loggerFactory, opts =>
            {
                opts.OutputOriginalData = true;
                opts.ApiCredentials = Authenticated ? new BitgetApiCredentials(key, sec, pass) : null;
            });
        }

        [Test]
        public async Task TestErrorResponseParsing()
        {
            if (!ShouldRun())
                return;

            var result = await CreateClient().SpotApi.ExchangeData.GetOrderBookAsync("TSTTST", default);

            Assert.That(result.Success, Is.False);
            Assert.That(result.Error.Code, Is.EqualTo(40034));
        }

        [Test]
        public async Task TestSpotAccount()
        {
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetFundingBalancesAsync(default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetAssetsValuationAsync(default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetTradeFeeAsync("ETHUSDT", Enums.BitgetBusinessType.Spot, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetAccountInfoAsync(default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetSpotBalancesAsync(default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetLedgerAsync(default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetTransferableAssetsAsync(Enums.V2.TransferAccountType.UsdcFutures, Enums.V2.TransferAccountType.UsdtFutures, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetTransferHistoryAsync("ETH", Enums.V2.TransferAccountType.Spot, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetBgbDeductEnabledAsync(default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetWithdrawalHistoryAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Account.GetDepositHistoryAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, default, default, default, default, default), true);
        }

        [Test]
        public async Task TestSpotExchangeData()
        {
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetServerTimeAsync(default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetAssetsAsync(default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetSymbolsAsync(default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetVipFeeRatesAsync(default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetTickersAsync(default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetOrderBookAsync("ETHUSDT", default, default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetKlinesAsync("ETHUSDT", Enums.V2.KlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetHistoricalKlinesAsync("ETHUSDT", Enums.V2.KlineInterval.OneDay, DateTime.UtcNow, default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetRecentTradesAsync("ETHUSDT", default, default), false);
            await RunAndCheckResult(client => client.SpotApiV2.ExchangeData.GetTradesAsync("ETHUSDT", default, default, default, default, default), false);
        }

        [Test]
        public async Task TestSpotTrading()
        {
            await RunAndCheckResult(client => client.SpotApiV2.Trading.GetOpenOrdersAsync(default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Trading.GetClosedOrdersAsync(default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Trading.GetUserTradesAsync("ETHUSDT", default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Trading.GetOpenTriggerOrdersAsync("ETHUSDT", default, default, default, default, default), true);
            await RunAndCheckResult(client => client.SpotApiV2.Trading.GetClosedTriggerOrdersAsync("ETHUSDT", DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddHours(-1), default, default), true);
        }

        [Test]
        public async Task TestFuturesAccount()
        {
            await RunAndCheckResult(client => client.FuturesApiV2.Account.GetBalanceAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Account.GetBalancesAsync(Enums.BitgetProductTypeV2.UsdtFutures, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Account.GetLedgerAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default, default, default, default, default, default), true);
        }

        [Test]
        public async Task TestFuturesExchangeData()
        {
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetServerTimeAsync(default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetContractsAsync(Enums.BitgetProductTypeV2.UsdcFutures, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetVipFeeRatesAsync(default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetOrderBookAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetTickerAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetTickersAsync(Enums.BitgetProductTypeV2.UsdtFutures, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetRecentTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default, default, default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.OneDay, default, default, default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetHistoricalKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetHistoricalIndexPriceKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetHistoricalMarkPriceKlinesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", Enums.BitgetFuturesKlineInterval.OneDay, default, default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetOpenInterestAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetNextFundingTimeAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetPricesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetHistoricalFundingRateAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default, default, default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetFundingRateAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
            await RunAndCheckResult(client => client.FuturesApiV2.ExchangeData.GetPositionTiersAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", default), false);
        }

        [Test]
        public async Task TestFuturesTrading()
        {
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetPositionAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", "USDT", default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetPositionsAsync(Enums.BitgetProductTypeV2.UsdtFutures, "USDT", default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetPositionHistoryAsync(default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetOpenOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetClosedOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetUserTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetHistoricalUserTradesAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetOpenTriggerOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, Enums.BitgetFuturesPlanType.NormalPlan, default, default, default, default, default, default, default, default), true);
            await RunAndCheckResult(client => client.FuturesApiV2.Trading.GetClosedTriggerOrdersAsync(Enums.BitgetProductTypeV2.UsdtFutures, Enums.BitgetFuturesPlanType.NormalPlan, default, default, default, default, default, default, default, default), true);
        }
    }
}
