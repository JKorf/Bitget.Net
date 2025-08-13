using Bitget.Net.Enums.V2;
using Bitget.Net.Interfaces.Clients.SpotApiV2;
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
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;

namespace Bitget.Net.Clients.SpotApiV2
{
    /// <inheritdoc />
    internal partial class BitgetRestClientSpotApi : RestApiClient, IBitgetRestClientSpotApi
    {
        internal static TimeSyncState _timeSyncState = new TimeSyncState("Spot Api");

        protected override ErrorCollection ErrorMapping { get; } = new ErrorCollection(
            [
                new ErrorInfo(ErrorType.SignatureInvalid, false, "API Key empty", "40001"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Sign empty", "40002"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Signature empty", "40003"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Invalid API key", "40006"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Signature error", "40009"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Passphrase empty", "40011"),
                new ErrorInfo(ErrorType.SignatureInvalid, false, "Invalid credentials", "40012"),

                new ErrorInfo(ErrorType.TimestampInvalid, false, "Timestamp expired",["40004", "40008", "40911", "40078"]),
                new ErrorInfo(ErrorType.TimestampInvalid, false, "Invalid timestamp", "40005"),

                new ErrorInfo(ErrorType.Timeout, false, "Request timed out",["40010", "40910"]),

                new ErrorInfo(ErrorType.Unauthorized, false, "2FA required", "40016"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Insufficient permissions",["40014", "40040"]),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid IP",["40018", "49003"]),
                new ErrorInfo(ErrorType.Unauthorized, false, "Withdrawal disabled", "40021"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Account restricted",["40022", "40023", "40025", "40916"]),
                new ErrorInfo(ErrorType.Unauthorized, false, "Account frozen", "40024"),
                new ErrorInfo(ErrorType.Unauthorized, false, "User disabled", "40026"),
                new ErrorInfo(ErrorType.Unauthorized, false, "KYC required",["40111", "40027", "40035", "40100", "40101", "59005"]),
                new ErrorInfo(ErrorType.Unauthorized, false, "Passphrase error", "40036"),
                new ErrorInfo(ErrorType.Unauthorized, false, "API key doesn't exist",["40037", "40041"]),
                new ErrorInfo(ErrorType.Unauthorized, false, "IP address not whitelisted", "40038"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Withdrawals temporarily disabled", "40052"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Unauthorized because of region", ["40000", "40104", "59006", "40103"]),

                new ErrorInfo(ErrorType.SystemError, true, "System unavailable", "40015"),
                new ErrorInfo(ErrorType.SystemError, true, "Server upgrade in progress", "40200"),
                new ErrorInfo(ErrorType.SystemError, true, "Status check abnormal",["40400", "40846"]),
                new ErrorInfo(ErrorType.SystemError, false, "Operation cannot be performed", "40401"),
                new ErrorInfo(ErrorType.SystemError, true, "Request failed, try again", "43059"),
                new ErrorInfo(ErrorType.SystemError, true, "Unknown error", ["19000", "59046", "59021", "45001", "49040", "50010", "50031", "31027", "80002"]),

                new ErrorInfo(ErrorType.InvalidParameter, false, "Parameter verification failed",["40017", "00171", "00172", "40053","40056","40057","40058","40059","40808", "43058", "41103", "41101", "43111", "43123",
                    "48001", "50011", "31028", "60006", "41002", "59013", "400172"]),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid parameter", "70101", "40020", "80001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Unknown parameter", "40034"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Asset does not support cross margin", "50001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Symbol does not support isolated margin", "50002"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Asset does not support cross isolated", "50003"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Symbol does not support cross margin", "50004"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "ClientOrderId invalid",["40304", "40305"]),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Batch endpoint only supports up to 20 orders", "40306"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Invalid orderId or clientOrderId", "40402"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Range validation failed", "40408", "70006"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Format validation failed", "40409"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Can only check the last 3 months", "40704"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Can only check the last 90 days", "40705"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Can only check the last 30 days", "70007", "70008"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Condition not met",["40812", "31002"]),
                new ErrorInfo(ErrorType.InvalidParameter, false, "One of orderId or clientOrderId should be provided", "40924"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Price or size should be provided together", "40925"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "No more than 8 decimal places allowed", "43125"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Decimal precision error", "01002", "49024"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Maximum digits error", "49026", "59014"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "StartTime should be less than endTime", "42072", "20001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "StartTime and endTime should not be greater than 366 days", "00001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "StartTime error", "70103", "43130"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "EndTime error", "70104"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "ReceiveWindow should be less than 60 seconds", "40079"),

                new ErrorInfo(ErrorType.MissingParameter, false, "Missing parameter",["40019", "48002"]),
                new ErrorInfo(ErrorType.MissingParameter, false, "Parameter empty", "40724"),
                new ErrorInfo(ErrorType.MissingParameter, false, "Parameter should not be null", "40811"),
                new ErrorInfo(ErrorType.MissingParameter, false, "Parameter should have value",["01001", "40813", "31003"]),

                new ErrorInfo(ErrorType.PriceInvalid, false, "Invalid order price",["40706", "50018"]),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price higher than highest bid price", "40815"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price lower than lowest bid price", "40816"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price lower than liquidation price", "40820"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Order price higher than liquidation price", "40821"),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Price step invalid",["40787", "43028", "45035", "45115"]),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Max price limit exceeded",["43039", "43009", "50047"]),
                new ErrorInfo(ErrorType.PriceInvalid, false, "Min price limit exceeded",["43040", "43008", "50046"]),

                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order quantity greater than max open quantity", "40762"),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order value too low",["43027", "43042", "43006", "43010", "45110", "45114"]),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Position smaller than the order quantity", "43029"),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order quantity too small",["43037", "45111"]),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Order quantity too large",["43038", "45112"]),
                new ErrorInfo(ErrorType.QuantityInvalid, false, "Max order value exceeded",["43041", "43007", "45103", "45104", "45113"]),

                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Market order not currently allowed", "40824"),
                new ErrorInfo(ErrorType.OrderConfigurationRejected, false, "Currently only market orders can be placed", "45123"),

                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Long position take profit price should be greater than the average open price",["40735", "40829", "45064"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Long position take profit price should be greater than current price",["40736", "40830", "40915", "43013", "45060", "31004"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Short position take profit price should be less than the average open price",["40737", "40831", "45065"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Short position take profit price should be less than current price",["40738", "40832", "43014", "45061"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Long position stop loss price should be less than the average open price",["40739", "40833", "45066"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Long position stop loss price should be less than current price",["40740", "40834", "40917", "43015", "45062", "31005"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Short position stop loss price should be greater than the average open price",["40741", "40835", "45067"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Short position stop loss price should be greater than current price",["40742", "40836", "43016", "45122"]),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price should be less than current market price", "43034"),
                new ErrorInfo(ErrorType.StopParametersInvalid, false, "Trigger price should be greater than current market price", "43035"),

                new ErrorInfo(ErrorType.DuplicateClientOrderId, false, "Duplicate client order id",["40708", "40786", "43118", "45034", "50060"]),

                new ErrorInfo(ErrorType.UnknownAsset, false, "Unknown asset", "50032"),
                new ErrorInfo(ErrorType.UnknownAsset, false, "Asset does not exist", "13002"),

                new ErrorInfo(ErrorType.UnknownSymbol, false, "Symbol invalid", "40072"),
                new ErrorInfo(ErrorType.UnknownSymbol, false, "Symbol does not exist", "40102"),

                new ErrorInfo(ErrorType.UnknownOrder, false, "Order not found",["40109", "22001"]),
                new ErrorInfo(ErrorType.UnknownOrder, false, "Order does not exist",["80011", "40768", "40819", "43001", "45057", "31007"]),

                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Symbol is not currently trading",["40308", "40844", "41113", "41114", "43119", "43120", "50026", "50025", "50027", "50030"]),
                new ErrorInfo(ErrorType.SymbolNotTrading, false, "Symbol is no longer trading",["40309", "40845", "50028"]),

                new ErrorInfo(ErrorType.NoPosition, false, "No position found",["40709", "40838", "43043", "22002"]),
                new ErrorInfo(ErrorType.NoPosition, false, "No position found, can't set tp/sl", "40837"),

                new ErrorInfo(ErrorType.BalanceInsufficient, false, "Insufficient balance",["43132", "59042", "59022", "59011", "60013", "40711", "40798", "43012", "45002", "49023", "40754", "50020"]),
                new ErrorInfo(ErrorType.BalanceInsufficient, false, "Insufficient margin", "40712"),
                new ErrorInfo(ErrorType.BalanceInsufficient, false, "Not enough open position",["40757", "45003", "45005", "45006"]),

                new ErrorInfo(ErrorType.InvalidOperation, false, "Symbol does not support cross margin",["40716", "22005"]),

                new ErrorInfo(ErrorType.OrderRateLimited, false, "Max number of open orders reached",["40761", "40723", "43005", "43128", "45118", "50048", "50017"]),
                new ErrorInfo(ErrorType.OrderRateLimited, false, "Max number of tracking orders reached",["45091"]),

            ]
        );

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
        public string ExchangeName => "Bitget";

