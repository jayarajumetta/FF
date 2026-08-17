using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Additional Interests | confidence=Medium score=113
    public ILocator AdditionalInterestsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=108
    public ILocator ClientInfo => _page.GetByLabel("Client Info", new() { Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|Common|Create New Client | confidence=High score=130
    public ILocator CreateNewClient => _page.GetByTestId("customer.selected-new-chip");

    // Source modules: EQ|Common|Create New Client | confidence=High score=130
    public ILocator CreateNewClient1 => _page.GetByTestId("customer.selected-new-chip");

    // Source modules: EQ|Common|Client Info | confidence=High score=127
    public ILocator CustomerDateOfBirth => _page.GetByRole(AriaRole.Textbox, new() { Name = "customer.dateOfBirth", Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=High score=127
    public ILocator CustomerNameFirst => _page.GetByRole(AriaRole.Textbox, new() { Name = "customer.name.first", Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=High score=127
    public ILocator CustomerNameLast => _page.GetByRole(AriaRole.Textbox, new() { Name = "customer.name.last", Exact = true });

    // Source modules: EQ|Common|Create New Client | confidence=Medium score=108
    public ILocator ExistingClientMatch => _page.GetByLabel("Existing Client Match", new() { Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=78
    public ILocator NewExistingClientSearch => _page.GetByLabel("New/Existing Client Search", new() { Exact = true });

    // Source modules: EQ|Common|Start New Quote | confidence=Medium score=113
    public ILocator NewQuote => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote", Exact = true });

}
