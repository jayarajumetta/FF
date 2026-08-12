using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPClaimsPriorInsuranceAddClaim
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPClaimsPriorInsuranceAddClaim(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ClaimsAddAndUpdateClaimsAsNeeded => EQBOPClaimsPriorInsuranceAddClaimLocators.ClaimsAddAndUpdateClaimsAsNeeded(_page);

    public Task PressClaimsAddAndUpdateClaimsAsNeededAsync(string key) => ClaimsAddAndUpdateClaimsAsNeeded.PressAsync(key);

    public Task DoubleClickClaimsAddAndUpdateClaimsAsNeededAsync() => ClaimsAddAndUpdateClaimsAsNeeded.DblClickAsync();

    public Task WaitForClaimsAddAndUpdateClaimsAsNeededAsync() =>
        ClaimsAddAndUpdateClaimsAsNeeded.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator ADDCLAIM => EQBOPClaimsPriorInsuranceAddClaimLocators.ADDCLAIM(_page);

    public Task PressADDCLAIMAsync(string key) => ADDCLAIM.PressAsync(key);

    public Task DoubleClickADDCLAIMAsync() => ADDCLAIM.DblClickAsync();

    public Task ClickADDCLAIMAsync() => ADDCLAIM.ClickAsync();

    private ILocator DateOfOccurrence => EQBOPClaimsPriorInsuranceAddClaimLocators.DateOfOccurrence(_page);

    public Task PressDateOfOccurrenceAsync(string key) => DateOfOccurrence.PressAsync(key);

    public Task DoubleClickDateOfOccurrenceAsync() => DateOfOccurrence.DblClickAsync();

    public Task SetDateOfOccurrenceAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DateOfOccurrence, _data.Resolve(value));

    public Task TypeDateOfOccurrenceAsync(string value, float delayMs = 40) =>
        DateOfOccurrence.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PolicyStart => EQBOPClaimsPriorInsuranceAddClaimLocators.PolicyStart(_page);

    public Task PressPolicyStartAsync(string key) => PolicyStart.PressAsync(key);

    public Task DoubleClickPolicyStartAsync() => PolicyStart.DblClickAsync();

    public Task SetPolicyStartAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PolicyStart, _data.Resolve(value));

    public Task TypePolicyStartAsync(string value, float delayMs = 40) =>
        PolicyStart.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PolicyExpire => EQBOPClaimsPriorInsuranceAddClaimLocators.PolicyExpire(_page);

    public Task PressPolicyExpireAsync(string key) => PolicyExpire.PressAsync(key);

    public Task DoubleClickPolicyExpireAsync() => PolicyExpire.DblClickAsync();

    public Task SetPolicyExpireAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PolicyExpire, _data.Resolve(value));

    public Task TypePolicyExpireAsync(string value, float delayMs = 40) =>
        PolicyExpire.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AmountPaid => EQBOPClaimsPriorInsuranceAddClaimLocators.AmountPaid(_page);

    public Task PressAmountPaidAsync(string key) => AmountPaid.PressAsync(key);

    public Task DoubleClickAmountPaidAsync() => AmountPaid.DblClickAsync();

    public Task SetAmountPaidAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AmountPaid, _data.Resolve(value));

    public Task TypeAmountPaidAsync(string value, float delayMs = 40) =>
        AmountPaid.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AmountReserved => EQBOPClaimsPriorInsuranceAddClaimLocators.AmountReserved(_page);

    public Task PressAmountReservedAsync(string key) => AmountReserved.PressAsync(key);

    public Task DoubleClickAmountReservedAsync() => AmountReserved.DblClickAsync();

    public Task SetAmountReservedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AmountReserved, _data.Resolve(value));

    public Task TypeAmountReservedAsync(string value, float delayMs = 40) =>
        AmountReserved.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ExpenseAmount => EQBOPClaimsPriorInsuranceAddClaimLocators.ExpenseAmount(_page);

    public Task PressExpenseAmountAsync(string key) => ExpenseAmount.PressAsync(key);

    public Task DoubleClickExpenseAmountAsync() => ExpenseAmount.DblClickAsync();

    public Task SetExpenseAmountAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ExpenseAmount, _data.Resolve(value));

    public Task TypeExpenseAmountAsync(string value, float delayMs = 40) =>
        ExpenseAmount.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TypeOfLossDropdown => EQBOPClaimsPriorInsuranceAddClaimLocators.TypeOfLossDropdown(_page);

    public Task PressTypeOfLossDropdownAsync(string key) => TypeOfLossDropdown.PressAsync(key);

    public Task DoubleClickTypeOfLossDropdownAsync() => TypeOfLossDropdown.DblClickAsync();

    public Task SetTypeOfLossDropdownAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TypeOfLossDropdown, _data.Resolve(value));

    public Task TypeTypeOfLossDropdownAsync(string value, float delayMs = 40) =>
        TypeOfLossDropdown.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TypeOfLossSelection => EQBOPClaimsPriorInsuranceAddClaimLocators.TypeOfLossSelection(_page);

    public Task PressTypeOfLossSelectionAsync(string key) => TypeOfLossSelection.PressAsync(key);

    public Task DoubleClickTypeOfLossSelectionAsync() => TypeOfLossSelection.DblClickAsync();

    public Task SetTypeOfLossSelectionAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TypeOfLossSelection, _data.Resolve(value));

    public Task TypeTypeOfLossSelectionAsync(string value, float delayMs = 40) =>
        TypeOfLossSelection.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DescriptionOfOccurrenceOrClaim => EQBOPClaimsPriorInsuranceAddClaimLocators.DescriptionOfOccurrenceOrClaim(_page);

    public Task PressDescriptionOfOccurrenceOrClaimAsync(string key) => DescriptionOfOccurrenceOrClaim.PressAsync(key);

    public Task DoubleClickDescriptionOfOccurrenceOrClaimAsync() => DescriptionOfOccurrenceOrClaim.DblClickAsync();

    public Task SetDescriptionOfOccurrenceOrClaimAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DescriptionOfOccurrenceOrClaim, _data.Resolve(value));

    public Task TypeDescriptionOfOccurrenceOrClaimAsync(string value, float delayMs = 40) =>
        DescriptionOfOccurrenceOrClaim.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OpenButton => EQBOPClaimsPriorInsuranceAddClaimLocators.OpenButton(_page);

    public Task PressOpenButtonAsync(string key) => OpenButton.PressAsync(key);

    public Task DoubleClickOpenButtonAsync() => OpenButton.DblClickAsync();

    public Task SetOpenButtonAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OpenButton, _data.Resolve(value));

    public Task TypeOpenButtonAsync(string value, float delayMs = 40) =>
        OpenButton.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Save => EQBOPClaimsPriorInsuranceAddClaimLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

    public Task ClickTypeOfLossDropdownAsync() => TypeOfLossDropdown.ClickAsync();
}
