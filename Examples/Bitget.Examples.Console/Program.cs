using Bitget.Net.Clients;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

// REST
var restClient = new BitgetRestClient();
var ticker = await restClient.SpotApi.ExchangeData.GetTickerAsync("ETHUSDT_SPBL");
Console.WriteLine($"Rest client ticker price for ETH-USDT: {ticker.Data.ClosePrice}");

Console.WriteLine();
Console.WriteLine("Press enter to start websocket subscription");
Console.ReadLine();

// Websocket
// Optional, manually add logging
var logFactory = new LoggerFactory();
logFactory.AddProvider(new TraceLoggerProvider());

var socketClient = new BitgetSocketClient(logFactory);
var subscription = await socketClient.SpotApi.SubscribeToTickerUpdatesAsync("ETHUSDT", update =>
{
    Console.WriteLine($"Websocket client ticker price for ETHUSDT: {update.Data.LastPrice}");
});

Console.ReadLine();
