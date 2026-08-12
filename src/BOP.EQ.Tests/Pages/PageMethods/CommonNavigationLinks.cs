using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class CommonNavigationLinks
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public CommonNavigationLinks(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Submission => CommonNavigationLinksLocators.Submission(_page);

    public Task PressSubmissionAsync(string key) => Submission.PressAsync(key);

    public Task DoubleClickSubmissionAsync() => Submission.DblClickAsync();

    public Task ClickSubmissionAsync() => Submission.ClickAsync();

    public Task WaitForSubmissionAsync() =>
        Submission.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SaveForLater => CommonNavigationLinksLocators.SaveForLater(_page);

    public Task PressSaveForLaterAsync(string key) => SaveForLater.PressAsync(key);

    public Task DoubleClickSaveForLaterAsync() => SaveForLater.DblClickAsync();

    public Task ClickSaveForLaterAsync() => SaveForLater.ClickAsync();

    public Task VerifySaveForLaterAsync(string expected) =>
        Expect(SaveForLater).ToContainTextAsync(_data.Resolve(expected));

    private ILocator ReturnToAdmin => CommonNavigationLinksLocators.ReturnToAdmin(_page);

    public Task PressReturnToAdminAsync(string key) => ReturnToAdmin.PressAsync(key);

    public Task DoubleClickReturnToAdminAsync() => ReturnToAdmin.DblClickAsync();

    public Task ClickReturnToAdminAsync() => ReturnToAdmin.ClickAsync();

    public Task VerifyReturnToAdminAsync(string expected) =>
        Expect(ReturnToAdmin).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForReturnToAdminAsync() =>
        ReturnToAdmin.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Billing => CommonNavigationLinksLocators.Billing(_page);

    public Task PressBillingAsync(string key) => Billing.PressAsync(key);

    public Task DoubleClickBillingAsync() => Billing.DblClickAsync();

    public Task ClickBillingAsync() => Billing.ClickAsync();

    public Task WaitForBillingAsync() =>
        Billing.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator NewQuote => CommonNavigationLinksLocators.NewQuote(_page);

    public Task PressNewQuoteAsync(string key) => NewQuote.PressAsync(key);

    public Task DoubleClickNewQuoteAsync() => NewQuote.DblClickAsync();

    public Task ClickNewQuoteAsync() => NewQuote.ClickAsync();

    private ILocator UnderwritingInfo => CommonNavigationLinksLocators.UnderwritingInfo(_page);

    public Task PressUnderwritingInfoAsync(string key) => UnderwritingInfo.PressAsync(key);

    public Task DoubleClickUnderwritingInfoAsync() => UnderwritingInfo.DblClickAsync();

    public Task ClickUnderwritingInfoAsync() => UnderwritingInfo.ClickAsync();

    public Task WaitForUnderwritingInfoAsync() =>
        UnderwritingInfo.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ReturnToQuote => CommonNavigationLinksLocators.ReturnToQuote(_page);

    public Task PressReturnToQuoteAsync(string key) => ReturnToQuote.PressAsync(key);

    public Task DoubleClickReturnToQuoteAsync() => ReturnToQuote.DblClickAsync();

    public Task ClickReturnToQuoteAsync() => ReturnToQuote.ClickAsync();

    private ILocator PolicyInfo => CommonNavigationLinksLocators.PolicyInfo(_page);

    public Task PressPolicyInfoAsync(string key) => PolicyInfo.PressAsync(key);

    public Task DoubleClickPolicyInfoAsync() => PolicyInfo.DblClickAsync();

    public Task ClickPolicyInfoAsync() => PolicyInfo.ClickAsync();

    private ILocator Notepad => CommonNavigationLinksLocators.Notepad(_page);

    public Task PressNotepadAsync(string key) => Notepad.PressAsync(key);

    public Task DoubleClickNotepadAsync() => Notepad.DblClickAsync();

    public Task ClickNotepadAsync() => Notepad.ClickAsync();

    private ILocator ReturnToPolicy => CommonNavigationLinksLocators.ReturnToPolicy(_page);

    public Task PressReturnToPolicyAsync(string key) => ReturnToPolicy.PressAsync(key);

    public Task DoubleClickReturnToPolicyAsync() => ReturnToPolicy.DblClickAsync();

    public Task ClickReturnToPolicyAsync() => ReturnToPolicy.ClickAsync();

}
