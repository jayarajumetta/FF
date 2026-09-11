using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AdditionalInterestsLocators
{
    private readonly IPage _page;
    public AdditionalInterestsLocators(IPage page) => _page = page;

    public ILocator AdditionalInterestNext => _page.Locator("[id=\"fields.data.next\"]");

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

}
