---
title: Socket API documentation
has_children: true
---
*[generated documentation]*  
### BitgetSocketClient  
*Client for accessing the Bitget websocket API*
  
***
*Futures streams*  
**[IBitgetSocketClientFuturesApi](FuturesApi/IBitgetSocketClientFuturesApi.html) FuturesApi { get; set; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(BitgetApiCredentials credentials);**  
***
*Spot streams*  
**[IBitgetSocketClientSpotApi](SpotApi/IBitgetSocketClientSpotApi.html) SpotApi { get; set; }**  
