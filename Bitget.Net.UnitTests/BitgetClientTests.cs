using Bitget.Net.Clients;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
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

            TestHelpers.SetResponse((BitgetRestClient)client, JsonConvert.SerializeObject(resultObj));

            // act
            var result = await client.SpotApi.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.Code == 400001);
            Assert.That(result.Error.Message == "Error occured");
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithNoJson_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            TestHelpers.SetResponse((BitgetRestClient)client, "", System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.SpotApi.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
        }

        [TestCase()]
        public async Task ReceivingHttpErrorWithJsonError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = TestHelpers.CreateClient();
            var resultObj = new BitgetResponse<object>()
            {
                Code = 400001,
                Message = "Error occured"
            };

            TestHelpers.SetResponse((BitgetRestClient)client, JsonConvert.SerializeObject(resultObj), System.Net.HttpStatusCode.BadRequest);

            // act
            var result = await client.SpotApi.ExchangeData.GetAssetsAsync();

            // assert
            ClassicAssert.IsFalse(result.Success);
            ClassicAssert.IsNotNull(result.Error);
            Assert.That(result.Error!.Code == 400001);
            Assert.That(result.Error.Message == "Error occured");
        }
    }
}
