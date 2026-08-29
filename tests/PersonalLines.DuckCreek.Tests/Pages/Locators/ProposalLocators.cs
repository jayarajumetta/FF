using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    public ILocator AgentCode => _page.Locator("[id=\"proposal.agentPC\"]");

    public ILocator CONFIRM => _page.Locator("[id=\"btnConfirmYes\"]");

    public ILocator CREATENEWACCOUNT => _page.Locator("[id=\"btnConfirmNo\"]");

    public ILocator ClientAlreadyExists => _page.GetByText("Client Already Exists", new() { Exact = true });

    public ILocator CountyComboBox => _page.Locator("[name=\"County_ComboBox\"], [id=\"County_ComboBox\"]").First;


    public ILocator EffectiveDate => _page.Locator("input[id=\"proposal.effectiveDate\"][name=\"proposal.effectiveDate\"]");

    public ILocator Motorcycle => _page.GetByTestId("proposal.product-chip-label");

    public ILocator NewQuote => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");





    public ILocator QuoteNumber => _page.GetByText("Quote Number", new() { Exact = true });


    public ILocator SSN => _page.Locator("[name=\"Txt_SSN\"], [id=\"Txt_SSN\"]").First;

    public ILocator SameAsMailingAddress => _page.Locator("span[id=\"proposal.product-0\"][data-testid=\"proposal.product-chip-label\"]");

    public ILocator StartQuote => _page.Locator("[id=\"startQuote\"]");

    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    public ILocator StateMONTANA => _page.GetByText("State == \"MONTANA", new() { Exact = true });



    public ILocator WritingCompany => _page.Locator("[id=\"proposal.writingCompany\"]");

}
