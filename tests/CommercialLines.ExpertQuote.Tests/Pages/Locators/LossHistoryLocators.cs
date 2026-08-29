using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class LossHistoryLocators
{
    private readonly IPage _page;
    public LossHistoryLocators(IPage page) => _page = page;

    public ILocator ADDCLAIM => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value\\\"\"]");

    public ILocator AddANote => _page.Locator("[id=\"note\"]");

    public ILocator AllLink => _page.Locator("[id=\"add-note\"]");

    public ILocator AmountPaid => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value\\\"\"]");

    public ILocator AmountReserved => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value\\\"\"]");

    public ILocator ClaimSummaryTableRowCellExplicitNameAmount => _page.GetByText("(ExplicitName=Amount)", new() { Exact = true });

    public ILocator ClaimSummaryTableRowCellExplicitNameCATClaim => _page.GetByText("(ExplicitName=CAT Claim)", new() { Exact = true });

    public ILocator ClaimSummaryTableRowCellExplicitNameClaimDate => _page.GetByText("(ExplicitName=Claim Date)", new() { Exact = true });

    public ILocator ClaimSummaryTableRowCellExplicitNameLineOfCoverage => _page.GetByText("(ExplicitName=Line of Coverage)", new() { Exact = true });

    public ILocator ClaimSummaryTableRowCellExplicitNameTypeOfLoss => _page.GetByText("(ExplicitName=Type of Loss)", new() { Exact = true });


    public ILocator DescriptionOfOccurrenceOrClaim => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value\\\"\"]");

    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    public ILocator Exception => _page.Locator("[id=\"exception\"]");

    public ILocator ExpenseAmount => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value\\\"\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LossRuns3YearsHeader => _page.Locator("[id=\"checklist-item-name\"]");


    public ILocator N3Years => _page.GetByTestId("fields.data.policy.policyUnderwriting.policyUnderwritingInput$yearsMaintainedContinuousInsuranceCoverage.value-chip-wrapper");

    public ILocator OpenButton => _page.GetByTestId("fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-chip-wrapper");

    public ILocator PolicyExpire => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodExpirationDate.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodExpirationDate.value\\\"\"]");

    public ILocator PolicyStart => _page.Locator("input[id=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodEffectiveDate.value\\\"\"][name=\"\\\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodEffectiveDate.value\\\"\"]");

    public ILocator PriorInsuranceLatestCarrier => _page.Locator("input[id=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value\"][name=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value\"]");

    public ILocator PriorInsuranceLatestExpirationDate => _page.Locator("input[id=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value\"][name=\"fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value\"]");

    public ILocator PriorPolicyNo => _page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-wrapper");

    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator TypeOfLossDropdown => _page.Locator("[id=\"\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$typeOfLoss.value\"\"]");


    public ILocator YearsInBusiness => _page.Locator("[id=\"fields.tierPricing.tierPricingInput$yearsInBusinessReason.value\"]");

}
