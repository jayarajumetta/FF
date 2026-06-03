namespace PnCTestAutomation.Models
{
    /// <summary>
    /// Additional interest / lienholder information
    /// </summary>
    public class AdditionalInterestData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        // For joint owner scenarios
        public string JointOwnerDrive { get; set; }
        public string RelationshipToAccountOwner { get; set; }
        public string DateOfBirth { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseState { get; set; }
    }
}
