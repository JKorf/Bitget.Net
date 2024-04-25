using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;

namespace Bitget.Net.Interfaces
{
    /// <summary>
    /// Bitget order book factory
    /// </summary>
    public interface IBitgetOrderBookFactory
    {
        /// <summary>
        /// Spot order book factory methods
        /// </summary>
        public IOrderBookFactory<BitgetOrderBookOptions> Spot { get; }

        /// <summary>
        /// Futures order book factory methods
        /// </summary>
        public IOrderBookFactory<BitgetOrderBookOptions> Futures { get; }

        /// <summary>
        /// Create a SymbolOrderBook for a spot symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateSpot(string symbol, Action<BitgetOrderBookOptions>? options = null);
        /// <summary>
        /// Create a SymbolOrderBook for a futures symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateFutures(string symbol, Action<BitgetOrderBookOptions>? options = null);
    }
}