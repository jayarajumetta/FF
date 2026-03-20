namespace Playwright_POC.Models
{
    /// <summary>
    /// Billing and payment information
    /// </summary>
    public class PaymentData
    {
        public string PrimaryPayer { get; set; }
        public string PaymentType { get; set; }
        public string PaymentPlan { get; set; }
        public string PaymentDueDate { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string CheckNumber { get; set; }
        public string Paperless { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }
}
