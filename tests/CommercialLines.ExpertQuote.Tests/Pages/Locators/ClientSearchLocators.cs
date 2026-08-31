using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    // EQ|Common|Start New Quote
    public ILocator NewQuote => _page.GetByRole(AriaRole.Button, new() { Name = "New Quote", Exact = true });

    // EQ|Common|Client Info: H1 + source HTML IDs.
    public ILocator ClientInfo => _page.GetByRole(AriaRole.Heading, new() { Name = "Client Info", Exact = true });
    public ILocator CustomerNameFirst => _page.Locator("[id='customer.name.first']");
    public ILocator CustomerNameLast => _page.Locator("[id='customer.name.last']");
    public ILocator CustomerDateOfBirth => _page.Locator("[id='customer.dateOfBirth']");
    public ILocator ClientInfoSearch => _page.Locator("[duckcreekid=\"Search\"], [data-duckcreekid=\"Search\"]");

    // EQ|Common|Create New Client
    public ILocator ExistingClientMatch => _page.GetByRole(AriaRole.Heading, new() { Name = "Existing Client Match", Exact = true });
    public ILocator CreateNewClient => _page.GetByTestId("customer.selected-new-chip");
    public ILocator AdditionalInterestsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Kept only for legacy generated page APIs.
    public ILocator NewExistingClientSearch => _page.GetByText("New/Existing Client Search", new() { Exact = true });
}
