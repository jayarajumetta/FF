using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQClaimsViolationNEW
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQClaimsViolationNEW(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ClaimDriverNotInHousehold => EQClaimsViolationNEWLocators.ClaimDriverNotInHousehold(_page);

    public Task PressClaimDriverNotInHouseholdAsync(string key) => ClaimDriverNotInHousehold.PressAsync(key);

    public Task DoubleClickClaimDriverNotInHouseholdAsync() => ClaimDriverNotInHousehold.DblClickAsync();

    public Task SetClaimDriverNotInHouseholdAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ClaimDriverNotInHousehold, _data.Resolve(value));

    public Task TypeClaimDriverNotInHouseholdAsync(string value, float delayMs = 40) =>
        ClaimDriverNotInHousehold.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyClaimDriverNotInHouseholdAsync(string expected) =>
        Expect(ClaimDriverNotInHousehold).ToContainTextAsync(_data.Resolve(expected));

    private ILocator ClaimViolationDoesNotApply => EQClaimsViolationNEWLocators.ClaimViolationDoesNotApply(_page);

    public Task PressClaimViolationDoesNotApplyAsync(string key) => ClaimViolationDoesNotApply.PressAsync(key);

    public Task DoubleClickClaimViolationDoesNotApplyAsync() => ClaimViolationDoesNotApply.DblClickAsync();

    public Task ClickClaimViolationDoesNotApplyAsync() => ClaimViolationDoesNotApply.ClickAsync();

    private ILocator ClaimViolationSaveAndContinue => EQClaimsViolationNEWLocators.ClaimViolationSaveAndContinue(_page);

    public Task PressClaimViolationSaveAndContinueAsync(string key) => ClaimViolationSaveAndContinue.PressAsync(key);

    public Task DoubleClickClaimViolationSaveAndContinueAsync() => ClaimViolationSaveAndContinue.DblClickAsync();

    public Task ClickClaimViolationSaveAndContinueAsync() => ClaimViolationSaveAndContinue.ClickAsync();

    private ILocator ComboBox => EQClaimsViolationNEWLocators.ComboBox(_page);

    public Task PressComboBoxAsync(string key) => ComboBox.PressAsync(key);

    public Task DoubleClickComboBoxAsync() => ComboBox.DblClickAsync();

    public Task SetComboBoxAsync(string value) =>
        ComboBox.SelectOptionAsync(_data.Resolve(value));

    private ILocator CONTINUEDoesnTApply => EQClaimsViolationNEWLocators.CONTINUEDoesnTApply(_page);

    public Task PressCONTINUEDoesnTApplyAsync(string key) => CONTINUEDoesnTApply.PressAsync(key);

    public Task DoubleClickCONTINUEDoesnTApplyAsync() => CONTINUEDoesnTApply.DblClickAsync();

    public Task ClickCONTINUEDoesnTApplyAsync() => CONTINUEDoesnTApply.ClickAsync();

    public Task VerifyCONTINUEDoesnTApplyAsync(string expected) =>
        Expect(CONTINUEDoesnTApply).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Next => EQClaimsViolationNEWLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

}
