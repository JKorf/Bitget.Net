using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bitget.Net.UnitTests
{
    [TestFixture()]
    public class BitgetClientTests
    {
        [Test]
        public void CheckInterfaces()
        {
            CryptoExchange.Net.Testing.TestHelpers.CheckForMissingRestInterfaces<BitgetRestClient>();
            CryptoExchange.Net.Testing.TestHelpers.CheckForMissingSocketInterfaces<BitgetSocketClient>();

        }

        [TestCase()]
        public async Task ReceivingError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            var resultObj = new BitgetResponse()
            {
                Code = 400001,
                Message = "Error occured"
            };

            TestHelpers.SetResponse((BitgetRestClient)client, JsonSerializer.Serialize(resultObj, SerializerOptions.WithConverters(BitgetExchange._serializerContext)));

            // act
            var result = await client.SpotApiV2.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.ErrorCode == "400001");
            Assert.That(result.Error.Message == "Error occured");
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithNoJson_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            TestHelpers.SetResponse((BitgetRestClient)client, "", System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.SpotApiV2.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithJsonError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            var resultObj = new BitgetResponse<string[]>()
            {
                Code = 400001,
                Message = "Error occurred"
            };

            TestHelpers.SetResponse((BitgetRestClient)client, "{\"code\": \"400001\", \"msg\": \"Error occurred\"}", System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.SpotApiV2.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.ErrorCode == "400001");
            Assert.That(result.Error.Message == "Error occurred");
        }

        [Test]
        [TestCase(TradeEnvironmentNames.Live, "https://api.bitget.com")]
        [TestCase("", "https://api.bitget.com")]
        public void TestConstructorEnvironments(string environmentName, string expected)
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bitget:Environment:Name", environmentName },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBitget(configuration.GetSection("Bitget"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBitgetRestClient>();

            var address = client.SpotApiV2.BaseAddress;

            Assert.That(address, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructorNullEnvironment()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bitget", null },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBitget(configuration.GetSection("Bitget"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBitgetRestClient>();

            var address = client.SpotApiV2.BaseAddress;

            Assert.That(address, Is.EqualTo("https://api.bitget.com"));
        }

        [Test]
        public void TestConstructorApiOverwriteEnvironment()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "Bitget:Environment:Name", "test" },
                    { "Bitget:Rest:Environment:Name", "live" },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBitget(configuration.GetSection("Bitget"));
            var provider = collection.BuildServiceProvider();

            var client = provider.GetRequiredService<IBitgetRestClient>();

            var address = client.SpotApiV2.BaseAddress;

            Assert.That(address, Is.EqualTo("https://api.bitget.com"));
        }

        [Test]
        public void TestConstructorConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ApiCredentials:Key", "123" },
                    { "ApiCredentials:Secret", "456" },
                    { "ApiCredentials:Pass", "000" },
                    { "Socket:ApiCredentials:Key", "456" },
                    { "Socket:ApiCredentials:Secret", "789" },
                    { "Socket:ApiCredentials:Pass", "xxx" },
                    { "Rest:OutputOriginalData", "true" },
                    { "Socket:OutputOriginalData", "false" },
                    { "Rest:Proxy:Host", "host" },
                    { "Rest:Proxy:Port", "80" },
                    { "Socket:Proxy:Host", "host2" },
                    { "Socket:Proxy:Port", "81" },
                }).Build();

            var collection = new ServiceCollection();
            collection.AddBitget(configuration);
            var provider = collection.BuildServiceProvider();

            var restClient = provider.GetRequiredService<IBitgetRestClient>();
            var socketClient = provider.GetRequiredService<IBitgetSocketClient>();

            Assert.That(((BaseApiClient)restClient.SpotApiV2).OutputOriginalData, Is.True);
            Assert.That(((BaseApiClient)socketClient.SpotApiV2).OutputOriginalData, Is.False);
            Assert.That(((BaseApiClient)restClient.SpotApiV2).AuthenticationProvider.ApiKey, Is.EqualTo("123"));
            Assert.That(((BaseApiClient)socketClient.SpotApiV2).AuthenticationProvider.ApiKey, Is.EqualTo("456"));
            Assert.That(((BaseApiClient)restClient.SpotApiV2).ClientOptions.Proxy.Host, Is.EqualTo("host"));
            Assert.That(((BaseApiClient)restClient.SpotApiV2).ClientOptions.Proxy.Port, Is.EqualTo(80));
            Assert.That(((BaseApiClient)socketClient.SpotApiV2).ClientOptions.Proxy.Host, Is.EqualTo("host2"));
            Assert.That(((BaseApiClient)socketClient.SpotApiV2).ClientOptions.Proxy.Port, Is.EqualTo(81));
        }
    }
}
