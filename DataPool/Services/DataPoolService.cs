using DataPool.Models;
using System.Text.Json;

namespace DataPool.Services
{
    public class DataPoolService : IDataPoolService
    {
        private readonly string _filePath;
        private readonly object _lock = new();

        private static readonly JsonSerializerOptions _readOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private static readonly JsonSerializerOptions _writeOptions = new()
        {
            WriteIndented = true
        };

        public DataPoolService(string filePath)
        {
            _filePath = filePath;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "[]");
        }

        // ── Internal helpers ──────────────────────────────────────────────────

        private List<QuoteRecord> Load()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<QuoteRecord>>(json, _readOptions) ?? new();
        }

        private void Save(List<QuoteRecord> records)
            => File.WriteAllText(_filePath, JsonSerializer.Serialize(records, _writeOptions));

        private static QuoteRecord FindOrThrow(List<QuoteRecord> records, string id)
            => records.FirstOrDefault(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
               ?? throw new KeyNotFoundException($"Quote '{id}' not found.");

        // ── Public interface ──────────────────────────────────────────────────

        public IReadOnlyList<QuoteRecord> GetAll(string? status = null, bool? isCommittedReferral = null, string? type = null)
        {
            lock (_lock)
            {
                IEnumerable<QuoteRecord> records = Load();
                if (status != null)
                    records = records.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                if (isCommittedReferral.HasValue)
                    records = records.Where(r => r.IsCommittedReferral == isCommittedReferral.Value);
                if (type != null)
                    records = records.Where(r => r.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
                return records.ToList();
            }
        }

        public IReadOnlyList<QuoteRecord> GetAvailable()
            => GetAll(status: "available");

        public QuoteRecord Add(QuoteRecord record)
        {
            lock (_lock)
            {
                var records = Load();
                if (records.Any(r => r.Id.Equals(record.Id, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException($"Quote '{record.Id}' already exists.");
                record.Status = "available";
                record.CreatedAt = DateTime.UtcNow;
                records.Add(record);
                Save(records);
                return record;
            }
        }

        public QuoteRecord Claim(string id, string claimedBy)
        {
            lock (_lock)
            {
                var records = Load();
                var record = FindOrThrow(records, id);
                if (record.Status != "available")
                    throw new InvalidOperationException($"Quote '{id}' is '{record.Status}' and cannot be claimed.");
                record.Status = "claimed";
                record.ClaimedBy = claimedBy;
                Save(records);
                return record;
            }
        }

        public QuoteRecord Consume(string id, string consumedBy)
        {
            lock (_lock)
            {
                var records = Load();
                var record = FindOrThrow(records, id);
                if (record.Status != "claimed")
                    throw new InvalidOperationException($"Quote '{id}' is '{record.Status}' and cannot be consumed.");
                record.Status = "consumed";
                record.ConsumedBy = consumedBy;
                Save(records);
                return record;
            }
        }

        public QuoteRecord Release(string id)
        {
            lock (_lock)
            {
                var records = Load();
                var record = FindOrThrow(records, id);
                if (record.Status != "claimed")
                    throw new InvalidOperationException($"Quote '{id}' is '{record.Status}' and cannot be released.");
                record.Status = "available";
                record.ClaimedBy = null;
                Save(records);
                return record;
            }
        }
    }
}
