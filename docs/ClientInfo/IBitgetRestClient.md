---
title: Rest API documentation
has_children: true
---
*[generated documentation]*  
### BitgetRestClient  
*Client for accessing the Bitget API.*
  
***
*Futures API endpoints*  
**[IBitgetRestClientFuturesApi](FuturesApi/IBitgetRestClientFuturesApi.html) FuturesApi { get; }**  
***
*Set the API credentials for this client. All Api clients in this client will use the new credentials, regardless of earlier set options.*  
**void SetApiCredentials(ApiCredentials credentials);**  
***
*Spot API endpoints*  
**[IBitgetRestClientSpotApi](SpotApi/IBitgetRestClientSpotApi.html) SpotApi { get; }**  
