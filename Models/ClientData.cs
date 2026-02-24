namespace Playwright_POC.Models
{
    /// <summary>
    /// Account owner / primary client information
    /// </summary>
    public class ClientData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        public string Email { get; set; }
        public string EmailType { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string SSN { get; set; }

        /// <summary>
        /// Full name in "FirstName LastName" format
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();

        /// <summary>
        /// Full name in "LastName, FirstName" format (for search results)
        /// </summary>
        public string FullNameReversed => $"{LastName}, {FirstName}".Trim();
    }
}
