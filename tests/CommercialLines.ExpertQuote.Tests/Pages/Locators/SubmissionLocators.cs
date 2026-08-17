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
    public ILocator CompleteApplication => _page.GetByText("Complete Application", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    // Source modules: EQ|BOP|Submission|Main Page | confidence=Medium score=113
    public ILocator LaunchToChecklistButton => _page.GetByRole(AriaRole.Button, new() { Name = "Launch to Checklist Button", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LoadingMessage => _page.GetByText("Loading Message", new() { Exact = true });

    // Source modules: EQ|BOP|Submission|Main Page | confidence=Medium score=78
    public ILocator NoReferralNeededVerification => _page.GetByLabel("No Referral Needed Verification", new() { Exact = true });

    // Source modules: EQ|Common|Submission|Refer to UW | confidence=Medium score=113
    public ILocator ReferToUW => _page.GetByRole(AriaRole.Button, new() { Name = "Refer to UW", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindow => _page.GetByText("stoplightWaitingWindow", new() { Exact = true });

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
    public ILocator Transmit => _page.GetByRole(AriaRole.Button, new() { Name = "Transmit", Exact = true });

    // Source modules: EQ|Common|Submission|Refer to UW | confidence=High score=127
    public ILocator UnderwritingRulesAgentComments => _page.GetByRole(AriaRole.Textbox, new() { Name = "Underwriting Rules - Agent Comments", Exact = true });

}