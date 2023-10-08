---
title: IBitgetSocketClientSpotApi
has_children: true
parent: Socket API documentation
---
*[generated documentation]*  
`BitgetSocketClient > SpotApi`  
*Bitget spot streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#account-channel](https://bitgetlimited.github.io/apidoc/en/spot/#account-channel)  
<p>

*Subscribe to updates to the account balance*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<IEnumerable<BitgetBalanceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#candlesticks-channel](https://bitgetlimited.github.io/apidoc/en/spot/#candlesticks-channel)  
<p>

*Subscribe to kline/candlestick updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|interval|Kline interval|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#candlesticks-channel](https://bitgetlimited.github.io/apidoc/en/spot/#candlesticks-channel)  
<p>

*Subscribe to kline/candlestick updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|interval|Kline interval|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel](https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel)  
<p>

*Subscribe to orderbook changes updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel](https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel)  
<p>

*Subscribe to orderbook snapshot updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|limit|The book depth, either 5 or 15|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel](https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel)  
<p>

*Subscribe to orderbook changes updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderBookUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel](https://bitgetlimited.github.io/apidoc/en/spot/#depth-channel)  
<p>

*Subscribe to orderbook snapshot updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|limit|The book depth, either 5 or 15|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToOrderUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#order-channel](https://bitgetlimited.github.io/apidoc/en/spot/#order-channel)  
<p>

*Subscribe to account order updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BitgetOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#tickers-channel](https://bitgetlimited.github.io/apidoc/en/spot/#tickers-channel)  
<p>

*Subscribe to symbol ticker updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#tickers-channel](https://bitgetlimited.github.io/apidoc/en/spot/#tickers-channel)  
<p>

*Subscribe to symbol ticker updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#trades-channel](https://bitgetlimited.github.io/apidoc/en/spot/#trades-channel)  
<p>

*Subscribe to symbol trade updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/spot/#trades-channel](https://bitgetlimited.github.io/apidoc/en/spot/#trades-channel)  
<p>

*Subscribe to symbol trade updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.SpotApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>
