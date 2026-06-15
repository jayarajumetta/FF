namespace PnCTestAutomation.Models
{
    /// <summary>
    /// Vehicle information for Personal Auto policies
    /// </summary>
    public class VehicleData
    {
        public string VIN { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string VehicleType { get; set; }

        // Ownership and usage
        public string Ownership { get; set; }
        public string Usage { get; set; }
        public string PurchaseDate { get; set; }
        public string OdometerReading { get; set; }
        public string AnnualMileage { get; set; }
        public string CustomizedEquipment { get; set; }

        /// <summary>
        /// Vehicle description: "2024 Toyota Camry"
        /// </summary>
        public string Description => $"{Year} {Make} {Model}".Trim();
    }
}
