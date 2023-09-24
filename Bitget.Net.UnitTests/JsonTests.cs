using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Authentication;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects;

namespace Bitget.Net.UnitTests
{
    [TestFixture]
    public class JsonTests
    {
        private JsonToObjectComparer<IBitgetRestClient> _comparer = new JsonToObjectComparer<IBitgetRestClient>((json) => TestHelpers.CreateResponseClient(json, options =>
        {
            options.ApiCredentials = new BitgetApiCredentials("123", "123", "123");
            options.SpotOptions.RateLimiters = new List<IRateLimiter>();
            options.SpotOptions.AutoTimestamp = false;
        }));

        [Test]
        public async Task ValidateSpotExchangeDataCalls()
        {
            await _comparer.ProcessSubject(
                "Spot/ExchangeData",
                c => c.SpotApi.ExchangeData, useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetNotificationsAsync", "data" },
                    { "GetAssetsAsync", "data" },
                    { "GetSymbolsAsync", "data" },
                    { "GetTickerAsync", "data" },
                    { "GetTickersAsync", "data" },
                    { "GetRecentTradesAsync", "data" },
                    { "GetTradesAsync", "data" },
                    { "GetKlinesAsync", "data" },
                    { "GetOrderBookAsync", "data" },
                    { "GetFeeRatesAsync", "data" },
                });
        }

        [Test]
        public async Task ValidateSpotAccountCalls()
        {
            await _comparer.ProcessSubject(
                "Spot/Account",
                c => c.SpotApi.Account, useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "GetBalancesAsync", "data" },
                    { "GetApiKeyInfoAsync", "data" },
                    { "GetBillsAsync", "data" },
                    { "GetTransferHistoryAsync", "data" },
                    { "GetDepositAddressAsync", "data" },
                    { "WithdrawAsync", "data" },
                    { "TransferAsync", "data" },
                    { "InnerWithdrawAsync", "data" },
                    { "GetWithdrawalHistoryAsync", "data" },
                    { "GetDepositHistoryAsync", "data" },
                });
        }

        [Test]
        public async Task ValidateSpotTradingCalls()
        {
            await _comparer.ProcessSubject(
                "Spot/Trading",
                c => c.SpotApi.Trading, useNestedJsonPropertyForCompare: new Dictionary<string, string>
                {
                    { "PlaceOrderAsync", "data" },
                    { "CancelOrderAsync", "data" },
                });
        }
    }
}
