using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.GetByRole(AriaRole.Link, new() { Name = "Accept", Exact = true });

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");



    public ILocator UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    public ILocator UnderwritingInfoNavigationGeneralUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score", Exact = true });

    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score Consent", Exact = true });

    public ILocator UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Underwriting Info Commercial Property History Is There APrior Carrier");

    public ILocator UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Underwriting Info Commercial General Liability History Is There APrior Carrier");

    public ILocator UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is there a Prior Carrier?*");



    public ILocator ReferenceNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Reference Number");

    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.GetByText("The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS", new() { Exact = true });

    public ILocator UpdateAnswers => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });
}
