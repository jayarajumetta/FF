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
        /// Removes consumed records older than <paramref name="consumedDaysOld"/> days
        /// and unclaimed (available) records older than <paramref name="availableDaysOld"/> days.
        /// Claimed records are never touched — only a manual Release can change their status.
        /// Returns (removedConsumed, removedAvailable).
        /// </summary>
        (int RemovedConsumed, int RemovedAvailable) CleanupOldRecords(int consumedDaysOld, int availableDaysOld);
    }
}
