using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PricingLocators
{
    private readonly IPage _page;
    public PricingLocators(IPage page) => _page = page;

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=95
    // CPP, CP, CR, IM, GL(NY, VT, MD, NJ) and WC(NY)
    public ILocator EstimatedPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimated Premium*", Exact = true });

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator FullTermPremium => _page.GetByLabel("Full Term Premium", new() { Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules: Pricing | confidence=High score=125
    public ILocator Premium => _page.GetByLabel("Premium", new() { Exact = true });

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PremiumChange => _page.GetByLabel("Premium Change", new() { Exact = true });

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PremiumWritten => _page.GetByLabel("Premium Written", new() { Exact = true });

    // Source modules: Submission|Premiums | confidence=Review score=97
    public ILocator PriorPremium => _page.GetByLabel("Prior Premium", new() { Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => _page.GetByLabel("Result", new() { Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

}