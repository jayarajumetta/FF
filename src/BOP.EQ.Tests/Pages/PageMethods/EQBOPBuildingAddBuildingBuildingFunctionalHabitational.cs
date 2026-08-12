using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingAddBuildingBuildingFunctionalHabitational
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingAddBuildingBuildingFunctionalHabitational(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator SelectIfClientOwnsOrRentsTheBuilding => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.SelectIfClientOwnsOrRentsTheBuilding(_page);

    public Task PressSelectIfClientOwnsOrRentsTheBuildingAsync(string key) => SelectIfClientOwnsOrRentsTheBuilding.PressAsync(key);

    public Task DoubleClickSelectIfClientOwnsOrRentsTheBuildingAsync() => SelectIfClientOwnsOrRentsTheBuilding.DblClickAsync();

    public Task WaitForSelectIfClientOwnsOrRentsTheBuildingAsync() =>
        SelectIfClientOwnsOrRentsTheBuilding.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator FunctionalPersonalPropertyUnchecked => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.FunctionalPersonalPropertyUnchecked(_page);

    public Task PressFunctionalPersonalPropertyUncheckedAsync(string key) => FunctionalPersonalPropertyUnchecked.PressAsync(key);

    public Task DoubleClickFunctionalPersonalPropertyUncheckedAsync() => FunctionalPersonalPropertyUnchecked.DblClickAsync();

    public Task ClickFunctionalPersonalPropertyUncheckedAsync() => FunctionalPersonalPropertyUnchecked.ClickAsync();

    private ILocator BuildingContainsHabitationalOccupanciesUnchecked => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.BuildingContainsHabitationalOccupanciesUnchecked(_page);

    public Task PressBuildingContainsHabitationalOccupanciesUncheckedAsync(string key) => BuildingContainsHabitationalOccupanciesUnchecked.PressAsync(key);

    public Task DoubleClickBuildingContainsHabitationalOccupanciesUncheckedAsync() => BuildingContainsHabitationalOccupanciesUnchecked.DblClickAsync();

    public Task ClickBuildingContainsHabitationalOccupanciesUncheckedAsync() => BuildingContainsHabitationalOccupanciesUnchecked.ClickAsync();

    private ILocator FunctionalPersonalPropertyChecked => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.FunctionalPersonalPropertyChecked(_page);

    public Task PressFunctionalPersonalPropertyCheckedAsync(string key) => FunctionalPersonalPropertyChecked.PressAsync(key);

    public Task DoubleClickFunctionalPersonalPropertyCheckedAsync() => FunctionalPersonalPropertyChecked.DblClickAsync();

    public Task WaitForFunctionalPersonalPropertyCheckedAsync() =>
        FunctionalPersonalPropertyChecked.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator BuildingContainsHabitationalOccupanciesChecked => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.BuildingContainsHabitationalOccupanciesChecked(_page);

    public Task PressBuildingContainsHabitationalOccupanciesCheckedAsync(string key) => BuildingContainsHabitationalOccupanciesChecked.PressAsync(key);

    public Task DoubleClickBuildingContainsHabitationalOccupanciesCheckedAsync() => BuildingContainsHabitationalOccupanciesChecked.DblClickAsync();

    public Task WaitForBuildingContainsHabitationalOccupanciesCheckedAsync() =>
        BuildingContainsHabitationalOccupanciesChecked.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator WindstormLossMitigationUnchecked => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.WindstormLossMitigationUnchecked(_page);

    public Task PressWindstormLossMitigationUncheckedAsync(string key) => WindstormLossMitigationUnchecked.PressAsync(key);

    public Task DoubleClickWindstormLossMitigationUncheckedAsync() => WindstormLossMitigationUnchecked.DblClickAsync();

    public Task ClickWindstormLossMitigationUncheckedAsync() => WindstormLossMitigationUnchecked.ClickAsync();

    private ILocator CertificateTypeBronzeRoof => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.CertificateTypeBronzeRoof(_page);

    public Task PressCertificateTypeBronzeRoofAsync(string key) => CertificateTypeBronzeRoof.PressAsync(key);

    public Task DoubleClickCertificateTypeBronzeRoofAsync() => CertificateTypeBronzeRoof.DblClickAsync();

    public Task ClickCertificateTypeBronzeRoofAsync() => CertificateTypeBronzeRoof.ClickAsync();

    private ILocator CertificateTypeGoldFSL => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.CertificateTypeGoldFSL(_page);

    public Task PressCertificateTypeGoldFSLAsync(string key) => CertificateTypeGoldFSL.PressAsync(key);

    public Task DoubleClickCertificateTypeGoldFSLAsync() => CertificateTypeGoldFSL.DblClickAsync();

    public Task ClickCertificateTypeGoldFSLAsync() => CertificateTypeGoldFSL.ClickAsync();

    private ILocator RoofShape => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.RoofShape(_page);

    public Task PressRoofShapeAsync(string key) => RoofShape.PressAsync(key);

    public Task DoubleClickRoofShapeAsync() => RoofShape.DblClickAsync();

    public Task SetRoofShapeAsync(string value) =>
        RoofShape.SelectOptionAsync(_data.Resolve(value));

    private ILocator RoofDeckAttachment => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.RoofDeckAttachment(_page);

    public Task PressRoofDeckAttachmentAsync(string key) => RoofDeckAttachment.PressAsync(key);

    public Task DoubleClickRoofDeckAttachmentAsync() => RoofDeckAttachment.DblClickAsync();

    public Task SetRoofDeckAttachmentAsync(string value) =>
        RoofDeckAttachment.SelectOptionAsync(_data.Resolve(value));

    private ILocator RoofToWallConnection => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.RoofToWallConnection(_page);

    public Task PressRoofToWallConnectionAsync(string key) => RoofToWallConnection.PressAsync(key);

    public Task DoubleClickRoofToWallConnectionAsync() => RoofToWallConnection.DblClickAsync();

    public Task SetRoofToWallConnectionAsync(string value) =>
        RoofToWallConnection.SelectOptionAsync(_data.Resolve(value));

    private ILocator DoorStrength => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.DoorStrength(_page);

    public Task PressDoorStrengthAsync(string key) => DoorStrength.PressAsync(key);

    public Task DoubleClickDoorStrengthAsync() => DoorStrength.DblClickAsync();

    public Task SetDoorStrengthAsync(string value) =>
        DoorStrength.SelectOptionAsync(_data.Resolve(value));

    private ILocator RoofCovering => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.RoofCovering(_page);

    public Task PressRoofCoveringAsync(string key) => RoofCovering.PressAsync(key);

    public Task DoubleClickRoofCoveringAsync() => RoofCovering.DblClickAsync();

    public Task SetRoofCoveringAsync(string value) =>
        RoofCovering.SelectOptionAsync(_data.Resolve(value));

    private ILocator OpeningProtection => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.OpeningProtection(_page);

    public Task PressOpeningProtectionAsync(string key) => OpeningProtection.PressAsync(key);

    public Task DoubleClickOpeningProtectionAsync() => OpeningProtection.DblClickAsync();

    public Task SetOpeningProtectionAsync(string value) =>
        OpeningProtection.SelectOptionAsync(_data.Resolve(value));

    private ILocator SecondaryWaterResistance => EQBOPBuildingAddBuildingBuildingFunctionalHabitationalLocators.SecondaryWaterResistance(_page);

    public Task PressSecondaryWaterResistanceAsync(string key) => SecondaryWaterResistance.PressAsync(key);

    public Task DoubleClickSecondaryWaterResistanceAsync() => SecondaryWaterResistance.DblClickAsync();

    public Task SetSecondaryWaterResistanceAsync(string value) =>
        SecondaryWaterResistance.SelectOptionAsync(_data.Resolve(value));

}
