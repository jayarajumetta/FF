using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonTransactVerifyDCPremiumLocators
{
        public static ILocator PolicyNumber(IPage page) =>
        page.Locator("id=activeAccountReferenceId");

}
