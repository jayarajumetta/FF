namespace DataPool.Models
{
    public class QuoteRecord
    {
        public string Id { get; set; } = string.Empty;

        /// <summary>"Quote" or "Policy"</summary>
        public string Type { get; set; } = "Quote";

        /// <summary>"available", "claimed", or "consumed"</summary>
        public string Status { get; set; } = "available";

        public bool IsCommittedReferral { get; set; }

        /// <summary>Business state abbreviation (e.g. "AL", "TX")</summary>
        public string? State { get; set; }

        public string? Notes { get; set; }
        public string? ClaimedBy { get; set; }
        public string? ConsumedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
