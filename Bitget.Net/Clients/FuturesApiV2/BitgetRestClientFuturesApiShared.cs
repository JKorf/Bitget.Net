using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Futures;
using CryptoExchange.Net.SharedApis.Interfaces.Rest.Spot;
using CryptoExchange.Net.SharedApis.Models;
using CryptoExchange.Net.SharedApis.Models.EndpointOptions;
using CryptoExchange.Net.SharedApis.Models.FilterOptions;
using CryptoExchange.Net.SharedApis.Models.Rest;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesApi : IBitgetRestClientFuturesApiShared
    {
        public string Exchange => BitgetExchange.ExchangeName;
        public ApiType[] SupportedApiTypes { get; } = new[] { ApiType.PerpetualLinear, ApiType.PerpetualInverse, ApiType.DeliveryLinear, ApiType.DeliveryInverse };

        #region Balance client
        EndpointOptions IBalanceRestClient.GetBalancesOptions { get; } = new EndpointOptions("GetBalancesRequest", true);

        async Task<ExchangeWebResult<IEnumerable<SharedBalance>>> IBalanceRestClient.GetBalancesAsync(ApiType apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IBalanceRestClient)this).GetBalancesOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedBalance>>(Exchange, validationError);

            var resultUsdt = Account.GetBalancesAsync(Enums.BitgetProductTypeV2.UsdtFutures, ct: ct);
            var resultUsdc = Account.GetBalancesAsync(Enums.BitgetProductTypeV2.UsdcFutures, ct: ct);
            await Task.WhenAll(resultUsdt, resultUsdc).ConfigureAwait(false);
            if (!resultUsdt.Result)
                return resultUsdt.Result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, default);
            if (!resultUsdc.Result)
                return resultUsdc.Result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, default);

            var result = new List<SharedBalance>();
            result.AddRange(resultUsdt.Result.Data.Select(x => new SharedBalance("USDT", x.Available, x.Equity)));
            result.AddRange(resultUsdc.Result.Data.Select(x => new SharedBalance("USDC", x.Available, x.Equity)));
            return resultUsdt.Result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, result);
        }

        #endregion

        #region Futures Ticker client

        EndpointOptions<GetTickerRequest> IFuturesTickerRestClient.GetFuturesTickerOptions { get; } = new EndpointOptions<GetTickerRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesTicker>> IFuturesTickerRestClient.GetFuturesTickerAsync(GetTickerRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesTickerRestClient)this).GetFuturesTickerOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesTicker>(Exchange, validationError);

            var productType = GetProductType(request.ApiType, exchangeParameters);

            var resultTicker = ExchangeData.GetTickerAsync(productType, request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), ct);
            var resultFunding = ExchangeData.GetNextFundingTimeAsync(productType, request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), ct);
            var resultPrices = ExchangeData.GetPricesAsync(productType, request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), ct);
            await Task.WhenAll(resultTicker, resultFunding, resultPrices).ConfigureAwait(false);
            if (!resultTicker.Result)
                return resultTicker.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, default);
            if (!resultFunding.Result)
                return resultFunding.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, default);
            if (!resultPrices.Result)
                return resultPrices.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, default);

            return resultTicker.Result.AsExchangeResult(Exchange,
                new SharedFuturesTicker(
                    resultTicker.Result.Data.Symbol,
                    resultTicker.Result.Data.LastPrice,
                    resultTicker.Result.Data.HighPrice,
                    resultTicker.Result.Data.LowPrice,
                    resultTicker.Result.Data.Volume)
                {
                    MarkPrice = resultPrices.Result.Data.MarkPrice,
                    IndexPrice = resultPrices.Result.Data.IndexPrice,
                    FundingRate = resultTicker.Result.Data.FundingRate,
                    NextFundingTime = resultFunding.Result.Data.NextFundingTime
                });
        }

        EndpointOptions IFuturesTickerRestClient.GetFuturesTickersOptions { get; } = new EndpointOptions("GetFuturesTickersRequest", false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<IEnumerable<SharedFuturesTicker>>> IFuturesTickerRestClient.GetFuturesTickersAsync(ApiType apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesTickerRestClient)this).GetFuturesTickerOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedFuturesTicker>>(Exchange, validationError);

            var resultTickers = await ExchangeData.GetTickersAsync(GetProductType(apiType, exchangeParameters), ct: ct).ConfigureAwait(false);
            if (!resultTickers)
                return resultTickers.AsExchangeResult<IEnumerable<SharedFuturesTicker>>(Exchange, default);

            return resultTickers.AsExchangeResult<IEnumerable<SharedFuturesTicker>>(Exchange, resultTickers.Data.Select(x =>
             new SharedFuturesTicker(x.Symbol, x.LastPrice, x.HighPrice, x.LowPrice, x.Volume)
                {
                    FundingRate = x.FundingRate,
                    IndexPrice = x.IndexPrice
                }
            ));
        }

        #endregion

        #region Futures Symbol client

        EndpointOptions IFuturesSymbolRestClient.GetFuturesSymbolsOptions { get; } = new EndpointOptions("GetFuturesSymbolsRequest", false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>> IFuturesSymbolRestClient.GetFuturesSymbolsAsync(ApiType apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesSymbolRestClient)this).GetFuturesSymbolsOptions.ValidateRequest(Exchange, exchangeParameters, apiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedFuturesSymbol>>(Exchange, validationError);

            var productType = GetProductType(apiType, exchangeParameters);
            var result = await ExchangeData.GetContractsAsync(
                productType,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedFuturesSymbol>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(s => new SharedFuturesSymbol(
                productType == BitgetProductTypeV2.CoinFutures && s.DeliveryPeriod.HasValue ? SharedSymbolType.DeliveryInverse :
                productType == BitgetProductTypeV2.CoinFutures && !s.DeliveryPeriod.HasValue ? SharedSymbolType.PerpetualInverse :
                s.DeliveryPeriod.HasValue ? SharedSymbolType.DeliveryLinear :
                SharedSymbolType.PerpetualLinear,
                s.BaseAsset,
                s.QuoteAsset,
                s.Symbol)
            {
                MinTradeQuantity = s.MinOrderQuantity,
                PriceDecimals = s.PriceDecimals,
                QuantityDecimals = s.QuantityDecimals,
                DeliveryTime = s.DeliveryTime,
                PriceStep = s.PriceStep,
                QuantityStep = s.QuantityStep,
                ContractSize = 1
            }));
        }

        #endregion

        #region Klines client

        GetKlinesOptions IKlineRestClient.GetKlinesOptions { get; } = new GetKlinesOptions(true, false)
        {
            MaxRequestDataPoints = 1000,
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<IEnumerable<SharedKline>>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedKline>>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IKlineRestClient)this).GetKlinesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedKline>>(Exchange, validationError);

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            var startTime = request.Filter?.StartTime;
            var endTime = request.Filter?.EndTime;
            var apiLimit = 1000;

            // API returns the newest data first if the timespan is bigger than the api limit of 1000 results
            // So we need to request the first 1000 from the start time, then the 1000 after that etc
            if (request.Filter?.StartTime != null)
            {
                // Not paginated, check if the data will fit
                var seconds = apiLimit * (int)request.Interval;
                var maxEndTime = (fromTimestamp ?? request.Filter.StartTime).Value.AddSeconds(seconds);
                if (maxEndTime < endTime)
                    endTime = maxEndTime;
            }

            var result = await ExchangeData.GetKlinesAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)),
                interval,
                KlineType.Market,
                fromTimestamp ?? request.Filter?.StartTime,
                endTime,
                limit: request.Filter?.Limit ?? apiLimit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedKline>>(Exchange, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (request.Filter?.StartTime != null && result.Data.Any())
            {
                var maxOpenTime = result.Data.Max(x => x.OpenTime);
                if (maxOpenTime < request.Filter.EndTime!.Value.AddSeconds(-(int)request.Interval))
                    nextToken = new DateTimeToken(maxOpenTime.AddSeconds((int)interval));
            }

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)), nextToken);
        }

        #endregion

        #region Recent Trade client

        GetRecentTradesOptions IRecentTradeRestClient.GetRecentTradesOptions { get; } = new GetRecentTradesOptions(1000, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedTrade>>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IRecentTradeRestClient)this).GetRecentTradesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedTrade>>(Exchange, validationError);

            var result = await ExchangeData.GetRecentTradesAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTrade>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)));
        }

        #endregion

        #region Leverage client

        EndpointOptions<GetLeverageRequest> ILeverageRestClient.GetLeverageOptions { get; } = new EndpointOptions<GetLeverageRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedLeverage>> ILeverageRestClient.GetLeverageAsync(GetLeverageRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((ILeverageRestClient)this).GetLeverageOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedLeverage>(Exchange, validationError);

            var result = await Trading.GetPositionAsync(
                GetProductType(request.ApiType, exchangeParameters),
                symbol: request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                marginAsset: exchangeParameters!.GetValue<string>(Exchange, "MarginAsset")!,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedLeverage>(Exchange, default);

            var position = result.Data.SingleOrDefault(x => x.PositionSide == (request.Side == SharedPositionSide.Both ? PositionSide.Oneway : request.Side == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long));

            return result.AsExchangeResult(Exchange, new SharedLeverage(position?.Leverage ?? 0));
        }

        SetLeverageOptions ILeverageRestClient.SetLeverageOptions { get; } = new SetLeverageOptions(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedLeverage>> ILeverageRestClient.SetLeverageAsync(SetLeverageRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((ILeverageRestClient)this).SetLeverageOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedLeverage>(Exchange, validationError);


            var result = await Account.SetLeverageAsync(
                GetProductType(request.ApiType, exchangeParameters),
                symbol: request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                marginAsset: exchangeParameters!.GetValue<string>(Exchange, "MarginAsset")!,
                (int)request.Leverage,
                side: request.Side == SharedPositionSide.Both ? PositionSide.Oneway : request.Side == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedLeverage>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedLeverage(request.Leverage)
            {
                Side = request.Side
            });
        }
        #endregion

        #region Mark Klines client

        GetKlinesOptions IMarkPriceKlineRestClient.GetMarkPriceKlinesOptions { get; } = new GetKlinesOptions(true, false)
        {
            MaxRequestDataPoints = 200,
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };

        async Task<ExchangeWebResult<IEnumerable<SharedMarkKline>>> IMarkPriceKlineRestClient.GetMarkPriceKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedMarkKline>>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IMarkPriceKlineRestClient)this).GetMarkPriceKlinesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedMarkKline>>(Exchange, validationError);

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            var result = await ExchangeData.GetHistoricalMarkPriceKlinesAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                interval,
                fromTimestamp ?? request.Filter?.StartTime,
                request.Filter?.EndTime,
                request.Filter?.Limit ?? 200,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedMarkKline>>(Exchange, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (request.Filter?.StartTime != null && result.Data.Any())
            {
                var maxOpenTime = result.Data.Max(x => x.OpenTime);
                if (maxOpenTime < request.Filter.EndTime!.Value.AddSeconds(-(int)request.Interval))
                    nextToken = new DateTimeToken(maxOpenTime.AddSeconds((int)interval));
            }

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedMarkKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice)), nextToken);
        }

        #endregion

        #region Index Klines client

        GetKlinesOptions IIndexPriceKlineRestClient.GetIndexPriceKlinesOptions { get; } = new GetKlinesOptions(true, false)
        {
            MaxRequestDataPoints = 200,
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<IEnumerable<SharedMarkKline>>> IIndexPriceKlineRestClient.GetIndexPriceKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedMarkKline>>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IMarkPriceKlineRestClient)this).GetMarkPriceKlinesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedMarkKline>>(Exchange, validationError);

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            var result = await ExchangeData.GetHistoricalIndexPriceKlinesAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                interval,
                fromTimestamp ?? request.Filter?.StartTime,
                request.Filter?.EndTime,
                request.Filter?.Limit ?? 200,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedMarkKline>>(Exchange, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (request.Filter?.StartTime != null && result.Data.Any())
            {
                var maxOpenTime = result.Data.Max(x => x.OpenTime);
                if (maxOpenTime < request.Filter.EndTime!.Value.AddSeconds(-(int)request.Interval))
                    nextToken = new DateTimeToken(maxOpenTime.AddSeconds((int)interval));
            }

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedMarkKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice)), nextToken);
        }

        #endregion

        #region Order Book client
        GetOrderBookOptions IOrderBookRestClient.GetOrderBookOptions { get; } = new GetOrderBookOptions(new[] { 5, 10, 20, 50, 100, 500, 1000 }, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };
        async Task<ExchangeWebResult<SharedOrderBook>> IOrderBookRestClient.GetOrderBookAsync(GetOrderBookRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IOrderBookRestClient)this).GetOrderBookOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedOrderBook>(Exchange, validationError);

            var result = await ExchangeData.GetOrderBookAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedOrderBook>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedOrderBook(result.Data.Asks, result.Data.Bids));
        }

        #endregion

        #region Open Interest client

        EndpointOptions<GetOpenInterestRequest> IOpenInterestRestClient.GetOpenInterestOptions { get; } = new EndpointOptions<GetOpenInterestRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };
        async Task<ExchangeWebResult<SharedOpenInterest>> IOpenInterestRestClient.GetOpenInterestAsync(GetOpenInterestRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IOpenInterestRestClient)this).GetOpenInterestOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedOpenInterest>(Exchange, validationError);

            var result = await ExchangeData.GetOpenInterestAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)), ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedOpenInterest>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedOpenInterest(result.Data.Quantity));
        }

        #endregion

        #region Funding Rate client
        GetFundingRateHistoryOptions IFundingRateRestClient.GetFundingRateHistoryOptions { get; } = new GetFundingRateHistoryOptions(false, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };

        async Task<ExchangeWebResult<IEnumerable<SharedFundingRate>>> IFundingRateRestClient.GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFundingRateRestClient)this).GetFundingRateHistoryOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedFundingRate>>(Exchange, validationError);

            int page = 1;
            int pageSize = 100;
            if (pageToken is PageToken token)
            {
                page = token.Page;
                pageSize = token.PageSize;
            }

            // Get data
            var result = await ExchangeData.GetHistoricalFundingRateAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                page: page,
                pageSize: pageSize,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedFundingRate>>(Exchange, default);

            PageToken? nextToken = null;
            if (result.Data.Count() == 100)
                nextToken = new PageToken(page + 1, pageSize);

            // Return
            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedFundingRate(x.FundingRate, x.FundingTime ?? default)), nextToken);
        }
        #endregion

        #region Futures Order Client

        PlaceFuturesOrderOptions IFuturesOrderRestClient.PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderOptions(
            new[]
            {
                SharedOrderType.Limit,
                SharedOrderType.Market
            },
            new[]
            {
                SharedTimeInForce.GoodTillCanceled,
                SharedTimeInForce.ImmediateOrCancel,
                SharedTimeInForce.FillOrKill
            },
            new SharedQuantitySupport(
                SharedQuantityType.BaseAssetQuantity,
                SharedQuantityType.BaseAssetQuantity,
                SharedQuantityType.BaseAssetQuantity,
                SharedQuantityType.BaseAssetQuantity))
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC"),
            },
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesOrderRequest.MarginMode), typeof(SharedMarginMode), "Isolated or cross margin mode", SharedMarginMode.Cross)
            }
        };

        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).PlaceFuturesOrderOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceOrderAsync(
                GetProductType(request.ApiType, exchangeParameters),
                request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)),
                exchangeParameters!.GetValue<string>(Exchange, "MarginAsset")!,
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderType == SharedOrderType.Limit ? OrderType.Limit : OrderType.Market,
                request.MarginMode == SharedMarginMode.Isolated ? MarginMode.IsolatedMargin : MarginMode.CrossMargin,
                quantity: request.Quantity ?? 0,
                price: request.Price,
                tradeSide: GetTradeSide(request),
                reduceOnly: request.ReduceOnly,
                timeInForce: request.TimeInForce == SharedTimeInForce.FillOrKill ? TimeInForce.FillOrKill : request.TimeInForce == SharedTimeInForce.ImmediateOrCancel ? TimeInForce.ImmediateOrCancel : request.TimeInForce == SharedTimeInForce.GoodTillCanceled ? TimeInForce.GoodTillCanceled : null,
                clientOrderId: request.ClientOrderId).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedId(result.Data.OrderId.ToString()));
        }

        EndpointOptions<GetOrderRequest> IFuturesOrderRestClient.GetFuturesOrderOptions { get; } = new EndpointOptions<GetOrderRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesOrder>> IFuturesOrderRestClient.GetFuturesOrderAsync(GetOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesOrderOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesOrder>(Exchange, validationError);

            var order = await Trading.GetOrderAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), request.OrderId).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedFuturesOrder>(Exchange, default);

            return order.AsExchangeResult(Exchange, new SharedFuturesOrder(
                order.Data.Symbol,
                order.Data.OrderId.ToString(),
                ParseOrderType(order.Data.OrderType),
                order.Data.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Data.Status),
                order.Data.CreateTime)
            {
                ClientOrderId = order.Data.ClientOrderId,
                AveragePrice = order.Data.AveragePrice,
                Price = order.Data.Price,
                Quantity = order.Data.Quantity,
                QuantityFilled = order.Data.QuantityFilled,
                QuoteQuantityFilled = order.Data.QuoteQuantityFilled,
                TimeInForce = ParseTimeInForce(order.Data.TimeInForce),
                UpdateTime = order.Data.UpdateTime,
                PositionSide = order.Data.PositionSide == PositionSide.Oneway ? SharedPositionSide.Both : order.Data.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = order.Data.ReduceOnly,
                Fee = order.Data.Fee
            });
        }

        EndpointOptions<GetOpenOrdersRequest> IFuturesOrderRestClient.GetOpenFuturesOrdersOptions { get; } = new EndpointOptions<GetOpenOrdersRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>> IFuturesOrderRestClient.GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetOpenFuturesOrdersOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedFuturesOrder>>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType));
            var orders = await Trading.GetOpenOrdersAsync(GetProductType(request.ApiType, exchangeParameters), symbol).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedFuturesOrder>>(Exchange, default);

            return orders.AsExchangeResult(Exchange, orders.Data.Orders.Select(x => new SharedFuturesOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                AveragePrice = x.AveragePrice,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                QuoteQuantityFilled = x.QuoteQuantityFilled,
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionSide == PositionSide.Oneway ? SharedPositionSide.Both : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
                Fee = x.Fee
            }));
        }

        PaginatedEndpointOptions<GetClosedOrdersRequest> IFuturesOrderRestClient.GetClosedFuturesOrdersOptions { get; } = new PaginatedEndpointOptions<GetClosedOrdersRequest>(true, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedFuturesOrder>>> IFuturesOrderRestClient.GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetClosedFuturesOrdersOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedFuturesOrder>>(Exchange, validationError);

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            // Get data
            var orders = await Trading.GetClosedOrdersAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)),
                startTime: fromTimestamp ?? request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit ?? 1000).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedFuturesOrder>>(Exchange, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (orders.Data.Orders.Count() == (request.Filter?.Limit ?? 1000))
                nextToken = new DateTimeToken(orders.Data.Orders.Max(o => o.CreateTime));

            return orders.AsExchangeResult(Exchange, orders.Data.Orders.Select(x => new SharedFuturesOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                AveragePrice = x.AveragePrice,
                Price = x.Price,
                Quantity = x.Quantity,
                QuantityFilled = x.QuantityFilled,
                QuoteQuantityFilled = x.QuoteQuantityFilled,
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionSide == PositionSide.Oneway ? SharedPositionSide.Both : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
                Fee = x.Fee
            }));
        }

        EndpointOptions<GetOrderTradesRequest> IFuturesOrderRestClient.GetFuturesOrderTradesOptions { get; } = new EndpointOptions<GetOrderTradesRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> IFuturesOrderRestClient.GetFuturesOrderTradesAsync(GetOrderTradesRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesOrderTradesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedUserTrade>>(Exchange, validationError);

            var orders = await Trading.GetUserTradesAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), orderId: request.OrderId).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            return orders.AsExchangeResult(Exchange, orders.Data.Trades.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Price = x.Price,
                Quantity = x.Quantity,
                Fee = x.Fees.Sum(x => x.TotalFee),
                FeeAsset = x.Fees.FirstOrDefault().FeeAsset,
                Role = x.Role == Role.Maker ? SharedRole.Maker : SharedRole.Taker
            }));
        }

        PaginatedEndpointOptions<GetUserTradesRequest> IFuturesOrderRestClient.GetFuturesUserTradesOptions { get; } = new PaginatedEndpointOptions<GetUserTradesRequest>(true, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> IFuturesOrderRestClient.GetFuturesUserTradesAsync(GetUserTradesRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesUserTradesOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedUserTrade>>(Exchange, validationError);

            // Determine page token
            string? fromId = null;
            if (pageToken is FromIdToken fromIdToken)
                fromId = fromIdToken.FromToken;

            // Get data
            var orders = await Trading.GetUserTradesAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)),
                startTime: request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit ?? 500,
                idLessThan: fromId
                ).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (orders.Data.Trades.Count() == (request.Filter?.Limit ?? 500))
                nextToken = new FromIdToken(orders.Data.EndId);

            return orders.AsExchangeResult(Exchange, orders.Data.Trades.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId.ToString(),
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Price = x.Price,
                Quantity = x.Quantity,
                Fee = x.Fees.Sum(x => x.TotalFee),
                FeeAsset = x.Fees.FirstOrDefault().FeeAsset,
                Role = x.Role == Role.Maker ? SharedRole.Maker : SharedRole.Taker
            }), nextToken);
        }

        EndpointOptions<CancelOrderRequest> IFuturesOrderRestClient.CancelFuturesOrderOptions { get; } = new EndpointOptions<CancelOrderRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.CancelFuturesOrderAsync(CancelOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).CancelFuturesOrderOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(GetProductType(request.ApiType, exchangeParameters), request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset, request.ApiType)), request.OrderId).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, default);

            return order.AsExchangeResult(Exchange, new SharedId(order.Data.OrderId.ToString()));
        }

        EndpointOptions<GetPositionsRequest> IFuturesOrderRestClient.GetPositionsOptions { get; } = new EndpointOptions<GetPositionsRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<IEnumerable<SharedPosition>>> IFuturesOrderRestClient.GetPositionsAsync(GetPositionsRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetPositionsOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<IEnumerable<SharedPosition>>(Exchange, validationError);

            WebCallResult<IEnumerable<Objects.Models.V2.BitgetPosition>> result;
            if (request.Symbol != null)
            {
                result = await Trading.GetPositionAsync(
                    GetProductType(request.ApiType, exchangeParameters),
                    symbol: request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                    marginAsset: exchangeParameters!.GetValue<string>(Exchange, "MarginAsset")!,
                    ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<IEnumerable<SharedPosition>>(Exchange, default);
            }
            else
            {
                var productType = GetProductType(request.ApiType, exchangeParameters);
                result = await Trading.GetPositionsAsync(productType, exchangeParameters!.GetValue<string>(Exchange, "MarginAsset")!, ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<IEnumerable<SharedPosition>>(Exchange, default);
            }

            return result.AsExchangeResult<IEnumerable<SharedPosition>>(Exchange, result.Data.Select(x => new SharedPosition(x.Symbol, x.Total, x.UpdateTime)
            {
                UnrealizedPnl = x.UnrealizedProfitAndLoss,
                LiquidationPrice = x.LiquidationPrice,
                AverageEntryPrice = x.AverageOpenPrice,
                Leverage = x.Leverage,
                MaintenanceMargin = x.MaintenanceMarginRate,
                PositionSide = x.PositionSide == PositionSide.Oneway ? SharedPositionSide.Both : x.PositionSide == PositionSide.Short ? SharedPositionSide.Short : SharedPositionSide.Long
            }).ToList());
        }

        EndpointOptions<ClosePositionRequest> IFuturesOrderRestClient.ClosePositionOptions { get; } = new EndpointOptions<ClosePositionRequest>(true);
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.ClosePositionAsync(ClosePositionRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).ClosePositionOptions.ValidateRequest(Exchange, request, exchangeParameters, request.ApiType, SupportedApiTypes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var result = await Trading.ClosePositionsAsync(
                GetProductType(request.ApiType, exchangeParameters),
                symbol: request.Symbol.GetSymbol((baseAsset, quoteAsset) => FormatSymbol(baseAsset, quoteAsset)),
                side: request.PositionSide == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedId(result.Data.Success.Single().ToString()));
        }

        private SharedOrderStatus ParseOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.New || status == OrderStatus.PartiallyFilled || status == OrderStatus.Initial || status == OrderStatus.Live) return SharedOrderStatus.Open;
            if (status == OrderStatus.Canceled) return SharedOrderStatus.Canceled;
            return SharedOrderStatus.Filled;
        }

        private SharedOrderType ParseOrderType(OrderType type)
        {
            if (type == OrderType.Market) return SharedOrderType.Market;
            if (type == OrderType.Limit) return SharedOrderType.Limit;

            return SharedOrderType.Other;
        }

        private SharedTimeInForce? ParseTimeInForce(TimeInForce? tif)
        {
            if (tif == null)
                return null;

            if (tif == TimeInForce.GoodTillCanceled) return SharedTimeInForce.GoodTillCanceled;
            if (tif == TimeInForce.ImmediateOrCancel) return SharedTimeInForce.ImmediateOrCancel;
            if (tif == TimeInForce.FillOrKill) return SharedTimeInForce.FillOrKill;

            return null;
        }

        private TradeSide? GetTradeSide(PlaceFuturesOrderRequest request)
        {
            if (request.PositionSide == SharedPositionSide.Both)
                return null;

            if (request.PositionSide == SharedPositionSide.Long)
            {
                return request.Side == SharedOrderSide.Buy ? TradeSide.Open : TradeSide.Close;
            }

            return request.Side == SharedOrderSide.Buy ? TradeSide.Close : TradeSide.Open;
        }

        #endregion

        private BitgetProductTypeV2 GetProductType(ApiType? apiType, ExchangeParameters? exchangeParameters)
        {
            if (apiType == ApiType.PerpetualInverse || apiType == ApiType.DeliveryInverse)
            {
                return BitgetProductTypeV2.CoinFutures;
            }

            var productTypeStr = exchangeParameters!.GetValue<string>(Exchange, "ProductType");
            return (BitgetProductTypeV2)Enum.Parse(typeof(BitgetProductTypeV2), productTypeStr);
        }
    }
}
