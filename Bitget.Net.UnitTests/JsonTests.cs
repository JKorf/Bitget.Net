using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Authentication;
using Bitget.Net.Interfaces.Clients;

namespace Bitget.Net.UnitTests
{
    [TestFixture]
    public class JsonTests
    {
        private JsonToObjectComparer<IBitgetRestClient> _comparer = new JsonToObjectComparer<IBitgetRestClient>((json) => TestHelpers.CreateResponseClient(json, options =>
        {
            options.ApiCredentials = new ApiCredentials("123", "123");
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
                });
        }

    }
}
