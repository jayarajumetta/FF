namespace Playwright_POC.Models
{
    /// <summary>
    /// Underwriting question answers
    /// </summary>
    public class UnderwritingData
    {
        public string GeneralAnswer { get; set; }

        // Common UW questions - can be extended per LOB
        public bool? ConvictionFelony { get; set; }
        public bool? PolicyDeclined5Years { get; set; }
        public bool? AlcoholOnPremises { get; set; }
        public bool? NoneOfTheAbove { get; set; }
    }
}
