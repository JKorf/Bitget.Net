using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetRestClientSpotApi : IBitgetRestClientSpotApiShared
    {
        private const string _topicId = "BitgetSpot";
        private const string _exchangeName = "Bitget";
        public TradingMode[] SupportedTradingModes { get; } = new[] { TradingMode.Spot };

        public void SetDefaultExchangeParameter(string key, object value) => ExchangeParameters.SetStaticParameter(Exchange, key, value);
        public void ResetDefaultExchangeParameters() => ExchangeParameters.ResetStaticParameters();
        public SharedClientInfo Discover() => SharedUtils.GetClientInfo(BitgetExchange.Metadata, this);
        private static HashSet<string> _exchangeSupportedFiatCurrencies = ["EUR", "USD", "BRL"];

        #region Kline client

        GetKlinesOptions IKlineRestClient.GetKlinesOptions { get; } = new GetKlinesOptions(_exchangeName, false, true, true, 1000, false,
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
            SharedKlineInterval.OneMonth);

        async Task<HttpResult<SharedKline[]>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var interval = (Enums.V2.KlineInterval)request.Interval;

            var validationError = SharedClient.GetKlinesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedKline[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var limit = request.Limit ?? 1000;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true);

            var result = await ExchangeData.GetKlinesAsync(
                symbol,
                interval,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedKline[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                    () => Pagination.NextPageFromTime(pageParams, result.Data.Min(x => x.OpenTime)),
                    result.Data.Length,
                    result.Data.Select(x => x.OpenTime),
                    request.StartTime,
                    request.EndTime ?? DateTime.UtcNow,
                    pageParams);

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.OpenTime, request.StartTime, request.EndTime, direction)
                   .Select(x => 
                        new SharedKline(
                            request.Symbol,
                            symbol,
                            x.OpenTime,
                            x.ClosePrice, 
                            x.HighPrice,
                            x.LowPrice,
                            x.OpenPrice,
                            x.Volume))
                   .ToArray(), nextPageRequest);
        }

        #endregion

        #region Spot Symbol client
        SharedSymbolCatalog? ISpotSymbolRestClient.SpotSymbolCatalog => ExchangeSymbolCache.GetSymbolCatalog(_topicId, EnvironmentName, null);
        GetSpotSymbolsOptions ISpotSymbolRestClient.GetSpotSymbolsOptions { get; } = new GetSpotSymbolsOptions(_exchangeName, false);

        async Task<HttpResult<SharedSpotSymbol[]>> ISpotSymbolRestClient.GetSpotSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotSymbol[]>(Exchange, validationError);

            var result = await _baseClient.UnifiedApi.ExchangeData.GetSpotSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotSymbol[]>(result);

            var data = result.Data
                .Select(x => ParseSymbol(x)!)
                .Where(x => x != null)
                .ToArray();

            ExchangeSymbolCache.UpdateSymbolInfo(_topicId, EnvironmentName, null, data);
            return HttpResult.Ok(result, SharedUtils.ApplySymbolFilter(data, request));
        }

        private SharedSpotSymbol ParseSymbol(BitgetUaSpotSymbol s)
        {
            var result = new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Symbol, s.Status == Enums.Uta.InstrumentStatus.Online)
            {
                MinTradeQuantity = s.MinOrderQuantity,
                MinNotionalValue = s.MinOrderValue,
                MaxTradeQuantity = s.MaxOrderQuantity,
                QuantityDecimals = s.QuantityPrecision,
                PriceDecimals = s.PricePrecision,
                DisplayName = s.Symbol
            };

            if (s.SymbolType == Enums.Uta.SymbolType.Commodity || s.SymbolType == Enums.Uta.SymbolType.Metal)
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Commodity;
            }
            else if (s.SymbolType == Enums.Uta.SymbolType.Stock)
            {
                result.BaseAssetType = SharedAssetType.TradFi;
                result.BaseAssetSubType = SharedAssetSubType.Equity;
            } 
            else if (LibraryHelpers.IsStableCoin(s.BaseAsset))
            {
                result.BaseAssetType = SharedAssetType.Crypto;
                result.BaseAssetSubType = SharedAssetSubType.StableCoin;
            }
            else if (_exchangeSupportedFiatCurrencies.Contains(s.BaseAsset))
            {
                result.BaseAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.BaseAssetType = SharedAssetType.Crypto;
            }

            if (LibraryHelpers.IsStableCoin(s.QuoteAsset))
            {
                result.QuoteAssetType = SharedAssetType.Crypto;
                result.QuoteAssetSubType = SharedAssetSubType.StableCoin;
            }
            else if (_exchangeSupportedFiatCurrencies.Contains(s.QuoteAsset))
            {
                result.QuoteAssetType = SharedAssetType.Fiat;
            }
            else
            {
                result.QuoteAssetType = SharedAssetType.Crypto;
            }

            return result;
        }

        async Task<ExchangeCallResult<SharedSymbol[]>> ISpotSymbolRestClient.GetSpotSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicId, EnvironmentName, null, baseAsset));
        }

        async Task<ExchangeCallResult<bool>> ISpotSymbolRestClient.SupportsSpotSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode != TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Only Spot symbols allowed");

            if (!ExchangeSymbolCache.HasCached(_topicId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicId, EnvironmentName, null, symbol));
        }

        async Task<ExchangeCallResult<bool>> ISpotSymbolRestClient.SupportsSpotSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicId, EnvironmentName, null))
            {
                var symbols = await ((ISpotSymbolRestClient)this).GetSpotSymbolsAsync(new GetSymbolsRequest()).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicId, EnvironmentName, null, symbolName));
        }
        #endregion

        #region Ticker client
        GetSpotTickerOptions ISpotTickerRestClient.GetSpotTickerOptions { get; } = new GetSpotTickerOptions(_exchangeName);

        async Task<HttpResult<SharedSpotTicker>> ISpotTickerRestClient.GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker>(Exchange, validationError);

            var result = await ExchangeData.GetTickersAsync(request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker>(result);

            var ticker = result.Data.Single();
            return HttpResult.Ok(result, new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, ticker.Symbol), ticker.Symbol, ticker.LastPrice, ticker.HighPrice, ticker.LowPrice, ticker.Volume, ticker.ChangePercentage24H * 100)
            {
                QuoteVolume = ticker.QuoteVolume
            });
        }

        GetSpotTickersOptions ISpotTickerRestClient.GetSpotTickersOptions { get; } = new GetSpotTickersOptions(_exchangeName);
        async Task<HttpResult<SharedSpotTicker[]>> ISpotTickerRestClient.GetSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker[]>(Exchange, validationError);

            var result = await ExchangeData.GetTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x => new SharedSpotTicker(ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, x.Symbol), x.Symbol, x.LastPrice, x.HighPrice, x.LowPrice, x.Volume, x.ChangePercentage24H * 100)
            {
                QuoteVolume = x.QuoteVolume
            }).ToArray());
        }

        #endregion

        #region Book Ticker client

        GetBookTickerOptions IBookTickerRestClient.GetBookTickerOptions { get; } = new GetBookTickerOptions(_exchangeName, false);
        async Task<HttpResult<SharedBookTicker>> IBookTickerRestClient.GetBookTickerAsync(GetBookTickerRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetBookTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBookTicker>(Exchange, validationError);

            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var resultTicker = await ExchangeData.GetOrderBookAsync(
                symbol,
                null,
                1,
                ct: ct).ConfigureAwait(false);
            if (!resultTicker.Success)
                return HttpResult.Fail<SharedBookTicker>(resultTicker);

            return HttpResult.Ok(resultTicker, new SharedBookTicker(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, symbol),
                symbol,
                resultTicker.Data.Asks[0].Price,
                resultTicker.Data.Asks[0].Quantity,
                resultTicker.Data.Bids[0].Price,
                resultTicker.Data.Bids[0].Quantity));
        }

        #endregion

        #region Recent Trade client

        GetRecentTradesOptions IRecentTradeRestClient.GetRecentTradesOptions { get; } = new GetRecentTradesOptions(_exchangeName, 500, false);

        async Task<HttpResult<SharedTrade[]>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetRecentTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTrade[]>(Exchange, validationError);

            // Get data
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await ExchangeData.GetRecentTradesAsync(
                symbol,
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTrade[]>(result);

            // Return
            return HttpResult.Ok(result, result.Data.Select(x => 
            new SharedTrade(request.Symbol, symbol, x.Quantity, x.Price, x.Timestamp)
            {
                Side = x.Side == BitgetOrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell
            }).ToArray());
        }

        #endregion

        #region Balance client
        GetBalancesOptions IBalanceRestClient.GetBalancesOptions { get; } = new GetBalancesOptions(_exchangeName, AccountTypeFilter.Spot, AccountTypeFilter.Funding);

        async Task<HttpResult<SharedBalance[]>> IBalanceRestClient.GetBalancesAsync(GetBalancesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetBalancesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedBalance[]>(Exchange, validationError);

            if (request.AccountType == SharedAccountType.Funding)
            {
                var result = await Account.GetFundingBalancesAsync(ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedBalance[]>(result);

                return HttpResult.Ok(result, result.Data.Select(x => 
                    new SharedBalance(
                        SupportedTradingModes, 
                        x.Asset,
                        x.Available,
                        x.Available + (x.Frozen ?? 0))).ToArray());
            }
            else
            {
                var result = await Account.GetSpotBalancesAsync(ct: ct).ConfigureAwait(false);
                if (!result.Success)
                    return HttpResult.Fail<SharedBalance[]>(result);

                return HttpResult.Ok(result, result.Data.Select(x => 
                    new SharedBalance(
                        SupportedTradingModes, 
                        x.Asset,
                        x.Available,
                        x.Available + x.Frozen)).ToArray());
            }
        }

        #endregion

        #region Spot Order client

        SharedFeeDeductionType ISpotOrderRestClient.SpotFeeDeductionType => SharedFeeDeductionType.DeductFromOutput;
        SharedFeeAssetType ISpotOrderRestClient.SpotFeeAssetType => SharedFeeAssetType.OutputAsset;
        SharedOrderType[] ISpotOrderRestClient.SpotSupportedOrderTypes { get; } = new[] { SharedOrderType.Limit, SharedOrderType.LimitMaker, SharedOrderType.Market };
        SharedTimeInForce[] ISpotOrderRestClient.SpotSupportedTimeInForce { get; } = new[] { SharedTimeInForce.GoodTillCanceled, SharedTimeInForce.ImmediateOrCancel, SharedTimeInForce.FillOrKill };
        SharedQuantitySupport ISpotOrderRestClient.SpotSupportedOrderQuantity { get; } = new SharedQuantitySupport(
                SharedQuantityType.BaseAsset,
                SharedQuantityType.BaseAsset,
                SharedQuantityType.QuoteAsset,
                SharedQuantityType.BaseAsset);

        string ISpotOrderRestClient.GenerateClientOrderId() => ExchangeHelpers.RandomString(32);

        PlaceSpotOrderOptions ISpotOrderRestClient.PlaceSpotOrderOptions { get; } = new PlaceSpotOrderOptions(_exchangeName);
        async Task<HttpResult<SharedId>> ISpotOrderRestClient.PlaceSpotOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.PlaceSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceOrderAsync(
                request.Symbol!.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                (request.OrderType == SharedOrderType.Limit || request.OrderType == SharedOrderType.LimitMaker) ? OrderType.Limit : OrderType.Market,
                quantity: (request.OrderType == SharedOrderType.Market && request.Side == SharedOrderSide.Buy ? request.Quantity?.QuantityInQuoteAsset : request.Quantity?.QuantityInBaseAsset) ?? 0,
                price: request.Price,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId,
                ct: ct).ConfigureAwait(false);

            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            return HttpResult.Ok(result, new SharedId(result.Data.OrderId));
        }

        GetSpotOrderOptions ISpotOrderRestClient.GetSpotOrderOptions { get; } = new GetSpotOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder>> ISpotOrderRestClient.GetSpotOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await Trading.GetOrderAsync(request.OrderId).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            if (!orders.Data.Any())
                return HttpResult.Fail<SharedSpotOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.Single();
            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType, null),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? null : order.Quantity, order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.QuoteQuantityFilled),                
                Fee = order.Fees?.NewFees?.TotalFee == null? null : Math.Abs(order.Fees.NewFees.TotalFee),
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                UpdateTime = order.UpdateTime,
                TriggerPrice = order.TriggerPrice,
                IsTriggerOrder = order.TriggerPrice != null
            });
        }

        GetOpenSpotOrdersOptions ISpotOrderRestClient.GetOpenSpotOrdersOptions { get; } = new GetOpenSpotOrdersOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder[]>> ISpotOrderRestClient.GetOpenSpotOrdersAsync(GetOpenOrdersRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOpenSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var symbol = request.Symbol?.GetSymbol(FormatSymbol);
            var orders = await Trading.GetOpenOrdersAsync(symbol).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(orders);

            return HttpResult.Ok(orders, orders.Data.Select(x => new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType, null),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                OrderPrice = x.Price,
                OrderQuantity = new SharedOrderQuantity(x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity, x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? x.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),                
                // Positive fees means rebate which we're not currently supported
                Fee = x.Fees?.NewFees?.TotalFee == null ? null : x.Fees.NewFees.TotalFee > 0 ? 0 : Math.Abs(x.Fees.NewFees.TotalFee),
                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                UpdateTime = x.UpdateTime,
                TriggerPrice = x.TriggerPrice,
                IsTriggerOrder = x.TriggerPrice != null
            }).ToArray());
        }

        GetSpotClosedOrdersOptions ISpotOrderRestClient.GetClosedSpotOrdersOptions { get; } = new GetSpotClosedOrdersOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90)
        };
        async Task<HttpResult<SharedSpotOrder[]>> ISpotOrderRestClient.GetClosedSpotOrdersAsync(GetClosedOrdersRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetClosedSpotOrdersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var result = await Trading.GetClosedOrdersAsync(request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotOrder[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => long.Parse(x.OrderId))),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxAge: TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x =>
                            new SharedSpotOrder(
                                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, x.Symbol), 
                                x.Symbol,
                                x.OrderId.ToString(),
                                ParseOrderType(x.OrderType, null),
                                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                                ParseOrderStatus(x.Status),
                                x.CreateTime)
                            {
                                ClientOrderId = x.ClientOrderId,
                                OrderPrice = x.Price,
                                OrderQuantity = new SharedOrderQuantity(x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity, x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? x.Quantity : null),
                                QuantityFilled = new SharedOrderQuantity(x.QuantityFilled, x.QuoteQuantityFilled),
                                // Positive fees means rebate which we're not currently supported
                                Fee = x.Fees?.NewFees?.TotalFee == null ? null : x.Fees.NewFees.TotalFee > 0 ? 0 : Math.Abs(x.Fees.NewFees.TotalFee),
                                AveragePrice = x.AveragePrice == 0 ? null : x.AveragePrice,
                                UpdateTime = x.UpdateTime,
                                TriggerPrice = x.TriggerPrice,
                                IsTriggerOrder = x.TriggerPrice != null
                            })
                       .ToArray(), nextPageRequest);
        }

        GetSpotOrderTradesOptions ISpotOrderRestClient.GetSpotOrderTradesOptions { get; } = new GetSpotOrderTradesOptions(_exchangeName, true);
        async Task<HttpResult<SharedUserTrade[]>> ISpotOrderRestClient.GetSpotOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var trades = await Trading.GetUserTradesAsync(request.Symbol!.GetSymbol(FormatSymbol), orderId: request.OrderId).ConfigureAwait(false);
            if (!trades.Success)
                return HttpResult.Fail<SharedUserTrade[]>(trades);

            return HttpResult.Ok(trades, trades.Data.Select(x => new SharedUserTrade(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, x.Symbol), 
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                // Positive fees means rebate which we're not currently supported
                Fee = x.Fees.TotalFee > 0 ? 0 : Math.Abs(x.Fees.TotalFee),
                FeeAsset = x.Fees.FeeAsset,
                Role = x.Role == Role.Taker ? SharedRole.Taker: SharedRole.Maker
            }).ToArray());
        }

        GetSpotUserTradesOptions ISpotOrderRestClient.GetSpotUserTradesOptions { get; } = new GetSpotUserTradesOptions(_exchangeName, false, true, true, 100)
        {
            MaxAge = TimeSpan.FromDays(90)
        };
        async Task<HttpResult<SharedUserTrade[]>> ISpotOrderRestClient.GetSpotUserTradesAsync(GetUserTradesRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotUserTradesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedUserTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest);

            // Get data
            var result = await Trading.GetUserTradesAsync(request.Symbol!.GetSymbol(FormatSymbol),
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedUserTrade[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => long.Parse(x.OrderId))),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxAge: TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x =>
                           new SharedUserTrade(
                               ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, x.Symbol), 
                               x.Symbol,
                               x.OrderId,
                               x.TradeId,
                               x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                               x.Quantity,
                               x.Price,
                               x.CreateTime)
                            {
                                // Positive fees means rebate which we're not currently supported
                                Fee = x.Fees.TotalFee > 0 ? 0 : Math.Abs(x.Fees.TotalFee),
                                FeeAsset = x.Fees.FeeAsset,
                                Role = x.Role == Role.Taker ? SharedRole.Taker : SharedRole.Maker
                            })
                       .ToArray(), nextPageRequest);
        }

        CancelSpotOrderOptions ISpotOrderRestClient.CancelSpotOrderOptions { get; } = new CancelSpotOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotOrderRestClient.CancelSpotOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(request.Symbol!.GetSymbol(FormatSymbol), request.OrderId).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }

        private SharedOrderStatus ParseOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Canceled || status == OrderStatus.Rejected)
                return SharedOrderStatus.Canceled;
            if (status == OrderStatus.Initial || status == OrderStatus.Live || status == OrderStatus.New || status == OrderStatus.PartiallyFilled)
                return SharedOrderStatus.Open;
            if (status == OrderStatus.Filled)
                return SharedOrderStatus.Filled;

            return SharedOrderStatus.Unknown;
        }

        private SharedOrderType ParseOrderType(OrderType type, TimeInForce? tif)
        {
            if (type == OrderType.Market) return SharedOrderType.Market;
            if (type == OrderType.Limit && tif == TimeInForce.PostOnly) return SharedOrderType.LimitMaker;
            if (type == OrderType.Limit) return SharedOrderType.Limit;

            return SharedOrderType.Other;
        }

        private TimeInForce GetTimeInForce(SharedOrderType type, SharedTimeInForce? tif)
        {
            if (type == SharedOrderType.LimitMaker) return TimeInForce.PostOnly;
            if (type == SharedOrderType.Market) return TimeInForce.FillOrKill;
            if (tif == SharedTimeInForce.ImmediateOrCancel) return TimeInForce.ImmediateOrCancel;
            if (tif == SharedTimeInForce.FillOrKill) return TimeInForce.FillOrKill;
            if (tif == SharedTimeInForce.GoodTillCanceled) return TimeInForce.GoodTillCanceled;

            return TimeInForce.GoodTillCanceled;
        }

        #endregion

        #region Spot Client Id Order Client

        GetSpotOrderByClientOrderIdOptions ISpotOrderClientIdRestClient.GetSpotOrderByClientOrderIdOptions { get; } = new GetSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotOrder>> ISpotOrderClientIdRestClient.GetSpotOrderByClientOrderIdAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotOrder>(Exchange, validationError);

            var orders = await Trading.GetOrderAsync(clientOrderId: request.OrderId).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotOrder>(orders);

            if (!orders.Data.Any())
                return HttpResult.Fail<SharedSpotOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.Single();
            return HttpResult.Ok(orders, new SharedSpotOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType, null),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? null : order.Quantity, order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.QuoteQuantityFilled),
                Fee = order.Fees?.NewFees?.TotalFee == null ? null : Math.Abs(order.Fees.NewFees.TotalFee),
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                UpdateTime = order.UpdateTime,
                TriggerPrice = order.TriggerPrice,
                IsTriggerOrder = order.TriggerPrice != null
            });
        }

        CancelSpotOrderByClientOrderIdOptions ISpotOrderClientIdRestClient.CancelSpotOrderByClientOrderIdOptions { get; } = new CancelSpotOrderByClientOrderIdOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotOrderClientIdRestClient.CancelSpotOrderByClientOrderIdAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(request.Symbol!.GetSymbol(FormatSymbol), clientOrderId: request.OrderId).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }
        #endregion

        #region Asset client
        GetAssetsOptions IAssetsRestClient.GetAssetsOptions { get; } = new GetAssetsOptions(_exchangeName, false);

        async Task<HttpResult<SharedAsset[]>> IAssetsRestClient.GetAssetsAsync(GetAssetsRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetAssetsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset[]>(Exchange, validationError);

            var assets = await ExchangeData.GetAssetsAsync(ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset[]>(assets);

            return HttpResult.Ok(assets, assets.Data.Select(x => new SharedAsset(x.Name)
            {
                Networks = x.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.DepositConfirm ?? x.WithdrawConfirm,
                    DepositEnabled = x.Depositable,
                    MinWithdrawQuantity = x.MinWithdrawQuantity,
                    WithdrawEnabled = x.Withdrawable,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            }).ToArray());
        }

        GetAssetOptions IAssetsRestClient.GetAssetOptions { get; } = new GetAssetOptions(_exchangeName, false);
        async Task<HttpResult<SharedAsset>> IAssetsRestClient.GetAssetAsync(GetAssetRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetAssetOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedAsset>(Exchange, validationError);

            var assets = await ExchangeData.GetAssetsAsync(request.Asset, ct: ct).ConfigureAwait(false);
            if (!assets.Success)
                return HttpResult.Fail<SharedAsset>(assets);

            var asset = assets.Data.SingleOrDefault();
            if (asset == null)
                return HttpResult.Fail<SharedAsset>(assets, new ServerError(new ErrorInfo(ErrorType.UnknownAsset, "Asset not found")));

            return HttpResult.Ok(assets, new SharedAsset(asset.Name)
            {
                Networks = asset.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.DepositConfirm ?? x.WithdrawConfirm,
                    DepositEnabled = x.Depositable,
                    MinWithdrawQuantity = x.MinWithdrawQuantity,
                    WithdrawEnabled = x.Withdrawable,
                    WithdrawFee = x.WithdrawFee,
                    ContractAddress = x.ContractAddress
                }).ToArray()
            });
        }

        #endregion

        #region Deposit client

        GetDepositAddressesOptions IDepositRestClient.GetDepositAddressesOptions { get; } = new GetDepositAddressesOptions(_exchangeName, true);
        async Task<HttpResult<SharedDepositAddress[]>> IDepositRestClient.GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetDepositAddressesOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDepositAddress[]>(Exchange, validationError);

            var depositAddresses = await Account.GetDepositAddressAsync(request.Asset, request.Network).ConfigureAwait(false);
            if (!depositAddresses.Success)
                return HttpResult.Fail<SharedDepositAddress[]>(depositAddresses);

            return HttpResult.Ok(depositAddresses, new[] { new SharedDepositAddress(depositAddresses.Data.Asset, depositAddresses.Data.Address)
            {
                TagOrMemo = depositAddresses.Data.Tag,
                Network = depositAddresses.Data.Network
            }
            });
        }

        GetDepositsOptions IDepositRestClient.GetDepositsOptions { get; } = new GetDepositsOptions(_exchangeName, false, true, true, 100);
        async Task<HttpResult<SharedDeposit[]>> IDepositRestClient.GetDepositsAsync(GetDepositsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetDepositsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedDeposit[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(90));

            // Get data
            var time = DateTime.UtcNow;
            var result = await Account.GetDepositHistoryAsync(
                startTime: pageParams.StartTime ?? time.AddDays(-90),
                endTime: pageParams.EndTime ?? time,
                asset: request.Asset,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedDeposit[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => long.Parse(x.OrderId))),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedDeposit(
                                x.Asset,
                                x.Quantity,
                                x.Status == TransferStatus.Success,
                                x.CreateTime,
                                ParseTransferStatus(x.Status))
                            {
                                Id = x.OrderId,
                                Network = x.Network,
                                TransactionId = x.TransactionId,
                            })
                       .ToArray(), nextPageRequest);
        }

        private SharedTransferStatus ParseTransferStatus(TransferStatus status)
        {
            if (status == TransferStatus.Success)
                return SharedTransferStatus.Completed;
            if (status == TransferStatus.Failed)
                return SharedTransferStatus.Failed;
            if (status == TransferStatus.Processing)
                return SharedTransferStatus.InProgress;

            return SharedTransferStatus.Unknown;
        }

        #endregion

        #region Order Book client

        GetOrderBookOptions IOrderBookRestClient.GetOrderBookOptions { get; } = new GetOrderBookOptions(_exchangeName, 1, 150, false);
        async Task<HttpResult<SharedOrderBook>> IOrderBookRestClient.GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetOrderBookOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedOrderBook>(Exchange, validationError);

            var result = await ExchangeData.GetOrderBookAsync(
                request.Symbol!.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedOrderBook>(result);

            return HttpResult.Ok(result, new SharedOrderBook(result.Data.Asks, result.Data.Bids));
        }

        #endregion

        #region Trade History client

        GetTradeHistoryOptions ITradeHistoryRestClient.GetTradeHistoryOptions { get; } = new GetTradeHistoryOptions(_exchangeName, false, true, true, 1000, false)
        {
            MaxAge = TimeSpan.FromDays(90)
        };

        async Task<HttpResult<SharedTrade[]>> ITradeHistoryRestClient.GetTradeHistoryAsync(GetTradeHistoryRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetTradeHistoryOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedTrade[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 1000;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, false);
            if (pageParams.FromId != null)
                pageParams.EndTime = null; // If filtering using FromId no timestamps should be set

            // Get data
            var symbol = request.Symbol!.GetSymbol(FormatSymbol);
            var result = await ExchangeData.GetTradesAsync(
                symbol,
                startTime: pageParams.StartTime,
                endTime: pageParams.EndTime,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedTrade[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => x.TradeId)!),
                result.Data.Length,
                result.Data.Select(x => x.Timestamp),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                maxAge: TimeSpan.FromDays(90));

            // Return
            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.Timestamp, request.StartTime, request.EndTime, direction)
                       .Select(x => 
                            new SharedTrade(request.Symbol, symbol, x.Quantity, x.Price, x.Timestamp)
                            {
                                Side = x.Side == BitgetOrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell
                            })
                       .ToArray(), nextPageRequest);
        }
        #endregion

        #region Withdrawal client
        GetWithdrawalsOptions IWithdrawalRestClient.GetWithdrawalsOptions { get; } = new GetWithdrawalsOptions(_exchangeName, false, true, true, 100);

        async Task<HttpResult<SharedWithdrawal[]>> IWithdrawalRestClient.GetWithdrawalsAsync(GetWithdrawalsRequest request, PageRequest? pageRequest, CancellationToken ct)
        {
            var validationError = SharedClient.GetWithdrawalsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedWithdrawal[]>(Exchange, validationError);

            var direction = DataDirection.Descending;
            var limit = request.Limit ?? 100;
            var pageParams = Pagination.GetPaginationParameters(direction, limit, request.StartTime, request.EndTime ?? DateTime.UtcNow, pageRequest, true, TimeSpan.FromDays(90));

            // Get data
            var time = DateTime.UtcNow;
            var result = await Account.GetWithdrawalHistoryAsync(
                startTime: pageParams.StartTime ?? time.AddDays(-90),
                endTime: pageParams.EndTime ?? time,
                asset: request.Asset,
                limit: limit,
                idLessThan: pageParams.FromId,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedWithdrawal[]>(result);

            var nextPageRequest = Pagination.GetNextPageRequest(
                () => Pagination.NextPageFromId(result.Data.Min(x => long.Parse(x.OrderId))),
                result.Data.Length,
                result.Data.Select(x => x.CreateTime),
                request.StartTime,
                request.EndTime ?? DateTime.UtcNow,
                pageParams,
                TimeSpan.FromDays(90));

            return HttpResult.Ok(result, ExchangeHelpers.ApplyFilter(result.Data, x => x.CreateTime, request.StartTime, request.EndTime, direction)
                       .Select(x =>
                           new SharedWithdrawal(
                               x.Asset,
                               x.ToAddress,
                               x.Quantity, 
                               x.Status == TransferStatus.Success,
                               x.CreateTime,
                               GetWithdrawalStatus(x))
                           {
                               Id = x.OrderId,
                               Confirmations = x.Confirmations,
                               Network = x.Network,
                               Tag = x.Tag,
                               TransactionId = x.TransactionId,
                               Fee = x.Fee
                           })
                       .ToArray(), nextPageRequest);
        }

        private SharedTransferStatus GetWithdrawalStatus(BitgetWithdrawalRecord x)
        {
            if (x.Status == TransferStatus.Failed)
                return SharedTransferStatus.Failed;

            if (x.Status == TransferStatus.Success)
                return SharedTransferStatus.Completed;

            if (x.Status == TransferStatus.Processing)
                return SharedTransferStatus.InProgress;

            return SharedTransferStatus.Unknown;
        }

        #endregion

        #region Withdraw client

        WithdrawOptions IWithdrawRestClient.WithdrawOptions { get; } = new WithdrawOptions(_exchangeName);

        async Task<HttpResult<SharedId>> IWithdrawRestClient.WithdrawAsync(WithdrawRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.WithdrawOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            // Get data
            var withdrawal = await Account.WithdrawAsync(
                request.Asset,
                TransferType.OnChain,
                request.Address,
                request.Quantity,
                network: request.Network,
                tag: request.AddressTag,
                ct: ct).ConfigureAwait(false);
            if (!withdrawal.Success)
                return HttpResult.Fail<SharedId>(withdrawal);

            return HttpResult.Ok(withdrawal, new SharedId(withdrawal.Data.OrderId));
        }

        #endregion

        #region Fee Client
        GetFeeOptions IFeeRestClient.GetFeeOptions { get; } = new GetFeeOptions(_exchangeName, true);

        async Task<HttpResult<SharedFee>> IFeeRestClient.GetFeesAsync(GetFeeRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetFeeOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFee>(Exchange, validationError);

            // Get data
            var result = await Account.GetTradeFeeAsync(request.Symbol!.GetSymbol(FormatSymbol), BitgetBusinessType.Spot, ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFee>(result);

            // Return
            return HttpResult.Ok(result, new SharedFee(result.Data.MakerRate * 100, result.Data.TakerRate * 100));
        }
        #endregion

        #region Trigger Order Client
        PlaceSpotTriggerOrderOptions ISpotTriggerOrderRestClient.PlaceSpotTriggerOrderOptions { get; } = new PlaceSpotTriggerOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotTriggerOrderRestClient.PlaceSpotTriggerOrderAsync(PlaceSpotTriggerOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.PlaceSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var result = await Trading.PlaceOrderAsync(
                request.Symbol!.GetSymbol(FormatSymbol),
                request.OrderSide == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                request.OrderPrice == null ? OrderType.Market : OrderType.Limit,
                timeInForce: request.OrderPrice == null ? TimeInForce.ImmediateOrCancel : TimeInForce.GoodTillCanceled,
                quantity: request.Quantity.QuantityInBaseAsset ?? request.Quantity.QuantityInQuoteAsset ?? 0,
                price: request.OrderPrice,
                clientOrderId: request.ClientOrderId,
                triggerPrice: request.TriggerPrice,                
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedId>(result);

            // Return
            return HttpResult.Ok(result, new SharedId(result.Data.OrderId.ToString()));
        }

        GetSpotTriggerOrderOptions ISpotTriggerOrderRestClient.GetSpotTriggerOrderOptions { get; } = new GetSpotTriggerOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedSpotTriggerOrder>> ISpotTriggerOrderRestClient.GetSpotTriggerOrderAsync(GetOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.GetSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTriggerOrder>(Exchange, validationError);

            var orders = await Trading.GetOrderAsync(request.OrderId).ConfigureAwait(false);
            if (!orders.Success)
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders);

            if (!orders.Data.Any())
                return HttpResult.Fail<SharedSpotTriggerOrder>(orders, new ServerError(new ErrorInfo(ErrorType.UnknownOrder, "Order not found")));

            var order = orders.Data.Single();
            return HttpResult.Ok(orders, new SharedSpotTriggerOrder(
                ExchangeSymbolCache.ParseSymbol(_topicId, EnvironmentName, null, order.Symbol),
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType, null),
                order.Side == OrderSide.Buy ? SharedTriggerOrderDirection.Enter: SharedTriggerOrderDirection.Exit,
                ParseTriggerOrderStatus(order.Status),
                order.TriggerPrice ?? 0,
                order.CreateTime)
            {
                OrderPrice = order.Price,
                OrderQuantity = new SharedOrderQuantity(order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? null : order.Quantity, order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? order.Quantity : null),
                QuantityFilled = new SharedOrderQuantity(order.QuantityFilled, order.QuoteQuantityFilled),
                Fee = order.Fees?.NewFees?.TotalFee == null ? null : Math.Abs(order.Fees.NewFees.TotalFee),
                AveragePrice = order.AveragePrice == 0 ? null : order.AveragePrice,
                UpdateTime = order.UpdateTime,
                ClientOrderId = order.ClientOrderId
            });
        }

        private SharedTriggerOrderStatus ParseTriggerOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Filled)
                return SharedTriggerOrderStatus.Filled;

            if (status == OrderStatus.Canceled || status == OrderStatus.Rejected)
                return SharedTriggerOrderStatus.CanceledOrRejected;

            if (status == OrderStatus.Live || status == OrderStatus.PartiallyFilled || status == OrderStatus.Initial || status == OrderStatus.New)
                return SharedTriggerOrderStatus.Active;

            return SharedTriggerOrderStatus.Unknown;
        }

        CancelSpotTriggerOrderOptions ISpotTriggerOrderRestClient.CancelSpotTriggerOrderOptions { get; } = new CancelSpotTriggerOrderOptions(_exchangeName, true);
        async Task<HttpResult<SharedId>> ISpotTriggerOrderRestClient.CancelSpotTriggerOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.CancelSpotTriggerOrderOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var order = await Trading.CancelOrderAsync(request.Symbol!.GetSymbol(FormatSymbol), request.OrderId, ct: ct).ConfigureAwait(false);
            if (!order.Success)
                return HttpResult.Fail<SharedId>(order);

            return HttpResult.Ok(order, new SharedId(order.Data.OrderId.ToString()));
        }
        #endregion

        #region Transfer client

        TransferOptions ITransferRestClient.TransferOptions { get; } = new TransferOptions(_exchangeName, [
            SharedAccountType.Funding,
            SharedAccountType.Spot,
            SharedAccountType.PerpetualLinearFutures,
            SharedAccountType.PerpetualInverseFutures,
            SharedAccountType.DeliveryLinearFutures,
            SharedAccountType.DeliveryInverseFutures,
            SharedAccountType.CrossMargin,
            SharedAccountType.IsolatedMargin
            ])
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<HttpResult<SharedId>> ITransferRestClient.TransferAsync(TransferRequest request, CancellationToken ct)
        {
            var validationError = SharedClient.TransferOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedId>(Exchange, validationError);

            var productType = ExchangeParameters.GetValue<string>(request.ExchangeParameters, Exchange, "ProductType")!;
            var fromAccount = GetTransferType(request.FromAccountType, productType);
            var toAccount = GetTransferType(request.ToAccountType, productType);
            if (fromAccount == null || toAccount == null)
                return HttpResult.Fail<SharedId>(Exchange, ArgumentError.Invalid("To/From AccountType", "invalid to/from account combination"));

            // Get data
            var transfer = await Account.TransferAsync(
                request.Asset,
                fromAccount.Value,
                toAccount.Value,
                request.Quantity,
                ct: ct).ConfigureAwait(false);
            if (!transfer.Success)
                return HttpResult.Fail<SharedId>(transfer);

            return HttpResult.Ok(transfer, new SharedId(transfer.Data.TransferId));
        }

        private TransferAccountType? GetTransferType(SharedAccountType type, string productType)
        {
            if (type == SharedAccountType.Funding) return TransferAccountType.Funding;
            if (type == SharedAccountType.Spot) return TransferAccountType.Spot;
            if (type == SharedAccountType.CrossMargin) return TransferAccountType.CrossMargin;
            if (type == SharedAccountType.IsolatedMargin) return TransferAccountType.IsolatedMargin;
            if (type == SharedAccountType.PerpetualInverseFutures || type == SharedAccountType.DeliveryInverseFutures) return TransferAccountType.CoinFutures;
            if ((type == SharedAccountType.PerpetualLinearFutures || type == SharedAccountType.DeliveryLinearFutures) && productType == "UsdcFutures") return TransferAccountType.UsdcFutures;
            if ((type == SharedAccountType.PerpetualLinearFutures || type == SharedAccountType.DeliveryLinearFutures) && productType == "UsdtFutures") return TransferAccountType.UsdtFutures;
            return null;
        }

        #endregion
    }
}
