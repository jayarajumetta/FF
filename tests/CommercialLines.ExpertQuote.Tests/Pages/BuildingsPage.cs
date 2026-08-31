using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BuildingsPage
{
    private readonly BrowserSession _browser;
    private readonly BuildingsLocators _locators;
    private readonly UiActions _ui;

    public BuildingsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new BuildingsLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterActualCashValueAsync(string value) =>
        _ui.FillAsync(_locators.ActualCashValue, value, new ControlIntent("Buildings", "ActualCashValue"));

    public Task PressActualCashValueAsync(string key) =>
        _ui.PressAsync(_locators.ActualCashValue, key, new ControlIntent("Buildings", "ActualCashValue"));

    public Task ClickActualCashValueAsync() =>
        _ui.ClickAsync(_locators.ActualCashValue, new ControlIntent("Buildings", "ActualCashValue"));

    public Task EnterAddANoteAsync(string value) =>
        _ui.FillAsync(_locators.AddANote, value, new ControlIntent("Buildings", "AddANote"));

    public Task ClickAddBuildingBPPAsync() =>
        _ui.ClickAsync(_locators.AddBuildingBPP, new ControlIntent("Buildings", "AddBuildingBPP"));

    public Task WaitForAddResidenceHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.AddResidenceHeader, expected, new ControlIntent("Buildings", "AddResidenceHeader"));

    public Task ClickAddResidenceToLocationAsync() =>
        _ui.ClickAsync(_locators.AddResidenceToLocation, new ControlIntent("Buildings", "AddResidenceToLocation"));

    public Task PressAdditionalDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.AdditionalDescription, key, new ControlIntent("Buildings", "AdditionalDescription"));

    public Task SelectAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync(string value) =>
        _ui.SelectAsync(_locators.AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes, value, new ControlIntent("Buildings", "AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes"));

    public Task PressBVSButtonAsync(string key) =>
        _ui.PressAsync(_locators.BVSButton, key, new ControlIntent("Buildings", "BVSButton"));

    public Task ClickBVSButtonAsync() =>
        _ui.ClickAsync(_locators.BVSButton, new ControlIntent("Buildings", "BVSButton"));

    public Task ClickBVSGroupAsync() =>
        _ui.ClickAsync(_locators.BVSGroup, new ControlIntent("Buildings", "BVSGroup"));

    public Task PressBVSGroupComboboxAsync(string key) =>
        _ui.PressAsync(_locators.BVSGroup, key, new ControlIntent("Buildings", "BVSGroupCombobox"));

    public Task ClickBVSResultAsync() =>
        _ui.ClickAsync(_locators.BVSResult, new ControlIntent("Buildings", "BVSResult"));

    public Task PressBVSResultsComboboxAsync(string key) =>
        _ui.PressAsync(_locators.BVSResult, key, new ControlIntent("Buildings", "BVSResultsCombobox"));

    public Task PressBuildingAsync(string key) =>
        _ui.PressAsync(_locators.Building, key, new ControlIntent("Buildings", "Building"));

    public Task WaitForBuildingContainsHabitationalOccupanciesCheckedAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingContainsHabitationalOccupanciesChecked, expected, new ControlIntent("Buildings", "BuildingContainsHabitationalOccupanciesChecked"));

    public Task PressBuildingContainsHabitationalOccupanciesUncheckedAsync(string key) =>
        _ui.PressAsync(_locators.BuildingContainsHabitationalOccupanciesChecked, key, new ControlIntent("Buildings", "BuildingContainsHabitationalOccupanciesUnchecked"));

    public Task PressBuildingCoverageAngularAsync(string key) =>
        _ui.PressAsync(_locators.BuildingCoverageAngular, key, new ControlIntent("Buildings", "BuildingCoverageAngular"));

    public Task WaitForBuildingDetailsHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingDetailsHeading, expected, new ControlIntent("Buildings", "BuildingDetailsHeading"));

    public Task ClickBuildingPhoto1Async() =>
        _ui.ClickAsync(_locators.BuildingPhoto1, new ControlIntent("Buildings", "BuildingPhoto1"));

    public Task WaitForBuildingPhoto1HeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto1Header"));

    public Task WaitForBuildingPhoto2Async(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto2"));

    public Task WaitForBuildingPhoto2HeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto2Header"));

    public Task WaitForBuildingPhoto3Async(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto3"));

    public Task WaitForBuildingPhoto3HeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto3Header"));

    public Task WaitForBuildingPhoto4Async(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto4"));

    public Task WaitForBuildingPhoto4HeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingPhoto1, expected, new ControlIntent("Buildings", "BuildingPhoto4Header"));

    public Task WaitForCheckBoxAngularAsync(string expected) =>
        _ui.WaitAsync(_locators.CheckBoxAngular, expected, new ControlIntent("Buildings", "CheckBoxAngular"));

    public Task PressCheckBoxAngularAsync(string key) =>
        _ui.PressAsync(_locators.CheckBoxAngular, key, new ControlIntent("Buildings", "CheckBoxAngular"));

    public Task ClickCheckBoxAngularAsync() =>
        _ui.ClickAsync(_locators.CheckBoxAngular, new ControlIntent("Buildings", "CheckBoxAngular"));

    public Task WaitForClassCodesAsync(string expected) =>
        _ui.WaitAsync(_locators.ClassCodes, expected, new ControlIntent("Buildings", "ClassCodes"));

    public Task PressCommercialButtonAsync(string key) =>
        _ui.PressAsync(_locators.CommercialButton, key, new ControlIntent("Buildings", "CommercialButton"));

    public Task ClickCommercialButtonAsync() =>
        _ui.ClickAsync(_locators.CommercialButton, new ControlIntent("Buildings", "CommercialButton"));

    public Task ClickDoesTheClientHaveASolidFuelHeatingTypeNoAsync() =>
        _ui.ClickAsync(_locators.DoesTheClientHaveASolidFuelHeatingTypeNo, new ControlIntent("Buildings", "DoesTheClientHaveASolidFuelHeatingTypeNo"));

    public Task PressDoesTheResidenceHaveAThermostaticallyControlledDeviceYesAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheResidenceHaveAThermostaticallyControlledDeviceYes, key, new ControlIntent("Buildings", "DoesTheResidenceHaveAThermostaticallyControlledDeviceYes"));

    public Task WaitForEChecklistEChecklistOKAsync(string expected) =>
        _ui.WaitAsync(_locators.EChecklistEChecklistOK, expected, new ControlIntent("Buildings", "EChecklistEChecklistOK"));

    public Task ClickEChecklistEChecklistOKAsync() =>
        _ui.ClickAsync(_locators.EChecklistEChecklistOK, new ControlIntent("Buildings", "EChecklistEChecklistOK"));

    public Task VerifyEQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestionsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, expected, property, new ControlIntent("Buildings", "EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions"));

    public Task VerifyEQBOPBuildingBuildingDetailsSelectBurglarAlarmAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, expected, property, new ControlIntent("Buildings", "EQBOPBuildingBuildingDetailsSelectBurglarAlarm"));

    public Task VerifyEQBOPBuildingBuildingDetailsSelectPelletStoveAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, expected, property, new ControlIntent("Buildings", "EQBOPBuildingBuildingDetailsSelectPelletStove"));

    public Task VerifyEQBOPBuildingBuildingDetailsSelectWoodFurnaceAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, expected, property, new ControlIntent("Buildings", "EQBOPBuildingBuildingDetailsSelectWoodFurnace"));

    public Task VerifyEQBOPBuildingBuildingDetailsSelectWoodStoveAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, expected, property, new ControlIntent("Buildings", "EQBOPBuildingBuildingDetailsSelectWoodStove"));

    public Task ClickExceptionAsync() =>
        _ui.ClickAsync(_locators.Exception, new ControlIntent("Buildings", "Exception"));

    public Task PressFrameAsync(string key) =>
        _ui.PressAsync(_locators.Frame, key, new ControlIntent("Buildings", "Frame"));

    public Task ClickFrameAsync() =>
        _ui.ClickAsync(_locators.Frame, new ControlIntent("Buildings", "Frame"));

    public Task WaitForFunctionalPersonalPropertyCheckedAsync(string expected) =>
        _ui.WaitAsync(_locators.BuildingContainsHabitationalOccupanciesChecked, expected, new ControlIntent("Buildings", "FunctionalPersonalPropertyChecked"));

    public Task PressFunctionalPersonalPropertyUncheckedAsync(string key) =>
        _ui.PressAsync(_locators.BuildingContainsHabitationalOccupanciesChecked, key, new ControlIntent("Buildings", "FunctionalPersonalPropertyUnchecked"));

    public Task PressGetValuationAsync(string key) =>
        _ui.PressAsync(_locators.GetValuation, key, new ControlIntent("Buildings", "GetValuation"));

    public Task ClickGetValuationAsync() =>
        _ui.ClickAsync(_locators.GetValuation, new ControlIntent("Buildings", "GetValuation"));

    public Task PressGrossSalesReceiptsAsync(string key) =>
        _ui.PressAsync(_locators.GrossSalesReceipts, key, new ControlIntent("Buildings", "GrossSalesReceipts"));

    public Task PressHeatingYearAsync(string key) =>
        _ui.PressAsync(_locators.HeatingYear, key, new ControlIntent("Buildings", "HeatingYear"));

    public Task PressInsuranceAmountAsync(string key) =>
        _ui.PressAsync(_locators.InsuranceAmount, key, new ControlIntent("Buildings", "InsuranceAmount"));

    public Task EnterInsuredOccupancySqFtAsync(string value) =>
        _ui.FillAsync(_locators.InsuredOccupancySqFt, value, new ControlIntent("Buildings", "InsuredOccupancySqFt"));

    public Task PressInsuredOccupancySqFtAngularAsync(string key) =>
        _ui.PressAsync(_locators.InsuredOccupancySqFt, key, new ControlIntent("Buildings", "InsuredOccupancySqFtAngular"));

    public Task SelectIsAnyHeatSourceThermostaticallyControlledYesAsync(string value) =>
        _ui.SelectAsync(_locators.IsAnyHeatSourceThermostaticallyControlledYes, value, new ControlIntent("Buildings", "IsAnyHeatSourceThermostaticallyControlledYes"));

    public Task PressIsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngularAsync(string key) =>
        _ui.PressAsync(_locators.IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular, key, new ControlIntent("Buildings", "IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular"));
