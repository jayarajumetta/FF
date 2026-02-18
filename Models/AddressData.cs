namespace Playwright_POC.Models
{
    /// <summary>
    /// Reusable address structure for mailing, risk, location addresses
    /// </summary>
    public class AddressData
    {
        public string Street { get; set; }
        public string AptNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }

        /// <summary>
        /// Whether client receives mail at this address
        /// </summary>
        public string ReceivesMail { get; set; }

        /// <summary>
        /// Whether client resides at this address
        /// </summary>
        public string IsResidence { get; set; }

        /// <summary>
        /// Full address in single-line format: "123 Main St, City, ST 12345"
        /// </summary>
        public string FullAddress
        {
            get
            {
                var apt = string.IsNullOrEmpty(AptNumber) ? "" : $" {AptNumber}";
                return $"{Street}{apt}, {City}, {State} {ZipCode}".Trim();
            }
        }
    }
}
