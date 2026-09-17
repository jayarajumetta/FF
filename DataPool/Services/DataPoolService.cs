using System.Collections.Concurrent;
using System.Text.Json;
using DataPool.Models;

namespace DataPool.Services
{
    public sealed class DataPoolService : IDataPoolService
    {
        private static readonly ConcurrentDictionary<string, object> FileLocks =
            new(StringComparer.OrdinalIgnoreCase);

        private static readonly JsonSerializerOptions ReadOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private static readonly JsonSerializerOptions WriteOptions = new()
        {
            WriteIndented = true
        };

        private readonly string _filePath;
        private readonly string _backupPath;
        private readonly object _lock;

        public DataPoolService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("A DataPool file path is required.", nameof(filePath));

            _filePath = Path.GetFullPath(filePath);
            _backupPath = $"{_filePath}.bak";
            _lock = FileLocks.GetOrAdd(_filePath, _ => new object());

            var directory = Path.GetDirectoryName(_filePath)
                            ?? throw new InvalidOperationException(
                                "The DataPool file path has no parent directory.");
            Directory.CreateDirectory(directory);

            lock (_lock)
            {
                if (!File.Exists(_filePath))
                    SaveAtomic(new List<QuoteRecord>(), createBackup: false);
            }
        }

        public IReadOnlyList<QuoteRecord> GetAll(
            string? status = null,
            bool? isCommittedReferral = null,
            string? transaction = null,
            string? lob = null,
            string? sfpVariant = null)
        {
            lock (_lock)
            {
                QuoteRecordValidator.ValidateFilters(
                    status,
                    transaction,
                    lob,
                    sfpVariant);

                IEnumerable<QuoteRecord> records = LoadValidated();
                if (status != null)
                    records = records.Where(record =>
                        record.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                if (isCommittedReferral.HasValue)
                    records = records.Where(record =>
                        record.IsCommittedReferral == isCommittedReferral.Value);
                if (transaction != null)
                    records = records.Where(record =>
                        record.Transaction.Equals(transaction, StringComparison.OrdinalIgnoreCase));
                if (lob != null)
                    records = records.Where(record =>
                        string.Equals(record.Lob, lob, StringComparison.OrdinalIgnoreCase));
                if (sfpVariant != null)
                    records = records.Where(record =>
                        string.Equals(record.SfpVariant, sfpVariant, StringComparison.OrdinalIgnoreCase));
                return records.ToList();
            }
        }

        public IReadOnlyList<QuoteRecord> GetAvailable() =>
            GetAll(status: "available");

        public QuoteRecord Add(QuoteRecord record)
        {
            QuoteRecordValidator.ValidateForAdd(record);
            lock (_lock)
            {
                var records = LoadValidated();
                if (records.Any(existing =>
                        existing.Id.Equals(record.Id, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new DataPoolConflictException(
                        "A quote with this identifier already exists.");
                }

                record.Status = "available";
                record.CreatedAt = DateTime.UtcNow;
                records.Add(record);
                SaveAtomic(records);
                return record;
            }
        }

        public QuoteRecord Claim(string id, string claimedBy)
        {
            QuoteRecordValidator.ValidateIdentifier(id, "Quote ID");
            QuoteRecordValidator.ValidateActor(claimedBy, "Claim");
            lock (_lock)
            {
                var records = LoadValidated();
                var record = FindOrThrow(records, id);
                if (!string.Equals(record.Status, "available", StringComparison.Ordinal))
                {
                    throw new DataPoolConflictException(
                        "Only an available quote can be claimed.");
                }

                record.Status = "claimed";
                record.ClaimedBy = claimedBy;
                record.ClaimedAt = DateTime.UtcNow;
                SaveAtomic(records);
                return record;
            }
        }

        public QuoteRecord Consume(string id, string consumedBy)
        {
            QuoteRecordValidator.ValidateIdentifier(id, "Quote ID");
            QuoteRecordValidator.ValidateActor(consumedBy, "Consume");
            lock (_lock)
            {
                var records = LoadValidated();
                var record = FindOrThrow(records, id);
                if (!string.Equals(record.Status, "claimed", StringComparison.Ordinal))
                {
                    throw new DataPoolConflictException(
                        "Only a claimed quote can be consumed.");
                }

                if (!string.Equals(record.ClaimedBy, consumedBy, StringComparison.Ordinal))
                {
                    throw new DataPoolConflictException(
                        "A quote can be consumed only by the identity that claimed it.");
                }

                record.Status = "consumed";
                record.ConsumedBy = consumedBy;
                SaveAtomic(records);
                return record;
            }
        }

        public QuoteRecord Release(string id)
        {
            QuoteRecordValidator.ValidateIdentifier(id, "Quote ID");
            lock (_lock)
            {
                var records = LoadValidated();
                var record = FindOrThrow(records, id);
                if (!string.Equals(record.Status, "claimed", StringComparison.Ordinal))
                {
                    throw new DataPoolConflictException(
                        "Only a claimed quote can be released.");
                }

                record.Status = "available";
                record.ClaimedBy = null;
                record.ClaimedAt = null;
                SaveAtomic(records);
                return record;
            }
        }

        public (int RemovedConsumed, int RemovedAvailable) CleanupOldRecords(
            int consumedDaysOld,
            int availableDaysOld)
        {
            if (consumedDaysOld < 0 || availableDaysOld < 0)
            {
                throw new DataPoolValidationException(
                    "Cleanup age thresholds cannot be negative.");
            }

            lock (_lock)
            {
                var records = LoadValidated();
                var consumedThreshold = DateTime.UtcNow.AddDays(-consumedDaysOld);
                var availableThreshold = DateTime.UtcNow.AddDays(-availableDaysOld);

                var beforeConsumed = records.Count;
                records.RemoveAll(record =>
                    record.Status == "consumed" &&
                    record.CreatedAt < consumedThreshold);
                var removedConsumed = beforeConsumed - records.Count;

                var beforeAvailable = records.Count;
                records.RemoveAll(record =>
                    record.Status == "available" &&
                    record.CreatedAt < availableThreshold);
                var removedAvailable = beforeAvailable - records.Count;

                if (removedConsumed > 0 || removedAvailable > 0)
                    SaveAtomic(records);

                return (removedConsumed, removedAvailable);
            }
        }

        private List<QuoteRecord> LoadValidated()
        {
            try
            {
                using var stream = new FileStream(
                    _filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                var records = JsonSerializer.Deserialize<List<QuoteRecord>>(
                                  stream,
                                  ReadOptions)
                              ?? throw new DataPoolStorageException(
                                  "DataPool storage contains an empty JSON value.");
                foreach (var record in records)
                    QuoteRecordValidator.ValidateStored(record);
                if (records
                    .GroupBy(record => record.Id, StringComparer.OrdinalIgnoreCase)
                    .Any(group => group.Count() > 1))
                {
                    throw new DataPoolStorageException(
                        "DataPool storage contains duplicate quote identifiers.");
                }

                return records;
            }
            catch (DataPoolStorageException)
            {
                throw;
            }
            catch (JsonException exception)
            {
                throw new DataPoolStorageException(
                    "DataPool storage contains malformed JSON; the existing file was not modified.",
                    exception);
            }
            catch (Exception exception) when (
                exception is IOException or UnauthorizedAccessException)
            {
                throw new DataPoolStorageException(
                    "DataPool storage could not be read safely; the existing file was not modified.",
                    exception);
            }
        }

        private void SaveAtomic(List<QuoteRecord> records, bool createBackup = true)
        {
            foreach (var record in records)
                QuoteRecordValidator.ValidateStored(record);

            var temporaryPath = $"{_filePath}.{Guid.NewGuid():N}.tmp";
            try
            {
                using (var stream = new FileStream(
                           temporaryPath,
                           FileMode.CreateNew,
                           FileAccess.Write,
                           FileShare.None,
                           4096,
                           FileOptions.WriteThrough))
                {
                    JsonSerializer.Serialize(stream, records, WriteOptions);
                    stream.Flush(flushToDisk: true);
                }

                if (File.Exists(_filePath))
                {
                    if (createBackup && File.Exists(_backupPath))
                        File.Delete(_backupPath);

                    File.Replace(
                        temporaryPath,
                        _filePath,
                        createBackup ? _backupPath : null,
                        ignoreMetadataErrors: true);
                }
                else
                {
                    File.Move(temporaryPath, _filePath);
                }
            }
            catch (Exception exception) when (
                exception is IOException or UnauthorizedAccessException)
            {
                throw new DataPoolStorageException(
                    "DataPool storage could not be replaced atomically.",
                    exception);
            }
            finally
            {
                DeleteIfPresent(temporaryPath);
            }
        }

        private static QuoteRecord FindOrThrow(
            IEnumerable<QuoteRecord> records,
            string id) =>
            records.FirstOrDefault(record =>
                record.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
            ?? throw new KeyNotFoundException("The requested quote was not found.");

        private static void DeleteIfPresent(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch
            {
                // Preserve the primary storage failure. A unique temp file is harmless
                // and can be removed by operational cleanup.
            }
        }
    }
}
