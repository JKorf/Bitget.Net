using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Models;
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

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetRestClientSpotApi : IBitgetRestClientSpotApiShared
    {
        public string Exchange => BitgetExchange.ExchangeName;

        #region Kline client

        GetKlinesOptions IKlineRestClient.GetKlinesOptions { get; } = new GetKlinesOptions(true)
        {
            MaxRequestDataPoints = 1000
        };

        async Task<ExchangeWebResult<IEnumerable<SharedKline>>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            var interval = (Enums.V2.KlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.V2.KlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedKline>>(Exchange, new ArgumentError("Interval not supported"));

            // Determine page token
            DateTime? fromTimestamp = null;
            if (pageToken is DateTimeToken dateTimeToken)
                fromTimestamp = dateTimeToken.LastTime;

            var startTime = request.Filter?.StartTime?.AddSeconds(-1);
            var endTime = request.Filter?.EndTime?.AddSeconds(-1);
            var apiLimit = 1000;

            // API returns the newest data first if the timespan is bigger than the api limit of 1000 results
            // So we need to request the first 1000 from the start time, then the 1000 after that etc
            if (request.Filter?.StartTime != null)
            {
                // Not paginated, check if the data will fit
                var seconds = apiLimit * (int)request.Interval;
                var maxEndTime = (fromTimestamp ?? request.Filter.StartTime).Value.AddSeconds(seconds - 1);
                if (maxEndTime < endTime)
                    endTime = maxEndTime;
            }

            var result = await ExchangeData.GetKlinesAsync(
                request.GetSymbol(FormatSymbol),
                interval,
                fromTimestamp ?? startTime,
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
                    nextToken = new DateTimeToken(maxOpenTime.AddSeconds((int)interval - 1));
            }

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)), nextToken);
        }

        #endregion

        #region Spot Symbol client

        async Task<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> ISpotSymbolRestClient.GetSpotSymbolsAsync(CancellationToken ct)
        {
            var result = await ExchangeData.GetSymbolsAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedSpotSymbol>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(s => new SharedSpotSymbol(s.BaseAsset, s.QuoteAsset, s.Symbol)
            {
                MinTradeQuantity = s.MinOrderQuantity,
                MaxTradeQuantity = s.MaxOrderQuantity,
                QuantityDecimals = s.QuantityPrecision,
                PriceDecimals = s.PricePrecision
            }));
        }

        #endregion

        #region Ticker client

        async Task<ExchangeWebResult<SharedTicker>> ITickerRestClient.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var result = await ExchangeData.GetTickersAsync(request.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedTicker>(Exchange, default);

            var ticker = result.Data.Single();
            return result.AsExchangeResult(Exchange, new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice, ticker.LowPrice));
        }
        
        async Task<ExchangeWebResult<IEnumerable<SharedTicker>>> ITickerRestClient.GetTickersAsync(ApiType? apiType, CancellationToken ct)
        {
            var result = await ExchangeData.GetTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, default);

            return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, result.Data.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice, x.LowPrice)));
        }

        #endregion

        #region Recent Trade client

        GetRecentTradesOptions IRecentTradeRestClient.GetRecentTradesOptions { get; } = new GetRecentTradesOptions(500);

        async Task<ExchangeWebResult<IEnumerable<SharedTrade>>> IRecentTradeRestClient.GetRecentTradesAsync(GetRecentTradesRequest request, CancellationToken ct)
        {
            // Get data
            var result = await ExchangeData.GetRecentTradesAsync(
                request.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTrade>>(Exchange, default);

            // Return
            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)));
        }

        #endregion

        #region Balance client

        async Task<ExchangeWebResult<IEnumerable<SharedBalance>>> IBalanceRestClient.GetBalancesAsync(ApiType? apiType, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var result = await Account.GetSpotBalancesAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedBalance(x.Asset, x.Available, x.Available + x.Frozen)));
        }

        #endregion

        #region Spot Order client

        PlaceSpotOrderOptions ISpotOrderRestClient.PlaceSpotOrderOptions { get; } = new PlaceSpotOrderOptions(
            new[]
            {
                SharedOrderType.Limit,
                SharedOrderType.Market,
                SharedOrderType.LimitMaker
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
                SharedQuantityType.QuoteAssetQuantity,
                SharedQuantityType.BaseAssetQuantity));

        async Task<ExchangeWebResult<SharedId>> ISpotOrderRestClient.PlaceOrderAsync(PlaceSpotOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            if (request.OrderType == SharedOrderType.Other)
                throw new ArgumentException("OrderType can't be `Other`", nameof(request.OrderType));

            var result = await Trading.PlaceOrderAsync(
                request.GetSymbol(FormatSymbol),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                (request.OrderType == SharedOrderType.Limit || request.OrderType == SharedOrderType.LimitMaker) ? OrderType.Limit : OrderType.Market,
                quantity: (request.OrderType == SharedOrderType.Market && request.Side == SharedOrderSide.Buy ? request.QuoteQuantity : request.Quantity) ?? 0,
                price: request.Price,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<SharedId>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedId(result.Data.OrderId));
        }

        async Task<ExchangeWebResult<SharedSpotOrder>> ISpotOrderRestClient.GetOrderAsync(GetOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var orders = await Trading.GetOrderAsync(request.OrderId).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<SharedSpotOrder>(Exchange, default);

#warning can it be empty?
            var order = orders.Data.Single();
            return orders.AsExchangeResult(Exchange, new SharedSpotOrder(
                order.Symbol,
                order.OrderId.ToString(),
                ParseOrderType(order.OrderType, null),
                order.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(order.Status),
                order.CreateTime)
            {
                ClientOrderId = order.ClientOrderId,
                Price = order.Price,
                Quantity = order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? null: order.Quantity,
                QuantityFilled = order.QuantityFilled,
                QuoteQuantity = order.OrderType == OrderType.Market && order.Side == OrderSide.Buy ? order.Quantity : null,
                QuoteQuantityFilled = order.QuoteQuantityFilled,
                Fee = order.Fees?.NewFees?.TotalFee,
                AveragePrice = order.AveragePrice,
                UpdateTime = order.UpdateTime,
            });
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetOpenOrdersAsync(GetSpotOpenOrdersRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            string? symbol = null;
            if (request.BaseAsset != null && request.QuoteAsset != null)
                symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);

            var orders = await Trading.GetOpenOrdersAsync(symbol).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedSpotOrder>>(Exchange, default);

            return orders.AsExchangeResult(Exchange, orders.Data.Select(x => new SharedSpotOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType, null),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                Price = x.Price,
                Quantity = x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity,
                QuantityFilled = x.QuantityFilled,
                QuoteQuantity = x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? x.Quantity : null,
                QuoteQuantityFilled = x.QuoteQuantityFilled,
                Fee = x.Fees?.NewFees?.TotalFee,
                AveragePrice = x.AveragePrice,
                UpdateTime = x.UpdateTime,
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetClosedOrdersAsync(GetSpotClosedOrdersRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            // Determine page token
            string? fromToken = null;
            if (pageToken is FromIdToken token)
                fromToken = token.FromToken;

            // Get data
            var orders = await Trading.GetClosedOrdersAsync(request.GetSymbol(FormatSymbol),
                startTime: request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit ?? 100,
                idLessThan: fromToken).ConfigureAwait(false);
            if (!orders)
                return orders.AsExchangeResult<IEnumerable<SharedSpotOrder>>(Exchange, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (orders.Data.Count() == (request.Filter?.Limit ?? 100))
                nextToken = new FromIdToken(orders.Data.OrderBy(d => d.CreateTime).First().OrderId);

            return orders.AsExchangeResult(Exchange, orders.Data.Select(x => new SharedSpotOrder(
                x.Symbol,
                x.OrderId.ToString(),
                ParseOrderType(x.OrderType, null),
                x.Side == OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                ParseOrderStatus(x.Status),
                x.CreateTime)
            {
                ClientOrderId = x.ClientOrderId,
                Price = x.Price,
                Quantity = x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? null : x.Quantity,
                QuantityFilled = x.QuantityFilled,
                QuoteQuantity = x.OrderType == OrderType.Market && x.Side == OrderSide.Buy ? x.Quantity : null,
                QuoteQuantityFilled = x.QuoteQuantityFilled,
                Fee = x.Fees?.NewFees?.TotalFee,
                AveragePrice = x.AveragePrice,
                UpdateTime = x.UpdateTime,
            }), nextToken);
        }

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetOrderTradesAsync(GetOrderTradesRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var trades = await Trading.GetUserTradesAsync(request.GetSymbol(FormatSymbol), orderId: request.OrderId).ConfigureAwait(false);
            if (!trades)
                return trades.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            return trades.AsExchangeResult(Exchange, trades.Data.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Fee = x.Fees.TotalFee,
                FeeAsset = x.Fees.FeeAsset,
                Role = x.Role == Role.Taker ? SharedRole.Taker: SharedRole.Maker
            }));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetUserTradesAsync(GetUserTradesRequest request, INextPageToken? pageToken, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            // Determine page token
            string? fromId = null;
            if (pageToken is FromIdToken fromIdToken)
                fromId = fromIdToken.FromToken;

            // Get data
            var trades = await Trading.GetUserTradesAsync(request.GetSymbol(FormatSymbol),
                startTime: request.Filter?.StartTime,
                endTime: request.Filter?.EndTime,
                limit: request.Filter?.Limit,
                idLessThan: fromId).ConfigureAwait(false);
            if (!trades)
                return trades.AsExchangeResult<IEnumerable<SharedUserTrade>>(Exchange, default);

            // Get next token
            FromIdToken? nextToken = null;
            if (trades.Data.Count() == (request.Filter?.Limit ?? 100))
                nextToken = new FromIdToken(trades.Data.Max(o => o.TradeId).ToString());

            return trades.AsExchangeResult(Exchange, trades.Data.Select(x => new SharedUserTrade(
                x.Symbol,
                x.OrderId,
                x.TradeId,
                x.Quantity,
                x.Price,
                x.CreateTime)
            {
                Fee = x.Fees.TotalFee,
                FeeAsset = x.Fees.FeeAsset,
                Role = x.Role == Role.Taker ? SharedRole.Taker : SharedRole.Maker
            }), nextToken);
        }

        async Task<ExchangeWebResult<SharedId>> ISpotOrderRestClient.CancelOrderAsync(CancelOrderRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var order = await Trading.CancelOrderAsync(request.GetSymbol(FormatSymbol), request.OrderId).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedId>(Exchange, default);

            return order.AsExchangeResult(Exchange, new SharedId(order.Data.OrderId.ToString()));
        }

        private SharedOrderStatus ParseOrderStatus(OrderStatus status)
        {
            if (status == OrderStatus.Live || status == OrderStatus.PartiallyFilled || status == OrderStatus.Initial || status == OrderStatus.New) return SharedOrderStatus.Open;
            if (status == OrderStatus.Canceled) return SharedOrderStatus.Canceled;
            return SharedOrderStatus.Filled;
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

            throw new ArgumentException("Unknown timeInForce setting");
        }

        #endregion

        #region Asset client

        async Task<ExchangeWebResult<IEnumerable<SharedAsset>>> IAssetRestClient.GetAssetsAsync(CancellationToken ct)
        {
            var assets = await ExchangeData.GetAssetsAsync(ct: ct).ConfigureAwait(false);
            if (!assets)
                return assets.AsExchangeResult<IEnumerable<SharedAsset>>(Exchange, default);

            return assets.AsExchangeResult(Exchange, assets.Data.Select(x => new SharedAsset(x.Name)
            {
                Networks = x.Networks.Select(x => new SharedAssetNetwork(x.Network)
                {
                    MinConfirmations = x.DepositConfirm ?? x.WithdrawConfirm,
                    DepositEnabled = x.Depositable,
                    MinWithdrawQuantity = x.MinWithdrawQuantity,
                    WithdrawEnabled = x.Withdrawable,
                    WithdrawFee = x.WithdrawFee
                })
            }));
        }

        #endregion

        #region Deposit client

        async Task<ExchangeWebResult<IEnumerable<SharedDepositAddress>>> IDepositRestClient.GetDepositAddressesAsync(GetDepositAddressesRequest request, CancellationToken ct)
        {
            var depositAddresses = await Account.GetDepositAddressAsync(request.Asset, request.Network).ConfigureAwait(false);
            if (!depositAddresses)
                return depositAddresses.AsExchangeResult<IEnumerable<SharedDepositAddress>>(Exchange, default);

            return depositAddresses.AsExchangeResult<IEnumerable<SharedDepositAddress>>(Exchange, new[] { new SharedDepositAddress(depositAddresses.Data.Asset, depositAddresses.Data.Address)
            {
                Tag = depositAddresses.Data.Tag,
                Network = depositAddresses.Data.Network
            }
            });
        }

        async Task<ExchangeWebResult<IEnumerable<SharedDeposit>>> IDepositRestClient.GetDepositsAsync(GetDepositsRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            // Determine page token
            string? from = null;
            if (pageToken is FromIdToken fromToken)
                from = fromToken.FromToken;

            // Get data
            var deposits = await Account.GetDepositHistoryAsync(
                startTime: request.Filter?.StartTime ?? DateTime.UtcNow.AddDays(-7),
                endTime: request.Filter?.EndTime ?? DateTime.UtcNow,
                asset: request.Asset,
                limit: request.Filter?.Limit ?? 100,
                idLessThan: from,
                ct: ct).ConfigureAwait(false);
            if (!deposits)
                return deposits.AsExchangeResult<IEnumerable<SharedDeposit>>(Exchange, default);

            // Determine next token
            FromIdToken? nextToken = null;
            if (deposits.Data.Count() == (request.Filter?.Limit ?? 100))
                nextToken = new FromIdToken(deposits.Data.Min(x => x.OrderId));

            return deposits.AsExchangeResult(Exchange, deposits.Data.Select(x => new SharedDeposit(x.Asset, x.Quantity, x.Status == TransferStatus.Success, x.CreateTime)
            {
                Network = x.Network,
                TransactionId = x.TransactionId,
            }), nextToken);
        }

        #endregion

        #region Order Book client

        GetOrderBookOptions IOrderBookRestClient.GetOrderBookOptions { get; } = new GetOrderBookOptions(1, 150);
        async Task<ExchangeWebResult<SharedOrderBook>> IOrderBookRestClient.GetOrderBookAsync(GetOrderBookRequest request, CancellationToken ct)
        {
            var validationError = ((IOrderBookRestClient)this).GetOrderBookOptions.Validate(request);
            if (validationError != null)
                return new ExchangeWebResult<SharedOrderBook>(Exchange, validationError);

            var result = await ExchangeData.GetOrderBookAsync(
                request.GetSymbol(FormatSymbol),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedOrderBook>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedOrderBook(result.Data.Asks, result.Data.Bids));
        }

        #endregion

        #region Trade History client

#warning has limitation of only last month is available

        async Task<ExchangeWebResult<IEnumerable<SharedTrade>>> ITradeHistoryRestClient.GetTradeHistoryAsync(GetTradeHistoryRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            string? fromId = null;
            if (pageToken is FromIdToken token)
                fromId = token.FromToken;

            // Get data
            var result = await ExchangeData.GetTradesAsync(
                request.GetSymbol(FormatSymbol),
                startTime: fromId != null ? null : request.StartTime,
                endTime: fromId != null ? null : request.EndTime,
                limit: 1000,
                idLessThan: fromId,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTrade>>(Exchange, default);

            FromIdToken? nextToken = null;
            if (result.Data.Any() && result.Data.First().Timestamp > request.EndTime)
                nextToken = new FromIdToken(result.Data.Min(x => x.TradeId).ToString());

            // Return
            return result.AsExchangeResult(Exchange, result.Data.Where(x => x.Timestamp >= request.StartTime).Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)), nextToken);
        }
        #endregion

        #region Withdrawal client

        async Task<ExchangeWebResult<IEnumerable<SharedWithdrawal>>> IWithdrawalRestClient.GetWithdrawalsAsync(GetWithdrawalsRequest request, INextPageToken? pageToken, CancellationToken ct)
        {
            // Determine page token
            string? from = null;
            if (pageToken is FromIdToken token)
                from = token.FromToken;

            // Get data
            var withdrawals = await Account.GetWithdrawalHistoryAsync(
                startTime: request.Filter?.StartTime ?? DateTime.UtcNow.AddDays(-7),
                endTime: request.Filter?.EndTime ?? DateTime.UtcNow,
                asset: request.Asset,
                limit: request.Filter?.Limit ?? 100,
                idLessThan: from,
                ct: ct).ConfigureAwait(false);
            if (!withdrawals)
                return withdrawals.AsExchangeResult<IEnumerable<SharedWithdrawal>>(Exchange, default);

            // Determine next token
            FromIdToken? nextToken = null;
            if (withdrawals.Data.Count() == (request.Filter?.Limit ?? 100))
                nextToken = new FromIdToken(withdrawals.Data.Min(x => x.OrderId));

            return withdrawals.AsExchangeResult(Exchange, withdrawals.Data.Select(x => new SharedWithdrawal(x.Asset, x.ToAddress, x.Quantity, x.Status == TransferStatus.Success, x.CreateTime)
            {
                Confirmations = x.Confirmations,
                Network = x.Network,
                Tag = x.Tag,
                TransactionId = x.TransactionId,
                Fee = x.Fee
            }));
        }

        #endregion

        #region Withdraw client

        WithdrawOptions IWithdrawRestClient.WithdrawOptions { get; } = new WithdrawOptions();

        async Task<ExchangeWebResult<SharedId>> IWithdrawRestClient.WithdrawAsync(WithdrawRequest request, ExchangeParameters? exchangeParameters, CancellationToken ct)
        {
            var validationError = ((IWithdrawRestClient)this).WithdrawOptions.Validate(request);
            if (validationError != null)
                return new ExchangeWebResult<SharedId>(Exchange, validationError);

            // Get data
            var withdrawal = await Account.WithdrawAsync(
                request.Asset,
                TransferType.OnChain,
                request.Address,
                request.Quantity,
                network: request.Network,
                tag: request.AddressTag,
                ct: ct).ConfigureAwait(false);
            if (!withdrawal)
                return withdrawal.AsExchangeResult<SharedId>(Exchange, default);

            return withdrawal.AsExchangeResult(Exchange, new SharedId(withdrawal.Data.OrderId));
        }

        #endregion
    }
}
