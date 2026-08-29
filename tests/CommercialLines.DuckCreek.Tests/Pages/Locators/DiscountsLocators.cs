using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    public ILocator AccountCredit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Account Credit", Exact = true });

    public ILocator BAPSpecificFieldsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator NAICSCodeSearchResults => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Results*", Exact = true });

    public ILocator NAICSCodeSearchValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "NAICS Code Search Value*", Exact = true });
}
