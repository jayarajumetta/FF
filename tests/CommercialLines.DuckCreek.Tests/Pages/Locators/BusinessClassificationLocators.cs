using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class BusinessClassificationLocators
{
    private readonly IPage _page;
    public BusinessClassificationLocators(IPage page) => _page = page;

    // Source modules: Pricing | confidence=Review score=97
    public ILocator InvalidClassCodeMessage => _page.GetByLabel("Invalid Class Code Message", new() { Exact = true });

}
