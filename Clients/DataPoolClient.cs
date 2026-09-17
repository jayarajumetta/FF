#nullable enable
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Configuration;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.DataPool
{
    public enum DataPoolPersistenceStatus
    {
        Persisted,
        AlreadyExists,
        NotConfigured,
        Unavailable,
        Rejected
    }

    public sealed record DataPoolPersistenceResult(
        DataPoolPersistenceStatus Status,
        string Message)
    {
        public bool Succeeded =>
            Status is DataPoolPersistenceStatus.Persisted or
                DataPoolPersistenceStatus.AlreadyExists;
    }

    public sealed class DataPoolPersistenceException : Exception
    {
        public DataPoolPersistenceException(
            string message,
            HttpStatusCode? statusCode = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; }
    }

    public interface IDataPoolClient
    {
        Task<DataPoolPersistenceResult> PersistAsync(
            QuoteRecord record,
            CancellationToken cancellationToken = default);
    }

    public sealed class DataPoolClient : IDataPoolClient
    {
        public const string ApiKeyHeader = "X-DataPool-Key";

        private readonly HttpClient _httpClient;
        private readonly DataPoolClientConfig _config;

        public DataPoolClient(HttpClient httpClient, DataPoolClientConfig config)
        {
            config.Validate();
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(config.BaseUrl);
            _config = config;
        }

        public async Task<DataPoolPersistenceResult> PersistAsync(
            QuoteRecord record,
            CancellationToken cancellationToken = default)
        {
            ValidateRecord(record);

            using var request = new HttpRequestMessage(HttpMethod.Post, "api/quotes")
            {
                Content = JsonContent.Create(record)
            };
            if (!string.IsNullOrWhiteSpace(_config.ApiKey))
                request.Headers.Add(ApiKeyHeader, _config.ApiKey);

            try
            {
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return new DataPoolPersistenceResult(
                        DataPoolPersistenceStatus.Persisted,
                        "Quote persistence completed.");
                }

                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    return new DataPoolPersistenceResult(
                        DataPoolPersistenceStatus.AlreadyExists,
                        "The quote already exists in DataPool.");
                }

                return HandleFailure(
                    DataPoolPersistenceStatus.Rejected,
                    $"DataPool rejected persistence with HTTP {(int)response.StatusCode} ({response.StatusCode}).",
                    response.StatusCode);
            }
            catch (HttpRequestException exception)
            {
                return HandleFailure(
                    DataPoolPersistenceStatus.Unavailable,
                    "DataPool was unavailable before a response was received.",
                    innerException: exception);
            }
            catch (OperationCanceledException exception)
                when (!cancellationToken.IsCancellationRequested)
            {
                return HandleFailure(
                    DataPoolPersistenceStatus.Unavailable,
                    "DataPool timed out before persistence completed.",
                    innerException: exception);
            }
        }

        private DataPoolPersistenceResult HandleFailure(
            DataPoolPersistenceStatus status,
            string message,
            HttpStatusCode? statusCode = null,
            Exception? innerException = null)
        {
            if (_config.Required)
                throw new DataPoolPersistenceException(message, statusCode, innerException);

            return new DataPoolPersistenceResult(status, message);
        }

        private static void ValidateRecord(QuoteRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            if (string.IsNullOrWhiteSpace(record.Id) || record.Id.Length > 128)
            {
                throw new ArgumentException(
                    "A quote identifier between 1 and 128 characters is required.",
                    nameof(record));
            }
        }
    }

    public sealed class UnavailableDataPoolClient : IDataPoolClient
    {
        private readonly DataPoolClientConfig _config;

        public UnavailableDataPoolClient(DataPoolClientConfig config)
        {
            config.Validate();
            _config = config;
        }

        public Task<DataPoolPersistenceResult> PersistAsync(
            QuoteRecord record,
            CancellationToken cancellationToken = default)
        {
            if (_config.Required)
            {
                throw new DataPoolPersistenceException(
                    "DataPool is required but DataPool:BaseUrl is not configured.");
            }

            return Task.FromResult(
                new DataPoolPersistenceResult(
                    DataPoolPersistenceStatus.NotConfigured,
                    "Optional DataPool persistence was not configured."));
        }
    }
}
