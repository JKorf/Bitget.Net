using Bitget.Net.Interfaces.Clients.SpotApi;
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

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetSocketClientSpotApi : IBitgetSocketClientSpotApiShared
    {
        public string Exchange => BitgetExchange.ExchangeName;

        async Task<CallResult<UpdateSubscription>> ITickerSocketClient.SubscribeToTickerUpdatesAsync(TickerSubscribeRequest request, Action<DataEvent<SharedTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedTicker(symbol, update.Data.LastPrice, update.Data.HighPrice24h, update.Data.LowPrice24h))), ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> ITradeSocketClient.SubscribeToTradeUpdatesAsync(TradeSubscribeRequest request, Action<DataEvent<IEnumerable<SharedTrade>>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTradeUpdatesAsync(symbol, update => handler(update.As(update.Data.Select(x => new SharedTrade(x.Quantity, x.Price, x.Timestamp)))), ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> IBookTickerSocketClient.SubscribeToBookTickerUpdatesAsync(BookTickerSubscribeRequest request, Action<DataEvent<SharedBookTicker>> handler, CancellationToken ct)
        {
            var symbol = FormatSymbol(request.BaseAsset, request.QuoteAsset, request.ApiType);
            var result = await SubscribeToTickerUpdatesAsync(symbol, update => handler(update.As(new SharedBookTicker(update.Data.BestAskPrice, update.Data.BestAskQuantity, update.Data.BestBidPrice, update.Data.BestBidQuantity))), ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> IBalanceSocketClient.SubscribeToBalanceUpdatesAsync(SharedRequest request, Action<DataEvent<IEnumerable<SharedBalance>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToBalanceUpdatesAsync(
                update => handler(update.As(update.Data.Select(x => new SharedBalance(x.Asset, x.Available, x.Available + (x.Locked ?? 0) + (x.Frozen ?? 0))))),
                ct: ct).ConfigureAwait(false);

            return result;
        }

        async Task<CallResult<UpdateSubscription>> ISpotOrderSocketClient.SubscribeToOrderUpdatesAsync(SharedRequest request, Action<DataEvent<IEnumerable<SharedSpotOrder>>> handler, CancellationToken ct)
        {
            var result = await SubscribeToOrderUpdatesAsync(
                update => handler(update.As(update.Data.Select(x =>
                    new SharedSpotOrder(
                        x.Symbol,
                        x.OrderId.ToString(),
                        x.OrderType == Enums.V2.OrderType.Limit ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Limit : x.OrderType == Enums.V2.OrderType.Market ? CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Market : CryptoExchange.Net.SharedApis.Enums.SharedOrderType.Other,
                        x.Side == Enums.V2.OrderSide.Buy ? CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Buy : CryptoExchange.Net.SharedApis.Enums.SharedOrderSide.Sell,
                        x.Status == Enums.V2.OrderStatus.Canceled ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Canceled : (x.Status == Enums.V2.OrderStatus.Live || x.Status == Enums.V2.OrderStatus.New) ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Open : x.Status == Enums.V2.OrderStatus.PartiallyFilled ? CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.PartiallyFilled : CryptoExchange.Net.SharedApis.Enums.SharedOrderStatus.Filled,
                        x.CreateTime)
                    {
                        ClientOrderId = x.ClientOrderId?.ToString(),
                        Quantity = x.OrderType == Enums.V2.OrderType.Market && x.Side == Enums.V2.OrderSide.Buy ? null : x.OrderQuantity, // For a market buy order the OrderQuantity is the quote quantity
                        QuantityFilled = x.QuantityFilled,
                        TimeInForce = x.TimeInForce == Enums.V2.TimeInForce.ImmediateOrCancel ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.ImmediateOrCancel : x.TimeInForce == Enums.V2.TimeInForce.FillOrKill ? CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.FillOrKill: CryptoExchange.Net.SharedApis.Enums.SharedTimeInForce.GoodTillCanceled,
                        AveragePrice = x.AveragePrice,
                        UpdateTime = x.UpdateTime,
                        Fee = x.Fees.Any() ? x.Fees.Sum(f => f.Fee) : 0,
                        FeeAsset = x.FeeAsset,
                        QuoteQuantity = x.Notional,
                        Price = x.Price
                    }
                ))),
                ct: ct).ConfigureAwait(false);

            return result;
        }
    }
}
