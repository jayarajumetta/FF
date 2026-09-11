using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    public ILocator AccountCredit => _page.Locator("input[fieldref=\"PolicyInput.AccountCredit\"]");

    public ILocator BAPSpecificFieldsOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator NAICSCodeSearchResults => _page.Locator("input[fieldref=\"PolicyInput.NAICSCodeDesc\"]");

    public ILocator NAICSCodeSearchValue => _page.Locator("input[fieldref=\"PolicyOutputNonShredded.NAICSCodeSearchValue\"]");
}
