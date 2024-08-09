using Bitget.Net.Clients.SpotApi;
using Bitget.Net.Interfaces.Clients.FuturesApi;
using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bitget.Net.Clients.FuturesApi
{
    /// <inheritdoc />
    internal class BitgetRestClientFuturesApi : RestApiClient, IBitgetRestClientFuturesApi
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Futures Api");

        /// <inheritdoc />
        public IBitgetRestClientFuturesApiAccount Account { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesApiTrading Trading { get; }

        internal BitgetRestClientFuturesApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.FuturesOptions)
        {
            Account = new BitgetRestClientFuturesApiAccount(this);
            ExchangeData = new BitgetRestClientFuturesApiExchangeData(this);
            Trading = new BitgetRestClientFuturesApiTrading(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", !string.IsNullOrEmpty(options.ChannelCode) ? options.ChannelCode! : baseClient._defaultChannelCode }
            };
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, ApiType? futuresType = null) => baseAsset.ToUpperInvariant() + quoteAsset.ToUpperInvariant() + "_UMCBL";

        internal Uri GetUri(string path)
        {
            return new Uri(BaseAddress.AppendPath(path));
        }

        internal async Task<WebCallResult> ExecuteAsync(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse>(uri, method, ct, parameters, signed, parameterPosition: parameterPosition, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.AsDatalessError(result.Error!);

            if (result.Data.Code != 0)
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.AsDataless();
        }

        internal async Task<WebCallResult<T>> ExecuteAsync<T>(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse<T>>(uri, method, ct, parameters, signed, parameterPosition: parameterPosition, requestWeight: 0).ConfigureAwait(false);
            if (!result)
                return result.AsError<T>(result.Error!);

            if (result.Data.Code != 0)
                return result.AsError<T>(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.As(result.Data.Data!);
        }

        internal async Task<WebCallResult<T>> ExecuteRawAsync<T>(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? parameterPosition = null) where T : class
        {
            var result = await SendRequestAsync<T>(uri, method, ct, parameters, signed, parameterPosition: parameterPosition, requestWeight:0).ConfigureAwait(false);
            if (!result)
                return result.AsError<T>(result.Error!);

            return result.As(result.Data!);
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders, IMessageAccessor accessor)
        {
            if (!accessor.IsJson)
                return new ServerError(accessor.GetOriginalString());

            var code = accessor.GetValue<int?>(MessagePath.Get().Property("code"));
            var msg = accessor.GetValue<string>(MessagePath.Get().Property("msg"));
            if (msg == null)
                return new ServerError(accessor.GetOriginalString());

            if (code == null)
                return new ServerError(msg);

            return new ServerError(code.Value, msg);
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override TimeSyncInfo? GetTimeSyncInfo()
            => new TimeSyncInfo(_logger, (ApiOptions.AutoTimestamp ?? ClientOptions.AutoTimestamp), (ApiOptions.TimestampRecalculationInterval ?? ClientOptions.TimestampRecalculationInterval), _timeSyncState);

        /// <inheritdoc />
        public override TimeSpan? GetTimeOffset()
            => _timeSyncState.TimeOffset;
    }
}
