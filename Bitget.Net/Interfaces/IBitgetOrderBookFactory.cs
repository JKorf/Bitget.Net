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
        /// Create a SymbolOrderBook for a spot symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateSpot(string symbol, Action<BitgetOrderBookOptions>? options = null);
    }
}