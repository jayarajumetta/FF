#nullable enable
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    public enum ApiRetryMode
    {
        None,
        IdempotentTransient
    }

    public interface IApiService
    {
        bool HasAccessToken { get; }
        void SetAccessToken(AccessToken accessToken);
        Task<TResponse> PostJsonAsync<TRequest, TResponse>(
            string endpoint,
            TRequest request,
            ApiRetryMode retryMode = ApiRetryMode.None,
            CancellationToken cancellationToken = default);
    }

    public sealed class ApiService : IApiService
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly HttpClient _httpClient;
        private readonly ApiClientConfig _config;

        public ApiService(HttpClient httpClient, ApiClientConfig config)
        {
            config.Validate();
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(config.BaseUrl);
            _config = config;
        }

        public bool HasAccessToken =>
            _httpClient.DefaultRequestHeaders.Authorization is
            {
                Scheme: "Bearer",
                Parameter.Length: > 0
            };

        public void SetAccessToken(AccessToken accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken.Value))
            {
                throw new ArgumentException(
                    "The access token cannot be empty.",
                    nameof(accessToken));
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken.Value);
        }

        public async Task<TResponse> PostJsonAsync<TRequest, TResponse>(
            string endpoint,
            TRequest request,
            ApiRetryMode retryMode = ApiRetryMode.None,
            CancellationToken cancellationToken = default)
        {
            var safeEndpoint = DescribeEndpoint(endpoint);
            if (!HasAccessToken)
            {
                throw new InvalidOperationException(
                    "The API client has not been authenticated for this scenario.");
            }

            var maximumAttempts = retryMode == ApiRetryMode.IdempotentTransient
                ? _config.MaxTransientAttempts
                : 1;

            for (var attempt = 1; attempt <= maximumAttempts; attempt++)
            {
                try
                {
                    using var response = await _httpClient.PostAsJsonAsync(
                        endpoint,
                        request,
                        JsonOptions,
                        cancellationToken);

                    if (IsTransient(response.StatusCode) && attempt < maximumAttempts)
                    {
                        await DelayBeforeRetryAsync(cancellationToken);
                        continue;
                    }

                    EnsureSuccess(response, safeEndpoint);
                    EnsureJson(response, safeEndpoint);
                    return await DeserializeAsync<TResponse>(
                        response,
                        safeEndpoint,
                        cancellationToken);
                }
                catch (HttpRequestException) when (attempt < maximumAttempts)
                {
                    await DelayBeforeRetryAsync(cancellationToken);
                }
                catch (HttpRequestException exception)
                {
                    throw new ApiRequestException(
                        $"API request to '{safeEndpoint}' failed before receiving a response.",
                        innerException: exception);
                }
            }

            throw new ApiRequestException(
                $"API request to '{safeEndpoint}' exhausted its transient retry attempts.");
        }

        private Task DelayBeforeRetryAsync(CancellationToken cancellationToken) =>
            Task.Delay(_config.RetryDelayMilliseconds, cancellationToken);

        private static bool IsTransient(HttpStatusCode statusCode) =>
            statusCode is HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests ||
            (int)statusCode >= 500;

        private static string DescribeEndpoint(string endpoint)
        {
            if (Uri.TryCreate(endpoint, UriKind.Absolute, out var absoluteUri))
            {
                return absoluteUri.GetLeftPart(UriPartial.Path);
            }

            var separatorIndex = endpoint.IndexOfAny(new[] { '?', '#' });
            return separatorIndex >= 0 ? endpoint[..separatorIndex] : endpoint;
        }

        private static void EnsureSuccess(HttpResponseMessage response, string endpoint)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiRequestException(
                    $"API request to '{endpoint}' failed with HTTP {(int)response.StatusCode} ({response.StatusCode}).",
                    response.StatusCode);
            }
        }

        private static void EnsureJson(HttpResponseMessage response, string endpoint)
        {
            var mediaType = response.Content.Headers.ContentType?.MediaType;
            if (!string.Equals(mediaType, "application/json", StringComparison.OrdinalIgnoreCase) &&
                !(mediaType?.EndsWith("+json", StringComparison.OrdinalIgnoreCase) ?? false))
            {
                throw new ApiRequestException(
                    $"API request to '{endpoint}' returned unsupported content type '{mediaType ?? "<missing>"}'.",
                    response.StatusCode);
            }
        }

        private static async Task<TResponse> DeserializeAsync<TResponse>(
            HttpResponseMessage response,
            string endpoint,
            CancellationToken cancellationToken)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<TResponse>(
                           JsonOptions,
                           cancellationToken)
                       ?? throw new ApiRequestException(
                           $"API request to '{endpoint}' returned an empty JSON payload.",
                           response.StatusCode);
            }
            catch (Exception exception) when (
                exception is JsonException or NotSupportedException)
            {
                throw new ApiRequestException(
                    $"API request to '{endpoint}' returned malformed or incompatible JSON.",
                    response.StatusCode,
                    exception);
            }
        }
    }
}
