namespace Playwright_POC.Models
{
    /// <summary>
    /// Policy-level information (quote details, coverages, discounts)
    /// </summary>
    public class PolicyData
    {
        // Quote identification
        public string QuoteNumber { get; set; }

        // Policy details
        public string EffectiveDate { get; set; }
        public string PolicyTerm { get; set; }
        public string AgentCode { get; set; }
        public string RatingState { get; set; }
        public string WritingCompany { get; set; }
        public string RiskAddress { get; set; }
        public string OwnershipType { get; set; }
        public string LessorRisk { get; set; }
        public string EligibilityRestrictions { get; set; }

        // Coverages
        public string PolicyCoverage { get; set; }
        public string CompCollOnly { get; set; }
        public string CompDeductible { get; set; }
        public string CollDeductible { get; set; }
        public string AccidentalDeathAndDismemberment { get; set; }
        public string LossOfIncome { get; set; }
        public string RentalReimbursement { get; set; }
        public string RoadsideAssistance { get; set; }

        // Discounts
        public string PolicyDiscount { get; set; }
        public string BenefitXpressDiscount { get; set; }
        public string AccountCompositionDiscount { get; set; }
    }
}
