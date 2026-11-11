using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class ExpertQuoteQuoteSearchLocators
{
    private readonly IPage _page;
    public ExpertQuoteQuoteSearchLocators(IPage page) => _page = page;

    // Source: EQ|Common|Search by QuoteNum.
    public ILocator QuoteSearchInput => _page.Locator("[id='quoteSearchInput']");
    public ILocator QuoteSearchButton => _page.Locator("button[id='quoteSearchButton'], button[data-testid='quoteSearchButton']");

    // Source: EQ|Common|Quote Identifying.
    public ILocator NameAndQuote => _page.Locator(".mdc-tab.mdc-tab--active .mdc-tab__text-label > span, mat-tab-header [role='tab'][aria-selected='true'] .mdc-tab__text-label > span").First;
    public ILocator CloseQuote => _page.Locator("mat-icon").Filter(new() { HasText = "clear" });

    // Source: EQ|Common|Review Required Pop-up.
    public ILocator KeepGoing => _page.Locator("[id='btnConfirmYes']");

    // Source: EQ|Common|Navigation.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByTestId($"{screen}-nav");
    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^" + Regex.Escape(screen), RegexOptions.IgnoreCase) });
}
