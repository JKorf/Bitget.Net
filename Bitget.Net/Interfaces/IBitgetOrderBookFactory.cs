using Bitget.Net.Enums;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.SharedApis;

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
        /// Usdt futures order book factory methods
        /// </summary>
        public IOrderBookFactory<BitgetOrderBookOptions> UsdtFutures { get; }

        /// <summary>
        /// Coin futures order book factory methods
        /// </summary>
        public IOrderBookFactory<BitgetOrderBookOptions> CoinFutures { get; }

        /// <summary>
        /// Usdc futures order book factory methods
        /// </summary>
        public IOrderBookFactory<BitgetOrderBookOptions> UsdcFutures { get; }

        /// <summary>
        /// Create a SymbolOrderBook for the symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="productType">Product type (for linear futures)</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook Create(SharedSymbol symbol, BitgetProductTypeV2? productType = null, Action<BitgetOrderBookOptions>? options = null);

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
        /// <param name="productType">The product type</param>
        /// <param name="symbol">The symbol</param>
        /// <param name="options">Book options</param>
        /// <returns></returns>
        ISymbolOrderBook CreateFutures(BitgetProductTypeV2 productType, string symbol, Action<BitgetOrderBookOptions>? options = null);
    }
}