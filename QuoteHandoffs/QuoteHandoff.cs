#nullable enable
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.QuoteHandoffs
{
    public sealed record QuoteReference(string QuoteNumber)
    {
        public static QuoteReference Create(string quoteNumber)
        {
            var normalized = quoteNumber?.Trim();
            if (string.IsNullOrWhiteSpace(normalized) || normalized.Length > 128)
            {
                throw new ArgumentException(
                    "Quote number must contain between 1 and 128 characters.",
                    nameof(quoteNumber));
            }

            return new QuoteReference(normalized);
        }
    }

    public interface IQuoteHandoff
    {
        void Publish(string quoteNumber);
        bool TryGet(out QuoteReference? quote);
        QuoteReference Require(string consumer);
    }

    public sealed class ScenarioQuoteHandoff : IQuoteHandoff
    {
        private readonly ScenarioContextData _scenarioData;

        public ScenarioQuoteHandoff(ScenarioContextData scenarioData)
        {
            _scenarioData = scenarioData;
        }

        public void Publish(string quoteNumber)
        {
            var quote = QuoteReference.Create(quoteNumber);
            _scenarioData.QuoteNumber = quote.QuoteNumber;
        }

        public bool TryGet(out QuoteReference? quote)
        {
            if (string.IsNullOrWhiteSpace(_scenarioData.QuoteNumber))
            {
                quote = null;
                return false;
            }

            quote = QuoteReference.Create(_scenarioData.QuoteNumber);
            return true;
        }

        public QuoteReference Require(string consumer)
        {
            if (string.IsNullOrWhiteSpace(consumer))
                throw new ArgumentException("Consumer identity is required.", nameof(consumer));

            return TryGet(out var quote)
                ? quote!
                : throw new InvalidOperationException(
                    $"No quote has been captured for the current scenario; '{consumer}' cannot continue.");
        }
    }

    public sealed record QuoteHandoffEnvelope(
        int Version,
        string RunId,
        string ScenarioId,
        string ProducerId,
        string ConsumerId,
        QuoteReference Quote,
        DateTimeOffset CreatedAtUtc);

    public sealed record QuoteHandoffRequest(
        string RunId,
        string ScenarioId,
        string ProducerId,
        string ConsumerId,
        TimeSpan MaximumAge);

    public interface ICrossProcessQuoteHandoffStore
    {
        Task PublishAsync(
            QuoteHandoffEnvelope envelope,
            CancellationToken cancellationToken = default);

        Task<QuoteReference> ReadAsync(
            QuoteHandoffRequest request,
            CancellationToken cancellationToken = default);
    }

    public sealed class FileQuoteHandoffStore : ICrossProcessQuoteHandoffStore
    {
        public const int CurrentVersion = 1;

        private static readonly ConcurrentDictionary<string, SemaphoreSlim> FileLocks =
            new(StringComparer.OrdinalIgnoreCase);

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        private readonly string _rootPath;
        private readonly Func<DateTimeOffset> _utcNow;

        public FileQuoteHandoffStore(
            string rootPath,
            Func<DateTimeOffset>? utcNow = null)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
                throw new ArgumentException("A handoff root path is required.", nameof(rootPath));

            _rootPath = Path.GetFullPath(rootPath);
            _utcNow = utcNow ?? (() => DateTimeOffset.UtcNow);
        }

        public async Task PublishAsync(
            QuoteHandoffEnvelope envelope,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(envelope);
            ValidateEnvelope(envelope);
            var path = GetPath(envelope.RunId, envelope.ScenarioId);
            var gate = FileLocks.GetOrAdd(path, _ => new SemaphoreSlim(1, 1));
            await gate.WaitAsync(cancellationToken);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                var temporaryPath = $"{path}.{Guid.NewGuid():N}.tmp";
                try
                {
                    await using (var stream = new FileStream(
                                     temporaryPath,
                                     FileMode.CreateNew,
                                     FileAccess.Write,
                                     FileShare.None,
                                     4096,
                                     FileOptions.Asynchronous | FileOptions.WriteThrough))
                    {
                        await JsonSerializer.SerializeAsync(
                            stream,
                            envelope,
                            JsonOptions,
                            cancellationToken);
                        await stream.FlushAsync(cancellationToken);
                        stream.Flush(flushToDisk: true);
                    }

                    if (File.Exists(path))
                        File.Replace(temporaryPath, path, null);
                    else
                        File.Move(temporaryPath, path);
                }
                finally
                {
                    if (File.Exists(temporaryPath))
                        File.Delete(temporaryPath);
                }
            }
            finally
            {
                gate.Release();
            }
        }

        public async Task<QuoteReference> ReadAsync(
            QuoteHandoffRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            ValidateRequest(request);
            var path = GetPath(request.RunId, request.ScenarioId);
            var gate = FileLocks.GetOrAdd(path, _ => new SemaphoreSlim(1, 1));
            await gate.WaitAsync(cancellationToken);
            try
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException(
                        "The requested quote handoff does not exist.",
                        path);
                }

                QuoteHandoffEnvelope envelope;
                try
                {
                    await using var stream = new FileStream(
                        path,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read);
                    envelope = await JsonSerializer.DeserializeAsync<QuoteHandoffEnvelope>(
                                   stream,
                                   JsonOptions,
                                   cancellationToken)
                               ?? throw new InvalidDataException(
                                   "The quote handoff payload is empty.");
                }
                catch (JsonException exception)
                {
                    throw new InvalidDataException(
                        "The quote handoff payload is not valid JSON.",
                        exception);
                }

                ValidateEnvelope(envelope);
                if (!string.Equals(envelope.RunId, request.RunId, StringComparison.Ordinal) ||
                    !string.Equals(envelope.ScenarioId, request.ScenarioId, StringComparison.Ordinal) ||
                    !string.Equals(envelope.ProducerId, request.ProducerId, StringComparison.Ordinal) ||
                    !string.Equals(envelope.ConsumerId, request.ConsumerId, StringComparison.Ordinal))
                {
                    throw new InvalidDataException(
                        "The quote handoff identity does not match the requesting run, scenario, producer, or consumer.");
                }

                var age = _utcNow() - envelope.CreatedAtUtc;
                if (age < TimeSpan.FromMinutes(-5) || age > request.MaximumAge)
                {
                    throw new InvalidDataException(
                        "The quote handoff is stale or has an invalid timestamp.");
                }

                return envelope.Quote;
            }
            finally
            {
                gate.Release();
            }
        }

        private string GetPath(string runId, string scenarioId) =>
            Path.Combine(
                _rootPath,
                SafeSegment(runId),
                $"{SafeSegment(scenarioId)}.quote-handoff.v{CurrentVersion}.json");

        private static string SafeSegment(string value)
        {
            var safe = new string(value
                .Select(character =>
                    char.IsLetterOrDigit(character) || character is '-' or '_'
                        ? character
                        : '-')
                .Take(48)
                .ToArray());
            var hash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(value)))[..12];
            return $"{safe}-{hash}";
        }

        private static void ValidateEnvelope(QuoteHandoffEnvelope envelope)
        {
            if (envelope.Version != CurrentVersion)
                throw new InvalidDataException("Unsupported quote handoff version.");
            RequireIdentity(envelope.RunId, nameof(envelope.RunId));
            RequireIdentity(envelope.ScenarioId, nameof(envelope.ScenarioId));
            RequireIdentity(envelope.ProducerId, nameof(envelope.ProducerId));
            RequireIdentity(envelope.ConsumerId, nameof(envelope.ConsumerId));
            _ = QuoteReference.Create(envelope.Quote?.QuoteNumber ?? string.Empty);
            if (envelope.CreatedAtUtc == default)
                throw new InvalidDataException("Quote handoff creation time is required.");
        }

        private static void ValidateRequest(QuoteHandoffRequest request)
        {
            RequireIdentity(request.RunId, nameof(request.RunId));
            RequireIdentity(request.ScenarioId, nameof(request.ScenarioId));
            RequireIdentity(request.ProducerId, nameof(request.ProducerId));
            RequireIdentity(request.ConsumerId, nameof(request.ConsumerId));
            if (request.MaximumAge <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(request.MaximumAge));
        }

        private static void RequireIdentity(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 128)
                throw new InvalidDataException($"{field} is required and must not exceed 128 characters.");
        }
    }
}
