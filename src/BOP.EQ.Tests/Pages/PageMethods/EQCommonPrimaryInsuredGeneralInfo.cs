using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonPrimaryInsuredGeneralInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonPrimaryInsuredGeneralInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BusinessName => EQCommonPrimaryInsuredGeneralInfoLocators.BusinessName(_page);

    public Task PressBusinessNameAsync(string key) => BusinessName.PressAsync(key);

    public Task DoubleClickBusinessNameAsync() => BusinessName.DblClickAsync();

    public Task SetBusinessNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BusinessName, _data.Resolve(value));

    public Task TypeBusinessNameAsync(string value, float delayMs = 40) =>
        BusinessName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DescriptionOfOperations => EQCommonPrimaryInsuredGeneralInfoLocators.DescriptionOfOperations(_page);

    public Task PressDescriptionOfOperationsAsync(string key) => DescriptionOfOperations.PressAsync(key);

    public Task DoubleClickDescriptionOfOperationsAsync() => DescriptionOfOperations.DblClickAsync();

    public Task SetDescriptionOfOperationsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DescriptionOfOperations, _data.Resolve(value));

    public Task TypeDescriptionOfOperationsAsync(string value, float delayMs = 40) =>
        DescriptionOfOperations.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task VerifyDescriptionOfOperationsAsync(string expected) =>
        Expect(DescriptionOfOperations).ToContainTextAsync(_data.Resolve(expected));

    private ILocator NumberOfFulltimeEmployees => EQCommonPrimaryInsuredGeneralInfoLocators.NumberOfFulltimeEmployees(_page);

    public Task PressNumberOfFulltimeEmployeesAsync(string key) => NumberOfFulltimeEmployees.PressAsync(key);

    public Task DoubleClickNumberOfFulltimeEmployeesAsync() => NumberOfFulltimeEmployees.DblClickAsync();

    public Task SetNumberOfFulltimeEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfFulltimeEmployees, _data.Resolve(value));

    public Task TypeNumberOfFulltimeEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfFulltimeEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NumberOfPartTimeEmployees => EQCommonPrimaryInsuredGeneralInfoLocators.NumberOfPartTimeEmployees(_page);

    public Task PressNumberOfPartTimeEmployeesAsync(string key) => NumberOfPartTimeEmployees.PressAsync(key);

    public Task DoubleClickNumberOfPartTimeEmployeesAsync() => NumberOfPartTimeEmployees.DblClickAsync();

    public Task SetNumberOfPartTimeEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfPartTimeEmployees, _data.Resolve(value));

    public Task TypeNumberOfPartTimeEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfPartTimeEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NumberOfSeasonalEmployees => EQCommonPrimaryInsuredGeneralInfoLocators.NumberOfSeasonalEmployees(_page);

    public Task PressNumberOfSeasonalEmployeesAsync(string key) => NumberOfSeasonalEmployees.PressAsync(key);

    public Task DoubleClickNumberOfSeasonalEmployeesAsync() => NumberOfSeasonalEmployees.DblClickAsync();

    public Task SetNumberOfSeasonalEmployeesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, NumberOfSeasonalEmployees, _data.Resolve(value));

    public Task TypeNumberOfSeasonalEmployeesAsync(string value, float delayMs = 40) =>
        NumberOfSeasonalEmployees.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator FarmBureauMemberNo => EQCommonPrimaryInsuredGeneralInfoLocators.FarmBureauMemberNo(_page);

    public Task PressFarmBureauMemberNoAsync(string key) => FarmBureauMemberNo.PressAsync(key);

    public Task DoubleClickFarmBureauMemberNoAsync() => FarmBureauMemberNo.DblClickAsync();

    public Task SetFarmBureauMemberNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, FarmBureauMemberNo, _data.Resolve(value));

    public Task TypeFarmBureauMemberNoAsync(string value, float delayMs = 40) =>
        FarmBureauMemberNo.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DoYouWishToDiscloseRaceAndGenderInfoNo => EQCommonPrimaryInsuredGeneralInfoLocators.DoYouWishToDiscloseRaceAndGenderInfoNo(_page);

    public Task PressDoYouWishToDiscloseRaceAndGenderInfoNoAsync(string key) => DoYouWishToDiscloseRaceAndGenderInfoNo.PressAsync(key);

    public Task DoubleClickDoYouWishToDiscloseRaceAndGenderInfoNoAsync() => DoYouWishToDiscloseRaceAndGenderInfoNo.DblClickAsync();

    public Task SetDoYouWishToDiscloseRaceAndGenderInfoNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DoYouWishToDiscloseRaceAndGenderInfoNo, _data.Resolve(value));

    public Task TypeDoYouWishToDiscloseRaceAndGenderInfoNoAsync(string value, float delayMs = 40) =>
        DoYouWishToDiscloseRaceAndGenderInfoNo.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IsTheClientAMemberOfAnyProfessionalTradeAssociationNo => EQCommonPrimaryInsuredGeneralInfoLocators.IsTheClientAMemberOfAnyProfessionalTradeAssociationNo(_page);

    public Task PressIsTheClientAMemberOfAnyProfessionalTradeAssociationNoAsync(string key) => IsTheClientAMemberOfAnyProfessionalTradeAssociationNo.PressAsync(key);

    public Task DoubleClickIsTheClientAMemberOfAnyProfessionalTradeAssociationNoAsync() => IsTheClientAMemberOfAnyProfessionalTradeAssociationNo.DblClickAsync();

    public Task SetIsTheClientAMemberOfAnyProfessionalTradeAssociationNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IsTheClientAMemberOfAnyProfessionalTradeAssociationNo, _data.Resolve(value));

    public Task TypeIsTheClientAMemberOfAnyProfessionalTradeAssociationNoAsync(string value, float delayMs = 40) =>
        IsTheClientAMemberOfAnyProfessionalTradeAssociationNo.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Save => EQCommonPrimaryInsuredGeneralInfoLocators.Save(_page);

    public Task PressSaveAsync(string key) => Save.PressAsync(key);

    public Task DoubleClickSaveAsync() => Save.DblClickAsync();

    public Task ClickSaveAsync() => Save.ClickAsync();

}
