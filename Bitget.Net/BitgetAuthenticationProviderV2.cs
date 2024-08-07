﻿using Bitget.Net.Objects;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using System.Text;
using System.Text.Json;

namespace Bitget.Net
{
    internal class BitgetAuthenticationProviderV2 : AuthenticationProvider<BitgetApiCredentials>
    {
        public string Passphrase => _credentials.PassPhrase;

        public BitgetAuthenticationProviderV2(BitgetApiCredentials credentials) : base(credentials)
        {
        }

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

            var body = parameterPosition == HttpMethodParameterPosition.InBody ? JsonSerializer.Serialize(bodyParameters) : "";
            string? query = null;
            if (uriParameters != null)
                query = uriParameters.ToFormData();

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
            headers["ACCESS-PASSPHRASE"] = _credentials.PassPhrase;
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
