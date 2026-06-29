using Bitget.Net.Clients.MessageHandlers;
using Bitget.Net.Interfaces.Clients.BrokerApiV2;
using Bitget.Net.Objects.Models;
using Bitget.Net.Objects.Models.V2;
using Bitget.Net.Objects.Options;
using CryptoExchange.Net;
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
    internal partial class BitgetRestClientBrokerApi : RestApiClient<BitgetEnvironment, BitgetAuthenticationProviderV2, BitgetCredentials>, IBitgetRestClientBrokerApi
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        protected override IRestMessageHandler MessageHandler { get; } = new BitgetRestMessageHandler(BitgetErrors.RestErrors);


        internal BitgetRestClientBrokerApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(loggerFactory, BitgetExchange.Metadata.Id, httpClient, options.Environment.RestBaseAddress, options, options.BrokerOptions)
        {
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

        public BitgetRestClientBrokerApi SharedClient => this;

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

        public async Task<HttpResult<BitgetBrokerAgentDirectCommissions>> GetAgentDirectCommissionsAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, string? coin = null, string? symbol = null, bool? showSub = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            parameters.Add("uid", uid);
            parameters.Add("coin", coin);
            parameters.Add("symbol", symbol);
            parameters.Add("showSub", showSub == null ? null : showSub == true ? "yes" : "no");

            var request = _definitions.GetOrCreate(HttpMethod.Get, BaseAddress, "/api/v2/broker/customer-commissions", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await SendAsync<BitgetBrokerAgentDirectCommissions>(request, parameters, ct).ConfigureAwait(false);
        }

        public async Task<HttpResult<BitgetBrokerAgentCustomer[]>> GetAgentCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, int pageNo = 1, int pageSize = 100, long? uid = null, string? referralCode = null, bool? showSub = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("pageNo", pageNo);
            parameters.Add("pageSize", pageSize);
            parameters.Add("uid", uid);
            parameters.Add("referralCode", referralCode);
            parameters.Add("showSub", showSub == null ? null : showSub == true ? "yes" : "no");

            var request = _definitions.GetOrCreate(HttpMethod.Post, BaseAddress, "/api/v2/broker/customer-list", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await SendAsync<BitgetBrokerAgentCustomer[]>(request, parameters, ct).ConfigureAwait(false);
        }

        public async Task<HttpResult<BitgetBrokerAgentCustomerList>> GetAgentSubCustomerListAsync(DateTime? startTime = null, DateTime? endTime = null, long? idLessThan = null, int limit = 100, long? uid = null, bool? showSub = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(BitgetExchange._parameterSerializationSettings);
            parameters.Add("startTime", startTime);
            parameters.Add("endTime", endTime);
            parameters.Add("idLessThan", idLessThan);
            parameters.Add("limit", limit);
            parameters.Add("uid", uid);
            parameters.Add("showSub", showSub == null ? null : showSub == true ? "yes" : "no");

            var request = _definitions.GetOrCreate(HttpMethod.Get, BaseAddress, "/api/v2/broker/sub-customer-list", BitgetExchange.RateLimiter.Overall, 1, true,
                limitGuard: new SingleLimitGuard(10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding, keySelector: SingleLimitGuard.PerApiKey));
            return await SendAsync<BitgetBrokerAgentCustomerList>(request, parameters, ct).ConfigureAwait(false);
        }
    }
}
