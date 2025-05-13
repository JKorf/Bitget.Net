using Bitget.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace Bitget.Net
{
    internal class BitgetAuthenticationProviderV2 : AuthenticationProvider
    {
        public string Passphrase => _credentials.Pass!;

        public BitgetAuthenticationProviderV2(ApiCredentials credentials) : base(credentials)
        {
            if (string.IsNullOrEmpty(credentials.Pass))
                throw new ArgumentNullException(nameof(ApiCredentials.Pass), "Passphrase is required for Bitget authentication");
        }

#if NET5_0_OR_GREATER
        [UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL3050:RequiresUnreferencedCode", Justification = "JsonSerializerOptions provided here has TypeInfoResolver set")]
        [UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL2026:RequiresUnreferencedCode", Justification = "JsonSerializerOptions provided here has TypeInfoResolver set")]
#endif
        public override void AuthenticateRequest(
            RestApiClient apiClient,
            Uri uri,
            HttpMethod method,
            ref IDictionary<string, object>? uriParameters,
            ref IDictionary<string, object>? bodyParameters,
            ref Dictionary<string, string>? headers,
            bool auth,
            ArrayParametersSerialization arraySerialization,
            HttpMethodParameterPosition parameterPosition,
            RequestBodyFormat requestBodyFormat)
        {
            if (!auth)
                return;

            var body = parameterPosition == HttpMethodParameterPosition.InBody ? JsonSerializer.Serialize(bodyParameters, SerializerOptions.WithConverters(BitgetExchange._serializerContext)) : "";
            string? query = null;
            if (uriParameters != null)
                query = uriParameters.CreateParamString(false, arraySerialization);

            headers ??= new Dictionary<string, string>();
            var timestamp = GetMillisecondTimestamp(apiClient);
            var signString = timestamp + method.ToString().ToUpperInvariant() +  uri.AbsolutePath + (string.IsNullOrEmpty(query) ? "" : ("?" +query)) + body;
            if (_credentials.CredentialType == ApiCredentialsType.Hmac)
            {
                headers["ACCESS-SIGN"] = SignHMACSHA256(signString, SignOutputType.Base64);
            }
            else
            {
                headers["ACCESS-SIGN"] = SignRSASHA256(Encoding.UTF8.GetBytes(signString), SignOutputType.Base64);
            }

            headers["ACCESS-KEY"] = _credentials.Key!;
            headers["ACCESS-TIMESTAMP"] = timestamp;
            headers["ACCESS-PASSPHRASE"] = _credentials.Pass!;
        }

        public string GetWebsocketSignature(long timestamp)
        {
            if (_credentials.CredentialType == ApiCredentialsType.Hmac)
            {
                return SignHMACSHA256(timestamp + "GET" + "/user/verify", SignOutputType.Base64);
            }
            else
            {
                // Bitget doesn't seem to support RSA signing for the socket API..
                throw new NotSupportedException("RSA signing for websocket is not supported by Bitget, use hmac credentials instead");
                //return SignRSASHA256(Encoding.UTF8.GetBytes(timestamp + "GET" + "/user/verify"), SignOutputType.Base64);
            }
        }
    }
}
