using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

    public ILocator UnderwritingInfoCommercialPropertyHistoryCommercialGeneralLiabilityHistory => _page.Locator("[id=\"pageTitle\"]");

    public ILocator UnderwritingInfoNavigationCommercialGeneralLiabilityHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial General Liability History", Exact = true });

    public ILocator CommercialPropertyHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Property History", Exact = true });

    public ILocator UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    public ILocator UnderwritingInfoNavigationGeneralUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score", Exact = true });

    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score Consent", Exact = true });

    public ILocator UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB7_1_1-inputEl\"]");

    public ILocator UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"]");

    public ILocator UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    public ILocator UnderwritingInfoOtherInsuranceHistoryOtherInsuranceHistory => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Other Insurance History");

    public ILocator UnderwritingInfoNavigationOtherInsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Other Insurance History", Exact = true });

    public ILocator ReferenceNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Reference Number");

    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS");

    public ILocator UpdateAnswers => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a0a4-7d37-fbe634036887");
}
