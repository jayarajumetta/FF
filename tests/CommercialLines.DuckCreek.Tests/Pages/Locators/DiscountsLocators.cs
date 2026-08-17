using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=95
    public ILocator AccountCredit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Account Credit", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    public ILocator BAPSpecificFieldsOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    public ILocator NAICSCodeSearchResults => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Results*", Exact = true });

    // Source modules: Policy Info|BAP Specific Fields | confidence=High score=125
    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Value*", Exact = true });

}