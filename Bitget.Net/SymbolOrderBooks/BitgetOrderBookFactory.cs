using Bitget.Net.Enums;
using Bitget.Net.Interfaces;
using Bitget.Net.Interfaces.Clients;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.SharedApis;
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

            Spot = new OrderBookFactory<BitgetOrderBookOptions>(CreateSpot,
                (sharedSymbol, options) => CreateSpot(BitgetExchange.FormatSymbol(sharedSymbol.BaseAsset, sharedSymbol.QuoteAsset, sharedSymbol.TradingMode, sharedSymbol.DeliverTime), options));
            UsdtFutures = new OrderBookFactory<BitgetOrderBookOptions>(
                (symbol, options) => CreateFutures(BitgetProductTypeV2.UsdtFutures, symbol, options),
                (sharedSymbol, options) => CreateFutures(BitgetProductTypeV2.UsdtFutures, sharedSymbol.GetSymbol(BitgetExchange.FormatSymbol), options));
            UsdcFutures = new OrderBookFactory<BitgetOrderBookOptions>(
                (symbol, options) => CreateFutures(BitgetProductTypeV2.UsdcFutures, symbol, options),
                (sharedSymbol, options) => CreateFutures(BitgetProductTypeV2.UsdcFutures, sharedSymbol.GetSymbol(BitgetExchange.FormatSymbol), options));
            CoinFutures = new OrderBookFactory<BitgetOrderBookOptions>(
                (symbol, options) => CreateFutures(BitgetProductTypeV2.CoinFutures, symbol, options),
                (sharedSymbol, options) => CreateFutures(BitgetProductTypeV2.CoinFutures, sharedSymbol.GetSymbol(BitgetExchange.FormatSymbol), options));
        }

        /// <inheritdoc />
        public ISymbolOrderBook Create(SharedSymbol symbol, BitgetProductTypeV2? productType = null, Action<BitgetOrderBookOptions>? options = null)
        {
            var symbolName = symbol.GetSymbol(BitgetExchange.FormatSymbol);
            if (symbol.TradingMode == TradingMode.Spot)
                return CreateSpot(symbolName, options);

            if (symbol.TradingMode.IsInverse())
                return CreateFutures(BitgetProductTypeV2.CoinFutures, symbolName, options);

            return CreateFutures(productType ?? BitgetProductTypeV2.UsdcFutures, symbolName, options);
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
