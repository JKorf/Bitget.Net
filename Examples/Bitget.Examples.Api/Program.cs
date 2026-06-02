using Bitget.Net.Objects;
using Bitget.Net.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the Bitget services
builder.Services.AddBitget();

// OR to provide API credentials for accessing private endpoints, or setting other options:
/*
builder.Services.AddBitget(options =>
{    
   options.ApiCredentials = new ApiCredentials("<APIKEY>", "<APISECRET>", "<PASS>");
   options.Rest.RequestTimeout = TimeSpan.FromSeconds(5);
});
*/

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Map the endpoints and inject the Bitget rest client
app.MapGet("/{Symbol}", async ([FromServices] IBitgetRestClient client, string symbol) =>
{
    var result = await client.SpotApiV2.ExchangeData.GetTickersAsync(symbol);
    return result.Success
        ? Results.Ok(result.Data.Single())
        : Results.Problem(result.Error?.Message, statusCode: 502);
})
.WithOpenApi();

app.MapGet("/Balances", async ([FromServices] IBitgetRestClient client) =>
{
    var result = await client.SpotApiV2.Account.GetSpotBalancesAsync();
    return result.Success
        ? Results.Ok(result.Data)
        : Results.Problem(result.Error?.Message, statusCode: 502);
})
.WithOpenApi();

app.Run();
