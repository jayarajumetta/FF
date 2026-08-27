using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class ProposalLocators
{
    private readonly IPage _page;
    public ProposalLocators(IPage page) => _page = page;

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    // v56 raw Tosca primary: EQ || Proposal Details/Start | AgentCode | Id
    public ILocator AgentCode => _page.Locator("[id=\"proposal.agentPC\"]");

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    // v56 raw Tosca primary: EQ||Proposal Start Proceed & SSN | Lnk_CONFIRM | Id
    public ILocator CONFIRM => _page.Locator("[id=\"btnConfirmYes\"]");

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    // v56 raw Tosca primary: EQ||Proposal Start Proceed & SSN | Lnk_CREATE NEW ACCOUNT | Id
    public ILocator CREATENEWACCOUNT => _page.Locator("[id=\"btnConfirmNo\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClientAlreadyExists => _page.GetByText("Client Already Exists", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator CountyComboBox => _page.Locator("[name=\"County_ComboBox\"], [id=\"County_ComboBox\"]").First;

    // Source modules: EQ || Proposal Details/Start | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || Proposal Details/Start | PROCEED | Id
    // v56 semantic alias: same physical raw-Tosca control as CONFIRM
    public ILocator CountyYes => CONFIRM;

    // Source modules: EQ || Proposal Details/Start | confidence=High score=127
    // v56 raw Tosca primary: EQ || Proposal Details/Start | EffectiveDate | Id+Name
    public ILocator EffectiveDate => _page.Locator("input[id=\"proposal.effectiveDate\"][name=\"proposal.effectiveDate\"]");

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator Motorcycle => _page.GetByTestId("proposal.product-chip-label");

    // Source modules: EQ||New Quote | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||New Quote | Txt_Quote\Policy Search | Id+Name
    public ILocator NewQuote => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=97
    // v56 raw Tosca primary: EQ||Proposal Start Proceed & SSN | Lnk_PROCEED | Id
    // v56 semantic alias: same physical raw-Tosca control as CONFIRM
    public ILocator PROCEED => CONFIRM;

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator PersonalAuto => Motorcycle; // semantic alias; locator defined once

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    // v56 raw Tosca primary: EQ||Proposal Start Proceed & SSN | Lnk_SUBMIT | Id
    // v56 semantic alias: same physical raw-Tosca control as CONFIRM
    public ILocator ProposalStartProceedSSNSUBMIT => CONFIRM;

    // Source modules: EQ||Tabs | confidence=Review score=97
    // v56 raw Tosca primary: EQ||Tabs | Txt_quoteSearchInput | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as NewQuote
    public ILocator QNum => NewQuote;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator QuoteNumber => _page.GetByText("Quote Number", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=130
    public ILocator RecreationalVehicle => Motorcycle; // semantic alias; locator defined once

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    public ILocator SSN => _page.Locator("[name=\"Txt_SSN\"], [id=\"Txt_SSN\"]").First;

    // Source modules: EQ || Proposal Details/Start | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Proposal Details/Start | Personal Auto | Id+attributes_data-testid
    public ILocator SameAsMailingAddress => _page.Locator("span[id=\"proposal.product-0\"][data-testid=\"proposal.product-chip-label\"]");

    // Source modules: EQ || Proposal Details/Start | confidence=High score=127
    // v56 raw Tosca primary: EQ || Proposal Details/Start | Start Quote | Id
    public ILocator StartQuote => _page.Locator("[id=\"startQuote\"]");

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    // v56 raw Tosca primary: EQ || Proposal Details/Start | State | Id
    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StateMONTANA => _page.GetByText("State == \"MONTANA", new() { Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=Review score=97
    // v56 raw Tosca primary: EQ || Proposal Details/Start | State | Id
    // v56 semantic alias: same physical raw-Tosca control as State
    public ILocator StateName => State;

    // Source modules: EQ||Proposal Start Proceed & SSN | confidence=High score=127
    // v56 raw Tosca primary: EQ||Proposal Start Proceed & SSN | Lnk_USE EXISTING ACCOUNT | Id
    // v56 semantic alias: same physical raw-Tosca control as CONFIRM
    public ILocator USEEXISTINGACCOUNT => CONFIRM;

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    // v56 raw Tosca primary: EQ || Proposal Details/Start | WritingCompany | Id
    public ILocator WritingCompany => _page.Locator("[id=\"proposal.writingCompany\"]");

}
