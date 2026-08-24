using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class SocialSecurityLocators
{
    private readonly IPage _page;
    public SocialSecurityLocators(IPage page) => _page = page;

    // Source: EQ|Common|SSN.
    public ILocator SsnNotFoundMessage =>
        _page.GetByText(new Regex(@"No SSN# Found|SSN.*could not be found", RegexOptions.IgnoreCase));
    public ILocator SsnInput => _page.Locator("[id='ssn']");

    // Tosca source: Tag=BUTTON, Id=btnConfirmYes. This is an HTML id, not data-testid.
    public ILocator SubmitAngular => _page.Locator("[id='btnConfirmYes']");
    public ILocator EChecklistEChecklistSubmit => SubmitAngular;

    public ILocator NoPrefillMatchFound =>
        _page.GetByRole(AriaRole.Heading, new() { Name = "No Prefill Match Found", Exact = true });
    public ILocator Continue => _page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true });

    // Compatibility aliases
    public ILocator TheSSNCouldNotBeFoundPleaseEnterAnSSN => SsnInput;
    public ILocator ScreenHeading => NoPrefillMatchFound;
}
