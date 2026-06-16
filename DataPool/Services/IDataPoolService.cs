using DataPool.Models;

namespace DataPool.Services
{
    public interface IDataPoolService
    {
        IReadOnlyList<QuoteRecord> GetAll(string? status = null, bool? isCommittedReferral = null, string? type = null, string? lob = null, string? sfpVariant = null);
        IReadOnlyList<QuoteRecord> GetAvailable();
        QuoteRecord Add(QuoteRecord record);
        QuoteRecord Claim(string id, string claimedBy);
        QuoteRecord Consume(string id, string consumedBy);
        QuoteRecord Release(string id);
    }
}
