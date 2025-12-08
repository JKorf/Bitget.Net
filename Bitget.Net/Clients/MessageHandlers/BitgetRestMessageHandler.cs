using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Bitget.Net.Clients.MessageHandlers
{
    internal class BitgetRestMessageHandler : JsonRestMessageHandler
    {
        private readonly ErrorMapping _errorMapping;

        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(BitgetExchange._serializerContext);

        public BitgetRestMessageHandler(ErrorMapping errorMapping)
        {
            _errorMapping = errorMapping;
        }

        public override async ValueTask<Error> ParseErrorResponse(
            int httpStatusCode,
            HttpResponseHeaders responseHeaders,
            Stream responseStream)
        {
            var (error, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
            if (error != null)
                return error;

            var errorMsg = document!.RootElement.TryGetProperty("msg", out var msgProp) ? msgProp.GetString() : null;
            var errorCode = document!.RootElement.TryGetProperty("code", out var codeProp) ? codeProp.GetString() : null;
            if (errorMsg == null)
                return new ServerError(ErrorInfo.Unknown);

            if (errorCode == null)
                return new ServerError(ErrorInfo.Unknown with { Message = errorMsg });

            return new ServerError(errorCode, _errorMapping.GetErrorInfo(errorCode, errorMsg));
        }
    }
}
