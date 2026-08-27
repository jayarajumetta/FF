using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=95
    // CPP, CP, CR, IM, GL(NY, VT, MD, NJ) and WC(NY)
    public ILocator EstimatedPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimated Premium*", Exact = true });

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator FullTermPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Full Term Premium");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    // Source modules: Pricing | confidence=High score=125
    public ILocator Premium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium");

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PremiumChange => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium Change");

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PremiumWritten => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium Written");

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PriorPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Prior Premium");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

}
