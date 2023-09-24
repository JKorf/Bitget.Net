using Bitget.Net.Interfaces.Clients.SpotApi;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Bitget.Net.Clients.SpotApi
{
    /// <inheritdoc />
    public class BitgetRestClientSpotApi : RestApiClient, IBitgetRestClientSpotApi//, ISpotClient
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Spot Api");

        /// <inheritdoc />
        public IBitgetRestClientSpotApiAccount Account { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiTrading Trading { get; }

        internal BitgetRestClientSpotApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.BaseAddress, options, options.SpotOptions)
        {
            Account = new BitgetRestClientSpotApiAccount(this);
            ExchangeData = new BitgetRestClientSpotApiExchangeData(this);
            Trading = new BitgetRestClientSpotApiTrading(this);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BitgetAuthenticationProvider((BitgetApiCredentials)credentials);

        internal Uri GetUri(string path)
        {
            return new Uri(BaseAddress.AppendPath(path));
        }

        internal async Task<WebCallResult> ExecuteAsync(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, int weight = 1, bool ignoreRatelimit = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse>(uri, method, ct, parameters, signed, parameterPosition, requestWeight: weight, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
            if (!result)
                return result.AsDatalessError(result.Error!);

            if (result.Data.Code != "00000")
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.AsDataless();
        }

        internal async Task<WebCallResult<T>> ExecuteAsync<T>(Uri uri, HttpMethod method, CancellationToken ct, Dictionary<string, object>? parameters = null, bool signed = false, int weight = 1, bool ignoreRatelimit = false, HttpMethodParameterPosition? parameterPosition = null)
        {
            var result = await SendRequestAsync<BitgetResponse<T>>(uri, method, ct, parameters, signed, parameterPosition, requestWeight: weight, ignoreRatelimit: ignoreRatelimit).ConfigureAwait(false);
            if (!result)
                return result.AsError<T>(result.Error!);

            if (result.Data.Code != "00000")
                return result.AsError<T>(new ServerError(result.Data.Code, result.Data.Message ?? "-"));

            return result.As(result.Data.Data!);
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders, string data)
        {
            var tokenData = data.ToJToken();
            if (tokenData == null)
                return new ServerError(data);

            var msg = tokenData["msg"];
            var code = tokenData["code"];
            if (msg == null || code == null || !int.TryParse(code.ToString(), out var intCode))
                return new ServerError(data);

            return new ServerError(intCode, msg.ToString());
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
