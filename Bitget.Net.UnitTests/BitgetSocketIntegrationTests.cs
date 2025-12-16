using Bitget.Net.Clients;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Bitget.Net.UnitTests
{
    [NonParallelizable]
    internal class BitgetSocketIntegrationTests : SocketIntegrationTest<BitgetSocketClient>
    {
        public override bool Run { get; set; } = false;

        public override BitgetSocketClient GetClient(ILoggerFactory loggerFactory, bool useUpdatedDeserialization)
        {
            var key = Environment.GetEnvironmentVariable("APIKEY");
            var sec = Environment.GetEnvironmentVariable("APISECRET");
            var pass = Environment.GetEnvironmentVariable("APIPASS");

            Authenticated = key != null && sec != null;
            return new BitgetSocketClient(Options.Create(new BitgetSocketOptions
            {
                OutputOriginalData = true,
                UseUpdatedDeserialization = useUpdatedDeserialization,
                ApiCredentials = Authenticated ? new CryptoExchange.Net.Authentication.ApiCredentials(key, sec, pass) : null
            }), loggerFactory);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task TestSubscriptions(bool useUpdatedDeserialization)
        {
            await RunAndCheckUpdate<BitgetTickerUpdate>(useUpdatedDeserialization , (client, updateHandler) => client.SpotApiV2.SubscribeToBalanceUpdatesAsync(default , default), false, true);
            await RunAndCheckUpdate<BitgetTickerUpdate[]>(useUpdatedDeserialization, (client, updateHandler) => client.SpotApiV2.SubscribeToTickerUpdatesAsync("ETHUSDT", updateHandler, default), true, false);

            await RunAndCheckUpdate<BitgetTickerUpdate>(useUpdatedDeserialization, (client, updateHandler) => client.FuturesApiV2.SubscribeToBalanceUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, default, default), false, true);
            await RunAndCheckUpdate<BitgetFuturesTickerUpdate[]>(useUpdatedDeserialization, (client, updateHandler) => client.FuturesApiV2.SubscribeToTickerUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "ETHUSDT", updateHandler, default), true, false);
        } 
    }
}
