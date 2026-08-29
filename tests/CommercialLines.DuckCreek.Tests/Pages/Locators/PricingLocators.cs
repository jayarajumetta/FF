using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");

    public ILocator FullTermPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Full Term Premium");

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator Premium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium");

    public ILocator PremiumChange => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium Change");

    public ILocator PremiumWritten => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Premium Written");

    public ILocator PriorPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Prior Premium");

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");
}
