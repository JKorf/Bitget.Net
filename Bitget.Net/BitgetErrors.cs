using CryptoExchange.Net.Objects.Errors;

namespace Bitget.Net
{
    internal static class BitgetErrors
    {
        public static ErrorMapping RestErrors { get; } = new ErrorMapping(
            [
                new ErrorInfo(ErrorType.Unauthorized, false, "API Key empty", "40001"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Sign empty", "40002"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Signature empty", "40003"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid API key", "40006"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Signature error", "40009"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Passphrase empty", "40011"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid credentials", "40012"),
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

                new ErrorInfo(ErrorType.InvalidTimestamp, false, "Timestamp expired",["40004", "40008", "40911", "40078"]),
                new ErrorInfo(ErrorType.InvalidTimestamp, false, "Invalid timestamp", "40005"),

                new ErrorInfo(ErrorType.Timeout, false, "Request timed out",["40010", "40910"]),

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

                new ErrorInfo(ErrorType.InvalidPrice, false, "Invalid order price",["40706", "50018"]),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Order price higher than highest bid price", "40815"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Order price lower than lowest bid price", "40816"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Order price lower than liquidation price", "40820"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Order price higher than liquidation price", "40821"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Price step invalid",["40787", "43028", "45035", "45115"]),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Max price limit exceeded",["43039", "43009", "50047"]),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Min price limit exceeded",["43040", "43008", "50046"]),

                new ErrorInfo(ErrorType.InvalidQuantity, false, "Order quantity greater than max open quantity", "40762"),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Order value too low",["43027", "43042", "43006", "43010", "45110", "45114"]),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Position smaller than the order quantity", "43029"),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Order quantity too small",["43037", "45111"]),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Order quantity too large",["43038", "45112"]),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Max order value exceeded",["43041", "43007", "45103", "45104", "45113"]),

                new ErrorInfo(ErrorType.RejectedOrderConfiguration, false, "Market order not currently allowed", "40824"),
                new ErrorInfo(ErrorType.RejectedOrderConfiguration, false, "Currently only market orders can be placed", "45123"),

                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Long position take profit price should be greater than the average open price",["40735", "40829", "45064"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Long position take profit price should be greater than current price",["40736", "40830", "40915", "43013", "45060", "31004"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Short position take profit price should be less than the average open price",["40737", "40831", "45065"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Short position take profit price should be less than current price",["40738", "40832", "43014", "45061"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Long position stop loss price should be less than the average open price",["40739", "40833", "45066"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Long position stop loss price should be less than current price",["40740", "40834", "40917", "43015", "45062", "31005"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Short position stop loss price should be greater than the average open price",["40741", "40835", "45067"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Short position stop loss price should be greater than current price",["40742", "40836", "43016", "45122"]),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Trigger price should be less than current market price", "43034"),
                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Trigger price should be greater than current market price", "43035"),

                new ErrorInfo(ErrorType.DuplicateClientOrderId, false, "Duplicate client order id",["40708", "40786", "43118", "45034", "50060"]),

                new ErrorInfo(ErrorType.UnknownAsset, false, "Unknown asset", "50032"),
                new ErrorInfo(ErrorType.UnknownAsset, false, "Asset does not exist", "13002"),

                new ErrorInfo(ErrorType.UnknownSymbol, false, "Symbol invalid", "40072"),
                new ErrorInfo(ErrorType.UnknownSymbol, false, "Symbol does not exist", "40102"),

                new ErrorInfo(ErrorType.UnknownOrder, false, "Order not found",["40109", "22001"]),
                new ErrorInfo(ErrorType.UnknownOrder, false, "Order does not exist",["80011", "40768", "40819", "43001", "45057", "31007"]),

                new ErrorInfo(ErrorType.UnavailableSymbol, false, "Symbol is not currently trading",["40308", "40844", "41113", "41114", "43119", "43120", "50026", "50025", "50027", "50030"]),
                new ErrorInfo(ErrorType.UnavailableSymbol, false, "Symbol is no longer trading",["40309", "40845", "50028"]),

                new ErrorInfo(ErrorType.NoPosition, false, "No position found",["40709", "40838", "43043", "22002"]),
                new ErrorInfo(ErrorType.NoPosition, false, "No position found, can't set tp/sl", "40837"),

                new ErrorInfo(ErrorType.MaxPosition, false, "Max position count exceeded", "45116", "59016", "22029"),

                new ErrorInfo(ErrorType.InsufficientBalance, false, "Insufficient balance",["43132", "59042", "59022", "59011", "60013", "40711", "40798", "43012", "45002", "49023", "40754", "50020"]),
                new ErrorInfo(ErrorType.InsufficientBalance, false, "Insufficient margin", "40712"),
                new ErrorInfo(ErrorType.InsufficientBalance, false, "Not enough open position",["40757", "45003", "45005", "45006"]),

                new ErrorInfo(ErrorType.InvalidOperation, false, "Symbol does not support cross margin",["40716", "22005"]),

                new ErrorInfo(ErrorType.RateLimitOrder, false, "Max number of open orders reached",["40761", "40723", "43005", "43128", "45118", "50048", "50017"]),
                new ErrorInfo(ErrorType.RateLimitOrder, false, "Max number of tracking orders reached",["45091"]),

            ]
        );

