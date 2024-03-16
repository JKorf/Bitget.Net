using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Bitget.Net.Clients;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.JsonNet;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Bitget.Net.UnitTests
{
    internal class JsonSocketTests
    {
        [Test]
        public async Task ValidateTickerUpdateStreamJson()
        {
            await TestFileToObject<BitgetTickerUpdate>(@"JsonResponses/Spot/Socket/TickerUpdate.txt");
        }

        [Test]
        public async Task ValidateBalanceUpdateStreamJson()
        {
            await TestFileToObject<IEnumerable<BitgetBalanceUpdate>>(@"JsonResponses/Spot/Socket/BalanceUpdate.txt");
        }

        [Test]
        public async Task ValidateOrderUpdateStreamJson()
        {
            await TestFileToObject<BitgetOrderUpdate>(@"JsonResponses/Spot/Socket/OrderUpdate.txt");
        }

        [Test]
        public async Task ValidateFuturesTickerUpdateStreamJson()
        {
            await TestFileToObject<BitgetFuturesTickerUpdate>(@"JsonResponses/Futures/Socket/TickerUpdate.txt");
        }

        private static async Task TestFileToObject<T>(string filePath, List<string> ignoreProperties = null)
        {
            var listener = new EnumValueTraceListener();
            Trace.Listeners.Add(listener);
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string json;
            try
            {
                var file = File.OpenRead(Path.Combine(path, filePath));
                using var reader = new StreamReader(file);
                json = await reader.ReadToEndAsync();
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            var result = JsonConvert.DeserializeObject<T>(json, SerializerOptions.WithConverters);
            JsonToObjectComparer<IBitgetSocketClient>.ProcessData("", result, json, ignoreProperties: new Dictionary<string, List<string>>
            {
                { "", ignoreProperties ?? new List<string>() }
            });
            Trace.Listeners.Remove(listener);
        }
    }
}
