namespace Playwright_POC.Models
{
    /// <summary>
    /// Prior insurance and claims history
    /// </summary>
    public class PriorInsuranceData
    {
        public string HasPriorInsurance { get; set; }
        public string CarrierName { get; set; }
        public string PolicyNumber { get; set; }
        public string YearsWithCarrier { get; set; }
        public string MonthsWithCarrier { get; set; }
        public string NoPriorInsuranceReason { get; set; }

        /// <summary>
        /// Had prior Farm/Fire policy with ANICO in last 90 days (SFP specific)
        /// </summary>
        public bool PriorFFANPolicy { get; set; }

        public string YearsInBusiness { get; set; }
        public string YearsContinuousCoverage { get; set; }
    }
}
