using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.GetByRole(AriaRole.Link, new() { Name = "Accept", Exact = true });

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator UnderwritingInfoNavigationCommercialGeneralLiabilityHistory => _page.Locator("a[onclick*='CommercialGeneralLiabilityHistory']").Filter(new LocatorFilterOptions { Visible = true }).First;

    public ILocator CommercialPropertyHistory => _page.Locator("a[onclick*='CommercialPropertyHistory']").Filter(new LocatorFilterOptions { Visible = true }).First;

    public ILocator UnderwritingInfoNavigationOtherInsuranceHistory => _page.Locator("a[onclick*='OtherInsuranceHistory']").Filter(new LocatorFilterOptions { Visible = true }).First;



    public ILocator UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='General UW Questions']/@for] | //label[normalize-space(string(.))='General UW Questions']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='General UW Questions']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator UnderwritingInfoNavigationGeneralUWQuestions => _page.Locator("a[onclick*='GeneralUWQuestionsNew']").Filter(new LocatorFilterOptions { Visible = true }).First;

    public ILocator InsuranceScore => _page.Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasText = "Insurance Score" }).First;

    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score Consent", Exact = true });

    public ILocator UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialPropertyNoPriorCarrier\"]");

    public ILocator UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialGeneralLiabilityNoPriorCarrier\"]");

    public ILocator UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialOtherNoPriorCarrier\"]").Filter(new LocatorFilterOptions { Visible = true }).First;



    public ILocator ReferenceNumber => _page.Locator("[fieldref='TierPricingOutputNonShredded.ScoreReferenceNumber']");

    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.GetByText("The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS", new() { Exact = true });

    public ILocator UpdateAnswers => _page.Locator("span.g-btn-text", new() { HasTextString = "Update Answers" }).Filter(new LocatorFilterOptions { Visible = true }).First;
}
