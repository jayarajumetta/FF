using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    // Source modules: Pricing | confidence=Review score=97
    // v57 raw Tosca: Pricing | Invalid Class Code Message | guid=3a13d49c-1688-e731-1800-7c037b36bb13 | strategy=associatedlabel-from-v55
    public ILocator InvalidClassCodeMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Invalid Class Code Message");

}
