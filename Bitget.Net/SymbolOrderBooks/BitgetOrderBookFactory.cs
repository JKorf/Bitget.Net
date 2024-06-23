using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.OrderBook;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.SymbolOrderBooks
{
    /// <summary>
    /// Bitget order book factory
    /// </summary>
    public class BitgetOrderBookFactory : IBitgetOrderBookFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <inheritdoc />
        public IOrderBookFactory<BitgetOrderBookOptions> Spot { get; }
        /// <inheritdoc />
        public IOrderBookFactory<BitgetOrderBookOptions> UsdtFutures { get; }
        /// <inheritdoc />
        public IOrderBookFactory<BitgetOrderBookOptions> UsdcFutures { get; }
        /// <inheritdoc />
        public IOrderBookFactory<BitgetOrderBookOptions> CoinFutures { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider">Service provider for resolving logging and clients</param>
        public BitgetOrderBookFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            Spot = new OrderBookFactory<BitgetOrderBookOptions>((symbol, options) => CreateSpot(symbol, options), (baseAsset, quoteAsset, options) => CreateSpot(baseAsset + quoteAsset, options));
            UsdtFutures = new OrderBookFactory<BitgetOrderBookOptions>((symbol, options) => CreateFutures(BitgetProductTypeV2.UsdtFutures, symbol, options), (baseAsset, quoteAsset, options) => CreateFutures(BitgetProductTypeV2.UsdtFutures, baseAsset + quoteAsset, options));
            UsdcFutures = new OrderBookFactory<BitgetOrderBookOptions>((symbol, options) => CreateFutures(BitgetProductTypeV2.UsdcFutures, symbol, options), (baseAsset, quoteAsset, options) => CreateFutures(BitgetProductTypeV2.UsdcFutures, baseAsset + quoteAsset, options));
            CoinFutures = new OrderBookFactory<BitgetOrderBookOptions>((symbol, options) => CreateFutures(BitgetProductTypeV2.CoinFutures, symbol, options), (baseAsset, quoteAsset, options) => CreateFutures(BitgetProductTypeV2.CoinFutures, baseAsset + quoteAsset, options));
        }

        /// <inheritdoc />
        public ISymbolOrderBook CreateSpot(string symbol, Action<BitgetOrderBookOptions>? options = null)
            => new BitgetSpotSymbolOrderBook(symbol,
                                             options,
                                             _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                             _serviceProvider.GetRequiredService<IBitgetSocketClient>());

        /// <inheritdoc />
        public ISymbolOrderBook CreateFutures(BitgetProductTypeV2 productType, string symbol, Action<BitgetOrderBookOptions>? options = null)
            => new BitgetFuturesSymbolOrderBook(productType, symbol,
                                             options,
                                             _serviceProvider.GetRequiredService<ILoggerFactory>(),
                                             _serviceProvider.GetRequiredService<IBitgetSocketClient>());
    }
}
