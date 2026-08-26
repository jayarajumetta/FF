using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Date Of Occurrence | Id+Name
    public ILocator ADDCLAIM => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value\\\"\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=114
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add a Note...Signature | Id
    public ILocator AddANote => _page.Locator("[id=\"note\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    public ILocator AllLink => _page.Locator("[id=\"add-note\"]");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Amount Paid | Id+Name
    public ILocator AmountPaid => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value\\\"\"]");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Amount Reserved | Id+Name
    public ILocator AmountReserved => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value\\\"\"]");

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
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Date Of Occurrence | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as ADDCLAIM
    public ILocator DateOfOccurrence => ADDCLAIM;

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Description Of Occurrence Or Claim | Id+Name
    public ILocator DescriptionOfOccurrenceOrClaim => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value\\\"\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | OK | Id
    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Exception | Id
    public ILocator Exception => _page.Locator("[id=\"exception\"]");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Expense Amount | Id+Name
    public ILocator ExpenseAmount => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value\\\"\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=97
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Loss Runs - 3 years Header | Id
    public ILocator LossRuns3YearsHeader => _page.Locator("[id=\"checklist-item-name\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=97
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Loss Runs Header | Id
    // v56 semantic alias: same physical raw-Tosca control as LossRuns3YearsHeader
    public ILocator LossRunsHeader => LossRuns3YearsHeader;

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=130
    public ILocator N3Years => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-chip-wrapper");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=130
    public ILocator OpenButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-chip-wrapper");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Policy Expire | Id+Name
    public ILocator PolicyExpire => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodExpirationDate.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodExpirationDate.value\\\"\"]");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Policy Start | Id+Name
    public ILocator PolicyStart => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodEffectiveDate.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodEffectiveDate.value\\\"\"]");

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|Prior Carrier-Claims|Required Info | Prior Insurance Latest Carrier | Id+Name
    public ILocator PriorInsuranceLatestCarrier => _page.Locator("input[id=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value\"][name=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value\"]");

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|Prior Carrier-Claims|Required Info | Prior Insurance Latest Expiration Date | Id+Name
    public ILocator PriorInsuranceLatestExpirationDate => _page.Locator("input[id=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value\"][name=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value\"]");

    // Source modules: EQ|Common|Prior Carrier-Claims|Required Info | confidence=High score=130
    public ILocator PriorPolicyNo => _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-wrapper");

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Type of Loss Dropdown | Id
    public ILocator TypeOfLossDropdown => _page.Locator("[id=\"\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$typeOfLoss.value\"\"]");

    // Source modules: EQ|BOP|Claims/Prior Insurance|Add Claim | confidence=Review score=97
    // v56 raw Tosca primary: EQ|BOP|Claims/Prior Insurance|Add Claim | Date Of Occurrence | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as ADDCLAIM
    public ILocator TypeOfLossSelection => ADDCLAIM;

    // Source modules: EQ|BOP|Pricing|CA & MA Risk Categories | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Pricing|CA & MA Risk Categories | Years in Business | Id
    public ILocator YearsInBusiness => _page.Locator("[id=\"fields.tierPricing.tierPricingInput$yearsInBusinessReason.value\"]");

}
