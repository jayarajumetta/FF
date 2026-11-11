using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class CommercialDuckCreekPolicyWorkflowLocators
{
    private readonly IPage _page;
    public CommercialDuckCreekPolicyWorkflowLocators(IPage page) => _page = page;

    public ILocator UserNameInitial => _page.Locator("div.userNameInitial", new() { HasTextString = "QA" }).Or(_page.Locator("div.userNameInitial", new() { HasTextString = "UP" })).Or(_page.Locator("div.userNameInitial", new() { HasTextString = "EA" }));

    public ILocator Logout => _page.Locator("[id=\"id_LogOut\"]", new() { HasTextString = "Logout" });

    public ILocator LogoutOkButton => _page.Locator("div.x-message-box[role=\"alertdialog\"] a.x-btn", new() { HasTextString = "OK" }).First;

    public ILocator QuickSearchButton => _page.Locator("[id=\"id_quickSearch\"]");

    public ILocator SearchButton => _page.Locator("#searchFilterActions a[name=\"searchFilterActions\"]");

    public ILocator SearchMethodEGDescriptionPolicy => _page.Locator("[id='_keynameAdvSearch1-inputEl']");

    public ILocator SearchResultsInsuredNameColumnHeader => _page.Locator("span.x-column-header-text-inner", new() { HasTextString = "Insured Name" });

    public ILocator SearchResultInsuredNameLink => _page.Locator("[id=\"clientPageLoadA\"]");

    public ILocator CommercialAutoQuoteLink => _page.Locator("#quoteList table.formTbl tr:not(.detailsLabel)").First.Locator("td").First.Locator("a");

    public ILocator SearchText => _page.Locator("[id='quickSearchTextId-inputEl']");
}
