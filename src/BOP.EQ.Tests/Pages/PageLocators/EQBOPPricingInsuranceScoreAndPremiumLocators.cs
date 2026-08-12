using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPricingInsuranceScoreAndPremiumLocators
{
    // REVIEW: preserved original selector.
        // REVIEW: no stronger source locator.
    public static ILocator InsuranceScoreRefNumber(IPage page) =>
        page.Locator("xpath=\"id('AccountOutputNonShredded.ReferenceNumber-0-layout')/span[2]\"");

        public static ILocator Premium(IPage page) =>
        page.Locator("id=LineOutput.PremiumSummaryPremium124-0-layout");

}
