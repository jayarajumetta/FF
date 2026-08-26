using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => _page.GetByText("All required fields have not been completed. Please complete highlighted tabs.", new() { Exact = true });

    // Source modules: EQ|Common|Form Check|UI - Forms List - BOP Smart | confidence=Medium score=83
    public ILocator Close => _page.GetByRole(AriaRole.Button, new() { Name = "Close", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Submission|Complete Application & Stoplight Functionality | Complete Application | DuckCreekId
    public ILocator CompleteApplication => _page.Locator("[duckcreekid=\"Complete Application\"], [data-duckcreekid=\"Complete Application\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    // Source modules: EQ|BOP|Submission|Main Page | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Submission|Main Page | Does this meet the current Large Account threshold? | Id+Name
    public ILocator LaunchToChecklistButton => _page.Locator("input[id=\"fields.data.policyInput$largeAccountIndicator.value-input\"][name=\"fields.data.policyInput$largeAccountIndicator.value\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Indicators and Errors | Loading Message | Id
    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    // Source modules: EQ|BOP|Submission|Main Page | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|BOP|Submission|Main Page | Does this meet the current Large Account threshold? | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as LaunchToChecklistButton
    public ILocator NoReferralNeededVerification => LaunchToChecklistButton;

    // Source modules: EQ|Common|Submission|Refer to UW | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|Submission|Refer to UW | Underwriting Rules - Agent Comments | Id+Name
    public ILocator ReferToUW => _page.Locator("input[id=\"\\\"fields.data.policy - Step 2 Underwriting Rules.uWRulesReview.uWRuleReviewLevel8.rows[0].uWRuleReview$agentComments.value\\\"\"][name=\"\\\"fields.data.policy - Step 2 Underwriting Rules.uWRulesReview.uWRuleReviewLevel8.rows[0].uWRuleReview$agentComments.value\\\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary: Submission|Complete Application & Stoplight Functionality | stoplightWaitingWindow | Id
    public ILocator StoplightWaitingWindow => _page.Locator("[id=\"stoplightWaitingWindow\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindowError => _page.GetByText("Error:", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindowFirstCloseButtonOnError => _page.GetByText("First Close button on Error", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SubmissionScreenHeading => _page.GetByText("Submission Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName2 => _page.GetByText("(ExplicitName=$2)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName4 => _page.GetByText("(ExplicitName=$4)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName5 => _page.GetByText("(ExplicitName=$5)", new() { Exact = true });

    // Source modules: EQ|BOP|Submission|Main Page | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Submission|Main Page | Does this meet the current Large Account threshold? | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as LaunchToChecklistButton
    public ILocator Transmit => LaunchToChecklistButton;

    // Source modules: EQ|Common|Submission|Refer to UW | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|Submission|Refer to UW | Underwriting Rules - Agent Comments | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as ReferToUW
    public ILocator UnderwritingRulesAgentComments => ReferToUW;

}
