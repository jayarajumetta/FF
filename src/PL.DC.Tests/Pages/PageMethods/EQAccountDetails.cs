using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAccountDetails
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAccountDetails(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LblMaritalStatus => EQAccountDetailsLocators.LblMaritalStatus(_page);

    public Task PressLblMaritalStatusAsync(string key) => LblMaritalStatus.PressAsync(key);

    public Task DoubleClickLblMaritalStatusAsync() => LblMaritalStatus.DblClickAsync();

    public Task VerifyLblMaritalStatusAsync(string expected) =>
        Expect(LblMaritalStatus).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForLblMaritalStatusAsync() =>
        LblMaritalStatus.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator LblIsTheAccountAddressAlsoWhereTheClientResides => EQAccountDetailsLocators.LblIsTheAccountAddressAlsoWhereTheClientResides(_page);

    public Task PressLblIsTheAccountAddressAlsoWhereTheClientResidesAsync(string key) => LblIsTheAccountAddressAlsoWhereTheClientResides.PressAsync(key);

    public Task DoubleClickLblIsTheAccountAddressAlsoWhereTheClientResidesAsync() => LblIsTheAccountAddressAlsoWhereTheClientResides.DblClickAsync();

    public Task VerifyLblIsTheAccountAddressAlsoWhereTheClientResidesAsync(string expected) =>
        Expect(LblIsTheAccountAddressAlsoWhereTheClientResides).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForLblIsTheAccountAddressAlsoWhereTheClientResidesAsync() =>
        LblIsTheAccountAddressAlsoWhereTheClientResides.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator TxtFirstNameAccountOwner => EQAccountDetailsLocators.TxtFirstNameAccountOwner(_page);

    public Task PressTxtFirstNameAccountOwnerAsync(string key) => TxtFirstNameAccountOwner.PressAsync(key);

    public Task DoubleClickTxtFirstNameAccountOwnerAsync() => TxtFirstNameAccountOwner.DblClickAsync();

    public Task VerifyTxtFirstNameAccountOwnerAsync(string expected) =>
        Expect(TxtFirstNameAccountOwner).ToContainTextAsync(_data.Resolve(expected));

    private ILocator TxtBestPhoneAccountOwner => EQAccountDetailsLocators.TxtBestPhoneAccountOwner(_page);

    public Task PressTxtBestPhoneAccountOwnerAsync(string key) => TxtBestPhoneAccountOwner.PressAsync(key);

    public Task DoubleClickTxtBestPhoneAccountOwnerAsync() => TxtBestPhoneAccountOwner.DblClickAsync();

    public Task SetTxtBestPhoneAccountOwnerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtBestPhoneAccountOwner, _data.Resolve(value));

    public Task TypeTxtBestPhoneAccountOwnerAsync(string value, float delayMs = 40) =>
        TxtBestPhoneAccountOwner.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtEmailAccountOwner => EQAccountDetailsLocators.TxtEmailAccountOwner(_page);

    public Task PressTxtEmailAccountOwnerAsync(string key) => TxtEmailAccountOwner.PressAsync(key);

    public Task DoubleClickTxtEmailAccountOwnerAsync() => TxtEmailAccountOwner.DblClickAsync();

    public Task SetTxtEmailAccountOwnerAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtEmailAccountOwner, _data.Resolve(value));

    public Task TypeTxtEmailAccountOwnerAsync(string value, float delayMs = 40) =>
        TxtEmailAccountOwner.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnSingle => EQAccountDetailsLocators.BtnSingle(_page);

    public Task PressBtnSingleAsync(string key) => BtnSingle.PressAsync(key);

    public Task DoubleClickBtnSingleAsync() => BtnSingle.DblClickAsync();

    public Task SetBtnSingleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnSingle, _data.Resolve(value));

    public Task TypeBtnSingleAsync(string value, float delayMs = 40) =>
        BtnSingle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnMarried => EQAccountDetailsLocators.BtnMarried(_page);

    public Task PressBtnMarriedAsync(string key) => BtnMarried.PressAsync(key);

    public Task DoubleClickBtnMarriedAsync() => BtnMarried.DblClickAsync();

    public Task SetBtnMarriedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnMarried, _data.Resolve(value));

    public Task TypeBtnMarriedAsync(string value, float delayMs = 40) =>
        BtnMarried.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnDivorced => EQAccountDetailsLocators.BtnDivorced(_page);

    public Task PressBtnDivorcedAsync(string key) => BtnDivorced.PressAsync(key);

    public Task DoubleClickBtnDivorcedAsync() => BtnDivorced.DblClickAsync();

    public Task SetBtnDivorcedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnDivorced, _data.Resolve(value));

    public Task TypeBtnDivorcedAsync(string value, float delayMs = 40) =>
        BtnDivorced.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtOwnerAddressLine2 => EQAccountDetailsLocators.TxtOwnerAddressLine2(_page);

    public Task PressTxtOwnerAddressLine2Async(string key) => TxtOwnerAddressLine2.PressAsync(key);

    public Task DoubleClickTxtOwnerAddressLine2Async() => TxtOwnerAddressLine2.DblClickAsync();

    public Task SetTxtOwnerAddressLine2Async(string value) =>
        UiActions.ApplyInputAsync(_page, TxtOwnerAddressLine2, _data.Resolve(value));

    public Task TypeTxtOwnerAddressLine2Async(string value, float delayMs = 40) =>
        TxtOwnerAddressLine2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtOwnerAddressCityNew => EQAccountDetailsLocators.TxtOwnerAddressCityNew(_page);

    public Task PressTxtOwnerAddressCityNewAsync(string key) => TxtOwnerAddressCityNew.PressAsync(key);

    public Task DoubleClickTxtOwnerAddressCityNewAsync() => TxtOwnerAddressCityNew.DblClickAsync();

    public Task SetTxtOwnerAddressCityNewAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtOwnerAddressCityNew, _data.Resolve(value));

    public Task TypeTxtOwnerAddressCityNewAsync(string value, float delayMs = 40) =>
        TxtOwnerAddressCityNew.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DrpdwnState => EQAccountDetailsLocators.DrpdwnState(_page);

    public Task PressDrpdwnStateAsync(string key) => DrpdwnState.PressAsync(key);

    public Task DoubleClickDrpdwnStateAsync() => DrpdwnState.DblClickAsync();

    public Task SetDrpdwnStateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DrpdwnState, _data.Resolve(value));

    public Task TypeDrpdwnStateAsync(string value, float delayMs = 40) =>
        DrpdwnState.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateName => EQAccountDetailsLocators.StateName(_page);

    public Task PressStateNameAsync(string key) => StateName.PressAsync(key);

    public Task DoubleClickStateNameAsync() => StateName.DblClickAsync();

    public Task SetStateNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateName, _data.Resolve(value));

    public Task TypeStateNameAsync(string value, float delayMs = 40) =>
        StateName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TxtOwnerAddressZip => EQAccountDetailsLocators.TxtOwnerAddressZip(_page);

    public Task PressTxtOwnerAddressZipAsync(string key) => TxtOwnerAddressZip.PressAsync(key);

    public Task DoubleClickTxtOwnerAddressZipAsync() => TxtOwnerAddressZip.DblClickAsync();

    public Task SetTxtOwnerAddressZipAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TxtOwnerAddressZip, _data.Resolve(value));

    public Task TypeTxtOwnerAddressZipAsync(string value, float delayMs = 40) =>
        TxtOwnerAddressZip.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Satellite => EQAccountDetailsLocators.Satellite(_page);

    public Task PressSatelliteAsync(string key) => Satellite.PressAsync(key);

    public Task DoubleClickSatelliteAsync() => Satellite.DblClickAsync();

    public Task WaitForSatelliteAsync() =>
        Satellite.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BtnNext => EQAccountDetailsLocators.BtnNext(_page);

    public Task PressBtnNextAsync(string key) => BtnNext.PressAsync(key);

    public Task DoubleClickBtnNextAsync() => BtnNext.DblClickAsync();

    public Task ClickBtnNextAsync() => BtnNext.ClickAsync();

    private ILocator BtnYesAtLeast90Days => EQAccountDetailsLocators.BtnYesAtLeast90Days(_page);

    public Task PressBtnYesAtLeast90DaysAsync(string key) => BtnYesAtLeast90Days.PressAsync(key);

    public Task DoubleClickBtnYesAtLeast90DaysAsync() => BtnYesAtLeast90Days.DblClickAsync();

    public Task SetBtnYesAtLeast90DaysAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnYesAtLeast90Days, _data.Resolve(value));

    public Task TypeBtnYesAtLeast90DaysAsync(string value, float delayMs = 40) =>
        BtnYesAtLeast90Days.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BtnYesClientResides => EQAccountDetailsLocators.BtnYesClientResides(_page);

    public Task PressBtnYesClientResidesAsync(string key) => BtnYesClientResides.PressAsync(key);

    public Task DoubleClickBtnYesClientResidesAsync() => BtnYesClientResides.DblClickAsync();

    public Task SetBtnYesClientResidesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BtnYesClientResides, _data.Resolve(value));

    public Task TypeBtnYesClientResidesAsync(string value, float delayMs = 40) =>
        BtnYesClientResides.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickBtnDivorcedAsync() => BtnDivorced.ClickAsync();

    public Task ClickBtnMarriedAsync() => BtnMarried.ClickAsync();

    public Task ClickBtnSingleAsync() => BtnSingle.ClickAsync();

    public Task ClickBtnYesAtLeast90DaysAsync() => BtnYesAtLeast90Days.ClickAsync();

    public Task ClickBtnYesClientResidesAsync() => BtnYesClientResides.ClickAsync();

    public Task ClickDrpdwnStateAsync() => DrpdwnState.ClickAsync();
}
