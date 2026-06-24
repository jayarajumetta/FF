using DataPool.Models;

namespace DataPool.Services
{
    public interface IDataPoolService
    {
        IReadOnlyList<QuoteRecord> GetAll(string? status = null, bool? isCommittedReferral = null, string? transaction = null, string? lob = null, string? sfpVariant = null);
        IReadOnlyList<QuoteRecord> GetAvailable();
        QuoteRecord Add(QuoteRecord record);
        QuoteRecord Claim(string id, string claimedBy);
        QuoteRecord Consume(string id, string consumedBy);
        QuoteRecord Release(string id);

        /// <summary>
        /// Releases claims stale for more than <paramref name="staleClaimedHours"/> hours
        /// and removes consumed records older than <paramref name="consumedDaysOld"/> days.
        /// Returns (releasedCount, removedCount).
        /// </summary>
        (int Released, int Removed) CleanupOldRecords(int consumedDaysOld, int staleClaimedHours);
    }
}
