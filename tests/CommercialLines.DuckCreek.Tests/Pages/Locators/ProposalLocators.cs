using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date:*", Exact = true });

    public ILocator NewQuote => _page.GetByRole(AriaRole.Link, new() { Name = "New Quote", Exact = true });

    public ILocator Product => _page.GetByRole(AriaRole.Textbox, new() { Name = "Product:*", Exact = true });

    public ILocator Start => _page.GetByRole(AriaRole.Button, new() { Name = "Start", Exact = true });
}
