using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    public ILocator EffectiveDate => _page.Locator("input[fieldref=\"PolicyInput.EffectiveDate\"]");

    public ILocator NewQuote => _page.GetByRole(AriaRole.Link, new() { Name = "New Quote", Exact = true });

    public ILocator Product => _page.Locator("input[fieldref=\"data.VersionIDPages\"]");

    public ILocator Start => _page.GetByRole(AriaRole.Link, new() { Name = "Start", Exact = true });
}
