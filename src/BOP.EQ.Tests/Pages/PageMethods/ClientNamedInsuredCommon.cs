using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class ClientNamedInsuredCommon
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public ClientNamedInsuredCommon(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator LaunchInspire => ClientNamedInsuredCommonLocators.LaunchInspire(_page);

    public Task PressLaunchInspireAsync(string key) => LaunchInspire.PressAsync(key);

    public Task DoubleClickLaunchInspireAsync() => LaunchInspire.DblClickAsync();

    public Task ClickLaunchInspireAsync() => LaunchInspire.ClickAsync();

    public Task WaitForLaunchInspireAsync() =>
        LaunchInspire.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Client => ClientNamedInsuredCommonLocators.Client(_page);

    public Task PressClientAsync(string key) => Client.PressAsync(key);

    public Task DoubleClickClientAsync() => Client.DblClickAsync();

    public Task WaitForClientAsync() =>
        Client.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator InsuredType => ClientNamedInsuredCommonLocators.InsuredType(_page);

    public Task PressInsuredTypeAsync(string key) => InsuredType.PressAsync(key);

    public Task DoubleClickInsuredTypeAsync() => InsuredType.DblClickAsync();

    public Task SetInsuredTypeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, InsuredType, _data.Resolve(value));

    public Task TypeInsuredTypeAsync(string value, float delayMs = 40) =>
        InsuredType.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator EntityType => ClientNamedInsuredCommonLocators.EntityType(_page);

    public Task PressEntityTypeAsync(string key) => EntityType.PressAsync(key);

    public Task DoubleClickEntityTypeAsync() => EntityType.DblClickAsync();

    public Task SetEntityTypeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, EntityType, _data.Resolve(value));

    public Task TypeEntityTypeAsync(string value, float delayMs = 40) =>
        EntityType.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator YearsInBusiness => ClientNamedInsuredCommonLocators.YearsInBusiness(_page);

    public Task PressYearsInBusinessAsync(string key) => YearsInBusiness.PressAsync(key);

    public Task DoubleClickYearsInBusinessAsync() => YearsInBusiness.DblClickAsync();

    public Task SetYearsInBusinessAsync(string value) =>
        UiActions.ApplyInputAsync(_page, YearsInBusiness, _data.Resolve(value));

    public Task TypeYearsInBusinessAsync(string value, float delayMs = 40) =>
        YearsInBusiness.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyYearsInBusinessAsync(string expected) =>
        Expect(YearsInBusiness).ToContainTextAsync(_data.Resolve(expected));

    private ILocator PrimaryPhone => ClientNamedInsuredCommonLocators.PrimaryPhone(_page);

    public Task PressPrimaryPhoneAsync(string key) => PrimaryPhone.PressAsync(key);

    public Task DoubleClickPrimaryPhoneAsync() => PrimaryPhone.DblClickAsync();

    public Task SetPrimaryPhoneAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PrimaryPhone, _data.Resolve(value));

    public Task TypePrimaryPhoneAsync(string value, float delayMs = 40) =>
        PrimaryPhone.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Address1 => ClientNamedInsuredCommonLocators.Address1(_page);

    public Task PressAddress1Async(string key) => Address1.PressAsync(key);

    public Task DoubleClickAddress1Async() => Address1.DblClickAsync();

    public Task SetAddress1Async(string value) =>
        UiActions.ApplyInputAsync(_page, Address1, _data.Resolve(value));

    public Task TypeAddress1Async(string value, float delayMs = 40) =>
        Address1.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ZipCode => ClientNamedInsuredCommonLocators.ZipCode(_page);

    public Task PressZipCodeAsync(string key) => ZipCode.PressAsync(key);

    public Task DoubleClickZipCodeAsync() => ZipCode.DblClickAsync();

    public Task SetZipCodeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ZipCode, _data.Resolve(value));

    public Task TypeZipCodeAsync(string value, float delayMs = 40) =>
        ZipCode.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyZipCodeAsync(string expected) =>
        Expect(ZipCode).ToContainTextAsync(_data.Resolve(expected));

    private ILocator Address2 => ClientNamedInsuredCommonLocators.Address2(_page);

    public Task PressAddress2Async(string key) => Address2.PressAsync(key);

    public Task DoubleClickAddress2Async() => Address2.DblClickAsync();

    public Task SetAddress2Async(string value) =>
        UiActions.ApplyInputAsync(_page, Address2, _data.Resolve(value));

    public Task TypeAddress2Async(string value, float delayMs = 40) =>
        Address2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickEntityTypeAsync() => EntityType.ClickAsync();
}
