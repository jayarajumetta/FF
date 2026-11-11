using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure =>
        _page.Locator("label").Filter(new() { HasText = "Are all collector vehicles kept in a fully enclosed and locked structure?" });

    public ILocator VehiclesKeptEnclosedNo => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator VehiclesKeptEnclosedYes => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-label").Filter(new() { HasText = "Yes" });

    public ILocator WhoWillCompleteInspectionHeader => _page.GetByText("Who will complete the inspection?", new() { Exact = true });

    public ILocator CompleteInspectionAgent => _page.GetByTestId("fields.data.policyInspection.line.risk.rows[0].vehicleInput$completeInspection.value-chip-label").Filter(new() { HasText = "Agent" });

    public ILocator ChkBoxCheckBoxNoneOfTheAbove => _page.GetByTestId("fields.data.policy.preQualificationQuestionPolicy$noneOfTheAbove.value-checkbox-wrapper");

    public ILocator PreQualificationNext => _page.Locator("[data-testid='fields.data.next-button-label']").Filter(new() { HasText = "Next" });

    public ILocator CycleUnderwritingNext => _page.GetByTestId("fields.pageAction.next-button-label").Filter(new() { HasText = "Next" });

    public ILocator EQCommonLoadingIndicatorWait => _page.GetByText("EQ |Common|Loading Indicator Wait", new() { Exact = true });

    public ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony => _page.GetByText("Eligibility Restrictions");

    public ILocator CollectorNVintageNo => _page.Locator("input[id='fields.data.policy.underwritingQuestionsPolicy$vintageVehGaragedInDiffLocation.value-0-input']").First;

    public ILocator HeaderUnderwriting => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Underwriting", Exact = true });

    public ILocator BtnNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });
    public ILocator NewQuoteSearch => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");


    public ILocator No43938 => _page.Locator("[data-testid*='fields.data.policy.underwritingQuestionsPolicy$']").GetByText("No", new() { Exact = true }).First;

    public ILocator No77DAE => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator TrafficRelatedFelonyNo => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$trafficRelatedFelony.value-chip-label").Filter(new() { HasText = "No" });


    public ILocator QuotePolicySearch => _page.Locator("[name=\"Txt_Quote\\\\Policy Search\"], [id=\"Txt_Quote\\\\Policy Search\"]").First;



    public ILocator Yes71588 => _page.GetByTestId("fields.data.policy.underwritingQuestionsPolicy$vehiclesKeptEnclosed.value-chip-wrapper");

    // Row indices in the id/data-testid (rows[0], rows[1], ...) reflect the underlying rule
    // configuration, not the order alerts are actually rendered on screen; different alert
    // combinations can shift which row index appears first. Selecting by rendered order
    // (Nth) instead of a hardcoded row index keeps this pointed at the first/second visible
    // Agent Comments box regardless of which row index the platform assigns.
    private ILocator AgentCommentsInputs => _page.Locator("input[data-testid*=\"uWRuleReview$agentComments.value\"]");

    public ILocator AgentComments => AgentCommentsInputs.Nth(0);

    public ILocator AgentComments2 => AgentCommentsInputs.Nth(1);

    // Row indices in the id/data-testid (rows[0], rows[1], ...) for Agent Note boxes can vary
    // depending on how many underwriting rule rows are rendered, so match all occurrences by
    // data-testid substring and iterate over them by count rather than hardcoding row indices.
    public ILocator AgentNoteInputs => _page.Locator("input[data-testid*=\"uWRuleReview$agentNote.value\"]");

    public ILocator ReferToUW => _page.Locator("button#fields\\.data\\.refer[data-testid=\"fields.data.refer\"]");

}
