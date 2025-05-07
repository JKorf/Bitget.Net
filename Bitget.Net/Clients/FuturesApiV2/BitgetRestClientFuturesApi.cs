using Bitget.Net.Interfaces.Clients.FuturesApiV2;
using Bitget.Net.Objects;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients.FuturesApiV2
{
    /// <inheritdoc />
    internal partial class BitgetRestClientFuturesApi : RestApiClient, IBitgetRestClientFuturesApi
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Futures Api");

        /// <inheritdoc />
        public IBitgetRestClientFuturesApiAccount Account { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBitgetRestClientFuturesApiTrading Trading { get; }

        /// <inheritdoc />
        public string ExchangeName => "Bitget";


        internal BitgetRestClientFuturesApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.FuturesOptions)
        {
            Account = new BitgetRestClientFuturesApiAccount(this);
            ExchangeData = new BitgetRestClientFuturesApiExchangeData(this);
            Trading = new BitgetRestClientFuturesApiTrading(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", !string.IsNullOrEmpty(options.ChannelCode) ? options.ChannelCode! : baseClient._defaultChannelCode },
                { "locale", options.Locale }
            };

            if (options.Environment.Name == "DemoTrading")
                StandardRequestHeaders.Add("paptrading", "1");
        }

        /// <inheritdoc />
        protected override IStreamMessageAccessor CreateAccessor() => new SystemTextJsonStreamMessageAccessor(SerializerOptions.WithConverters(BitgetExchange._serializerContext));
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public IBitgetRestClientFuturesApiShared SharedClient => this;

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BitgetAuthenticationProviderV2(credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight, requestHeaders);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null) where T : class
        {
            var result = await base.SendAsync<BitgetResponse<T>>(baseAddress, definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return result.As<T>(default);

            if (result.Data.Code != 0)
                return result.AsError<T>(new ServerError(result.Data.Code, result.Data.Message!));

            return result.As<T>(result.Data.Data);
        }

        internal Task<WebCallResult> SendAsync(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null)
            => SendToAddressAsync(BaseAddress, definition, parameters, cancellationToken, weight, requestHeaders);

        internal async Task<WebCallResult> SendToAddressAsync(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null)
        {
            var result = await base.SendAsync<BitgetResponse>(baseAddress, definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return result.AsDataless();

            if (result.Data.Code != 0)
                return result.AsDatalessError(new ServerError(result.Data.Code, result.Data.Message!));

            return result.AsDataless();
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor, Exception? exception)
        {
            if (!accessor.IsJson)
                return new ServerError(null, "Unknown request error", exception: exception);

            var code = accessor.GetValue<string>(MessagePath.Get().Property("code"));
            var msg = accessor.GetValue<string>(MessagePath.Get().Property("msg"));
            if (msg == null)
                return new ServerError(null, "Unknown request error", exception: exception);

            if (code == null)
                return new ServerError(null, msg, exception);

            return new ServerError(int.Parse(code), msg, exception);
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
