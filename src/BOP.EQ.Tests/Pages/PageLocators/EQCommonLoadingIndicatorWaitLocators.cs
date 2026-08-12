using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonLoadingIndicatorWaitLocators
{
        public static ILocator Loading(IPage page) =>
        page.GetByText("Loading ...", new() { Exact = true });

}
