using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonAccountDetailsAccountInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonAccountDetailsAccountInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AccountInformationHeader => EQCommonAccountDetailsAccountInfoLocators.AccountInformationHeader(_page);

    public Task PressAccountInformationHeaderAsync(string key) => AccountInformationHeader.PressAsync(key);

    public Task DoubleClickAccountInformationHeaderAsync() => AccountInformationHeader.DblClickAsync();

    public Task WaitForAccountInformationHeaderAsync() =>
        AccountInformationHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator OwnerMiddleName => EQCommonAccountDetailsAccountInfoLocators.OwnerMiddleName(_page);

    public Task PressOwnerMiddleNameAsync(string key) => OwnerMiddleName.PressAsync(key);

    public Task DoubleClickOwnerMiddleNameAsync() => OwnerMiddleName.DblClickAsync();

    public Task SetOwnerMiddleNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OwnerMiddleName, _data.Resolve(value));

    public Task TypeOwnerMiddleNameAsync(string value, float delayMs = 40) =>
        OwnerMiddleName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OwnerPhone => EQCommonAccountDetailsAccountInfoLocators.OwnerPhone(_page);

    public Task PressOwnerPhoneAsync(string key) => OwnerPhone.PressAsync(key);

    public Task DoubleClickOwnerPhoneAsync() => OwnerPhone.DblClickAsync();

    public Task SetOwnerPhoneAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OwnerPhone, _data.Resolve(value));

    public Task TypeOwnerPhoneAsync(string value, float delayMs = 40) =>
        OwnerPhone.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OwnerEmail => EQCommonAccountDetailsAccountInfoLocators.OwnerEmail(_page);

    public Task PressOwnerEmailAsync(string key) => OwnerEmail.PressAsync(key);

    public Task DoubleClickOwnerEmailAsync() => OwnerEmail.DblClickAsync();

    public Task SetOwnerEmailAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OwnerEmail, _data.Resolve(value));

    public Task TypeOwnerEmailAsync(string value, float delayMs = 40) =>
        OwnerEmail.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Married => EQCommonAccountDetailsAccountInfoLocators.Married(_page);

    public Task PressMarriedAsync(string key) => Married.PressAsync(key);

    public Task DoubleClickMarriedAsync() => Married.DblClickAsync();

    public Task SetMarriedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Married, _data.Resolve(value));

    public Task TypeMarriedAsync(string value, float delayMs = 40) =>
        Married.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StreetAddress => EQCommonAccountDetailsAccountInfoLocators.StreetAddress(_page);

    public Task PressStreetAddressAsync(string key) => StreetAddress.PressAsync(key);

    public Task DoubleClickStreetAddressAsync() => StreetAddress.DblClickAsync();

    public Task SetStreetAddressAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StreetAddress, _data.Resolve(value));

    public Task TypeStreetAddressAsync(string value, float delayMs = 40) =>
        StreetAddress.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Address2 => EQCommonAccountDetailsAccountInfoLocators.Address2(_page);

    public Task PressAddress2Async(string key) => Address2.PressAsync(key);

    public Task DoubleClickAddress2Async() => Address2.DblClickAsync();

    public Task SetAddress2Async(string value) =>
        UiActions.ApplyInputAsync(_page, Address2, _data.Resolve(value));

    public Task TypeAddress2Async(string value, float delayMs = 40) =>
        Address2.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator City => EQCommonAccountDetailsAccountInfoLocators.City(_page);

    public Task PressCityAsync(string key) => City.PressAsync(key);

    public Task DoubleClickCityAsync() => City.DblClickAsync();

    public Task SetCityAsync(string value) =>
        UiActions.ApplyInputAsync(_page, City, _data.Resolve(value));

    public Task TypeCityAsync(string value, float delayMs = 40) =>
        City.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateDropdown => EQCommonAccountDetailsAccountInfoLocators.StateDropdown(_page);

    public Task SelectStateAsync(string value) =>
        UiActions.SelectFromOverlayAsync(_page, StateDropdown, _data.Resolve(value));

    public Task PressStateDropdownAsync(string key) => StateDropdown.PressAsync(key);

    public Task DoubleClickStateDropdownAsync() => StateDropdown.DblClickAsync();

    public Task SetStateDropdownAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateDropdown, _data.Resolve(value));

    public Task TypeStateDropdownAsync(string value, float delayMs = 40) =>
        StateDropdown.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateName => EQCommonAccountDetailsAccountInfoLocators.StateName(_page);

    public Task PressStateNameAsync(string key) => StateName.PressAsync(key);

    public Task DoubleClickStateNameAsync() => StateName.DblClickAsync();

    public Task SetStateNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateName, _data.Resolve(value));

    public Task TypeStateNameAsync(string value, float delayMs = 40) =>
        StateName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Zip => EQCommonAccountDetailsAccountInfoLocators.Zip(_page);

    public Task PressZipAsync(string key) => Zip.PressAsync(key);

    public Task DoubleClickZipAsync() => Zip.DblClickAsync();

    public Task SetZipAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Zip, _data.Resolve(value));

    public Task TypeZipAsync(string value, float delayMs = 40) =>
        Zip.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator County => EQCommonAccountDetailsAccountInfoLocators.County(_page);

    public Task PressCountyAsync(string key) => County.PressAsync(key);

    public Task DoubleClickCountyAsync() => County.DblClickAsync();

    public Task SetCountyAsync(string value) =>
        UiActions.ApplyInputAsync(_page, County, _data.Resolve(value));

    public Task TypeCountyAsync(string value, float delayMs = 40) =>
        County.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Map => EQCommonAccountDetailsAccountInfoLocators.Map(_page);

    public Task PressMapAsync(string key) => Map.PressAsync(key);

    public Task DoubleClickMapAsync() => Map.DblClickAsync();

    public Task WaitForMapAsync() =>
        Map.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Satellite => EQCommonAccountDetailsAccountInfoLocators.Satellite(_page);

    public Task PressSatelliteAsync(string key) => Satellite.PressAsync(key);

    public Task DoubleClickSatelliteAsync() => Satellite.DblClickAsync();

    public Task WaitForSatelliteAsync() =>
        Satellite.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Next => EQCommonAccountDetailsAccountInfoLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

    private ILocator HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes => EQCommonAccountDetailsAccountInfoLocators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes(_page);

    public Task PressHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync(string key) => HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes.PressAsync(key);

    public Task DoubleClickHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync() => HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes.DblClickAsync();

    public Task SetHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, _data.Resolve(value));

    public Task TypeHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync(string value, float delayMs = 40) =>
        HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IsTheAccountAddressAlsoWhereTheClientResidesYes => EQCommonAccountDetailsAccountInfoLocators.IsTheAccountAddressAlsoWhereTheClientResidesYes(_page);

    public Task PressIsTheAccountAddressAlsoWhereTheClientResidesYesAsync(string key) => IsTheAccountAddressAlsoWhereTheClientResidesYes.PressAsync(key);

    public Task DoubleClickIsTheAccountAddressAlsoWhereTheClientResidesYesAsync() => IsTheAccountAddressAlsoWhereTheClientResidesYes.DblClickAsync();

    public Task SetIsTheAccountAddressAlsoWhereTheClientResidesYesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IsTheAccountAddressAlsoWhereTheClientResidesYes, _data.Resolve(value));

    public Task TypeIsTheAccountAddressAlsoWhereTheClientResidesYesAsync(string value, float delayMs = 40) =>
        IsTheAccountAddressAlsoWhereTheClientResidesYes.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForOwnerPhoneAsync() => OwnerPhone.WaitForAsync(new() { State = WaitForSelectorState.Visible });
}
