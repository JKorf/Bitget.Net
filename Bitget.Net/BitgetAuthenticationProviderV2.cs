using Bitget.Net.Objects.Socket;
using Bitget.Net.Objects.Socket.Queries;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using System.Text;

namespace Bitget.Net
{
    internal class BitgetAuthenticationProviderV2 : AuthenticationProvider
    {
        private static IStringMessageSerializer _serializer = new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(BitgetExchange._serializerContext));

        public override ApiCredentialsType[] SupportedCredentialTypes => [ApiCredentialsType.Hmac, ApiCredentialsType.RsaXml, ApiCredentialsType.RsaPem];
        public string Passphrase => _credentials.Pass!;

        public BitgetAuthenticationProviderV2(ApiCredentials credentials) : base(credentials)
        {
            if (string.IsNullOrEmpty(credentials.Pass))
                throw new ArgumentNullException(nameof(ApiCredentials.Pass), "Passphrase is required for Bitget authentication");
        }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration request)
        {
            if (!request.Authenticated)
                return;

            var body = request.ParameterPosition == HttpMethodParameterPosition.InBody ? GetSerializedBody(_serializer, request.BodyParameters ?? new Dictionary<string, object>()) : "";
            var query = request.GetQueryString(false);
            if (!string.IsNullOrEmpty(query))
                query = $"?{query}";

            var timestamp = GetMillisecondTimestamp(apiClient);
            var signString = timestamp + request.Method.ToString().ToUpperInvariant() + request.Path + query + body;
            var signature = _credentials.CredentialType == ApiCredentialsType.Hmac 
                ? SignHMACSHA256(signString, SignOutputType.Base64) 
                : SignRSASHA256(Encoding.UTF8.GetBytes(signString), SignOutputType.Base64);
            
            request.Headers ??= new Dictionary<string, string>();
            request.Headers["ACCESS-SIGN"] = signature;
            request.Headers["ACCESS-KEY"] = _credentials.Key!;
            request.Headers["ACCESS-TIMESTAMP"] = timestamp;
            request.Headers["ACCESS-PASSPHRASE"] = _credentials.Pass!;

            request.SetQueryString(query);
            request.SetBodyContent(body);
        }

        public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
        {
            if (_credentials.CredentialType != ApiCredentialsType.Hmac)
                throw new NotSupportedException("Only Hmac credentials are supported for websocket");


            var time = DateTimeConverter.ConvertToSeconds(GetTimestamp(apiClient));
            var signature = SignHMACSHA256(time + "GET" + "/user/verify", SignOutputType.Base64);

            var socketRequest = new BitgetSocketRequest
            {
                Op = "login",
                Args = new[]
                {
                    new Dictionary<string, string>
                    {
                        { "apiKey", ApiKey },
                        { "passphrase", Passphrase },
                        { "timestamp", time.ToString()! },
                        { "sign", signature },
                    }
                }
            };

            return new BitgetAuthQuery(apiClient, socketRequest);
        }
    }
}
