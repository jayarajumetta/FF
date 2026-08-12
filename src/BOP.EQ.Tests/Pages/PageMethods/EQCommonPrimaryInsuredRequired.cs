using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPrimaryInsuredRequired
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPrimaryInsuredRequired(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ExistingClient => EQCommonPrimaryInsuredRequiredLocators.ExistingClient(_page);

    public Task PressExistingClientAsync(string key) => ExistingClient.PressAsync(key);

    public Task DoubleClickExistingClientAsync() => ExistingClient.DblClickAsync();

    public Task SetExistingClientAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ExistingClient, _data.Resolve(value));

    public Task TypeExistingClientAsync(string value, float delayMs = 40) =>
        ExistingClient.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IndividualSoleProprietorOld => EQCommonPrimaryInsuredRequiredLocators.IndividualSoleProprietorOld(_page);

    public Task PressIndividualSoleProprietorOldAsync(string key) => IndividualSoleProprietorOld.PressAsync(key);

    public Task DoubleClickIndividualSoleProprietorOldAsync() => IndividualSoleProprietorOld.DblClickAsync();

    public Task ClickIndividualSoleProprietorOldAsync() => IndividualSoleProprietorOld.ClickAsync();

    private ILocator NextSFP => EQCommonPrimaryInsuredRequiredLocators.NextSFP(_page);

    public Task PressNextSFPAsync(string key) => NextSFP.PressAsync(key);

    public Task DoubleClickNextSFPAsync() => NextSFP.DblClickAsync();

    public Task ClickNextSFPAsync() => NextSFP.ClickAsync();

    private ILocator IndividualSoleProprietor => EQCommonPrimaryInsuredRequiredLocators.IndividualSoleProprietor(_page);

    public Task PressIndividualSoleProprietorAsync(string key) => IndividualSoleProprietor.PressAsync(key);

    public Task DoubleClickIndividualSoleProprietorAsync() => IndividualSoleProprietor.DblClickAsync();

    public Task SetIndividualSoleProprietorAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IndividualSoleProprietor, _data.Resolve(value));

    public Task TypeIndividualSoleProprietorAsync(string value, float delayMs = 40) =>
        IndividualSoleProprietor.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator MobilePhoneNumber => EQCommonPrimaryInsuredRequiredLocators.MobilePhoneNumber(_page);

    public Task PressMobilePhoneNumberAsync(string key) => MobilePhoneNumber.PressAsync(key);

    public Task DoubleClickMobilePhoneNumberAsync() => MobilePhoneNumber.DblClickAsync();

    public Task SetMobilePhoneNumberAsync(string value) =>
        UiActions.ApplyInputAsync(_page, MobilePhoneNumber, _data.Resolve(value));

    public Task TypeMobilePhoneNumberAsync(string value, float delayMs = 40) =>
        MobilePhoneNumber.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PrimaryPhone => EQCommonPrimaryInsuredRequiredLocators.PrimaryPhone(_page);

    public Task PressPrimaryPhoneAsync(string key) => PrimaryPhone.PressAsync(key);

    public Task DoubleClickPrimaryPhoneAsync() => PrimaryPhone.DblClickAsync();

    public Task SetPrimaryPhoneAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PrimaryPhone, _data.Resolve(value));

    public Task TypePrimaryPhoneAsync(string value, float delayMs = 40) =>
        PrimaryPhone.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Save => EQCommonPrimaryInsuredRequiredLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

    private ILocator EditGeneralInfo => EQCommonPrimaryInsuredRequiredLocators.EditGeneralInfo(_page);

    public Task PressEditGeneralInfoAsync(string key) => EditGeneralInfo.PressAsync(key);

    public Task DoubleClickEditGeneralInfoAsync() => EditGeneralInfo.DblClickAsync();

    public Task ClickEditGeneralInfoAsync() => EditGeneralInfo.ClickAsync();

    public Task ClickExistingClientAsync() => ExistingClient.ClickAsync();
}
