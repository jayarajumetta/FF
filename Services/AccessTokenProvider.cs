#nullable enable
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Integrations;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    public interface IAccessTokenProvider
    {
        Task<AccessToken> GetAccessTokenAsync(CancellationToken cancellationToken = default);
    }

    public sealed class AccessTokenProvider : IAccessTokenProvider
    {
        private readonly HttpClient _httpClient;
        private readonly OAuthConfig _config;
        private readonly IPingSecretProvider _secretProvider;

        public AccessTokenProvider(
            HttpClient httpClient,
            OAuthConfig config,
            IPingSecretProvider secretProvider)
        {
            _httpClient = httpClient;
            _config = config;
            _secretProvider = secretProvider;
        }

        public async Task<AccessToken> GetAccessTokenAsync(
            CancellationToken cancellationToken = default)
        {
            _config.ValidateClientCredentials();
            var clientSecret = await _secretProvider.GetSecretAsync(
                _config.PingSecretId,
                cancellationToken);

            var tokenRequest = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials",
                ["client_id"] = _config.ClientId,
                ["client_secret"] = clientSecret
            };
            if (!string.IsNullOrWhiteSpace(_config.Scope))
            {
                tokenRequest["scope"] = _config.Scope;
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, _config.TokenUrl)
            {
                Content = new FormUrlEncodedContent(tokenRequest)
            };

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new AuthenticationFlowException(
                    $"OAuth token request failed with HTTP {(int)response.StatusCode} ({response.StatusCode}).",
                    response.StatusCode);
            }

            var mediaType = response.Content.Headers.ContentType?.MediaType;
            if (!string.Equals(mediaType, "application/json", StringComparison.OrdinalIgnoreCase) &&
                !(mediaType?.EndsWith("+json", StringComparison.OrdinalIgnoreCase) ?? false))
            {
                throw new AuthenticationFlowException(
                    $"OAuth token request returned unsupported content type '{mediaType ?? "<missing>"}'.",
                    response.StatusCode);
            }

            OAuthTokenResponse tokenResponse;
            try
            {
                tokenResponse = await response.Content.ReadFromJsonAsync<OAuthTokenResponse>(
                                    cancellationToken: cancellationToken)
                                ?? throw new AuthenticationFlowException(
                                    "OAuth token request returned an empty JSON payload.",
                                    response.StatusCode);
            }
            catch (Exception exception) when (
                exception is JsonException or NotSupportedException)
            {
                throw new AuthenticationFlowException(
                    "OAuth token request returned malformed JSON.",
                    response.StatusCode,
                    exception);
            }

            if (string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
            {
                throw new AuthenticationFlowException(
                    "OAuth token response did not contain an access token.",
                    response.StatusCode);
            }

            DateTimeOffset? expiresAt = tokenResponse.ExpiresInSeconds is > 0
                ? DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresInSeconds.Value)
                : null;

            return new AccessToken(tokenResponse.AccessToken, expiresAt);
        }
    }
}
