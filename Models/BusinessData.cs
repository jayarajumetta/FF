namespace PnCTestAutomation.Models
{
    /// <summary>
    /// Business information for BOP (Business Owners Policy)
    /// </summary>
    public class BusinessData
    {
        public string EntityType { get; set; }
        public string DBAName { get; set; }
        public string LessorRiskExposure { get; set; }

        // Class code info
        public string ClassCodeNumber { get; set; }
        public string ClassDescription { get; set; }
        public string ClassCodeRestriction { get; set; }
    }
}
