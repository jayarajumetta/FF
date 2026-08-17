using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=Medium score=113
    public ILocator ADDCLAIM => _page.GetByRole(AriaRole.Button, new() { Name = "+ ADD CLAIM", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=114
    public ILocator AddANote => _page.GetByRole(AriaRole.Textbox, new() { Name = "Add a Note...", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=113
    public ILocator AllLink => _page.GetByRole(AriaRole.Link, new() { Name = "All Link", Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator AmountPaid => _page.GetByRole(AriaRole.Textbox, new() { Name = "Amount Paid", Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator AmountReserved => _page.GetByRole(AriaRole.Textbox, new() { Name = "Amount Reserved", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClaimSummaryTableRowCellExplicitNameAmount => _page.GetByText("(ExplicitName=Amount)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClaimSummaryTableRowCellExplicitNameCATClaim => _page.GetByText("(ExplicitName=CAT Claim)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClaimSummaryTableRowCellExplicitNameClaimDate => _page.GetByText("(ExplicitName=Claim Date)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClaimSummaryTableRowCellExplicitNameLineOfCoverage => _page.GetByText("(ExplicitName=Line of Coverage)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ClaimSummaryTableRowCellExplicitNameTypeOfLoss => _page.GetByText("(ExplicitName=Type of Loss)", new() { Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator DateOfOccurrence => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Occurrence", Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator DescriptionOfOccurrenceOrClaim => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Occurrence Or Claim", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator EChecklistEChecklistOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator Exception => _page.GetByRole(AriaRole.Button, new() { Name = "Exception", Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator ExpenseAmount => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expense Amount", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=97
    public ILocator LossRuns3YearsHeader => _page.GetByLabel("Loss Runs - 3 years Header", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=97
    public ILocator LossRunsHeader => _page.GetByLabel("Loss Runs Header", new() { Exact = true });

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=130
    public ILocator N3Years => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-chip-wrapper");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=130
    public ILocator OpenButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-chip-wrapper");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator PolicyExpire => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Expire", Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator PolicyStart => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Start", Exact = true });

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=127
    public ILocator PriorInsuranceLatestCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior Insurance Latest Carrier", Exact = true });

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=127
    public ILocator PriorInsuranceLatestExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior Insurance Latest Expiration Date", Exact = true });

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=130
    public ILocator PriorPolicyNo => _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-wrapper");

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    public ILocator TypeOfLossDropdown => _page.GetByLabel("Type of Loss Dropdown", new() { Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=Review score=97
    public ILocator TypeOfLossSelection => _page.GetByLabel("Type of Loss Selection", new() { Exact = true });

    // Source modules: EQ|BOP|Pricing|CA & MA Risk Categories | confidence=High score=127
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Combobox, new() { Name = "Years in Business", Exact = true });

}