        /// <inheritdoc />
        public new BitgetRestOptions ClientOptions => (BitgetRestOptions)base.ClientOptions;

        internal BitgetRestClientSpotApi(ILogger logger, HttpClient? httpClient, BitgetRestClient baseClient, BitgetRestOptions options)
            : base(logger, httpClient, options.Environment.RestBaseAddress, options, options.SpotOptions)
        {
            Account = new BitgetRestClientSpotApiAccount(this);
            Margin = new BitgetRestClientSpotApiMargin(this);
            ExchangeData = new BitgetRestClientSpotApiExchangeData(this);
            Trading = new BitgetRestClientSpotApiTrading(this);

            StandardRequestHeaders = new Dictionary<string, string>
            {
                { "X-CHANNEL-API-CODE", !string.IsNullOrEmpty(options.ChannelCode) ? options.ChannelCode! : baseClient._defaultChannelCode },
                { "locale", options.Locale }
            };

            if (options.Environment.Name == BitgetEnvironment.DemoTrading.Name)
                StandardRequestHeaders.Add("paptrading", "1");
        }

        /// <inheritdoc />
        protected override IStreamMessageAccessor CreateAccessor() => new SystemTextJsonStreamMessageAccessor(SerializerOptions.WithConverters(BitgetExchange._serializerContext));
        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

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

        /// <inheritdoc />
        protected override Error ParseErrorResponse(int httpStatusCode, KeyValuePair<string, string[]>[] responseHeaders, IMessageAccessor accessor, Exception? exception)
        {
            if (!accessor.IsValid)
                return new ServerError(ErrorInfo.Unknown, exception: exception);

            var code = accessor.GetValue<string>(MessagePath.Get().Property("code"));
            var msg = accessor.GetValue<string>(MessagePath.Get().Property("msg"));
            if (msg == null)
                return new ServerError(ErrorInfo.Unknown, exception: exception);

            if (code == null)
                return new ServerError(ErrorInfo.Unknown with { Message = msg }, exception);

            return new ServerError(code, GetErrorInfo(int.Parse(code), msg), exception);
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
