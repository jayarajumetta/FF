using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class DiscountsLocators
{
    private readonly IPage _page;
    public DiscountsLocators(IPage page) => _page = page;

    public ILocator AccountCredit => _page.Locator("input[fieldref=\"PolicyInput.AccountCredit\"]");

    public ILocator BAPSpecificFieldsOK => _page.FrameLocator("iframe").GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator NAICSCodeSearchResults => _page.Locator("input[fieldref=\"PolicyInput.NAICSCodeDesc\"]");

    public ILocator NAICSCodeSearchValue => _page.FrameLocator("iframe").Locator("input[fieldref=\"PolicyOutputNonShredded.NAICSCodeSearchValue\"]");
}
