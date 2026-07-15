using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal partial class BitgetRestClientSpotApi : RestApiClient<BitgetEnvironment, BitgetAuthenticationProviderV2, BitgetCredentials>, IBitgetRestClientSpotApi
    {
        protected override ErrorMapping ErrorMapping => BitgetErrors.RestErrors;
        /// <inheritdoc />
        public IBitgetRestClientSpotApiAccount Account { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiMargin Margin { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IBitgetRestClientSpotApiTrading Trading { get; }

        /// <inheritdoc />
        public IBitgetRestClientSpotApiShared SharedClient => this;

        /// <inheritdoc />
        public new BitgetRestOptions ClientOptions => (BitgetRestOptions)base.ClientOptions;

        protected override IRestMessageHandler MessageHandler { get; } = new BitgetRestMessageHandler(BitgetErrors.RestErrors);

        internal BitgetRestClient _baseClient;

        internal BitgetRestClientSpotApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(loggerFactory, BitgetExchange.Metadata.Id, httpClient, options.Environment.RestBaseAddress, options, options.SpotOptions)
        {
            _baseClient = baseClient;

            Account = new BitgetRestClientSpotApiAccount(this);
            Margin = new BitgetRestClientSpotApiMargin(this);
            ExchangeData = new BitgetRestClientSpotApiExchangeData(this);
            Trading = new BitgetRestClientSpotApiTrading(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", LibraryHelpers.GetClientReference(() => options.ChannelCode, Exchange) },
                { "locale", options.Locale }
            };

            if (options.Environment.Name == BitgetEnvironment.DemoTrading.Name)
                StandardRequestHeaders.Add("paptrading", "1");
        }

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        /// <inheritdoc />
        protected override BitgetAuthenticationProviderV2 CreateAuthenticationProvider(BitgetCredentials credentials)
            => new BitgetAuthenticationProviderV2(credentials);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => BitgetExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

        internal async Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null) where T : class
        {
            var result = await base.SendAsync<BitgetResponse<T>>(definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<T>(result);

            if (result.Data.Code != 0)
                return HttpResult.Fail<T>(result, new ServerError(result.Data.Code.ToString(), GetErrorInfo(result.Data.Code, result.Data.Message!)));

            return HttpResult.Ok<T>(result, result.Data.Data!);
        }

        internal async Task<HttpResult> SendAsync(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null, Dictionary<string, string>? requestHeaders = null)
        {
            var result = await base.SendAsync<BitgetResponse>(definition, parameters, cancellationToken, requestHeaders, weight).ConfigureAwait(false);
            if (!result.Success)
                return result;

            if (result.Data.Code != 0)
                return HttpResult.Fail(result, new ServerError(result.Data.Code.ToString(), GetErrorInfo(result.Data.Code, result.Data.Message!)));

            return result;
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

    }
}
