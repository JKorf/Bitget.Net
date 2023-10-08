---
title: IBitgetSocketClientFuturesApi
has_children: true
parent: Socket API documentation
---
*[generated documentation]*  
`BitgetSocketClient > FuturesApi`  
*Bitget futures streams*
  

***

## SubscribeToBalanceUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#account-channel](https://bitgetlimited.github.io/apidoc/en/mix/#account-channel)  
<p>

*Subscribe to updates to the account balance*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToBalanceUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesBalanceUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|instrumentType|Instrument type|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToKlineUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel](https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel)  
<p>

*Subscribe to kline/candlestick updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
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

## SubscribeToKlineUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel](https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel)  
<p>

*Subscribe to kline/candlestick updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToKlineUpdatesAsync(/* parameters */);  
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

## SubscribeToOrderBookUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel](https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel)  
<p>

*Subscribe to orderbook changes updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel](https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel)  
<p>

*Subscribe to orderbook snapshot updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel](https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel)  
<p>

*Subscribe to orderbook changes updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel](https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel)  
<p>

*Subscribe to orderbook snapshot updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToOrderBookUpdatesAsync(/* parameters */);  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#order-channel](https://bitgetlimited.github.io/apidoc/en/mix/#order-channel)  
<p>

*Subscribe to account order updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|instrumentType|Instrument type|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPlanOrderUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#plan-order-channel](https://bitgetlimited.github.io/apidoc/en/mix/#plan-order-channel)  
<p>

*Subscribe to plan order updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToPlanOrderUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPlanOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesPlanOrderUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|instrumentType|Instrument type|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToPositionUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#positions-channel](https://bitgetlimited.github.io/apidoc/en/mix/#positions-channel)  
<p>

*Subscribe to position updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToPositionUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetPositionUpdate>>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|instrumentType|Instrument type|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel](https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel)  
<p>

*Subscribe to symbol ticker updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbols|Symbols to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTickerUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel](https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel)  
<p>

*Subscribe to symbol ticker updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToTickerUpdatesAsync(/* parameters */);  
```  

```csharp  
Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol to subscribe|
|handler|The handler for the data|
|_[Optional]_ ct|Cancellation token for closing this subscription|

</p>

***

## SubscribeToTradeUpdatesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel](https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel)  
<p>

*Subscribe to symbol trade updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
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

[https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel](https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel)  
<p>

*Subscribe to symbol trade updates*  

```csharp  
var client = new BitgetSocketClient();  
var result = await client.FuturesApi.SubscribeToTradeUpdatesAsync(/* parameters */);  
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
