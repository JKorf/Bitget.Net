using Bitget.Net.Clients.FuturesApiV2;
using Bitget.Net.Enums;
using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using System.Timers;

namespace Bitget.Net.Clients.SpotApiV2
{
    internal partial class BitgetRestClientSpotSharedApi
    {
        #region Get Spot Ticker

        public GetSpotTickerOptions GetSpotTickerOptions { get; } = new GetSpotTickerOptions(_exchangeName);

        async Task<ICallResult<SharedSpotTicker>> IGetSpotTicker.GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
            => await GetSpotTickerAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotTicker>> GetSpotTickerAsync(GetTickerRequest request, CancellationToken ct)
        {
            var validationError = GetSpotTickerOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker>(Exchange, validationError);

            var result = await _api.ExchangeData.GetTickersAsync(request.Symbol!.GetSymbol(FormatSymbol), ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker>(result);

            var ticker = result.Data.Single();
            return HttpResult.Ok(result, 
                new SharedSpotTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, ticker.Symbol),
                    ticker.Symbol, 
                    ticker.LastPrice, 
                    ticker.HighPrice,
                    ticker.LowPrice, 
                    new SharedOrderQuantity(ticker.Volume, ticker.QuoteVolume),
                    ticker.ChangePercentage24H * 100)
            {
            });
        }

        #endregion

        #region Get All Spot Tickers

        Task<HttpResult<SharedSpotTicker[]>> ISpotTickerRestClient.GetSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
            => GetAllSpotTickersAsync(request, ct);
        GetAllSpotTickersOptions ISpotTickerRestClient.GetSpotTickersOptions => GetAllSpotTickersOptions;

        public GetAllSpotTickersOptions GetAllSpotTickersOptions { get; } = new GetAllSpotTickersOptions(_exchangeName);
        async Task<ICallResult<SharedSpotTicker[]>> IGetAllSpotTickers.GetAllSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
            => await GetAllSpotTickersAsync(request, ct).ConfigureAwait(false);

        public async Task<HttpResult<SharedSpotTicker[]>> GetAllSpotTickersAsync(GetTickersRequest request, CancellationToken ct)
        {
            var validationError = GetAllSpotTickersOptions.ValidateRequest(request, this);
            if (validationError != null)
                return HttpResult.Fail<SharedSpotTicker[]>(Exchange, validationError);

            var result = await _api.ExchangeData.GetTickersAsync(ct: ct).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<SharedSpotTicker[]>(result);

            return HttpResult.Ok(result, result.Data.Select(x => 
                new SharedSpotTicker(
                    ExchangeSymbolCache.ParseSymbol(_topicId, _api.EnvironmentName, null, x.Symbol),
                    x.Symbol,
                    x.LastPrice,
                    x.HighPrice,
                    x.LowPrice,
                    new SharedOrderQuantity(x.Volume, x.QuoteVolume),
                    x.ChangePercentage24H * 100)
                {
                }).ToArray());
        }

        #endregion

    }
}
