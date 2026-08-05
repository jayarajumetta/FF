namespace DataPool.Models
{
    public class QuoteRecord
    {
        public string Id { get; set; } = string.Empty;

        /// <summary>"Quote" or "Policy"</summary>
        public string Transaction { get; set; } = "Quote";

        /// <summary>"available", "claimed", or "consumed"</summary>
        public string Status { get; set; } = "available";

        /// <summary>UTC timestamp when this record was claimed. Used for stale-claim detection.</summary>
        public DateTime? ClaimedAt { get; set; }

        /// <summary>Line of business: "SFP", "BOP", "PA", etc.</summary>
        public string? Lob { get; set; }

        /// <summary>
        /// SFP product variant — only set when Lob == "SFP".
        /// Derived from ProductSelection: "BasicPolicy" or "CE".
        /// </summary>
        public string? SfpVariant { get; set; }

        public bool IsCommittedReferral { get; set; }

        /// <summary>Business state abbreviation (e.g. "AL", "TX")</summary>
        public string? State { get; set; }

        public string? Notes { get; set; }
        public string? ClaimedBy { get; set; }
        public string? ConsumedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Policy effective date (e.g. "06/16/2026"), extracted from quote data.</summary>
        public string? EffectiveDate { get; set; }

        /// <summary>Test environment the quote was generated in (e.g. "qa", "dev").</summary>
        public string? Environment { get; set; }
    }
}
