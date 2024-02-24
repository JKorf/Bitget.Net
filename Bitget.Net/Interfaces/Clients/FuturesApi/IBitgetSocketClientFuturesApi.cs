using Bitget.Net.Enums;
using Bitget.Net.Objects.Models;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;

namespace Bitget.Net.Interfaces.Clients.FuturesApi
{
    /// <summary>
    /// Bitget futures streams
    /// </summary>
    public interface IBitgetSocketClientFuturesApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Subscribe to kline/candlestick updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline/candlestick updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#candlesticks-channel" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, BitgetStreamKlineInterval interval, Action<DataEvent<IEnumerable<BitgetKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to symbol ticker updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to symbol ticker updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#tickers-channel" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<BitgetFuturesTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook changes updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook snapshot updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe</param>
        /// <param name="limit">The book depth, either 5 or 15</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook changes updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook snapshot updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#order-book-channel" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
        /// <param name="limit">The book depth, either 5 or 15</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int limit, Action<DataEvent<BitgetOrderBookUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to symbol trade updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to symbol trade updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#trades-channel" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to subscribe</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<IEnumerable<BitgetTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to updates to the account balance
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#account-channel" /></para>
        /// </summary>
        /// <param name="instrumentType">Instrument type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesBalanceUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to position updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#positions-channel" /></para>
        /// </summary>
        /// <param name="instrumentType">Instrument type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetPositionUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to account order updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#order-channel" /></para>
        /// </summary>
        /// <param name="instrumentType">Instrument type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to plan order updates
        /// <para><a href="https://bitgetlimited.github.io/apidoc/en/mix/#plan-order-channel" /></para>
        /// </summary>
        /// <param name="instrumentType">Instrument type</param>
        /// <param name="handler">The handler for the data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPlanOrderUpdatesAsync(BitgetInstrumentType instrumentType, Action<DataEvent<IEnumerable<BitgetFuturesPlanOrderUpdate>>> handler, CancellationToken ct = default);

    }
}
