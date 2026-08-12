using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class TransACTTransACTDetailPopup
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public TransACTTransACTDetailPopup(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IFRAME => TransACTTransACTDetailPopupLocators.IFRAME(_page);

    public Task PressIFRAMEAsync(string key) => IFRAME.PressAsync(key);

    public Task DoubleClickIFRAMEAsync() => IFRAME.DblClickAsync();

    public Task WaitForIFRAMEAsync() =>
        IFRAME.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
