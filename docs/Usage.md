---
title: Getting started
nav_order: 2
---

## Creating client
There are 2 clients available to interact with the Bitget API, the `BitgetRestClient` and `BitgetSocketClient`. They can be created manually on the fly or be added to the dotnet DI using the `AddBitget` extension method.

*Manually create a new client*
```csharp
var bitgetRestClient = new BitgetRestClient(options
{
    // Set options here for this client
});

var bitgetSocketClient = new BitgetSocketClient(options =>
{
    // Set options here for this client
});
```

*Using dotnet dependency inject*
```csharp
services.AddBitget(
    restOptions => {
        // set options for the rest client
    },
    socketClientOptions => {
        // set options for the socket client
    }); 
    
// IBitgetRestClient, IBitgetSocketClient and IBitgetOrderBookFactory, as well as an implementation of the ISpotClient interface for Bitget are now available for injecting
```

Different options are available to set on the clients, see this example
```csharp
var bitgetRestClient = new BitgetRestClient(options =>
{
    options.ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET", "PASSPHRASE");
    options.RequestTimeout = TimeSpan.FromSeconds(60);
});
```
Alternatively, options can be provided before creating clients by using `SetDefaultOptions` or during the registration in the DI container:  
```csharp
BitgetRestClient.SetDefaultOptions(options => {
    // Set options here for all new clients
});
var bitgetRestClient = new BitgetRestClient();
```
More info on the specific options can be found in the [CryptoExchange.Net documentation](https://jkorf.github.io/CryptoExchange.Net/Options.html)
