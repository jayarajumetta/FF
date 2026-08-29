using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.Locator("a[fieldref=\"Accept\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");



    public ILocator UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    public ILocator UnderwritingInfoNavigationGeneralUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    public ILocator InsuranceScore => _page.Locator("a[fieldref=\"Insurance Score\"]");

    public ILocator InsuranceScoreConsent => _page.Locator("a[fieldref=\"Insurance Score Consent\"]");

    public ILocator UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB7_1_1-inputEl\"]");

    public ILocator UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"]");

    public ILocator UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is there a Prior Carrier?*");



    public ILocator ReferenceNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Reference Number");

    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.Locator("div[fieldref=\"The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS\"]");

    public ILocator UpdateAnswers => _page.Locator("a[fieldref=\"Update Answers\"]");
}
