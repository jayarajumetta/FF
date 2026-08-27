using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    // Source modules: Submission|Complete Application & Stoplight Functionality | confidence=Review score=97
    public ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "All required fields have not been completed. Please complete highlighted tabs.");

    // Source modules: Submission|Complete Application & Stoplight Functionality | confidence=High score=125
    public ILocator CompleteApplication => _page.GetByRole(AriaRole.Button, new() { Name = "Complete Application", Exact = true });

    // Source modules: Submission|Required and Optional Fields | confidence=Medium score=113
    public ILocator IsThisCoverageBound => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is this coverage bound?*", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    // Source modules: Submission|Complete Application & Stoplight Functionality | confidence=High score=97
    public ILocator StoplightWaitingWindow => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "stoplightWaitingWindow");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindowClose => _page.GetByText("Close", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindowError => _page.GetByText("Error:", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator StoplightWaitingWindowFirstCloseButtonOnError => _page.GetByText("First Close button on Error", new() { Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

}
