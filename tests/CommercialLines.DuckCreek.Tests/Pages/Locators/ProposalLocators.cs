using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Source modules: Product Selection | confidence=High score=125
    // v56 raw Tosca primary: Employers Liability | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator NewQuote => _page.GetByRole(AriaRole.Link, new() { Name = "New Quote", Exact = true });

    // Source modules: Product Selection | confidence=High score=95
    public ILocator Product => _page.GetByRole(AriaRole.Textbox, new() { Name = "Product:*", Exact = true });

    // Source modules: Product Selection | confidence=High score=125
    public ILocator Start => _page.GetByRole(AriaRole.Button, new() { Name = "Start", Exact = true });

}
