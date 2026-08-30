using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class SubmissionLocators
{
    private readonly IPage _page;
    public SubmissionLocators(IPage page) => _page = page;

    public ILocator AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "All required fields have not been completed. Please complete highlighted tabs.");

    public ILocator CompleteApplication => _page.GetByRole(AriaRole.Link, new() { Name = "Complete Application", Exact = true });

    public ILocator IsThisCoverageBound => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is this coverage bound?*");

    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    public ILocator StoplightWaitingWindow => _page.Locator("[id=\"stoplightWaitingWindow\"]");

    public ILocator StoplightWaitingWindowClose => _page.GetByText("Close", new() { Exact = true });

    public ILocator StoplightWaitingWindowError => _page.GetByText("Error:", new() { Exact = true });

    public ILocator StoplightWaitingWindowFirstCloseButtonOnError => _page.GetByText("First Close button on Error", new() { Exact = true });

    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");
}
