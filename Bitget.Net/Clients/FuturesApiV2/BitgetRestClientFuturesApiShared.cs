using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using System.Linq;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesApi : IBitgetRestClientFuturesApiShared
    {
        private const string _topicId = "BitgetFutures";
        public string Exchange => BitgetExchange.ExchangeName;
        public TradingMode[] SupportedTradingModes { get; } = new[] { TradingMode.PerpetualLinear, TradingMode.PerpetualInverse, TradingMode.DeliveryLinear, TradingMode.DeliveryInverse };

        public void SetDefaultExchangeParameter(string key, object value) => ExchangeParameters.SetStaticParameter(Exchange, key, value);
        public void ResetDefaultExchangeParameters() => ExchangeParameters.ResetStaticParameters();

        #region Balance client
        EndpointOptions<GetBalancesRequest> IBalanceRestClient.GetBalancesOptions { get; } = new EndpointOptions<GetBalancesRequest>(true);

        async Task<ExchangeWebResult<SharedBalance[]>> IBalanceRestClient.GetBalancesAsync(GetBalancesRequest request, CancellationToken ct)
        {
            var validationError = ((IBalanceRestClient)this).GetBalancesOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedBalance[]>(Exchange, validationError);

            var resultUsdt = Account.GetBalancesAsync(BitgetProductTypeV2.UsdtFutures, ct: ct);
            var resultUsdc = Account.GetBalancesAsync(BitgetProductTypeV2.UsdcFutures, ct: ct);
            await Task.WhenAll(resultUsdt, resultUsdc).ConfigureAwait(false);
            if (!resultUsdt.Result)
                return resultUsdt.Result.AsExchangeResult<SharedBalance[]>(Exchange, null, default);
            if (!resultUsdc.Result)
                return resultUsdc.Result.AsExchangeResult<SharedBalance[]>(Exchange, null, default);

            var result = new List<SharedBalance>();
            result.AddRange(resultUsdt.Result.Data.Select(x => new SharedBalance("USDT", x.MaxTransferable, x.Available)));
            result.AddRange(resultUsdc.Result.Data.Select(x => new SharedBalance("USDC", x.MaxTransferable, x.Available)));
            return resultUsdt.Result.AsExchangeResult<SharedBalance[]>(Exchange, SupportedTradingModes, result.ToArray());
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
        async Task<ExchangeWebResult<SharedFuturesTicker>> IFuturesTickerRestClient.GetFuturesTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTickerRestClient)this).GetFuturesTickerOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesTicker>(Exchange, validationError);

            var productType = GetProductType(request.Symbol.TradingMode, request.ExchangeParameters);

            var resultTicker = ExchangeData.GetTickerAsync(productType, request.Symbol.GetSymbol(FormatSymbol), ct);
            Task<WebCallResult<BitgetFundingTime>> resultFunding = Task.FromResult<WebCallResult<BitgetFundingTime>>(default!);
            if (!request.Symbol.TradingMode.IsDelivery())
                resultFunding = ExchangeData.GetNextFundingTimeAsync(productType, request.Symbol.GetSymbol(FormatSymbol), ct);
            var resultPrices = ExchangeData.GetPricesAsync(productType, request.Symbol.GetSymbol(FormatSymbol), ct);
            await Task.WhenAll(resultTicker, resultFunding, resultPrices).ConfigureAwait(false);
            if (!resultTicker.Result)
                return resultTicker.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, null, default);
            if (resultFunding.Result?.Success == false)
                return resultFunding.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, null, default);
            if (!resultPrices.Result)
                return resultPrices.Result.AsExchangeResult<SharedFuturesTicker>(Exchange, null, default);

            return resultTicker.Result.AsExchangeResult(Exchange,
                request.Symbol.TradingMode,
                new SharedFuturesTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicId, resultTicker.Result.Data.Symbol),
                    resultTicker.Result.Data.Symbol,
                    resultTicker.Result.Data.LastPrice,
                    resultTicker.Result.Data.HighPrice,
                    resultTicker.Result.Data.LowPrice,
                    resultTicker.Result.Data.Volume,
                    resultTicker.Result.Data.ChangePercentage24H * 100)
                {
                    MarkPrice = resultPrices.Result.Data.MarkPrice,
                    IndexPrice = resultPrices.Result.Data.IndexPrice,
                    FundingRate = resultTicker.Result.Data.FundingRate,
                    NextFundingTime = resultFunding.Result?.Data.NextFundingTime
                });
        }

        EndpointOptions<GetTickersRequest> IFuturesTickerRestClient.GetFuturesTickersOptions { get; } = new EndpointOptions<GetTickersRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<SharedFuturesTicker[]>> IFuturesTickerRestClient.GetFuturesTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTickerRestClient)this).GetFuturesTickersOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesTicker[]>(Exchange, validationError);

            var resultTickers = await ExchangeData.GetTickersAsync(GetProductType(request.TradingMode, request.ExchangeParameters), ct: ct).ConfigureAwait(false);
            if (!resultTickers)
                return resultTickers.AsExchangeResult<SharedFuturesTicker[]>(Exchange, null, default);

            IEnumerable<BitgetFuturesTicker> data = resultTickers.Data;
            if (request.TradingMode != null)
                data = data.Where(x => (request.TradingMode == TradingMode.DeliveryLinear || request.TradingMode == TradingMode.DeliveryInverse) ? x.DeliveryTime != null : x.DeliveryTime == null);

            return resultTickers.AsExchangeResult<SharedFuturesTicker[]>(Exchange, request.TradingMode == null ? SupportedTradingModes : new[] { request.TradingMode.Value }, data.Select(x =>
             new SharedFuturesTicker(ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), x.Symbol, x.LastPrice, x.HighPrice, x.LowPrice, x.Volume, x.ChangePercentage24H * 100)
                {
                    FundingRate = x.FundingRate,
                    IndexPrice = x.IndexPrice
                }
            ).ToArray());
        }

        #endregion

        #region Book Ticker client

        EndpointOptions<GetBookTickerRequest> IBookTickerRestClient.GetBookTickerOptions { get; } = new EndpointOptions<GetBookTickerRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedBookTicker>> IBookTickerRestClient.GetBookTickerAsync(GetBookTickerRequest request, CancellationToken ct)
        {
            var validationError = ((IBookTickerRestClient)this).GetBookTickerOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedBookTicker>(Exchange, validationError);

            var symbol = request.Symbol.GetSymbol(FormatSymbol);
            var resultTicker = await ExchangeData.GetOrderBookAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                symbol,
                null,
                1,
                ct: ct).ConfigureAwait(false);
            if (!resultTicker)
                return resultTicker.AsExchangeResult<SharedBookTicker>(Exchange, null, default);

            return resultTicker.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedBookTicker(
                ExchangeSymbolCache.ParseSymbol(_topicId, symbol),
                symbol,
                resultTicker.Data.Asks[0].Price,
                resultTicker.Data.Asks[0].Quantity,
                resultTicker.Data.Bids[0].Price,
                resultTicker.Data.Bids[0].Quantity));
        }

        #endregion

        #region Futures Symbol client

        EndpointOptions<GetSymbolsRequest> IFuturesSymbolRestClient.GetFuturesSymbolsOptions { get; } = new EndpointOptions<GetSymbolsRequest>(false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesSymbol[]>> IFuturesSymbolRestClient.GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesSymbolRestClient)this).GetFuturesSymbolsOptions.ValidateRequest(Exchange, request, request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesSymbol[]>(Exchange, validationError);

            var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
            var result = await ExchangeData.GetContractsAsync(
                productType,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedFuturesSymbol[]>(Exchange, null, default);

            IEnumerable<BitgetContract> data = result.Data;
            if (request.TradingMode != null)
            {
                data = data
                    .Where(x => ((request.TradingMode == TradingMode.PerpetualInverse || request.TradingMode == TradingMode.PerpetualLinear) && x.ContractType == ContractType.Perpetual)
                             || ((request.TradingMode == TradingMode.DeliveryLinear || request.TradingMode == TradingMode.DeliveryInverse) && x.ContractType == ContractType.Delivery));
            }

            var response = result.AsExchangeResult<SharedFuturesSymbol[]>(Exchange, request.TradingMode == null ? SupportedTradingModes: new[] { request.TradingMode.Value }, data.Select(s => 
            new SharedFuturesSymbol(
                productType == BitgetProductTypeV2.CoinFutures && s.ContractType == ContractType.Delivery ? TradingMode.DeliveryInverse :
                productType == BitgetProductTypeV2.CoinFutures && s.ContractType == ContractType.Perpetual ? TradingMode.PerpetualInverse :
                s.DeliveryPeriod.HasValue ? TradingMode.DeliveryLinear :
                TradingMode.PerpetualLinear,
                s.BaseAsset,
                s.QuoteAsset,
                s.Symbol, 
                s.Status == Enums.V2.FuturesSymbolStatus.Normal)
            {
                MinTradeQuantity = s.MinOrderQuantity,
                PriceDecimals = s.PriceDecimals,
                QuantityDecimals = s.QuantityDecimals,
                DeliveryTime = s.DeliveryTime,
                PriceStep = s.PriceStep,
                QuantityStep = s.QuantityStep,
                ContractSize = 1,
                MaxShortLeverage = s.MaxLeverage,
                MaxLongLeverage = s.MaxLeverage,
                MaxTradeQuantity = s.MaxLimitOrderQuantity == null && s.MaxLimitOrderQuantity == null ? null : Math.Min(s.MaxLimitOrderQuantity ?? decimal.MaxValue, s.MaxMarketOrderQuantity ?? decimal.MaxValue)
            }).ToArray());

            ExchangeSymbolCache.UpdateSymbolInfo(_topicId, response.Data);
            return response;
        }

        #endregion

        #region Klines client

        GetKlinesOptions IKlineRestClient.GetKlinesOptions { get; } = new GetKlinesOptions(SharedPaginationSupport.Descending, true, 1000, false,
            SharedKlineInterval.OneMinute,
            SharedKlineInterval.FiveMinutes,
            SharedKlineInterval.FifteenMinutes,
            SharedKlineInterval.ThirtyMinutes,
            SharedKlineInterval.OneHour,
            SharedKlineInterval.FourHours,
            SharedKlineInterval.SixHours,
            SharedKlineInterval.TwelveHours,
            SharedKlineInterval.OneDay,
            SharedKlineInterval.OneWeek,
            SharedKlineInterval.OneMonth)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<SharedKline[]>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<SharedKline[]>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IKlineRestClient)this).GetKlinesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedKline[]>(Exchange, validationError);

            // Determine pagination
            // Data is normally returned oldest first, so to do newest first pagination we have to do some calc
            DateTime endTime = request.EndTime ?? DateTime.UtcNow;
            DateTime? startTime = request.StartTime;
            if (pageToken is DateTimeToken dateTimeToken)
                endTime = dateTimeToken.LastTime;

            var limit = request.Limit ?? 1000;
            if (startTime == null || startTime < endTime)
            {
                var offset = (int)interval * limit;
                startTime = endTime.AddSeconds(-offset);
            }

            if (startTime < request.StartTime)
                startTime = request.StartTime;

            var result = await ExchangeData.GetKlinesAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                interval,
                KlineType.Market,
                startTime,
                endTime,
                limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedKline[]>(Exchange, null, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (result.Data.Count() == limit)
            {
                var minOpenTime = result.Data.Min(x => x.OpenTime);
                if (request.StartTime == null || minOpenTime > request.StartTime.Value)
                    nextToken = new DateTimeToken(minOpenTime.AddSeconds(-(int)(interval - 1)));
            }

            return result.AsExchangeResult<SharedKline[]>(Exchange, request.Symbol.TradingMode, result.Data.Reverse().Select(x => new SharedKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)).ToArray(), nextToken);
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
        async Task<ExchangeWebResult<SharedTrade[]>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            var validationError = ((IRecentTradeRestClient)this).GetRecentTradesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedTrade[]>(Exchange, validationError);

            var result = await ExchangeData.GetRecentTradesAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedTrade[]>(Exchange, null, default);

            return result.AsExchangeResult<SharedTrade[]>(Exchange, request.Symbol.TradingMode, result.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)
            {
                Side = x.Side == BitgetOrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell
            }).ToArray());
        }

        #endregion

        #region Leverage client
        SharedLeverageSettingMode ILeverageRestClient.LeverageSettingType => SharedLeverageSettingMode.PerSide;

        EndpointOptions<GetLeverageRequest> ILeverageRestClient.GetLeverageOptions { get; } = new EndpointOptions<GetLeverageRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedLeverage>> ILeverageRestClient.GetLeverageAsync(GetLeverageRequest request, CancellationToken ct)
        {
            var validationError = ((ILeverageRestClient)this).GetLeverageOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedLeverage>(Exchange, validationError);

            var result = await Trading.GetPositionAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol.GetSymbol(FormatSymbol),
                marginAsset: ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedLeverage>(Exchange, null, default);

            var position = result.Data.SingleOrDefault(x => x.PositionSide == (request.PositionSide == null ? PositionSide.Oneway : request.PositionSide == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long));

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedLeverage(position?.Leverage ?? 0));
        }

        SetLeverageOptions ILeverageRestClient.SetLeverageOptions { get; } = new SetLeverageOptions()
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedLeverage>> ILeverageRestClient.SetLeverageAsync(SetLeverageRequest request, CancellationToken ct)
        {
            var validationError = ((ILeverageRestClient)this).SetLeverageOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedLeverage>(Exchange, validationError);

            var result = await Account.SetLeverageAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol.GetSymbol(FormatSymbol),
                marginAsset: ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                (int)request.Leverage,
                side: request.Side == null ? null : request.Side == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedLeverage>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedLeverage(request.Leverage)
            {
                Side = request.Side
            });
        }
        #endregion

        #region Mark Klines client

        GetKlinesOptions IMarkPriceKlineRestClient.GetMarkPriceKlinesOptions { get; } = new GetKlinesOptions(SharedPaginationSupport.Descending, true, 200, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };

        async Task<ExchangeWebResult<SharedFuturesKline[]>> IMarkPriceKlineRestClient.GetMarkPriceKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<SharedFuturesKline[]>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IMarkPriceKlineRestClient)this).GetMarkPriceKlinesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesKline[]>(Exchange, validationError);

            // Determine pagination
            // Data is normally returned oldest first, so to do newest first pagination we have to do some calc
            DateTime endTime = RoundUp(request.EndTime ?? DateTime.UtcNow, TimeSpan.FromSeconds((int)interval));
            DateTime? startTime = request.StartTime;
            if (pageToken is DateTimeToken dateTimeToken)
                endTime = dateTimeToken.LastTime;

            var limit = request.Limit ?? 200;
            if (startTime == null || startTime < endTime)
            {
                var offset = (int)interval * limit;
                startTime = endTime.AddSeconds(-offset);
            }

            if (startTime < request.StartTime)
                startTime = request.StartTime;

            var result = await ExchangeData.GetHistoricalMarkPriceKlinesAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                interval,
                startTime,
                endTime,
                limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedFuturesKline[]>(Exchange, null, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (result.Data.Count() == limit)
            {
                var minOpenTime = result.Data.Min(x => x.OpenTime);
                if (request.StartTime == null || minOpenTime > request.StartTime.Value)
                    nextToken = new DateTimeToken(minOpenTime);
            }

            return result.AsExchangeResult<SharedFuturesKline[]>(Exchange, request.Symbol.TradingMode, result.Data.Reverse().Select(x => new SharedFuturesKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice)).ToArray(), nextToken);
        }

        #endregion

        #region Index Klines client

        GetKlinesOptions IIndexPriceKlineRestClient.GetIndexPriceKlinesOptions { get; } = new GetKlinesOptions(SharedPaginationSupport.Descending, true, 200, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<SharedFuturesKline[]>> IIndexPriceKlineRestClient.GetIndexPriceKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var interval = (Enums.BitgetFuturesKlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.BitgetFuturesKlineInterval), interval))
                return new ExchangeWebResult<SharedFuturesKline[]>(Exchange, new ArgumentError("Interval not supported"));

            var validationError = ((IMarkPriceKlineRestClient)this).GetMarkPriceKlinesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesKline[]>(Exchange, validationError);

            // Determine pagination
            // Data is normally returned oldest first, so to do newest first pagination we have to do some calc
            DateTime endTime = RoundUp(request.EndTime ?? DateTime.UtcNow, TimeSpan.FromSeconds((int)interval));
            DateTime? startTime = request.StartTime;
            if (pageToken is DateTimeToken dateTimeToken)
                endTime = dateTimeToken.LastTime;

            var limit = request.Limit ?? 200;
            if (startTime == null || startTime < endTime)
            {
                var offset = (int)interval * limit;
                startTime = endTime.AddSeconds(-offset);
            }

            if (startTime < request.StartTime)
                startTime = request.StartTime;

            var result = await ExchangeData.GetHistoricalIndexPriceKlinesAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                interval,
                startTime,
                endTime,
                limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedFuturesKline[]>(Exchange, null, default);

            // Get next token
            DateTimeToken? nextToken = null;
            if (result.Data.Count() == limit)
            {
                var minOpenTime = result.Data.Min(x => x.OpenTime);
                if (request.StartTime == null || minOpenTime > request.StartTime.Value)
                    nextToken = new DateTimeToken(minOpenTime);
            }

            return result.AsExchangeResult<SharedFuturesKline[]>(Exchange, request.Symbol.TradingMode, result.Data.Reverse().Select(x => new SharedFuturesKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice)).ToArray(), nextToken);
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
        async Task<ExchangeWebResult<SharedOrderBook>> IOrderBookRestClient.GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
        {
            var validationError = ((IOrderBookRestClient)this).GetOrderBookOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedOrderBook>(Exchange, validationError);

            var result = await ExchangeData.GetOrderBookAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedOrderBook>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedOrderBook(result.Data.Asks, result.Data.Bids));
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
        async Task<ExchangeWebResult<SharedOpenInterest>> IOpenInterestRestClient.GetOpenInterestAsync(GetOpenInterestRequest request, CancellationToken ct)
        {
            var validationError = ((IOpenInterestRestClient)this).GetOpenInterestOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedOpenInterest>(Exchange, validationError);

            var result = await ExchangeData.GetOpenInterestAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedOpenInterest>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedOpenInterest(result.Data.Quantity));
        }

        #endregion

        #region Funding Rate client
        GetFundingRateHistoryOptions IFundingRateRestClient.GetFundingRateHistoryOptions { get; } = new GetFundingRateHistoryOptions(SharedPaginationSupport.Descending, true, 100, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
            }
        };

        async Task<ExchangeWebResult<SharedFundingRate[]>> IFundingRateRestClient.GetFundingRateHistoryAsync(GetFundingRateHistoryRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var validationError = ((IFundingRateRestClient)this).GetFundingRateHistoryOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFundingRate[]>(Exchange, validationError);

            int page = 1;
            int pageSize = request.Limit ?? 100;
            if (pageToken is PageToken token)
            {
                page = token.Page;
                pageSize = token.PageSize;
            }

            // Get data
            var result = await ExchangeData.GetHistoricalFundingRateAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                page: page,
                pageSize: pageSize,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedFundingRate[]>(Exchange, null, default);

            PageToken? nextToken = null;
            if (result.Data.Count() == pageSize && (request.StartTime == null || result.Data.Min(x => x.FundingTime) > request.StartTime))
                nextToken = new PageToken(page + 1, pageSize);

            // Return
            return result.AsExchangeResult<SharedFundingRate[]>(Exchange, request.Symbol.TradingMode,result.Data.Where(x => request.StartTime == null ? true : x.FundingTime >= request.StartTime).Select(x => new SharedFundingRate(x.FundingRate, x.FundingTime ?? default)).ToArray(), nextToken);
        }
        #endregion

        #region Futures Order Client

        SharedFeeDeductionType IFuturesOrderRestClient.FuturesFeeDeductionType => SharedFeeDeductionType.AddToCost;
        SharedFeeAssetType IFuturesOrderRestClient.FuturesFeeAssetType => SharedFeeAssetType.InputAsset;
        SharedOrderType[] IFuturesOrderRestClient.FuturesSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.Market };
        SharedTimeInForce[] IFuturesOrderRestClient.FuturesSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        SharedQuantitySupport IFuturesOrderRestClient.FuturesSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset);

        string IFuturesOrderRestClient.GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        PlaceFuturesOrderOptions IFuturesOrderRestClient.PlaceFuturesOrderOptions { get; } = new PlaceFuturesOrderOptions(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC"),
            }
        };
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.PlaceFuturesOrderAsync(PlaceFuturesOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).PlaceFuturesOrderOptions.ValidateRequest(
                Exchange,
                request,
                request.Symbol.TradingMode,
                SupportedTradingModes,
                ((IFuturesOrderRestClient)this).FuturesSupportedOrderTypes,
                ((IFuturesOrderRestClient)this).FuturesSupportedTimeInForce,
                ((IFuturesOrderRestClient)this).FuturesSupportedOrderQuantity);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var (side, posSide) = GetTradeSide(request);
            var result = await Trading.PlaceOrderAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                side,
                request.OrderType == SharedOrderType.Limit ? OrderType.Limit : OrderType.Market,
                request.MarginMode == SharedMarginMode.Isolated ? MarginMode.IsolatedMargin : MarginMode.CrossMargin,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                price: request.Price,
                tradeSide: posSide,
                reduceOnly: request.ReduceOnly,
                timeInForce: request.TimeInForce == SharedTimeInForce.FillOrKill ? TimeInForce.FillOrKill : request.TimeInForce == SharedTimeInForce.ImmediateOrCancel ? TimeInForce.ImmediateOrCancel : request.TimeInForce == SharedTimeInForce.GoodTillCanceled ? TimeInForce.GoodTillCanceled : null,
                clientOrderId: request.ClientOrderId,
                takeProfitPrice: request.TakeProfitPrice,
                stopLossPrice: request.StopLossPrice,
                ct: ct).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(result.Data.OrderId.ToString()));
        }

        EndpointOptions<GetOrderRequest> IFuturesOrderRestClient.GetFuturesOrderOptions { get; } = new EndpointOptions<GetOrderRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesOrder>> IFuturesOrderRestClient.GetFuturesOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesOrder>(Exchange, validationError);

            var order = await Trading.GetOrderAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedFuturesOrder>(Exchange, null, default);

            return order.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, order.Data.Symbol), 
                order.Data.Symbol,
                order.Data.OrderId.ToString(),
                ParseOrderType(order.Data.OrderType),
                ParseSide(order.Data),
                ParseOrderStatus(order.Data.Status),
                order.Data.CreateTime)
            {
                ClientOrderId = order.Data.ClientOrderId,
                AveragePrice = order.Data.AveragePrice == 0 ? null : order.Data.AveragePrice,
                OrderPrice = order.Data.Price,
                OrderQuantity = new SharedOrderQuantity(order.Data.Quantity, contractQuantity: order.Data.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.Data.QuantityFilled, order.Data.QuoteQuantityFilled, contractQuantity: order.Data.QuantityFilled),
                TimeInForce = ParseTimeInForce(order.Data.TimeInForce),
                UpdateTime = order.Data.UpdateTime,
                PositionSide = order.Data.PositionSide == PositionSide.Oneway ? null : order.Data.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = order.Data.ReduceOnly,
                Fee = order.Data.Fee == null ? null : Math.Abs(order.Data.Fee.Value),
                TakeProfitPrice = order.Data.TakeProfitPrice,
                StopLossPrice = order.Data.StopLossPrice
            });
        }

        EndpointOptions<GetOpenOrdersRequest> IFuturesOrderRestClient.GetOpenFuturesOrdersOptions { get; } = new EndpointOptions<GetOpenOrdersRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesOrder[]>> IFuturesOrderRestClient.GetOpenFuturesOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetOpenFuturesOrdersOptions.ValidateRequest(Exchange, request, request.Symbol?.TradingMode ?? request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesOrder[]>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            var orders = await Trading.GetOpenOrdersAsync(GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters), symbol, ct: ct).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedFuturesOrder[]>(Exchange, null, default);

            return orders.AsExchangeResult<SharedFuturesOrder[]>(Exchange, request.Symbol == null ? SupportedTradingModes : new[] { request.Symbol.TradingMode }, orders.Data.Orders.Select(x => new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                ParseSide(x),
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                OrderPrice = x.Price,
                OrderQuantity = new SharedOrderQuantity(x.Quantity, contractQuantity: x.Quantity),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled, x.QuantityFilled),
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionSide == PositionSide.Oneway ? null : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
                Fee = x.Fee == null ? null : Math.Abs(x.Fee.Value),
                TakeProfitPrice = x.TakeProfitPrice,
                StopLossPrice = x.StopLossPrice
            }).ToArray());
        }

        PaginatedEndpointOptions<GetClosedOrdersRequest> IFuturesOrderRestClient.GetClosedFuturesOrdersOptions { get; } = new PaginatedEndpointOptions<GetClosedOrdersRequest>(SharedPaginationSupport.Descending, true, 100, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedFuturesOrder[]>> IFuturesOrderRestClient.GetClosedFuturesOrdersAsync(GetClosedOrdersRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetClosedFuturesOrdersOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesOrder[]>(Exchange, validationError);

            // Determine page token
            string? fromId = null;
            if (pageToken is FromIdToken idToken)
                fromId = idToken.FromToken;

            // Get data
            var limit = request.Limit ?? 1000;
            var orders = await Trading.GetClosedOrdersAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol),
                startTime: request.StartTime,
                endTime: request.EndTime,
                limit: limit,
                idLessThan: fromId,
                ct: ct).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedFuturesOrder[]>(Exchange, null, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (orders.Data.Orders.Count() == limit)
                nextToken = new FromIdToken(orders.Data.Orders.OrderBy(x => x.CreateTime).First().OrderId);

            return orders.AsExchangeResult<SharedFuturesOrder[]>(Exchange, SupportedTradingModes ,orders.Data.Orders.Select(x => new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType),
                ParseSide(x),
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                OrderPrice = x.Price,
                OrderQuantity = new SharedOrderQuantity(x.Quantity, contractQuantity: x.Quantity),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled, x.QuantityFilled),
                TimeInForce = ParseTimeInForce(x.TimeInForce),
                UpdateTime = x.UpdateTime,
                PositionSide = x.PositionSide == PositionSide.Oneway ? null : x.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = x.ReduceOnly,
                Fee = x.Fee == null ? null : Math.Abs(x.Fee.Value),
                TakeProfitPrice = x.TakeProfitPrice,
                StopLossPrice = x.StopLossPrice
            }).ToArray(), nextToken);
        }

        EndpointOptions<GetOrderTradesRequest> IFuturesOrderRestClient.GetFuturesOrderTradesOptions { get; } = new EndpointOptions<GetOrderTradesRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedUserTrade[]>> IFuturesOrderRestClient.GetFuturesOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesOrderTradesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedUserTrade[]>(Exchange, validationError);

            var orders = await Trading.GetUserTradesAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), orderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedUserTrade[]>(Exchange, null, default);

            return orders.AsExchangeResult<SharedUserTrade[]>(Exchange, request.Symbol.TradingMode,orders.Data.Trades.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Price = x.Price,
                Quantity = x.Quantity,
                Fee = Math.Abs(x.Fees.Sum(x => x.TotalFee)),
                FeeAsset = x.Fees.FirstOrDefault()?.FeeAsset,
                Role = x.Role == Role.Maker ? SharedRole.Maker : SharedRole.Taker
            }).ToArray());
        }

        PaginatedEndpointOptions<GetUserTradesRequest> IFuturesOrderRestClient.GetFuturesUserTradesOptions { get; } = new PaginatedEndpointOptions<GetUserTradesRequest>(SharedPaginationSupport.Descending, true, 100, true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedUserTrade[]>> IFuturesOrderRestClient.GetFuturesUserTradesAsync(GetUserTradesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesUserTradesOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedUserTrade[]>(Exchange, validationError);

            // Determine page token
            string? fromId = null;
            if (pageToken is FromIdToken fromIdToken)
                fromId = fromIdToken.FromToken;

            // Get data
            var orders = await Trading.GetUserTradesAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol),
                startTime: request.StartTime,
                endTime: request.EndTime,
                limit: request.Limit ?? 100,
                idLessThan: fromId,
                ct: ct
                ).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedUserTrade[]>(Exchange, null, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (orders.Data.Trades.Count() == (request.Limit ?? 500))
                nextToken = new FromIdToken(orders.Data.EndId);

            return orders.AsExchangeResult<SharedUserTrade[]>(Exchange, request.Symbol.TradingMode,orders.Data.Trades.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                x.TradeId.ToString(),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Price = x.Price,
                Quantity = x.Quantity,
                Fee = Math.Abs(x.Fees.Sum(x => x.TotalFee)),
                FeeAsset = x.Fees.FirstOrDefault()?.FeeAsset,
                Role = x.Role == Role.Maker ? SharedRole.Maker : SharedRole.Taker
            }).ToArray(), nextToken);
        }

        EndpointOptions<CancelOrderRequest> IFuturesOrderRestClient.CancelFuturesOrderOptions { get; } = new EndpointOptions<CancelOrderRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.CancelFuturesOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).CancelFuturesOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, null, default);

            return order.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(order.Data.OrderId.ToString()));
        }

        EndpointOptions<GetPositionsRequest> IFuturesOrderRestClient.GetPositionsOptions { get; } = new EndpointOptions<GetPositionsRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedPosition[]>> IFuturesOrderRestClient.GetPositionsAsync(GetPositionsRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetPositionsOptions.ValidateRequest(Exchange, request, request.Symbol?.TradingMode ?? request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedPosition[]>(Exchange, validationError);

            WebCallResult<Objects.Models.V2.BitgetPosition[]> result;
            if (request.Symbol != null)
            {
                result = await Trading.GetPositionAsync(
                    GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                    symbol: request.Symbol.GetSymbol(FormatSymbol),
                    marginAsset: ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                    ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<SharedPosition[]>(Exchange, null, default);
            }
            else
            {
                var productType = GetProductType(request.TradingMode, request.ExchangeParameters);
                result = await Trading.GetPositionsAsync(productType, ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!, ct: ct).ConfigureAwait(false);
                if (!result)
                    return result.AsExchangeResult<SharedPosition[]>(Exchange, null, default);
            }

            return result.AsExchangeResult<SharedPosition[]>(Exchange, request.Symbol == null ? SupportedTradingModes : new[] { request.Symbol.TradingMode }, result.Data.Select(x => new SharedPosition(ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), x.Symbol, x.Total, x.UpdateTime)
            {
                UnrealizedPnl = x.UnrealizedProfitAndLoss,
                LiquidationPrice = x.LiquidationPrice,
                AverageOpenPrice = x.AverageOpenPrice,
                Leverage = x.Leverage,
                PositionSide = x.PositionSide == PositionSide.Short ? SharedPositionSide.Short : SharedPositionSide.Long
            }).ToArray());
        }

        EndpointOptions<ClosePositionRequest> IFuturesOrderRestClient.ClosePositionOptions { get; } = new EndpointOptions<ClosePositionRequest>(true);
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderRestClient.ClosePositionAsync(ClosePositionRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).ClosePositionOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var result = await Trading.ClosePositionsAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol.GetSymbol(FormatSymbol),
                side: request.PositionSide == null ? null : request.PositionSide == SharedPositionSide.Short ? PositionSide.Short : PositionSide.Long).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(result.Data.Success.Single().OrderId.ToString()));
        }

        private SharedOrderSide ParseSide(BitgetFuturesOrder x)
        {
            if (x.TradeSide == TradeSide.Open)
                return x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell;

            if (x.TradeSide == TradeSide.Close)
                return x.Side == OrderSide.Buy ? SharedOrderSide.Sell : SharedOrderSide.Buy;

            return x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell;
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

        private (OrderSide, TradeSide?) GetTradeSide(PlaceFuturesOrderRequest request)
        {
            if (request.PositionSide == null)
                // One way mode
                return (request.Side == SharedOrderSide.Buy ? OrderSide.Buy: OrderSide.Sell, null);

            if (request.PositionSide == SharedPositionSide.Long)
            {
                // Hedge mode long
                if (request.Side == SharedOrderSide.Buy)
                    return (OrderSide.Buy, TradeSide.Open);
                return (OrderSide.Buy, TradeSide.Close);
            }

            // Hedge mode short
            if (request.Side == SharedOrderSide.Buy)
                return (OrderSide.Sell, TradeSide.Close);
            return (OrderSide.Sell, TradeSide.Open);
        }

        #endregion

        #region Futures Client Id Order Client

        EndpointOptions<GetOrderRequest> IFuturesOrderClientIdRestClient.GetFuturesOrderByClientOrderIdOptions { get; } = new EndpointOptions<GetOrderRequest>(true);
        async Task<ExchangeWebResult<SharedFuturesOrder>> IFuturesOrderClientIdRestClient.GetFuturesOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).GetFuturesOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesOrder>(Exchange, validationError);

            var order = await Trading.GetOrderAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedFuturesOrder>(Exchange, null, default);

            return order.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedFuturesOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, order.Data.Symbol),
                order.Data.Symbol,
                order.Data.OrderId.ToString(),
                ParseOrderType(order.Data.OrderType),
                ParseSide(order.Data),
                ParseOrderStatus(order.Data.Status),
                order.Data.CreateTime)
            {
                ClientOrderId = order.Data.ClientOrderId,
                AveragePrice = order.Data.AveragePrice == 0 ? null : order.Data.AveragePrice,
                OrderPrice = order.Data.Price,
                OrderQuantity = new SharedOrderQuantity(order.Data.Quantity, contractQuantity: order.Data.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.Data.QuantityFilled, order.Data.QuoteQuantityFilled, order.Data.QuantityFilled),
                TimeInForce = ParseTimeInForce(order.Data.TimeInForce),
                UpdateTime = order.Data.UpdateTime,
                PositionSide = order.Data.PositionSide == PositionSide.Oneway ? null : order.Data.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ReduceOnly = order.Data.ReduceOnly,
                Fee = order.Data.Fee == null ? null : Math.Abs(order.Data.Fee.Value),
                TakeProfitPrice = order.Data.TakeProfitPrice,
                StopLossPrice = order.Data.StopLossPrice
            });
        }

        EndpointOptions<CancelOrderRequest> IFuturesOrderClientIdRestClient.CancelFuturesOrderByClientOrderIdOptions { get; } = new EndpointOptions<CancelOrderRequest>(true);
        async Task<ExchangeWebResult<SharedId>> IFuturesOrderClientIdRestClient.CancelFuturesOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesOrderRestClient)this).CancelFuturesOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(GetProductType(request.Symbol.TradingMode, request.ExchangeParameters), request.Symbol.GetSymbol(FormatSymbol), clientOrderId: request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, null, default);

            return order.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(order.Data.OrderId));
        }
        #endregion

        #region Position Mode client
        SharedPositionModeSelection IPositionModeRestClient.PositionModeSettingType => SharedPositionModeSelection.PerAccount;

        GetPositionModeOptions IPositionModeRestClient.GetPositionModeOptions { get; } = new GetPositionModeOptions()
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription("Symbol", typeof(SharedSymbol), "A symbol to request position mode for. Actual symbol doesn't matter as the setting is account wide", "ETH-USDT")
            },
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")                
            }
        };
        async Task<ExchangeWebResult<SharedPositionModeResult>> IPositionModeRestClient.GetPositionModeAsync(GetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = ((IPositionModeRestClient)this).GetPositionModeOptions.ValidateRequest(Exchange, request, request.Symbol?.TradingMode ?? request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedPositionModeResult>(Exchange, validationError);

            var productType = GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters);
            var result = await Account.GetBalanceAsync(
                productType,
                request.Symbol!.GetSymbol(FormatSymbol),
                ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedPositionModeResult>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, productType == BitgetProductTypeV2.CoinFutures ? new[] { TradingMode.DeliveryInverse, TradingMode.PerpetualInverse } : new[] { TradingMode.DeliveryLinear, TradingMode.PerpetualLinear }, new SharedPositionModeResult(result.Data.PositionMode == PositionMode.Hedge ? SharedPositionMode.HedgeMode : SharedPositionMode.OneWay));
        }

        SetPositionModeOptions IPositionModeRestClient.SetPositionModeOptions { get; } = new SetPositionModeOptions()
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ExchangeWebResult<SharedPositionModeResult>> IPositionModeRestClient.SetPositionModeAsync(SetPositionModeRequest request, CancellationToken ct)
        {
            var validationError = ((IPositionModeRestClient)this).SetPositionModeOptions.ValidateRequest(Exchange, request, request.Symbol?.TradingMode ?? request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedPositionModeResult>(Exchange, validationError);

            var productType = GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters);
            var result = await Account.SetPositionModeAsync(
                productType, 
                request.PositionMode == SharedPositionMode.HedgeMode ? PositionMode.Hedge : PositionMode.OneWay, ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedPositionModeResult>(Exchange, null, default);

            return result.AsExchangeResult(Exchange, productType == BitgetProductTypeV2.CoinFutures ? new[] { TradingMode.DeliveryInverse, TradingMode.PerpetualInverse } : new[] { TradingMode.DeliveryLinear, TradingMode.PerpetualLinear }, new SharedPositionModeResult(request.PositionMode));
        }
        #endregion

        #region Position History client

        GetPositionHistoryOptions IPositionHistoryRestClient.GetPositionHistoryOptions { get; } = new GetPositionHistoryOptions(SharedPaginationSupport.Descending, true, 100);
        async Task<ExchangeWebResult<SharedPositionHistory[]>> IPositionHistoryRestClient.GetPositionHistoryAsync(GetPositionHistoryRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var validationError = ((IPositionHistoryRestClient)this).GetPositionHistoryOptions.ValidateRequest(Exchange, request, request.Symbol?.TradingMode ?? request.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedPositionHistory[]>(Exchange, validationError);

            // Determine page token
            string? fromId = null;
            if (pageToken is FromIdToken token)
                fromId = token.FromToken;

            int limit = request.Limit ?? 100;

            // Get data
            var orders = await Trading.GetPositionHistoryAsync(
                GetProductType(request.Symbol?.TradingMode ?? request.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol?.GetSymbol(FormatSymbol),
                startTime: request.StartTime,
                endTime: request.EndTime,
                idLessThan: fromId,
                limit: limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedPositionHistory[]>(Exchange, null, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (!string.IsNullOrEmpty(orders.Data.EndId))
                nextToken = new FromIdToken(orders.Data.EndId);

            return orders.AsExchangeResult<SharedPositionHistory[]>(Exchange, request.Symbol == null ? SupportedTradingModes : new[] { request.Symbol.TradingMode }, orders.Data.Entries.Select(x => new SharedPositionHistory(
                ExchangeSymbolCache.ParseSymbol(_topicId, x.Symbol), 
                x.Symbol,
                x.Side == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                x.AverageOpenPrice,
                x.AverageClosePrice,
                x.CloseTotalPosition,
                x.NetProfit,
                x.UpdateTime)
            {
                PositionId = x.PositionId
            }).ToArray(), nextToken);
        }
        #endregion

        #region Fee Client
        EndpointOptions<GetFeeRequest> IFeeRestClient.GetFeeOptions { get; } = new EndpointOptions<GetFeeRequest>(false);

        async Task<ExchangeWebResult<SharedFee>> IFeeRestClient.GetFeesAsync(GetFeeRequest request, CancellationToken ct)
        {
            var validationError = ((IFeeRestClient)this).GetFeeOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFee>(Exchange, validationError);

            // Get data
            var result = await ExchangeData.GetVipFeeRatesAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedFee>(Exchange, null, default);

            // Return
            return result.AsExchangeResult(Exchange, SupportedTradingModes, new SharedFee(result.Data.First().MakerFeeRate * 100, result.Data.First().TakerFeeRate * 100));
        }
        #endregion

        #region Trigger Order Client
        PlaceFuturesTriggerOrderOptions IFuturesTriggerOrderRestClient.PlaceFuturesTriggerOrderOptions { get; } = new PlaceFuturesTriggerOrderOptions(false)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "PositionMode the account is in", SharedPositionMode.OneWay)
            }
            ,
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };
        async Task<ExchangeWebResult<SharedId>> IFuturesTriggerOrderRestClient.PlaceFuturesTriggerOrderAsync(PlaceFuturesTriggerOrderRequest request, CancellationToken ct)
        {
            var (side, tradeSide) = GetTradeSide(request);
            var validationError = ((IFuturesTriggerOrderRestClient)this).PlaceFuturesTriggerOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes, side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell, ((IFuturesOrderRestClient)this).FuturesSupportedOrderQuantity);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceTriggerOrderAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                TriggerPlanType.Normal,
                request.MarginMode == SharedMarginMode.Isolated ? MarginMode.IsolatedMargin : MarginMode.CrossMargin,
                side,
                request.OrderPrice != null ? OrderType.Limit : OrderType.Market,
                orderPrice: request.OrderPrice,
                quantity: request.Quantity?.QuantityInBaseAsset ?? request.Quantity?.QuantityInContracts ?? 0,
                triggerPrice: request.TriggerPrice,
                tradeSide: tradeSide,
                clientOrderId: request.ClientOrderId,
                //triggerPriceType: request.TriggerPriceType == null ? null : request.TriggerPriceType == SharedTriggerPriceType.LastPrice ? TriggerPriceType.LastPrice : TriggerPriceType.MarkPrice,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, null, default);

            // Return
            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(result.Data.OrderId.ToString()));
        }

        EndpointOptions<GetOrderRequest> IFuturesTriggerOrderRestClient.GetFuturesTriggerOrderOptions { get; } = new EndpointOptions<GetOrderRequest>(true);
        async Task<ExchangeWebResult<SharedFuturesTriggerOrder>> IFuturesTriggerOrderRestClient.GetFuturesTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTriggerOrderRestClient)this).GetFuturesTriggerOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedFuturesTriggerOrder>(Exchange, validationError);

            var orders = await Trading.GetOpenTriggerOrdersAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                TriggerPlanTypeFilter.Trigger,
                orderId: request.OrderId).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedFuturesTriggerOrder>(Exchange, null, default);

            if (!orders.Data.Orders.Any())
            {
                orders = await Trading.GetClosedTriggerOrdersAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                TriggerPlanTypeFilter.Trigger,
                orderId: request.OrderId).ConfigureAwait(false);
                if (!orders)
                    return orders.AsExchangeResult<SharedFuturesTriggerOrder>(Exchange, null, default);
            }

            if (!orders.Data.Orders.Any())
                return orders.AsExchangeError<SharedFuturesTriggerOrder>(Exchange, new ServerError("Order not found"));

            var order = orders.Data.Orders.Single();

            return orders.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedFuturesTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                order.OrderType == OrderType.Market ? SharedOrderType.Market : SharedOrderType.Limit,
                order.TradeSide == null ? null : order.TradeSide == TradeSide.Open ? SharedTriggerOrderDirection.Enter : SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order.Status),
                order.TriggerPrice ?? 0,
                null,
                order.CreateTime)
            {
                PlacedOrderId = order.OrderId,
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.Quantity, contractQuantity: order.Quantity),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, null, contractQuantity: order.QuantityFilled),
                UpdateTime = order.UpdateTime,
                PositionSide = order.PositionSide == PositionSide.Oneway ? null : order.PositionSide == PositionSide.Long ? SharedPositionSide.Long : SharedPositionSide.Short,
                ClientOrderId = order.ClientOrderId
            });
        }

        private SharedTriggerOrderStatus ParseTriggerOrderStatus(TriggerOrderStatus? status)
        {
            if (status == TriggerOrderStatus.Executed)
                return SharedTriggerOrderStatus.Filled;

            if (status == TriggerOrderStatus.FailedExecute || status == TriggerOrderStatus.Canceled)
                return SharedTriggerOrderStatus.CanceledOrRejected;

            return SharedTriggerOrderStatus.Active;
        }

        EndpointOptions<CancelOrderRequest> IFuturesTriggerOrderRestClient.CancelFuturesTriggerOrderOptions { get; } = new EndpointOptions<CancelOrderRequest>(true);
        async Task<ExchangeWebResult<SharedId>> IFuturesTriggerOrderRestClient.CancelFuturesTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTriggerOrderRestClient)this).CancelFuturesTriggerOrderOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var order = await Trading.CancelTriggerOrdersAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                orderIds: [new BitgetCancelOrderRequest { OrderId = request.OrderId }],
                ct: ct).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, null, default);

            return order.AsExchangeResult(Exchange, request.Symbol.TradingMode, new SharedId(request.OrderId));
        }


        private (OrderSide, TradeSide?) GetTradeSide(PlaceFuturesTriggerOrderRequest request)
        {
            if (request.PositionMode == SharedPositionMode.OneWay)
            {
                // One way mode
                return
                    (request.PositionSide == SharedPositionSide.Long && request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Buy :
                    request.PositionSide == SharedPositionSide.Long && request.OrderDirection == SharedTriggerOrderDirection.Exit ? OrderSide.Sell :
                    request.PositionSide == SharedPositionSide.Short && request.OrderDirection == SharedTriggerOrderDirection.Enter ? OrderSide.Sell : OrderSide.Buy, null);
            }

            if (request.PositionSide == SharedPositionSide.Long)
            {
                // Hedge mode long
                if (request.OrderDirection == SharedTriggerOrderDirection.Enter)
                    return (OrderSide.Buy, TradeSide.Open);
                return (OrderSide.Buy, TradeSide.Close);
            }

            // Hedge mode short
            if (request.OrderDirection == SharedTriggerOrderDirection.Enter)
                return (OrderSide.Sell, TradeSide.Open);
            return (OrderSide.Sell, TradeSide.Close);
        }
        #endregion

        #region Tp/SL Client
        EndpointOptions<SetTpSlRequest> IFuturesTpSlRestClient.SetFuturesTpSlOptions { get; } = new EndpointOptions<SetTpSlRequest>(true)
        {
            RequiredOptionalParameters = new List<ParameterDescription>
            {
                new ParameterDescription(nameof(PlaceFuturesTriggerOrderRequest.PositionMode), typeof(SharedPositionMode), "PositionMode the account is in", SharedPositionMode.OneWay)
            },
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures"),
                new ParameterDescription("MarginAsset", typeof(string), "The margin asset to be used", "USDC")
            }
        };

        async Task<ExchangeWebResult<SharedId>> IFuturesTpSlRestClient.SetFuturesTpSlAsync(SetTpSlRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTpSlRestClient)this).SetFuturesTpSlOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceTpSlOrderAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                request.Symbol.GetSymbol(FormatSymbol),
                ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "MarginAsset")!,
                request.TpSlSide == SharedTpSlSide.TakeProfit ? PlanType.PositionTakeProfit : PlanType.PositionStopLoss,
                null,
                request.TriggerPrice,
                hedgeModePositionSide: request.PositionMode != SharedPositionMode.HedgeMode ? null : request.PositionSide == SharedPositionSide.Long ? PositionSide.Long : PositionSide.Short,
                oneWaySide: request.PositionMode != SharedPositionMode.OneWay ? null : request.PositionSide == SharedPositionSide.Long ? OrderSide.Buy: OrderSide.Sell,
                ct: ct).ConfigureAwait(false);
           
            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, null, default);

            // Return
            return result.AsExchangeResult(Exchange, SupportedTradingModes, new SharedId(result.Data.OrderId.ToString()));
        }

        EndpointOptions<CancelTpSlRequest> IFuturesTpSlRestClient.CancelFuturesTpSlOptions { get; } = new EndpointOptions<CancelTpSlRequest>(true)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };

        async Task<ExchangeWebResult<bool>> IFuturesTpSlRestClient.CancelFuturesTpSlAsync(CancelTpSlRequest request, CancellationToken ct)
        {
            var validationError = ((IFuturesTpSlRestClient)this).CancelFuturesTpSlOptions.ValidateRequest(Exchange, request, request.Symbol.TradingMode, SupportedTradingModes);
            if (validationError != null)
                return new ExchangeWebResult<bool>(Exchange, validationError);

            var result = await Trading.CancelTriggerOrdersAsync(
                GetProductType(request.Symbol.TradingMode, request.ExchangeParameters),
                symbol: request.Symbol.GetSymbol(FormatSymbol),
                orderIds: [new BitgetCancelOrderRequest {
                    OrderId = request.OrderId
                }],
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<bool>(Exchange, null, default);

            // Return
            return result.AsExchangeResult(Exchange, request.Symbol.TradingMode, true);
        }

        #endregion

        private BitgetProductTypeV2 GetProductType(TradingMode? tradingMode, ExchangeParameters? exchangeParameters)
        {
            if (tradingMode == TradingMode.PerpetualInverse || tradingMode == TradingMode.DeliveryInverse)
            {
                return BitgetProductTypeV2.CoinFutures;
            }

            var productTypeStr = ExchangeParameters.GetValue<string>(exchangeParameters, Exchange, "ProductType");
            return (BitgetProductTypeV2)Enum.Parse(typeof(BitgetProductTypeV2), productTypeStr!);
        }

        public static DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new DateTime(dt.Ticks + delta, dt.Kind);
        }
    }
}
