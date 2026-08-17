using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class SocialSecurityLocators
{
    private readonly IPage _page;
    public SocialSecurityLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|SSN | confidence=Medium score=83
    public ILocator Continue => _page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator EChecklistEChecklistSubmit => _page.GetByRole(AriaRole.Button, new() { Name = "Submit", Exact = true });

    // Source modules: EQ|Common|SSN | confidence=Medium score=78
    public ILocator NoPrefillMatchFound => _page.GetByLabel("No Prefill Match Found", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|Common|SSN | confidence=High score=127
    public ILocator SubmitAngular => _page.GetByRole(AriaRole.Button, new() { Name = "Submit - Angular***", Exact = true });

    // Source modules: EQ|Common|SSN | confidence=Medium score=108
    public ILocator TheSSNCouldNotBeFoundPleaseEnterAnSSN => _page.GetByLabel("The SSN could not be found. Please enter an SSN.", new() { Exact = true });

}