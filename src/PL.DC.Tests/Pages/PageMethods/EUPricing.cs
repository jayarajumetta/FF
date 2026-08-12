using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EUPricing
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EUPricing(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator TxtUnderwritingNotes => EUPricingLocators.TxtUnderwritingNotes(_page);

    public Task PressTxtUnderwritingNotesAsync(string key) => TxtUnderwritingNotes.PressAsync(key);

    public Task DoubleClickTxtUnderwritingNotesAsync() => TxtUnderwritingNotes.DblClickAsync();

    public Task SetTxtUnderwritingNotesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtUnderwritingNotes, _data.Resolve(value));

    public Task TypeTxtUnderwritingNotesAsync(string value, float delayMs = 40) =>
        TxtUnderwritingNotes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForTxtUnderwritingNotesAsync() =>
        TxtUnderwritingNotes.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnApprove => EUPricingLocators.BtnApprove(_page);

    public Task PressBtnApproveAsync(string key) => BtnApprove.PressAsync(key);

    public Task DoubleClickBtnApproveAsync() => BtnApprove.DblClickAsync();

    public Task ClickBtnApproveAsync() => BtnApprove.ClickAsync();

    public Task WaitForBtnApproveAsync() =>
        BtnApprove.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LnkHome => EUPricingLocators.LnkHome(_page);

    public Task PressLnkHomeAsync(string key) => LnkHome.PressAsync(key);

    public Task DoubleClickLnkHomeAsync() => LnkHome.DblClickAsync();

    public Task ClickLnkHomeAsync() => LnkHome.ClickAsync();

}
