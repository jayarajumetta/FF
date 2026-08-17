using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator AgentPC => _page.GetByRole(AriaRole.Textbox, new() { Name = "AgentPC", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=130
    public ILocator BusinessOwners => _page.GetByTestId("proposal.product-chip-item-wrapper");

    // Source modules: EQ|Common|Create Quote Landing Page | confidence=High score=127
    public ILocator EffectiveDate6F16B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator EffectiveDate78F67 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Individual => _page.GetByText("Individual", new() { Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator IndividualDBA => _page.GetByRole(AriaRole.Textbox, new() { Name = "Individual DBA", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator IndividuallyOwnedDBAOrTA => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Individually Owned, DBA, or T/A", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=130
    public ILocator LessorsRiskNo => _page.GetByTestId("proposal.LessorsRiskExposure-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Missouri => _page.GetByText("Missouri", new() { Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=96
    public ILocator NewAccountAddress => _page.GetByRole(AriaRole.Radio, new() { Name = "newAccountAddress", Exact = true });

    // Source modules:  | confidence=Medium score=78
    public ILocator No => _page.GetByLabel("No", new() { Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=130
    public ILocator PolicyTerm => _page.GetByTestId("proposal.term");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ProposalDetails => _page.GetByText("Proposal Details", new() { Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=Medium score=78
    public ILocator ProposalDetailsHeader => _page.GetByLabel("Proposal Details Header", new() { Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator SearchBusinessName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Business Name", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=Medium score=113
    public ILocator SelectSFPCE => _page.GetByRole(AriaRole.Button, new() { Name = "Select -SFP CE", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=130
    public ILocator SpecialFarmPackage => _page.GetByTestId("proposal.product-chip-label");

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator StartQuote => _page.GetByRole(AriaRole.Button, new() { Name = "Start Quote", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator State => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules: EQ|Common|Proposal Start | confidence=High score=127
    public ILocator StateDropdown => _page.GetByLabel("State Dropdown", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator True => _page.GetByText("True", new() { Exact = true });

}