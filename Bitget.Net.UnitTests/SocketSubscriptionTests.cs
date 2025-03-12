using Bitget.Net.Clients;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Testing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitget.Net.UnitTests
{
    [TestFixture]
    public class SocketSubscriptionTests
    {
        [Test]
        public async Task ValidateSpotSubscriptions()
        {
            var client = new BitgetSocketClient(opts =>
            {
                opts.ApiCredentials = new ApiCredentials("123", "456", "789");
            });
            var tester = new SocketSubscriptionValidator<BitgetSocketClient>(client, "Subscriptions/Spot", "https://api.bitget.com", "data");
            await tester.ValidateAsync<BitgetTickerUpdate>((client, handler) => client.SpotApiV2.SubscribeToTickerUpdatesAsync("ETHUSDT", handler), "Ticker", useFirstUpdateItem: true);
            await tester.ValidateAsync<BitgetTradeUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToTradeUpdatesAsync("BTCUSDT", handler), "Trades");
            await tester.ValidateAsync<BitgetKlineUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToKlineUpdatesAsync("ETHUSDT", Enums.BitgetStreamKlineIntervalV2.OneWeek, handler), "Klines");
            await tester.ValidateAsync<BitgetOrderBookUpdate>((client, handler) => client.SpotApiV2.SubscribeToOrderBookUpdatesAsync("BTCUSDT", 5, handler), "OrderBook", useFirstUpdateItem: true);
            await tester.ValidateAsync<BitgetOrderUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToOrderUpdatesAsync(handler), "Order");
            await tester.ValidateAsync<BitgetUserTradeUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToUserTradeUpdatesAsync(handler), "UserTrade", ignoreProperties: new List<string> { "deduction" });
            await tester.ValidateAsync<BitgetTriggerOrderUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToTriggerOrderUpdatesAsync(handler), "TriggerOrder");
            await tester.ValidateAsync<BitgetBalanceUpdate[]>((client, handler) => client.SpotApiV2.SubscribeToBalanceUpdatesAsync(handler), "Balance");
        }

        [Test]
        public async Task ValidateFuturesSubscriptions()
        {
            var client = new BitgetSocketClient(opts =>
            {
                opts.ApiCredentials = new ApiCredentials("123", "456", "789");
            });
            var tester = new SocketSubscriptionValidator<BitgetSocketClient>(client, "Subscriptions/Futures", "https://api.bitget.com", "data");
            await tester.ValidateAsync<BitgetFuturesTickerUpdate>((client, handler) => client.FuturesApiV2.SubscribeToTickerUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "BTCUSDT", handler), "Ticker", useFirstUpdateItem: true, ignoreProperties: new List<string> { "symbol" });
            await tester.ValidateAsync<BitgetTradeUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToTradeUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "BTCUSDT", handler), "Trade");
            await tester.ValidateAsync<BitgetFuturesKlineUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToKlineUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "BTCUSDT", Enums.BitgetStreamKlineIntervalV2.TwelveHours, handler), "Kline");
            await tester.ValidateAsync<BitgetOrderBookUpdate>((client, handler) => client.FuturesApiV2.SubscribeToOrderBookUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, "BTCUSDT", 5, handler), "OrderBook", useFirstUpdateItem: true);
            await tester.ValidateAsync<BitgetFuturesBalanceUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToBalanceUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "Balance");
            await tester.ValidateAsync<BitgetPositionUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToPositionUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "Position", ignoreProperties: new List<string> { "autoMargin" });
            await tester.ValidateAsync<BitgetFuturesUserTradeUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToUserTradeUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "UserTrade", ignoreProperties: new List<string> { "deduction" });
            await tester.ValidateAsync<BitgetFuturesOrderUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToOrderUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "Order", ignoreProperties: new List<string> { "deduction", "reduceOnly" });
            await tester.ValidateAsync<BitgetFuturesTriggerOrderUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToTriggerOrderUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "TriggerOrder", ignoreProperties: new List<string> { "deduction", "reduceOnly" });
            await tester.ValidateAsync<BitgetPositionHistoryUpdate[]>((client, handler) => client.FuturesApiV2.SubscribeToPositionHistoryUpdatesAsync(Enums.BitgetProductTypeV2.UsdtFutures, handler), "PositionClose", ignoreProperties: new List<string> { "deduction", "reduceOnly" });
        }
    }
}
