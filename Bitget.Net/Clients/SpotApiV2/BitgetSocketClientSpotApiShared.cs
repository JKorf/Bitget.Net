using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis.Interfaces.Socket;
using CryptoExchange.Net.SharedApis.Models.Socket;
using CryptoExchange.Net.SharedApis.RequestModels;
using CryptoExchange.Net.SharedApis.ResponseModels;
using CryptoExchange.Net.SharedApis.SubscribeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.SharedApis.Enums;
using CryptoExchange.Net.SharedApis.Models;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetSocketClientSpotApi : IBitgetSocketClientSpotApiShared
    {
        public string Exchange => BitgetExchange.ExchangeName;

        async Task<ExchangeResult<UpdateSubscription>> ITickerSocketClient.SubscribeToTickerUpdatesAsync(TickerSubscribeRequest request, Action<DataEvent<SharedSpotTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedSpotTicker(symbol, update.Data.LastPrice, update.Data.HighPrice24h, update.Data.LowPrice24h, update.Data.BaseVolume))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(TradeSubscribeRequest request, Action<DataEvent<IEnumerable<SharedTrade>>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTradeUpdatesAsync(symbol, update => handler(update.As(update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(BookTickerSubscribeRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedBookTicker(update.Data.BestAskPrice, update.Data.BestAskQuantity, update.Data.BestBidPrice, update.Data.BestBidQuantity))), ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(ApiType? apiType, Action<DataEvent<IEnumerable<SharedBalance>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToBalanceUpdatesAsync(
                update => handler(update.As(update.Data.Select(x => new SharedBalance(x.Asset, x.Available, x.Available + (x.Locked ?? 0) + (x.Frozen ?? 0))))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToSpotOrderUpdatesAsync(Action<DataEvent<IEnumerable<SharedSpotOrder>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToOrderUpdatesAsync(
                update => handler(update.As(update.Data.Select(x =>
                    new SharedSpotOrder(
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.OrderType == Enums.V2.OrderType.Limit ? SharedOrderType.Limit : x.OrderType == Enums.V2.OrderType.Market ? SharedOrderType.Market : SharedOrderType.Other,
                        x.Side == Enums.V2.OrderSide.Buy ? SharedOrderSide.Buy : SharedOrderSide.Sell,
                        x.Status == Enums.V2.OrderStatus.Canceled ? SharedOrderStatus.Canceled : (x.Status == Enums.V2.OrderStatus.Live || x.Status == Enums.V2.OrderStatus.New || x.Status == Enums.V2.OrderStatus.PartiallyFilled) ? SharedOrderStatus.Open : SharedOrderStatus.Filled,
                        x.CreateTime)
                    {
                        ClientOrderId = x.ClientOrderId?.ToString(),
                        Quantity = x.OrderType == Enums.V2.OrderType.Market && x.Side == Enums.V2.OrderSide.Buy ? null : x.OrderQuantity, // For a market buy order the OrderQuantity is the quote quantity
                        QuantityFilled = x.QuantityFilled,
                        TimeInForce = x.TimeInForce == Enums.V2.TimeInForce.ImmediateOrCancel ? SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.V2.TimeInForce.FillOrKill ? SharedTimeInForce.FillOrKill: SharedTimeInForce.GoodTillCanceled,
                        AveragePrice = x.AveragePrice,
                        UpdateTime = x.UpdateTime,
                        Fee = x.Fees.Any() ? x.Fees.Sum(f => f.Fee) : 0,
                        FeeAsset = x.FeeAsset,
                        QuoteQuantity = x.Notional,
                        Price = x.Price,
                        LastTrade = x.TradeId == null ? null : new SharedUserTrade(x.Symbol, x.OrderId, x.TradeId, x.BaseVolume!.Value, x.LastTradePrice!.Value, x.LastTradeTime!.Value)
                        {
                            Fee = x.LastTradeFee,
                            FeeAsset = x.FeeAsset,
                            Role = x.LastTradeRole == Enums.V2.Role.Taker ? SharedRole.Taker : SharedRole.Maker
                        }
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }

        async Task<ExchangeResult<UpdateSubscription>> ISpotUserTradeSocketClient.SubscribeToUserTradeUpdatesAsync(ApiType? apiType, Action<DataEvent<IEnumerable<SharedUserTrade>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToUserTradeUpdatesAsync(
                update => handler(update.As(update.Data.Select(x =>
                    new SharedUserTrade(
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.TradeId.ToString(),
                        x.Quantity,
                        x.Price,

                        x.UpdateTime ?? x.CreateTime)
                    {
                        Fee = x.Fees.First().TotalFee,
                        FeeAsset = x.Fees.First().FeeAsset,
                        Role = x.Role == Enums.V2.Role.Maker ? SharedRole.Maker : SharedRole.Taker
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return new ExchangeResult<UpdateSubscription>(Exchange, result);
        }
    }
}