public Task PressNumberOfStoriesAsync(string key) =>
        _ui.PressAsync(_locators.NumberOfStories, key, new ControlIntent("Buildings", "NumberOfStories"));

    public Task WaitForOccupancySQFTHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.OccupancySQFTHeading, expected, new ControlIntent("Buildings", "OccupancySQFTHeading"));

    public Task VerifyOccupancySqFootageTotalAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OccupancySqFootageTotal, expected, property, new ControlIntent("Buildings", "OccupancySqFootageTotal"));

    public Task PressOccupancySqFtLimitAsync(string key) =>
        _ui.PressAsync(_locators.OccupancySqFtLimit, key, new ControlIntent("Buildings", "OccupancySqFtLimit"));

    public Task EnterPerilsAsync(string value) =>
        _ui.FillAsync(_locators.Perils, value, new ControlIntent("Buildings", "Perils"));

    public Task PressPersonalPropertyLimitAsync(string key) =>
        _ui.PressAsync(_locators.PersonalPropertyLimit, key, new ControlIntent("Buildings", "PersonalPropertyLimit"));

    public Task WaitForPersonalPropertyLimitCheckBoxAngularAsync(string expected) =>
        _ui.WaitAsync(_locators.PersonalPropertyLimitCheckBoxAngular, expected, new ControlIntent("Buildings", "PersonalPropertyLimitCheckBoxAngular"));

    public Task PressPersonalPropertyLimitCheckBoxAngularAsync(string key) =>
        _ui.PressAsync(_locators.PersonalPropertyLimitCheckBoxAngular, key, new ControlIntent("Buildings", "PersonalPropertyLimitCheckBoxAngular"));

    public Task ClickPersonalPropertyLimitCheckBoxAngularAsync() =>
        _ui.ClickAsync(_locators.PersonalPropertyLimitCheckBoxAngular, new ControlIntent("Buildings", "PersonalPropertyLimitCheckBoxAngular"));

    public Task PressPlumbingYearAsync(string key) =>
        _ui.PressAsync(_locators.PlumbingYear, key, new ControlIntent("Buildings", "PlumbingYear"));

    public Task ClickRCTAsync() =>
        _ui.ClickAsync(_locators.RCT, new ControlIntent("Buildings", "RCT"));

    public Task PressRateType1Async(string key) =>
        _ui.PressAsync(_locators.RateType1, key, new ControlIntent("Buildings", "RateType1"));

    public Task PressReplacementCostAsync(string key) =>
        _ui.PressAsync(_locators.ActualCashValue, key, new ControlIntent("Buildings", "ReplacementCost"));

    public Task ClickReplacementCostAsync() =>
        _ui.ClickAsync(_locators.ActualCashValue, new ControlIntent("Buildings", "ReplacementCost"));

    public Task VerifyResidenceCoverageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ResidenceCoverage, expected, property, new ControlIntent("Buildings", "ResidenceCoverage"));

    public Task PressResidenceCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ResidenceCoverage, key, new ControlIntent("Buildings", "ResidenceCoverage"));

    public Task ClickResidenceCoverageAsync() =>
        _ui.ClickAsync(_locators.ResidenceCoverage, new ControlIntent("Buildings", "ResidenceCoverage"));

    public Task EnterRoofImpact1Async(string value) =>
        _ui.FillAsync(_locators.RoofImpact1, value, new ControlIntent("Buildings", "RoofImpact1"));

    public Task EnterRoofType1Async(string value) =>
        _ui.FillAsync(_locators.RoofType1, value, new ControlIntent("Buildings", "RoofType1"));

    public Task PressRoofTypeMainAsync(string key) =>
        _ui.PressAsync(_locators.GetValuation, key, new ControlIntent("Buildings", "RoofTypeMain"));

    public Task ClickRoofTypeSelectionAsync() =>
        _ui.ClickAsync(_locators.GetValuation, new ControlIntent("Buildings", "RoofTypeSelection"));

    public Task PressRoofYearAsync(string key) =>
        _ui.PressAsync(_locators.AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes, key, new ControlIntent("Buildings", "RoofYear"));

    public Task PressSaveAsync(string key) =>
        _ui.PressAsync(_locators.Save, key, new ControlIntent("Buildings", "Save"));

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Buildings", "Save"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ScreenHeading, expected, property, new ControlIntent("Buildings", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.ScreenHeading);

    public Task ClickSeasonalOrVacantNoAsync() =>
        _ui.ClickAsync(_locators.SeasonalOrVacantNo, new ControlIntent("Buildings", "SeasonalOrVacantNo"));

    public Task PressSelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngularAsync(string key) =>
        _ui.PressAsync(_locators.SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular, key, new ControlIntent("Buildings", "SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular"));

    public Task WaitForSelectIfClientOwnsOrRentsTheBuildingAsync(string expected) =>
        _ui.WaitAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, expected, new ControlIntent("Buildings", "SelectIfClientOwnsOrRentsTheBuilding"));

    public Task PressSingleFamilyAsync(string key) =>
        _ui.PressAsync(_locators.SingleFamily, key, new ControlIntent("Buildings", "SingleFamily"));

    public Task WaitForSprinklerYesAsync(string expected) =>
        _ui.WaitAsync(_locators.SprinklerYes, expected, new ControlIntent("Buildings", "SprinklerYes"));

    public Task SelectSprinklerYesAsync(string value) =>
        _ui.SelectAsync(_locators.SprinklerYes, value, new ControlIntent("Buildings", "SprinklerYes"));

    public Task PressSquareFeetAsync(string key) =>
        _ui.PressAsync(_locators.SquareFeet, key, new ControlIntent("Buildings", "SquareFeet"));

    public Task ClickStandardRCTUseDefaultsAsync() =>
        _ui.ClickAsync(_locators.StandardRCTUseDefaults, new ControlIntent("Buildings", "StandardRCTUseDefaults"));

    public Task PressWiringYearAsync(string key) =>
        _ui.PressAsync(_locators.WiringYear, key, new ControlIntent("Buildings", "WiringYear"));

    public Task PressYearBuiltAsync(string key) =>
        _ui.PressAsync(_locators.YearBuilt, key, new ControlIntent("Buildings", "YearBuilt"));

    public Task PressYearBuiltRenovatedAsync(string key) =>
        _ui.PressAsync(_locators.YearBuiltRenovated, key, new ControlIntent("Buildings", "YearBuiltRenovated"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
