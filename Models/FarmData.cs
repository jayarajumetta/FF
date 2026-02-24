namespace Playwright_POC.Models
{
    /// <summary>
    /// Farm information for SFP (Special Farm Package)
    /// </summary>
    public class FarmData
    {
        public string PrimaryFarmType { get; set; }
        public string LivestockType { get; set; }
        public string GrossFarmIncome { get; set; }
        public string GrowIndustrialHemp { get; set; }

        // Location Properties
        public string LocationNickname { get; set; }
        public string LocationType { get; set; }
        public string MilesFromFireDepartment { get; set; }
        public string FeetFromHydrant { get; set; }
        public string TotalAcreage { get; set; }

        // Coverage Properties
        public string WindHailDeductible { get; set; }
        public string Narrative { get; set; }
    }
}
