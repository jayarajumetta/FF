using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    public ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => _page.GetByText("All required fields have not been completed. Please complete highlighted tabs.", new() { Exact = true });

    public ILocator Close => _page.GetByRole(AriaRole.Button, new() { Name = "Close", Exact = true });

    public ILocator CompleteApplication => _page.Locator("[duckcreekid=\"Complete Application\"], [data-duckcreekid=\"Complete Application\"]");

    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    public ILocator LaunchToChecklistButton => _page.Locator("input[id=\"fields.data.policyInput$largeAccountIndicator.value-input\"][name=\"fields.data.policyInput$largeAccountIndicator.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");


    public ILocator ReferToUW => _page.Locator("input[id=\"\\\"fields.data.policy - Step 2 Underwriting Rules.uWRulesReview.uWRuleReviewLevel8.rows[0].uWRuleReview$agentComments.value\\\"\"][name=\"\\\"fields.data.policy - Step 2 Underwriting Rules.uWRulesReview.uWRuleReviewLevel8.rows[0].uWRuleReview$agentComments.value\\\"\"]");

    public ILocator StoplightWaitingWindow => _page.Locator("[id=\"stoplightWaitingWindow\"]");

    public ILocator StoplightWaitingWindowError => _page.GetByText("Error:", new() { Exact = true });

    public ILocator StoplightWaitingWindowFirstCloseButtonOnError => _page.GetByText("First Close button on Error", new() { Exact = true });

    public ILocator SubmissionScreenHeading => _page.GetByText("Submission Screen Heading", new() { Exact = true });

    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

    public ILocator TABLERowCellExplicitName2 => _page.GetByText("(ExplicitName=$2)", new() { Exact = true });

    public ILocator TABLERowCellExplicitName4 => _page.GetByText("(ExplicitName=$4)", new() { Exact = true });

    public ILocator TABLERowCellExplicitName5 => _page.GetByText("(ExplicitName=$5)", new() { Exact = true });



}
