using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ClassCodes => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.ClassCodes(_page);

    public Task PressClassCodesAsync(string key) => ClassCodes.PressAsync(key);

    public Task DoubleClickClassCodesAsync() => ClassCodes.DblClickAsync();

    public Task WaitForClassCodesAsync() =>
        ClassCodes.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator OccupancySQFTHeading => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.OccupancySQFTHeading(_page);

    public Task PressOccupancySQFTHeadingAsync(string key) => OccupancySQFTHeading.PressAsync(key);

    public Task DoubleClickOccupancySQFTHeadingAsync() => OccupancySQFTHeading.DblClickAsync();

    public Task WaitForOccupancySQFTHeadingAsync() =>
        OccupancySQFTHeading.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator OccupancySqFtLimit => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.OccupancySqFtLimit(_page);

    public Task PressOccupancySqFtLimitAsync(string key) => OccupancySqFtLimit.PressAsync(key);

    public Task DoubleClickOccupancySqFtLimitAsync() => OccupancySqFtLimit.DblClickAsync();

    public Task SetOccupancySqFtLimitAsync(string value) =>
        UiActions.ApplyInputAsync(_page, OccupancySqFtLimit, _data.Resolve(value));

    public Task TypeOccupancySqFtLimitAsync(string value, float delayMs = 40) =>
        OccupancySqFtLimit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OccupancySqFootageTotal => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.OccupancySqFootageTotal(_page);

    public Task PressOccupancySqFootageTotalAsync(string key) => OccupancySqFootageTotal.PressAsync(key);

    public Task DoubleClickOccupancySqFootageTotalAsync() => OccupancySqFootageTotal.DblClickAsync();

    public Task VerifyOccupancySqFootageTotalAsync(string expected) =>
        Expect(OccupancySqFootageTotal).ToContainTextAsync(_data.Resolve(expected));

    private ILocator PersonalPropertyLimitCheckBoxAngular => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.PersonalPropertyLimitCheckBoxAngular(_page);

    public Task PressPersonalPropertyLimitCheckBoxAngularAsync(string key) => PersonalPropertyLimitCheckBoxAngular.PressAsync(key);

    public Task DoubleClickPersonalPropertyLimitCheckBoxAngularAsync() => PersonalPropertyLimitCheckBoxAngular.DblClickAsync();

    public Task SetPersonalPropertyLimitCheckBoxAngularAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PersonalPropertyLimitCheckBoxAngular, _data.Resolve(value));

    public Task TypePersonalPropertyLimitCheckBoxAngularAsync(string value, float delayMs = 40) =>
        PersonalPropertyLimitCheckBoxAngular.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForPersonalPropertyLimitCheckBoxAngularAsync() =>
        PersonalPropertyLimitCheckBoxAngular.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PersonalPropertyLimit => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.PersonalPropertyLimit(_page);

    public Task PressPersonalPropertyLimitAsync(string key) => PersonalPropertyLimit.PressAsync(key);

    public Task DoubleClickPersonalPropertyLimitAsync() => PersonalPropertyLimit.DblClickAsync();

    public Task SetPersonalPropertyLimitAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PersonalPropertyLimit, _data.Resolve(value));

    public Task TypePersonalPropertyLimitAsync(string value, float delayMs = 40) =>
        PersonalPropertyLimit.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator GrossSalesReceipts => EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSLocators.GrossSalesReceipts(_page);

    public Task PressGrossSalesReceiptsAsync(string key) => GrossSalesReceipts.PressAsync(key);

    public Task DoubleClickGrossSalesReceiptsAsync() => GrossSalesReceipts.DblClickAsync();

    public Task SetGrossSalesReceiptsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, GrossSalesReceipts, _data.Resolve(value));

    public Task TypeGrossSalesReceiptsAsync(string value, float delayMs = 40) =>
        GrossSalesReceipts.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickPersonalPropertyLimitCheckBoxAngularAsync() => PersonalPropertyLimitCheckBoxAngular.ClickAsync();
}
