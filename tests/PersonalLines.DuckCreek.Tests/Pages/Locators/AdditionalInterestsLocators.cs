using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AdditionalInterestsLocators
{
    private readonly IPage _page;
    public AdditionalInterestsLocators(IPage page) => _page = page;

    // Source modules: EQ || AdditionalInterest | confidence=Medium score=113
    public ILocator AdditionalInterestNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

}