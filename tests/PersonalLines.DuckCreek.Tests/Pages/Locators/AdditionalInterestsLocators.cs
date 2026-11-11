using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AdditionalInterestsLocators
{
    private readonly IPage _page;
    public AdditionalInterestsLocators(IPage page) => _page = page;

    public ILocator AdditionalInterestNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator AdditionalInterestHeader => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Additional Interest Summary" });


    public ILocator CONTINUED555D => _page.Locator("[data-testid='btnConfirmYes']").Filter(new() { HasText = "Continue" });

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

}
