using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ApplicationPage
{
    private readonly IPage _page;
    public ApplicationPage(InsuranceAutomation.Core.BrowserSession browser, InsuranceAutomation.Core.UiActions ui) => _page = browser.Page;
    public Task NavigateAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Application URL is required.", nameof(url));
        return _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
    }
}
