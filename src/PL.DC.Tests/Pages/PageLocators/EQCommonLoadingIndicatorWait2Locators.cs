using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonLoadingIndicatorWait2Locators
{
        public static ILocator Loading(IPage page) =>
        page.GetByText("Loading ...", new() { Exact = true });

}
