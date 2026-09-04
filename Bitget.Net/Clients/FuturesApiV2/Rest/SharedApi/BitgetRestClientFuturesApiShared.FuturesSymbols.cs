using Bitget.Net.Enums;
using Bitget.Net.Enums.Uta;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using ContractType = Bitget.Net.Enums.V2.ContractType;

namespace Bitget.Net.Clients.FuturesApiV2
{
    internal partial class BitgetRestClientFuturesSharedApi
    {
        #region Get Futures Symbols

        public SharedSymbolCatalog? FuturesSymbolCatalog => ExchangeSymbolCache.GetSymbolCatalog(_exchangeName, _topicId, _api.EnvironmentName, null);
        public GetFuturesSymbolsOptions GetFuturesSymbolsOptions { get; } = new GetFuturesSymbolsOptions(_exchangeName, false)
        {
            RequiredExchangeParameters = new List<ParameterDescription>
            {
                new ParameterDescription("ProductType", typeof(string), "The product type that is target, either UsdcFutures, UsdtFutures or CoinFutures", "UsdtFutures")
            }
        };
        async Task<ICallResult<SharedFuturesSymbol[]>> IGetFuturesSymbols.GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
            => await GetFuturesSymbolsAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedFuturesSymbol[]>> GetFuturesSymbolsAsync(GetSymbolsRequest request, CancellationToken ct)
        {
            var validationError = GetFuturesSymbolsOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedFuturesSymbol[]>(Exchange, validationError);

            var productCategory = GetProductCategory(request.TradingMode, request.ExchangeParameters);
            var result = await _api._baseClient.UnifiedApi.ExchangeData.GetFuturesSymbolsAsync(
                productCategory,
                ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedFuturesSymbol[]>(result);

            var data = result.Data
                .Select(x => ParseSymbol(x, productCategory))
                .ToArray();

            ExchangeSymbolCache.UpdateSymbolInfo(_topicId, _api.EnvironmentName, productCategory.ToString(), data);
            return HttpResult.Ok(result, SharedUtils.ApplySymbolFilter(data, request));
        }

        #endregion

        private SharedFuturesSymbol ParseSymbol(BitgetUaFuturesSymbol s, ProductCategory productCategory)
        {
            var result = new SharedFuturesSymbol(
                    productCategory == ProductCategory.CoinFutures && s.Type == ContractType.Delivery ? TradingMode.DeliveryInverse :
                    productCategory == ProductCategory.CoinFutures && s.Type == ContractType.Perpetual ? TradingMode.PerpetualInverse :
                    s.DeliveryPeriod.HasValue ? TradingMode.DeliveryLinear :
                    TradingMode.PerpetualLinear,
                    s.BaseAsset,
                    s.QuoteAsset,
                    s.Symbol,
                    s.Status == InstrumentStatus.Online)
            {
                MinTradeQuantity = s.MinOrderQuantity,
                PriceDecimals = s.PricePrecision,
                QuantityDecimals = s.QuantityPrecision,
                DeliveryTime = s.DeliveryTime,
                PriceStep = s.PriceMultiplier,
                QuantityStep = s.QuantityMultiplier,
                ContractSize = 1,
                MaxShortLeverage = s.MaxLeverage,
                MaxLongLeverage = s.MaxLeverage,
                MaxTradeQuantity = Math.Min(s.MaxOrderQuantity, s.MaxMarketOrderQuantity),
                DisplayName = s.Symbol,
                TakerFeePercentage = s.TakerFeeRate * 100,
                MakerFeePercentage = s.MakerFeeRate * 100,
                UpperPriceLimitPercentage = s.SellLimitPriceRatio * 100,
                LowerPriceLimitPercentage = -s.BuyLimitPriceRatio * 100
            };

            if (productCategory != ProductCategory.CoinFutures)
            {
                result.BaseAssetType = s.IsRwa ? SharedAssetType.TradFi : SharedAssetType.Crypto;
                result.BaseAssetSubType = ParseSymbolSubType(s);
                result.QuoteAssetType = SharedAssetType.Crypto;
                result.QuoteAssetSubType = SharedAssetSubType.StableCoin;
            }
            else
            {
                result.BaseAssetType = SharedAssetType.Crypto;
                result.QuoteAssetType = SharedAssetType.Fiat;
            }

            return result;
        }

        private SharedAssetSubType? ParseSymbolSubType(BitgetUaFuturesSymbol s)
        {
            if (s.SymbolType == SymbolType.Commodity || s.SymbolType == SymbolType.Metal)
                return SharedAssetSubType.Commodity;

            if (s.SymbolType == SymbolType.Stock)
                return SharedAssetSubType.Equity;

            return null;
        }

        public async Task<ExchangeCallResult<SharedSymbol[]>> GetFuturesSymbolsForBaseAssetAsync(string baseAsset)
        {
            if (!ExchangeSymbolCache.HasCached(_topicId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<SharedSymbol[]>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<SharedSymbol[]>.Ok(Exchange, ExchangeSymbolCache.GetSymbolsForBaseAsset(_topicId, _api.EnvironmentName, null, baseAsset));
        }

        public async Task<ExchangeCallResult<bool>> SupportsFuturesSymbolAsync(SharedSymbol symbol)
        {
            if (symbol.TradingMode == TradingMode.Spot)
                throw new ArgumentException(nameof(symbol), "Spot symbols not allowed");

            if (!ExchangeSymbolCache.HasCached(_topicId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicId, _api.EnvironmentName, null, symbol));
        }

        public async Task<ExchangeCallResult<bool>> SupportsFuturesSymbolAsync(string symbolName)
        {
            if (!ExchangeSymbolCache.HasCached(_topicId, _api.EnvironmentName, null))
            {
                var symbols = await GetFuturesSymbolsAsync(new GetSymbolsRequest(), default).ConfigureAwait(false);
                if (!symbols.Success)
                    return ExchangeCallResult<bool>.Fail(Exchange, symbols.Error!);
            }

            return ExchangeCallResult<bool>.Ok(Exchange, ExchangeSymbolCache.SupportsSymbol(_topicId, _api.EnvironmentName, null, symbolName));
        }
    }
}
