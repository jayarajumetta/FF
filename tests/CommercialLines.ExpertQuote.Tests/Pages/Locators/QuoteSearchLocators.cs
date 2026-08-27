using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class QuoteSearchLocators
{
    private readonly IPage _page;
    public QuoteSearchLocators(IPage page) => _page = page;

    // Source: EQ|Common|Search by QuoteNum.
    public ILocator QuoteSearchInput => _page.Locator("[id='quoteSearchInput']");
    // v56 raw Tosca primary: Submission, select Policy Forms | Search | DuckCreekId
    public ILocator QuoteSearchButton => _page.Locator("[duckcreekid=\"Search\"], [data-duckcreekid=\"Search\"]");

    // Source: EQ|Common|Quote Identifying.
    // Name and Quote = SPAN.ng-star-inserted in the current Angular Material tab/header.
    public ILocator NameAndQuote => _page.Locator("mat-tab-header [role='tab'] span.ng-star-inserted");
    // Close Quote = MAT-ICON with InnerText=clear. Clicking the icon bubbles to its action button.
    public ILocator CloseQuote => _page.Locator("mat-icon").Filter(new() { HasText = "clear" });

    // Source: EQ|Common|Review Required Pop-up.
    public ILocator KeepGoing => _page.Locator("[id='btnConfirmYes']");

    // Source: EQ|Common|Navigation. Screen is a reusable parameter; navigation is a click,
    // and the postcondition is an H1 beginning with the requested screen name.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByText(screen, new() { Exact = true });
    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^" + Regex.Escape(screen), RegexOptions.IgnoreCase) });

    // Compatibility aliases for generated APIs.
    public ILocator ClientInfoSearch => QuoteSearchButton;
    public ILocator PreQualification => GetScreenHeading("PreQualification");
    public ILocator QuoteSearch => QuoteSearchInput;
    public ILocator Loading => _page.GetByText("Loading ...", new() { Exact = true });
}
