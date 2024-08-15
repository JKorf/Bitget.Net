﻿using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Interfaces;
using CryptoExchange.Net.SharedApis.Models;
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

        public IEnumerable<SharedOrderType> SupportedOrderType { get; } = new[]
        {
            SharedOrderType.Limit,
            SharedOrderType.Market,
            SharedOrderType.LimitMaker
        };

        public IEnumerable<SharedTimeInForce> SupportedTimeInForce { get; } = new[]
        {
            SharedTimeInForce.GoodTillCanceled,
            SharedTimeInForce.ImmediateOrCancel,
            SharedTimeInForce.FillOrKill
        };

        public SharedQuantitySupport OrderQuantitySupport { get; } =
            new SharedQuantitySupport(
                SharedQuantityType.BaseAssetQuantity,
                SharedQuantityType.BaseAssetQuantity,
                SharedQuantityType.QuoteAssetQuantity,
                SharedQuantityType.BaseAssetQuantity);

        async Task<ExchangeWebResult<IEnumerable<SharedKline>>> IKlineRestClient.GetKlinesAsync(GetKlinesRequest request, CancellationToken ct)
        {
            var interval = (Enums.V2.KlineInterval)request.Interval;
            if (!Enum.IsDefined(typeof(Enums.V2.KlineInterval), interval))
                return new ExchangeWebResult<IEnumerable<SharedKline>>(Exchange, new ArgumentError("Interval not supported"));

            var result = await ExchangeData.GetKlinesAsync(
                FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                interval,
                request.StartTime,
                request.EndTime,
                request.Limit,
                ct: ct
                ).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedKline>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedKline(x.OpenTime, x.ClosePrice, x.HighPrice, x.LowPrice, x.OpenPrice, x.Volume)));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedSpotSymbol>>> ISpotSymbolRestClient.GetSymbolsAsync(SharedRequest request, CancellationToken ct)
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

        async Task<ExchangeWebResult<SharedTicker>> ITickerRestClient.GetTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var result = await ExchangeData.GetTickersAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType), ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<SharedTicker>(Exchange, default);

            var ticker = result.Data.Single();
            return result.AsExchangeResult(Exchange, new SharedTicker(ticker.Symbol, ticker.LastPrice, ticker.HighPrice, ticker.LowPrice));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedTicker>>> ITickerRestClient.GetTickersAsync(SharedRequest request, CancellationToken ct)
        {
            var result = await ExchangeData.GetTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, default);

            return result.AsExchangeResult<IEnumerable<SharedTicker>>(Exchange, result.Data.Select(x => new SharedTicker(x.Symbol, x.LastPrice, x.HighPrice, x.LowPrice)));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedTrade>>> ITradeRestClient.GetTradesAsync(GetTradesRequest request, CancellationToken ct)
        {
            if (request.StartTime != null || request.EndTime != null)
                return new ExchangeWebResult<IEnumerable<SharedTrade>>(Exchange, new ArgumentError("Start/EndTime filtering not supported"));

            var result = await ExchangeData.GetRecentTradesAsync(
                FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                limit: request.Limit,
                ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedTrade>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)));
        }

        async Task<ExchangeWebResult<IEnumerable<SharedBalance>>> IBalanceRestClient.GetBalancesAsync(SharedRequest request, CancellationToken ct)
        {
            var result = await Account.GetSpotBalancesAsync(ct: ct).ConfigureAwait(false);
            if (!result)
                return result.AsExchangeResult<IEnumerable<SharedBalance>>(Exchange, default);

            return result.AsExchangeResult(Exchange, result.Data.Select(x => new SharedBalance(x.Asset, x.Available, x.Available + x.Frozen)));
        }

        async Task<ExchangeWebResult<SharedOrderId>> ISpotOrderRestClient.PlaceOrderAsync(PlaceSpotOrderRequest request, CancellationToken ct)
        {
            if (request.OrderType == SharedOrderType.Other)
                throw new ArgumentException("OrderType can't be `Other`", nameof(request.OrderType));

            var result = await Trading.PlaceOrderAsync(
                FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                request.Side == SharedOrderSide.Buy ? OrderSide.Buy : OrderSide.Sell,
                (request.OrderType == SharedOrderType.Limit || request.OrderType == SharedOrderType.LimitMaker) ? OrderType.Limit : OrderType.Market,
                quantity: (request.OrderType == SharedOrderType.Market && request.Side == SharedOrderSide.Buy ? request.QuoteQuantity : request.Quantity) ?? 0,
                price: request.Price,
                timeInForce: GetTimeInForce(request.OrderType, request.TimeInForce),
                clientOrderId: request.ClientOrderId).ConfigureAwait(false);

            if (!result)
                return result.AsExchangeResult<SharedOrderId>(Exchange, default);

            return result.AsExchangeResult(Exchange, new SharedOrderId(result.Data.OrderId));
        }

        async Task<ExchangeWebResult<SharedSpotOrder>> ISpotOrderRestClient.GetOrderAsync(GetOrderRequest request, CancellationToken ct)
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

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetOpenOrdersAsync(GetSpotOpenOrdersRequest request, CancellationToken ct)
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

        async Task<ExchangeWebResult<IEnumerable<SharedSpotOrder>>> ISpotOrderRestClient.GetClosedOrdersAsync(GetSpotClosedOrdersRequest request, CancellationToken ct)
        {
            var orders = await Trading.GetClosedOrdersAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                startTime: request.StartTime,
                endTime: request.EndTime,
                limit: request.Limit).ConfigureAwait(false);
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

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetOrderTradesAsync(GetOrderTradesRequest request, CancellationToken ct)
        {
            var trades = await Trading.GetUserTradesAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType), orderId: request.OrderId).ConfigureAwait(false);
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

        async Task<ExchangeWebResult<IEnumerable<SharedUserTrade>>> ISpotOrderRestClient.GetUserTradesAsync(GetUserTradesRequest request, CancellationToken ct)
        {
            var trades = await Trading.GetUserTradesAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType),
                startTime: request.StartTime,
                endTime: request.EndTime,
                limit: request.Limit).ConfigureAwait(false);
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
                Role = x.Role == Role.Taker ? SharedRole.Taker : SharedRole.Maker
            }));
        }

        async Task<ExchangeWebResult<SharedOrderId>> ISpotOrderRestClient.CancelOrderAsync(CancelOrderRequest request, CancellationToken ct)
        {
            var order = await Trading.CancelOrderAsync(FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType), request.OrderId).ConfigureAwait(false);
            if (!order)
                return order.AsExchangeResult<SharedOrderId>(Exchange, default);

            return order.AsExchangeResult(Exchange, new SharedOrderId(order.Data.OrderId.ToString()));
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
    }
}
