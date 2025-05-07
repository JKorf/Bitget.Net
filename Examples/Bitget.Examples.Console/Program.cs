using Bitget.Net.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// REST
var restClient = new BitgetRestClient();
var ticker = await restClient.SpotApiV2.ExchangeData.GetTickersAsync("ETHUSDT_SPBL");
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
    Console.WriteLine($"Websocket client ticker price for ETHUSDT: {update.Data.LastPrice}");
});

Console.ReadLine();
