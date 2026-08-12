using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EditCoverageOptionNew
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EditCoverageOptionNew(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SupplementalUMUIMOptIn => EditCoverageOptionNewLocators.SupplementalUMUIMOptIn(_page);

    public Task PressSupplementalUMUIMOptInAsync(string key) => SupplementalUMUIMOptIn.PressAsync(key);

    public Task DoubleClickSupplementalUMUIMOptInAsync() => SupplementalUMUIMOptIn.DblClickAsync();

    public Task ClickSupplementalUMUIMOptInAsync() => SupplementalUMUIMOptIn.ClickAsync();

    public Task WaitForSupplementalUMUIMOptInAsync() =>
        SupplementalUMUIMOptIn.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SupplementalUMUIMCov => EditCoverageOptionNewLocators.SupplementalUMUIMCov(_page);

    public Task PressSupplementalUMUIMCovAsync(string key) => SupplementalUMUIMCov.PressAsync(key);

    public Task DoubleClickSupplementalUMUIMCovAsync() => SupplementalUMUIMCov.DblClickAsync();

    public Task ClickSupplementalUMUIMCovAsync() => SupplementalUMUIMCov.ClickAsync();

    private ILocator UMCoverage => EditCoverageOptionNewLocators.UMCoverage(_page);

    public Task PressUMCoverageAsync(string key) => UMCoverage.PressAsync(key);

    public Task DoubleClickUMCoverageAsync() => UMCoverage.DblClickAsync();

    public Task ClickUMCoverageAsync() => UMCoverage.ClickAsync();

    public Task WaitForUMCoverageAsync() =>
        UMCoverage.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator SaveAndContinue => EditCoverageOptionNewLocators.SaveAndContinue(_page);

    public Task PressSaveAndContinueAsync(string key) => SaveAndContinue.PressAsync(key);

    public Task DoubleClickSaveAndContinueAsync() => SaveAndContinue.DblClickAsync();

    public Task ClickSaveAndContinueAsync() => SaveAndContinue.ClickAsync();

}