        public static ErrorMapping SocketErrors { get; } = new ErrorMapping(
            [
                new ErrorInfo(ErrorType.InvalidParameter, false, "Channel does not exist", "30001"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Parameter error", "30016"),

                new ErrorInfo(ErrorType.Unauthorized, false, "Login failed", "30005"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid API key", "30011"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid passphrase", "30012"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid signature", "30015"),

                new ErrorInfo(ErrorType.InvalidTimestamp, false, "Invalid timestamp", "30013"),
                new ErrorInfo(ErrorType.InvalidTimestamp, false, "Timestamp expired", "30014"),

                new ErrorInfo(ErrorType.RateLimitRequest, false, "Request rate limit reached", "30006", "30007"),
            ]);

        public static ErrorMapping UnifiedErrors { get; } = new ErrorMapping(
            [
                new ErrorInfo(ErrorType.Unauthorized, false, "Region not allowed", "40000"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Unauthorized", "25620"),
                new ErrorInfo(ErrorType.Unauthorized, false, "Invalid credentials", "40006", "40009", "30005", "30011", "30012", "30015"),

                new ErrorInfo(ErrorType.InvalidTimestamp, false, "Timestamp expired", "40008"),
                new ErrorInfo(ErrorType.InvalidTimestamp, true, "Invalid timestamp", "30013", "30014"),

                new ErrorInfo(ErrorType.SystemError, true, "System error", "25000", "40015"),
                new ErrorInfo(ErrorType.SystemError, true, "Operation timeout", "25001"),
                new ErrorInfo(ErrorType.SystemError, true, "Concurrency error, try again", "25003"),

                new ErrorInfo(ErrorType.RateLimitRequest, false, "Request rate limit", "429", "25004"),
                new ErrorInfo(ErrorType.RateLimitOrder, false, "Max number of tp/sl orders reached", "25599"),
                new ErrorInfo(ErrorType.RateLimitOrder, false, "Max number of open orders reached", "40761"),

                new ErrorInfo(ErrorType.UnavailableSymbol, false, "Symbol doesn't support API trading", "25013", "22004"),
                new ErrorInfo(ErrorType.UnavailableSymbol, false, "Symbol not available", "25101", "25102", "25104", "25105", "25108", "22056", "40844", "40845"),

                new ErrorInfo(ErrorType.UnknownSymbol, false, "Symbol does not exist", "25100"),
                new ErrorInfo(ErrorType.UnknownAsset, false, "Asset does not exist", "25201"),
                new ErrorInfo(ErrorType.UnknownOrder, false, "Unknown order", "25204"),

                new ErrorInfo(ErrorType.NoPosition, false, "Position not found", "25601"),

                new ErrorInfo(ErrorType.MissingParameter, false, "Parameter not set", "40811", "40813"),
                new ErrorInfo(ErrorType.InvalidParameter, false, "Parameter validation failed", "25200", "40017", "95011", "40808"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Price value not in range", "25205", "25206", "22046", "22047", "40815", "40816", "40820", "40821"),
                new ErrorInfo(ErrorType.InvalidPrice, false, "Price tick invalid", "25244"),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Quantity not in range", "25207", "25208"),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Quantity step not valid", "25610", "22038"),
                new ErrorInfo(ErrorType.InvalidQuantity, false, "Quantity less than min order quantity", "25611", "13008", "22034"),

                new ErrorInfo(ErrorType.InvalidStopParameters, false, "Tp/sl not valid", "25579", "25580", "25581", "25582", "25583", "25584", "25585", "25586",
                    "25587", "25588", "25589", "25590", "25591", "25592", "25602", "25603", "25604", "25605", "25606", "25607", "25608", "25609", "25650",
                    "25651", "25652", "25653", "40829", "40830", "40831", "40832", "40833", "40834", "40835", "40836"),

                new ErrorInfo(ErrorType.InsufficientBalance, false, "Insufficient balance", "25202", "25203", "25228", "25231", "40798", "40800"),

                new ErrorInfo(ErrorType.MaxPosition, false, "Order quantity exceeds the maximum open quantity", "25230"),

                new ErrorInfo(ErrorType.DuplicateClientOrderId, false, "Duplicate client order id", "25212"),
            ]
        );
    }
}
