using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.GetByRole(AriaRole.Link, new() { Name = "Accept", Exact = true });

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");



    public ILocator UnderwritingInfoGeneralUWQuestionsGeneralUWQuestions => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='General UW Questions']/@for] | //label[normalize-space(string(.))='General UW Questions']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='General UW Questions']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator UnderwritingInfoNavigationGeneralUWQuestions => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score", Exact = true });

    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score Consent", Exact = true });

    public ILocator UnderwritingInfoCommercialPropertyHistoryIsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialPropertyNoPriorCarrier\"]");

    public ILocator UnderwritingInfoCommercialGeneralLiabilityHistoryIsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialGeneralLiabilityNoPriorCarrier\"]");

    public ILocator UnderwritingInfoOtherInsuranceHistoryIsThereAPriorCarrier => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Is there a Prior Carrier?*']/@for] | //label[normalize-space(string(.))='Is there a Prior Carrier?*']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Is there a Prior Carrier?*']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");



    public ILocator ReferenceNumber => _page.Locator("xpath=(//*[@id = //label[normalize-space(string(.))='Reference Number']/@for] | //label[normalize-space(string(.))='Reference Number']//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1] | //label[normalize-space(string(.))='Reference Number']/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])");

    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.GetByText("The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS", new() { Exact = true });

    public ILocator UpdateAnswers => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });
}
