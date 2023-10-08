---
title: IBitgetRestClientFuturesApiTrading
has_children: false
parent: IBitgetRestClientFuturesApi
grand_parent: Rest API documentation
---
*[generated documentation]*  
`BitgetRestClient > FuturesApi > Trading`  
*Bitget trading endpoints, placing and mananging orders.*
  

***

## CancelOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#cancel-order](https://bitgetlimited.github.io/apidoc/en/mix/#cancel-order)  
<p>

*Cancel an order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.CancelOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> CancelOrderAsync(string symbol, string marginAsset, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|marginAsset|Margin asset|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## CancelPlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order](https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order)  
<p>

*Cancel a plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.CancelPlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> CancelPlanOrderAsync(string symbol, string marginAsset, BitgetPlanType planType, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|planType|Plan type|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#modify-order](https://bitgetlimited.github.io/apidoc/en/mix/#modify-order)  
<p>

*Edit an order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.EditOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> EditOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, string? newClientOrderId = default, decimal? price = default, decimal? quantity = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ newClientOrderId|New client order id|
|_[Optional]_ price|New price|
|_[Optional]_ quantity|New quantity|
|_[Optional]_ takeProfitPrice|new take profit price|
|_[Optional]_ stopLossPrice|New stop loss price|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditPlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order](https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order)  
<p>

*Edit a plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.EditPlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> EditPlanOrderAsync(string symbol, string marginAsset, decimal triggerPrice, BitgetTriggerType triggerType, BitgetOrderType orderType, string? orderId = default, string? clientOrderId = default, decimal? executePrice = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|triggerPrice|Trigger price|
|triggerType|Trigger type|
|orderType|Order type|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ executePrice|Execute price|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditPlanOrderTpSlAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order-tpsl](https://bitgetlimited.github.io/apidoc/en/mix/#modify-plan-order-tpsl)  
<p>

*Edit the take profit / stop loss of a plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.EditPlanOrderTpSlAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> EditPlanOrderTpSlAsync(string symbol, string marginAsset, string? orderId = default, string? clientOrderId = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ takeProfitPrice|New take profit price|
|_[Optional]_ stopLossPrice|New stop loss price|
|_[Optional]_ ct|Cancellation token|

</p>

***

## EditStopOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order](https://bitgetlimited.github.io/apidoc/en/mix/#modify-stop-order)  
<p>

*Edit an existing stop order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.EditStopOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> EditStopOrderAsync(string symbol, string marginAsset, BitgetPlanType planType, decimal triggerPrice, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|planType|Plan type|
|triggerPrice|Trigger price|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenOrdersAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-open-order](https://bitgetlimited.github.io/apidoc/en/mix/#get-open-order)  
<p>

*Get list of open orders for a symbol*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetOpenOrdersAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOpenOrdersAsync(string symbol, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOpenOrdersByProductAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-all-open-order](https://bitgetlimited.github.io/apidoc/en/mix/#get-all-open-order)  
<p>

*Get list of open order for a product type*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetOpenOrdersByProductAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesOrder>>> GetOpenOrdersByProductAsync(BitgetProductType type, string? marginAsset = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Type|
|_[Optional]_ marginAsset|Filter by margin asset|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-order-details](https://bitgetlimited.github.io/apidoc/en/mix/#get-order-details)  
<p>

*Get an order by id*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetFuturesOrder>> GetOrderAsync(string symbol, string? orderId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Order id, either this or clientOrderId should be provided|
|_[Optional]_ clientOrderId|Client order id, either this or orderId should be provided|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-orders](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-orders)  
<p>

*Get order history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(string symbol, DateTime startTime, DateTime endTime, int pageSize, string? endId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|startTime|Filter by start time|
|endTime|Filter by end time|
|pageSize|Page size|
|_[Optional]_ endId|Last end Id of last query|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetOrderHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-history-orders](https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-history-orders)  
<p>

*Get order history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetPagination<BitgetFuturesOrder>>> GetOrderHistoryAsync(BitgetProductType type, DateTime startTime, DateTime endTime, int pageSize, string? endId = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|startTime|Filter by start time|
|endTime|Filter by end time|
|pageSize|Page size|
|_[Optional]_ endId|Last end Id of last query|
|_[Optional]_ clientOrderId|Filter by client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetPlanOrderHistoryAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-history-plan-orders-tpsl](https://bitgetlimited.github.io/apidoc/en/mix/#get-history-plan-orders-tpsl)  
<p>

*Get plan order history*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetPlanOrderHistoryAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesPlanOrder>>> GetPlanOrderHistoryAsync(DateTime startTime, DateTime endTime, BitgetProductType? type = default, string? symbol = default, int? pageSize = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|startTime|Start time|
|endTime|End time|
|_[Optional]_ type|Filter by product type|
|_[Optional]_ symbol|Filter by symbol|
|_[Optional]_ pageSize|Page size|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-order-fill-detail](https://bitgetlimited.github.io/apidoc/en/mix/#get-order-fill-detail)  
<p>

*Get user trades*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(string symbol, string? orderId = default, DateTime? startTime = default, DateTime? endTime = default, string? endId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|_[Optional]_ orderId|Filter by order id|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ endId|Last end Id of last query|
|_[Optional]_ ct|Cancellation token|

</p>

***

## GetUserTradesAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-order-fill-detail](https://bitgetlimited.github.io/apidoc/en/mix/#get-producttype-order-fill-detail)  
<p>

*Get user trades*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.GetUserTradesAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<IEnumerable<BitgetFuturesUserTrade>>> GetUserTradesAsync(BitgetProductType type, DateTime? startTime = default, DateTime? endTime = default, string? endId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|type|Product type|
|_[Optional]_ startTime|Filter by start time|
|_[Optional]_ endTime|Filter by end time|
|_[Optional]_ endId|Last end Id of last query|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#place-order](https://bitgetlimited.github.io/apidoc/en/mix/#place-order)  
<p>

*Place a new order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.PlaceOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlaceOrderAsync(string symbol, string marginAsset, BitgetFuturesOrderSide side, BitgetOrderType type, decimal quantity, decimal? price = default, BitgetTimeInForce? timeInForce = default, bool? reduceOnly = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|marginAsset|Margin asset|
|side|Position side|
|type|Position side|
|quantity|Quantity|
|_[Optional]_ price|Price|
|_[Optional]_ timeInForce|Time in force|
|_[Optional]_ reduceOnly|Reduce only|
|_[Optional]_ takeProfitPrice|Preset take profit price|
|_[Optional]_ stopLossPrice|Preset stop loss price|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlacePlanOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#place-plan-order](https://bitgetlimited.github.io/apidoc/en/mix/#place-plan-order)  
<p>

*Place a new plan order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.PlacePlanOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlacePlanOrderAsync(string symbol, string marginAsset, BitgetFuturesOrderSide side, BitgetOrderType type, BitgetTriggerType triggerType, decimal quantity, decimal triggerPrice, decimal? executePrice = default, bool? reduceOnly = default, decimal? takeProfitPrice = default, decimal? stopLossPrice = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol id|
|marginAsset|Margin asset|
|side|Position side|
|type|Position side|
|triggerType|Trigger type|
|quantity|Quantity|
|triggerPrice|Trigger price|
|_[Optional]_ executePrice|Execute price|
|_[Optional]_ reduceOnly|Reduce only|
|_[Optional]_ takeProfitPrice|Preset take profit price|
|_[Optional]_ stopLossPrice|Preset stop loss price|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlacePositionTpSlAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#place-position-tpsl](https://bitgetlimited.github.io/apidoc/en/mix/#place-position-tpsl)  
<p>

*Set stop loss / take profit price for an position. When the position take profit / stop loss are triggered, the full amount of the position will be entrusted at the market price by default*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.PlacePositionTpSlAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlacePositionTpSlAsync(string symbol, string marginAsset, BitgetPlanType planType, decimal triggerPrice, BitgetTriggerType triggerType, BitgetPositionSide side, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|planType|Plan type|
|triggerPrice|Trigger price|
|triggerType|Trigger type|
|side|Order side|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceStopOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#place-stop-order](https://bitgetlimited.github.io/apidoc/en/mix/#place-stop-order)  
<p>

*Place a new stop order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.PlaceStopOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlaceStopOrderAsync(string symbol, string marginAsset, BitgetPlanType planType, decimal triggerPrice, BitgetPositionSide side, BitgetTriggerType? triggerType = default, decimal? quantity = default, decimal? executePrice = default, decimal? rangeRate = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|planType|Plan type|
|triggerPrice|Trigger price|
|side|Position side|
|_[Optional]_ triggerType|Trigger type|
|_[Optional]_ quantity|Quantity|
|_[Optional]_ executePrice|Execution price|
|_[Optional]_ rangeRate|Only works when planType is "MovingPlan", "1" means 1.0% price correction, two decimal places|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>

***

## PlaceTrailingStopOrderAsync  

[https://bitgetlimited.github.io/apidoc/en/mix/#place-trailing-stop-order](https://bitgetlimited.github.io/apidoc/en/mix/#place-trailing-stop-order)  
<p>

*Place a new trailling stop order*  

```csharp  
var client = new BitgetRestClient();  
var result = await client.FuturesApi.Trading.PlaceTrailingStopOrderAsync(/* parameters */);  
```  

```csharp  
Task<WebCallResult<BitgetOrderResult>> PlaceTrailingStopOrderAsync(string symbol, string marginAsset, decimal triggerPrice, BitgetFuturesOrderSide side, decimal quantity, decimal rangeRate, BitgetTriggerType? triggerType = default, string? clientOrderId = default, CancellationToken ct = default);  
```  

|Parameter|Description|
|---|---|
|symbol|Symbol|
|marginAsset|Margin asset|
|triggerPrice|Trigger price|
|side|Order side|
|quantity|Quantity|
|rangeRate|"1" means 1.0% price correction, max 10|
|_[Optional]_ triggerType|Trigger type|
|_[Optional]_ clientOrderId|Client order id|
|_[Optional]_ ct|Cancellation token|

</p>
