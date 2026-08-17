using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator AgentCode => _page.GetByRole(AriaRole.Combobox, new() { Name = "AgentCode", Exact = true });

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    public ILocator CONFIRM => _page.GetByRole(AriaRole.Button, new() { Name = "Lnk_CONFIRM", Exact = true });

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    public ILocator CREATENEWACCOUNT => _page.GetByRole(AriaRole.Button, new() { Name = "Lnk_CREATE NEW ACCOUNT", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClientAlreadyExists => _page.GetByText("Client Already Exists", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator CountyComboBox => _page.GetByRole(AriaRole.Combobox, new() { Name = "County_ComboBox", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=Medium score=83
    public ILocator CountyYes => _page.GetByRole(AriaRole.Link, new() { Name = "County_Yes", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=127
    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "EffectiveDate", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator Motorcycle => _page.GetByTestId("proposal.product-chip-label");

    // Source modules: EQ||New Quote | confidence=Medium score=113
    public ILocator NewQuote => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_New Quote", Exact = true });

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    public ILocator PROCEED => _page.GetByRole(AriaRole.Button, new() { Name = "Lnk_PROCEED", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator PersonalAuto => _page.GetByTestId("proposal.product-chip-label");

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    public ILocator ProposalStartProceedSSNSUBMIT => _page.GetByRole(AriaRole.Button, new() { Name = "Lnk_SUBMIT", Exact = true });

    // Source modules: EQ||Tabs | confidence=Review score=97
    public ILocator QNum => _page.GetByLabel("Lbl_QNum", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuoteNumber => _page.GetByText("Quote Number", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator RecreationalVehicle => _page.GetByTestId("proposal.product-chip-label");

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    public ILocator SSN => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_SSN", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=Medium score=113
    public ILocator SameAsMailingAddress => _page.GetByRole(AriaRole.Radio, new() { Name = "SameAsMailingAddress", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=127
    public ILocator StartQuote => _page.GetByRole(AriaRole.Button, new() { Name = "Start Quote", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator State => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StateMONTANA => _page.GetByText("State == \"MONTANA", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=Review score=97
    public ILocator StateName => _page.GetByLabel("State Name", new() { Exact = true });

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    public ILocator USEEXISTINGACCOUNT => _page.GetByRole(AriaRole.Button, new() { Name = "Lnk_USE EXISTING ACCOUNT", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator WritingCompany => _page.GetByRole(AriaRole.Combobox, new() { Name = "WritingCompany", Exact = true });

}
