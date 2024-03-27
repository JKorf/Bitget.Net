using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the Bitget services
builder.Services.AddBitget();

// OR to provide API credentials for accessing private endpoints, or setting other options:
/*
builder.Services.AddBitget(restOptions =>
{
    restOptions.ApiCredentials = new BitgetApiCredentials("<APIKEY>", "<APISECRET>", "<PASS>");
    restOptions.RequestTimeout = TimeSpan.FromSeconds(5);
}, socketOptions =>
{
    socketOptions.ApiCredentials = new BitgetApiCredentials("<APIKEY>", "<APISECRET>", "<PASS>");
});
*/

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Map the endpoints and inject the Bitget rest client
app.MapGet("/{Symbol}", async ([FromServices] IBitgetRestClient client, string symbol) =>
{
    var result = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);
    return (object)(result.Success ? result.Data : result.Error!);
})
.WithOpenApi();

app.MapGet("/Balances", async ([FromServices] IBitgetRestClient client) =>
{
    var result = await client.SpotApi.Account.GetBalancesAsync();
    return (object)(result.Success ? result.Data : result.Error!);
})
.WithOpenApi();

app.Run();