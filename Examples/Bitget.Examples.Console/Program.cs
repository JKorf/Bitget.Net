using Bitget.Net.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// REST
var restClient = new BitgetRestClient();
var ticker = await restClient.SpotApiV2.ExchangeData.GetTickersAsync("ETHUSDT");
if (!ticker.Success)
{
    Console.WriteLine($"Failed to get ticker: {ticker.Error}");
    return;
}

Console.WriteLine($"Rest client ticker price for ETH-USDT: {ticker.Data.Single().LastPrice}");

Console.WriteLine();
Console.WriteLine("Press enter to start websocket subscription");
Console.ReadLine();

// Websocket
// Optional, manually add logging
var logFactory = new LoggerFactory();
logFactory.AddProvider(new TraceLoggerProvider());

var socketClient = new BitgetSocketClient(Options.Create(new BitgetSocketOptions() { }), logFactory);
var subscription = await socketClient.SpotApiV2.SubscribeToTickerUpdatesAsync("ETHUSDT", update =>
{
    foreach (var tickerUpdate in update.Data)
        Console.WriteLine($"Websocket client ticker price for {tickerUpdate.Symbol}: {tickerUpdate.LastPrice}");
});

if (!subscription.Success)
{
    Console.WriteLine($"Failed to subscribe to ticker updates: {subscription.Error}");
    return;
}

Console.ReadLine();
