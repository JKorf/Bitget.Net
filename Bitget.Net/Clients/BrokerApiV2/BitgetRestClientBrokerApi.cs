using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Interfaces.Clients.BrokerApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients.BrokerApiV2
{
    /// <inheritdoc />
    internal partial class BitgetRestClientBrokerApi : RestApiClient, IBitgetRestClientBrokerApi
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        /// <inheritdoc />
        public string ExchangeName => "Bitget";
        protected override IRestMessageHandler MessageHandler { get; } = new BitgetRestMessageHandler(BitgetErrors.RestErrors);


        internal BitgetRestClientBrokerApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.BrokerOptions)
        {
            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", LibraryHelpers.GetClientReference(() => options.ChannelCode, ExchangeName) },
                { "locale", options.Locale }
            };

            if (options.Environment.Name == BitgetEnvironment.DemoTrading.Name)
                StandardRequestHeaders.Add("paptrading", "1");
        }

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public BitgetRestClientBrokerApi SharedClient => this;


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
                return result.AsError<T>(new ServerError(result.Data.Code.ToString(), GetErrorInfo(result.Data.Code, result.Data.Message!)));

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
                return result.AsDatalessError(new ServerError(result.Data.Code.ToString(), GetErrorInfo(result.Data.Code, result.Data.Message!)));

            return result.AsDataless();
        }

        public async Task<WebCallResult<BitgetBrokerAgentDirectCommissions>> GetAgentDirectCommissionsAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, string? coin = null, string? symbol = null, bool? showSub = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptionalString("idLessThan", idLessThan);
            parameters.AddString("limit", limit);
            parameters.AddOptionalString("uid", uid);
            parameters.AddOptional("coin", coin);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("showSub", showSub == null ? null : showSub == true ? "yes" : "no");

            var request = _definitions.GetOrCreate(HttpMethod.Get, "/api/v2/broker/customer-commissions", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await SendAsync<BitgetBrokerAgentDirectCommissions>(request, parameters, ct).ConfigureAwait(false);
        }

        public async Task<WebCallResult<BitgetBrokerAgentCustomer[]>> GetAgentCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 100, long? uid = null, string? referralCode = null, bool? showSub = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddString("pageNo", pageNo);
            parameters.AddString("pageSize", pageSize);
            parameters.AddOptionalString("uid", uid);
            parameters.AddOptional("referralCode", referralCode);
            parameters.AddOptional("showSub", showSub == null ? null : showSub == true ? "yes" : "no");

            var request = _definitions.GetOrCreate(HttpMethod.Post, "/api/v2/broker/customer-list", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await SendAsync<BitgetBrokerAgentCustomer[]>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}
