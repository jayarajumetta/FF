using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class ClientOtherInsuredInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public ClientOtherInsuredInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator WebsiteAddress => ClientOtherInsuredInfoLocators.WebsiteAddress(_page);

    public Task PressWebsiteAddressAsync(string key) => WebsiteAddress.PressAsync(key);

    public Task DoubleClickWebsiteAddressAsync() => WebsiteAddress.DblClickAsync();

    public Task SetWebsiteAddressAsync(string value) =>
        UiActions.ApplyInputAsync(_page, WebsiteAddress, _data.Resolve(value));

    public Task TypeWebsiteAddressAsync(string value, float delayMs = 40) =>
        WebsiteAddress.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NameOfAuditContact => ClientOtherInsuredInfoLocators.NameOfAuditContact(_page);

    public Task PressNameOfAuditContactAsync(string key) => NameOfAuditContact.PressAsync(key);

    public Task DoubleClickNameOfAuditContactAsync() => NameOfAuditContact.DblClickAsync();

    public Task SetNameOfAuditContactAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NameOfAuditContact, _data.Resolve(value));

    public Task TypeNameOfAuditContactAsync(string value, float delayMs = 40) =>
        NameOfAuditContact.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AuditTelephone => ClientOtherInsuredInfoLocators.AuditTelephone(_page);

    public Task PressAuditTelephoneAsync(string key) => AuditTelephone.PressAsync(key);

    public Task DoubleClickAuditTelephoneAsync() => AuditTelephone.DblClickAsync();

    public Task SetAuditTelephoneAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AuditTelephone, _data.Resolve(value));

    public Task TypeAuditTelephoneAsync(string value, float delayMs = 40) =>
        AuditTelephone.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NameOfInspectionContact => ClientOtherInsuredInfoLocators.NameOfInspectionContact(_page);

    public Task PressNameOfInspectionContactAsync(string key) => NameOfInspectionContact.PressAsync(key);

    public Task DoubleClickNameOfInspectionContactAsync() => NameOfInspectionContact.DblClickAsync();

    public Task SetNameOfInspectionContactAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NameOfInspectionContact, _data.Resolve(value));

    public Task TypeNameOfInspectionContactAsync(string value, float delayMs = 40) =>
        NameOfInspectionContact.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyNameOfInspectionContactAsync(string expected) =>
        Expect(NameOfInspectionContact).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForNameOfInspectionContactAsync() =>
        NameOfInspectionContact.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator InspectionTelephone => ClientOtherInsuredInfoLocators.InspectionTelephone(_page);

    public Task PressInspectionTelephoneAsync(string key) => InspectionTelephone.PressAsync(key);

    public Task DoubleClickInspectionTelephoneAsync() => InspectionTelephone.DblClickAsync();

    public Task SetInspectionTelephoneAsync(string value) =>
        UiActions.ApplyInputAsync(_page, InspectionTelephone, _data.Resolve(value));

    public Task TypeInspectionTelephoneAsync(string value, float delayMs = 40) =>
        InspectionTelephone.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator InsuredEMailAddress => ClientOtherInsuredInfoLocators.InsuredEMailAddress(_page);

    public Task PressInsuredEMailAddressAsync(string key) => InsuredEMailAddress.PressAsync(key);

    public Task DoubleClickInsuredEMailAddressAsync() => InsuredEMailAddress.DblClickAsync();

    public Task SetInsuredEMailAddressAsync(string value) =>
        UiActions.ApplyInputAsync(_page, InsuredEMailAddress, _data.Resolve(value));

    public Task TypeInsuredEMailAddressAsync(string value, float delayMs = 40) =>
        InsuredEMailAddress.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

}
