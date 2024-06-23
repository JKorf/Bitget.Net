﻿using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.FuturesApiV2
{
    /// <summary>
    /// Bitget futures streams
    /// </summary>
    public interface IBitgetSocketClientFuturesApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Subscribe to ticker updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Tickers-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Tickers-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">The symbols</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/New-Trades-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for multiple symbols
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/New-Trades-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">The symbols</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Candlesticks-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="interval">Interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, string symbol, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetFuturesKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates for symbols
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Candlesticks-Channel" /></para>
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="symbols">Symbols</param>
        /// <param name="interval">Interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetFuturesKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for a symbol
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Order-Book-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbol">Symbols</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updates after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, string symbol, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to order book updates for symbols
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/public/Order-Book-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="symbols">Symbols</param>
        /// <param name="limit">Order book depth. 1, 5 or 15 for full updates of these levels, or null for initial snapshot and only incremental updates after</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(BitgetProductTypeV2 productType, IEnumerable<string> symbols, int? limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account balance updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/Account-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetFuturesBalanceUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetPositionUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetFuturesUserTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/Positions-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetFuturesOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trigger order updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/Plan-Order-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTriggerOrderUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetFuturesTriggerOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position history/closing updates
        /// <para><a href="https://www.bitget.com/api-doc/contract/websocket/private/History-Positions-Channel" /></para>
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionHistoryUpdatesAsync(BitgetProductTypeV2 productType, Action<DataEvent<IEnumerable<BitgetPositionHistoryUpdate>>> handler, CancellationToken ct = default);
    }
}