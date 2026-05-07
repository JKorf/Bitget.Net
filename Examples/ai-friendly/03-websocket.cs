// 03-websocket.cs
//
// Demonstrates: Bitget V2 public websocket subscriptions.
//
// Setup: dotnet add package JK.Bitget.Net

using Bitget.Net.Clients;
using Bitget.Net.Enums;

var socketClient = new BitgetSocketClient();

var spotTickerSubscription = await socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync(
    "BTCUSDT",
    update =>
    {
        var ticker = update.Data.FirstOrDefault();
        if (ticker != null)
            Console.WriteLine($"Spot BTCUSDT ticker: {ticker.LastPrice}");
    });

if (!spotTickerSubscription.Success)
{
    Console.WriteLine($"Spot ticker subscription failed: {spotTickerSubscription.Error}");
    return;
}

var futuresKlineSubscription = await socketClient.FuturesApiV2.SubscribeToKlineUpdatesAsync(
    BitgetProductTypeV2.UsdtFutures,
    "ETHUSDT",
    BitgetStreamKlineIntervalV2.OneMinute,
    update =>
    {
        var candle = update.Data.FirstOrDefault();
        if (candle != null)
            Console.WriteLine($"Futures ETHUSDT 1m candle: open={candle.OpenPrice}, close={candle.ClosePrice}");
    });

if (!futuresKlineSubscription.Success)
{
    Console.WriteLine($"Futures kline subscription failed: {futuresKlineSubscription.Error}");
    await socketClient.UnsubscribeAsync(spotTickerSubscription.Data);
    return;
}

Console.WriteLine("Listening. Press Enter to unsubscribe.");
Console.ReadLine();

await socketClient.UnsubscribeAsync(spotTickerSubscription.Data);
await socketClient.UnsubscribeAsync(futuresKlineSubscription.Data);
