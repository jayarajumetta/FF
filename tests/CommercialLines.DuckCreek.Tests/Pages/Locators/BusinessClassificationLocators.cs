using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    public ILocator InvalidClassCodeMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Invalid Class Code Message");
}
