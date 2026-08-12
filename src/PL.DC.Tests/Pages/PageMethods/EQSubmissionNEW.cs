using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQSubmissionNEW
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQSubmissionNEW(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator CorrectionNeededStep1 => EQSubmissionNEWLocators.CorrectionNeededStep1(_page);

    public Task PressCorrectionNeededStep1Async(string key) => CorrectionNeededStep1.PressAsync(key);

    public Task DoubleClickCorrectionNeededStep1Async() => CorrectionNeededStep1.DblClickAsync();

    public Task VerifyCorrectionNeededStep1Async(string expected) =>
        Expect(CorrectionNeededStep1).ToContainTextAsync(_data.Resolve(expected));

    private ILocator SaveExit1 => EQSubmissionNEWLocators.SaveExit1(_page);

    public Task PressSaveExit1Async(string key) => SaveExit1.PressAsync(key);

    public Task DoubleClickSaveExit1Async() => SaveExit1.DblClickAsync();

    public Task ClickSaveExit1Async() => SaveExit1.ClickAsync();

    private ILocator ReferUW => EQSubmissionNEWLocators.ReferUW(_page);

    public Task PressReferUWAsync(string key) => ReferUW.PressAsync(key);

    public Task DoubleClickReferUWAsync() => ReferUW.DblClickAsync();

    public Task ClickReferUWAsync() => ReferUW.ClickAsync();

    public Task VerifyReferUWAsync(string expected) =>
        Expect(ReferUW).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Checklist1 => EQSubmissionNEWLocators.Checklist1(_page);

    public Task PressChecklist1Async(string key) => Checklist1.PressAsync(key);

    public Task DoubleClickChecklist1Async() => Checklist1.DblClickAsync();

    public Task ClickChecklist1Async() => Checklist1.ClickAsync();

    public Task VerifyChecklist1Async(string expected) =>
        Expect(Checklist1).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Transmit => EQSubmissionNEWLocators.Transmit(_page);

    public Task PressTransmitAsync(string key) => Transmit.PressAsync(key);

    public Task DoubleClickTransmitAsync() => Transmit.DblClickAsync();

    public Task ClickTransmitAsync() => Transmit.ClickAsync();

    public Task WaitForTransmitAsync() =>
        Transmit.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
