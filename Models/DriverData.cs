namespace Playwright_POC.Models
{
    /// <summary>
    /// Driver information for Personal Auto policies
    /// </summary>
    public class DriverData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        // License info
        public string LicenseNumber { get; set; }
        public string LicenseState { get; set; }
        public string YearsLicensed { get; set; }
        public string MonthsLicensed { get; set; }

        // Driver status
        public string OperatorStatus { get; set; }
        public string DriverStatus { get; set; }
        public string IsNamedInsured { get; set; }
        public string FinancialResponsibility { get; set; }
        public string RelationshipToAccountOwner { get; set; }

        /// <summary>
        /// Full name in "FirstName LastName" format
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}
