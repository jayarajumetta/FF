#nullable enable
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Models;
using PnCTestAutomation.Services;

namespace PnCTestAutomation.Integrations
{
    public interface IPingSecretProvider
    {
        Task<string> GetSecretAsync(string secretId, CancellationToken cancellationToken = default);
    }

    public sealed class PingSecretProvider : IPingSecretProvider
    {
        private readonly HttpClient _httpClient;
        private readonly PingSecretConfig _config;

        public PingSecretProvider(HttpClient httpClient, PingSecretConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetSecretAsync(
            string secretId,
            CancellationToken cancellationToken = default)
        {
            _config.Validate();
            if (string.IsNullOrWhiteSpace(secretId))
            {
                throw new InvalidOperationException(
                    "A Ping secret identifier must be supplied through configuration.");
            }

            var accessToken = await GetPingAccessTokenAsync(cancellationToken);
            var endpoint = $"{_config.SecretEndpoint.TrimEnd('/')}/{Uri.EscapeDataString(secretId)}";

            using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            EnsureSuccess(response, "Ping secret retrieval");
            EnsureJson(response, "Ping secret retrieval");

            var secret = await DeserializeAsync<PingSecretResponse>(
                response,
                "Ping secret retrieval",
                cancellationToken);

            if (string.IsNullOrWhiteSpace(secret.Value))
            {
                throw new AuthenticationFlowException(
                    "Ping secret response did not contain a value.");
            }

            return secret.Value;
        }

        private async Task<string> GetPingAccessTokenAsync(CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndpoint);
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = _config.BootstrapClientId,
                ["client_secret"] = _config.BootstrapClientSecret
            });

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            EnsureSuccess(response, "Ping token request");
            EnsureJson(response, "Ping token request");

            var token = await DeserializeAsync<PingTokenResponse>(
                response,
                "Ping token request",
                cancellationToken);

            if (string.IsNullOrWhiteSpace(token.AccessToken))
            {
                throw new AuthenticationFlowException(
                    "Ping token response did not contain an access token.");
            }

            return token.AccessToken;
        }

        private static void EnsureSuccess(HttpResponseMessage response, string operation)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new AuthenticationFlowException(
                    $"{operation} failed with HTTP {(int)response.StatusCode} ({response.StatusCode}).",
                    response.StatusCode);
            }
        }

        private static void EnsureJson(HttpResponseMessage response, string operation)
        {
            var mediaType = response.Content.Headers.ContentType?.MediaType;
            if (!IsJsonMediaType(mediaType))
            {
                throw new AuthenticationFlowException(
                    $"{operation} returned unsupported content type '{mediaType ?? "<missing>"}'.",
                    response.StatusCode);
            }
        }

        private static bool IsJsonMediaType(string? mediaType) =>
            string.Equals(mediaType, "application/json", StringComparison.OrdinalIgnoreCase) ||
            (mediaType?.EndsWith("+json", StringComparison.OrdinalIgnoreCase) ?? false);

        private static async Task<T> DeserializeAsync<T>(
            HttpResponseMessage response,
            string operation,
            CancellationToken cancellationToken)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<T>(
                           cancellationToken: cancellationToken)
                       ?? throw new AuthenticationFlowException(
                           $"{operation} returned an empty JSON payload.",
                           response.StatusCode);
            }
            catch (Exception exception) when (
                exception is JsonException or NotSupportedException)
            {
                throw new AuthenticationFlowException(
                    $"{operation} returned malformed JSON.",
                    response.StatusCode,
                    exception);
            }
        }
    }
}
