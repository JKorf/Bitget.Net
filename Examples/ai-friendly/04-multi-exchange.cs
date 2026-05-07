// 04-multi-exchange.cs
//
// Demonstrates: writing exchange-agnostic code using CryptoExchange.Net.SharedApis.
// Same code works against Bitget and other exchanges from the CryptoExchange.Net family.
//
// Setup:
//   dotnet add package JK.Bitget.Net
//   dotnet add package Binance.Net  // optional, for comparison

using Bitget.Net.Clients;
using CryptoExchange.Net.SharedApis;

// Bitget exposes SharedClient on both SpotApiV2 and FuturesApiV2.
ISpotTickerRestClient bitgetSpotShared = new BitgetRestClient().SpotApiV2.SharedClient;

var btcusdt = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");

await PrintTicker(bitgetSpotShared, btcusdt);

async Task PrintTicker(ISpotTickerRestClient client, SharedSymbol symbol)
{
    var result = await client.GetSpotTickerAsync(new GetTickerRequest(symbol));
    if (!result.Success)
    {
        Console.WriteLine($"[{client.Exchange}] Failed: {result.Error}");
        return;
    }

    Console.WriteLine($"[{client.Exchange}] {result.Data.Symbol}: {result.Data.LastPrice}");
}

// Common REST shared interfaces:
//   ISpotTickerRestClient, ISpotSymbolRestClient, ISpotOrderRestClient
//   IFuturesTickerRestClient, IFuturesOrderRestClient, IFuturesSymbolRestClient
//   IBalanceRestClient, IPositionRestClient, IFeeRestClient, IOrderBookRestClient

// ---- WEBSOCKET EXAMPLE - SHARED SUBSCRIPTION ----
var bitgetSocket = new BitgetSocketClient();
ITickerSocketClient bitgetTickerSocket = bitgetSocket.SpotApiV2.SharedClient;

var sub = await bitgetTickerSocket.SubscribeToTickerUpdatesAsync(
    new SubscribeTickerRequest(btcusdt),
    update => Console.WriteLine($"[{bitgetTickerSocket.Exchange}] {update.Data.Symbol}: {update.Data.LastPrice}"));

if (!sub.Success)
{
    Console.WriteLine($"Subscribe failed: {sub.Error}");
    return;
}

Console.WriteLine("Press Enter to exit");
Console.ReadLine();

await bitgetSocket.UnsubscribeAsync(sub.Data);

// Note: shared socket interfaces do not expose UnsubscribeAsync.
// Keep the concrete socket client and call concreteClient.UnsubscribeAsync(sub.Data).
