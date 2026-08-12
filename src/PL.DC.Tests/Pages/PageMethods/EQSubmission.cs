using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQSubmission
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQSubmission(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LblValueTotalPolicyPremium => EQSubmissionLocators.LblValueTotalPolicyPremium(_page);

    public Task PressLblValueTotalPolicyPremiumAsync(string key) => LblValueTotalPolicyPremium.PressAsync(key);

    public Task DoubleClickLblValueTotalPolicyPremiumAsync() => LblValueTotalPolicyPremium.DblClickAsync();

    public async Task StoreLblValueTotalPolicyPremiumAsync(string key)
    {
        var value = await LblValueTotalPolicyPremium.TextContentAsync() ?? await LblValueTotalPolicyPremium.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator LblValueEffectiveDate => EQSubmissionLocators.LblValueEffectiveDate(_page);

    public Task PressLblValueEffectiveDateAsync(string key) => LblValueEffectiveDate.PressAsync(key);

    public Task DoubleClickLblValueEffectiveDateAsync() => LblValueEffectiveDate.DblClickAsync();

    public async Task StoreLblValueEffectiveDateAsync(string key)
    {
        var value = await LblValueEffectiveDate.TextContentAsync() ?? await LblValueEffectiveDate.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator LblValuePolicyNumber => EQSubmissionLocators.LblValuePolicyNumber(_page);

    public Task PressLblValuePolicyNumberAsync(string key) => LblValuePolicyNumber.PressAsync(key);

    public Task DoubleClickLblValuePolicyNumberAsync() => LblValuePolicyNumber.DblClickAsync();

    public async Task StoreLblValuePolicyNumberAsync(string key)
    {
        var value = await LblValuePolicyNumber.TextContentAsync() ?? await LblValuePolicyNumber.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator LblValueChecklistId => EQSubmissionLocators.LblValueChecklistId(_page);

    public Task PressLblValueChecklistIdAsync(string key) => LblValueChecklistId.PressAsync(key);

    public Task DoubleClickLblValueChecklistIdAsync() => LblValueChecklistId.DblClickAsync();

    public async Task StoreLblValueChecklistIdAsync(string key)
    {
        var value = await LblValueChecklistId.TextContentAsync() ?? await LblValueChecklistId.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator BtnSaveAndExit => EQSubmissionLocators.BtnSaveAndExit(_page);

    public Task PressBtnSaveAndExitAsync(string key) => BtnSaveAndExit.PressAsync(key);

    public Task DoubleClickBtnSaveAndExitAsync() => BtnSaveAndExit.DblClickAsync();

    public Task ClickBtnSaveAndExitAsync() => BtnSaveAndExit.ClickAsync();

}
